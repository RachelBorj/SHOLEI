using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace SHOLEI
{
    public partial class Orders : Form
    {

        public Orders()
        {
            InitializeComponent();
        }

        private void Orders_Load(object sender, EventArgs e)
        {
            LoadStudentOrders();
        }
        private void LoadStudentOrders()
        {
            // Clear existing rows and columns in the DataGridView
            dgvOrderRequest.Rows.Clear();
            dgvOrderRequest.Columns.Clear();

            // Add columns to the DataGridView
            dgvOrderRequest.Columns.Add("OrderID", "Order ID");
            dgvOrderRequest.Columns["OrderID"].Visible = false;
            dgvOrderRequest.Columns.Add("StudentID", "Student ID");
            dgvOrderRequest.Columns.Add("StudentName", "Student Name");
            dgvOrderRequest.Columns.Add("ProductName", "Product Name");
            dgvOrderRequest.Columns.Add("Size", "Size");
            dgvOrderRequest.Columns.Add("Quantity", "Quantity");
            dgvOrderRequest.Columns.Add("Price", "Price");

            // Add Accept and Decline buttons
            DataGridViewButtonColumn acceptButtonColumn = new DataGridViewButtonColumn
            {
                Name = "AcceptButton",
                HeaderText = "Action",
                Text = "Accept",
                UseColumnTextForButtonValue = true
            };
            dgvOrderRequest.Columns.Add(acceptButtonColumn);

            DataGridViewButtonColumn declineButtonColumn = new DataGridViewButtonColumn
            {
                Name = "DeclineButton",
                HeaderText = "Action",
                Text = "Decline",
                UseColumnTextForButtonValue = true
            };
            dgvOrderRequest.Columns.Add(declineButtonColumn);

            // Define the connection string
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"C:\\Users\\Rache\\Desktop\\SHOLEI\\SHOLEI\\bin\\Debug\\Solei.accdb\"";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                
                try
                {
                    // Query to get student orders
                    string query = "SELECT O.OrderID, O.StudentID, O.StudentName, I.ProductName, I.Size, I.Quantity, I.Price " +
                                   "FROM OrderItems I " +
                                   "INNER JOIN Orders O ON I.OrderID = O.OrderID " +
                                   "WHERE O.Status = 'Pending' " +
                                   "ORDER BY O.OrderDate DESC";

                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);                  

                    // Add rows to the DataGridView
                    foreach (DataRow row in dataTable.Rows)
                    {
                        dgvOrderRequest.Rows.Add(row["OrderID"], row["StudentID"], row["StudentName"], row["ProductName"], row["Size"], row["Quantity"], row["Price"]);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error fetching data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void PromptForPaymentAndAcceptOrder(string orderID)
        {
            // Prompt the admin to enter the amount paid
            string paymentInput = Microsoft.VisualBasic.Interaction.InputBox("Enter the amount paid by the student:", "Payment", "", -1, -1);

            if (decimal.TryParse(paymentInput, out decimal paymentAmount) && paymentAmount > 0)
            {
                // If the payment is valid (greater than 0), update the order status
                UpdateOrderStatus(orderID, "Accepted", paymentAmount);
            }
            else
            {
                MessageBox.Show("Invalid payment amount. Please enter a valid amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvOrderRequest_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) // Ensure valid row and column indices
            {
                // Ensure OrderID is not null
                var cellValue = dgvOrderRequest.Rows[e.RowIndex].Cells["OrderID"].Value;
                if (cellValue != null)
                {
                    string orderID = cellValue.ToString();

                    if (e.ColumnIndex == dgvOrderRequest.Columns["AcceptButton"].Index)
                    {
                        // Accept button clicked, prompt for payment and then accept the order
                        PromptForPaymentAndAcceptOrder(orderID);
                    }
                    else if (e.ColumnIndex == dgvOrderRequest.Columns["DeclineButton"].Index)
                    {
                        // Decline button clicked
                        UpdateOrderStatus(orderID, "Declined", 0);
                    }
                }
                else
                {
                    MessageBox.Show("Order ID is missing for the selected row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void UpdateOrderStatus(string orderID, string status, decimal paymentAmount)
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"C:\\Users\\Rache\\Desktop\\SHOLEI\\SHOLEI\\bin\\Debug\\Solei.accdb\"";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    // Update the order status and payment amount
                    string query = "UPDATE Orders SET Status = @Status, PaymentAmount = @PaymentAmount WHERE OrderID = @OrderID";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Status", status);
                        command.Parameters.AddWithValue("@PaymentAmount", paymentAmount);
                        command.Parameters.AddWithValue("@OrderID", orderID);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show($"Order {status.ToLower()} successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh the DataGridView
                    LoadStudentOrders();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating order: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private decimal GetTotalAmountForOrder(string orderID)
        {
            decimal totalAmount = 0;

            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"C:\\Users\\Rache\\Desktop\\SHOLEI\\SHOLEI\\bin\\Debug\\Solei.accdb\"";
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT Quantity, Price FROM OrderItems WHERE OrderID = @OrderID";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@OrderID", orderID);
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                decimal quantity = reader.GetDecimal(0);
                                decimal price = reader.GetDecimal(1);
                                totalAmount += quantity * price;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error calculating total amount: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return totalAmount;
        }
    }
}
    