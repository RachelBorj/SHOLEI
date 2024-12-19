using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace SHOLEI
{
    public partial class OrdersForm : Form
    {
        private OleDbConnection connection;
        public OrdersForm()
        {
            InitializeComponent();
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"C:\\Users\\Rache\\Desktop\\SHOLEI\\SHOLEI\\bin\\Debug\\Solei.accdb\"");
        }

        private void OrdersForm_Load(object sender, EventArgs e)
        {
            LoadAcceptedOrders();
            AddButtonColumns();
        }
        private void LoadAcceptedOrders()
        {
            string query = @"
SELECT o.OrderID, 
       o.StudentID, 
       o.StudentName, 
       o.Section, 
       o.Course, 
       o.OrderDate, 
       oi.ProductName, 
       oi.[Size], 
       oi.Quantity, 
       oi.Price, 
       o.PaymentAmount,
       o.[Status]
FROM [Orders] o
INNER JOIN [OrderItems] oi ON o.OrderID = oi.OrderID
WHERE o.[Status] = 'Accepted'";
            OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
            DataTable table = new DataTable();

            try
            {
                adapter.Fill(table);
                dgvToReceive.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading accepted orders: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddButtonColumns()
        {
            // Clear any existing button columns to avoid duplicates
            dgvToReceive.Columns.Clear();

            // Reload the data
            LoadAcceptedOrders();

            // Add "Mark as Received" button column
            DataGridViewButtonColumn receivedButton = new DataGridViewButtonColumn
            {
                Name = "ReceivedButton",
                HeaderText = "Actions",
                Text = "Received",
                UseColumnTextForButtonValue = true // Makes the button display the Text value
            };
            dgvToReceive.Columns.Add(receivedButton);

            // Add "Mark as Refunded" button column
            DataGridViewButtonColumn refundedButton = new DataGridViewButtonColumn
            {
                Name = "RefundedButton",
                HeaderText = "Actions",
                Text = "Refunded",
                UseColumnTextForButtonValue = true // Makes the button display the Text value
            };
            dgvToReceive.Columns.Add(refundedButton);
        }

        private void dgvToReceive_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is a button column
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string orderID = dgvToReceive.Rows[e.RowIndex].Cells["OrderID"].Value.ToString();

                if (dgvToReceive.Columns[e.ColumnIndex].Name == "ReceivedButton")
                {
                    UpdateOrderStatus(orderID, "Received");
                }
                else if (dgvToReceive.Columns[e.ColumnIndex].Name == "RefundedButton")
                {
                    UpdateOrderStatus(orderID, "Refunded");
                }
            }
        }
        private void UpdateOrderStatus(string orderID, string newStatus)
        {
            string query = "UPDATE Orders SET Status = @Status WHERE OrderID = @OrderID";
            using (OleDbCommand cmd = new OleDbCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("@Status", newStatus);
                cmd.Parameters.AddWithValue("@OrderID", orderID);

                connection.Open();
                cmd.ExecuteNonQuery();
                connection.Close();
            }

            MessageBox.Show($"Order {orderID} has been marked as {newStatus}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadAcceptedOrders(); // Refresh the data
        }
    }
}
