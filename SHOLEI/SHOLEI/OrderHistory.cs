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
using Microsoft.Office.Interop.Excel;

namespace SHOLEI
{
    public partial class OrderHistory : Form
    {
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""C:\Users\Rache\Desktop\SHOLEI\SHOLEI\bin\Debug\Solei.accdb""";
        public OrderHistory()
        {
            InitializeComponent();
        }

        private void OrderHistory_Load(object sender, EventArgs e)
        {
            cmbOrderStatus.Items.Add("All");
            cmbOrderStatus.Items.Add("Declined");
            cmbOrderStatus.Items.Add("Received");
            cmbOrderStatus.Items.Add("Refunded");
            cmbOrderStatus.SelectedIndex = 0; // Default selection as "All"
            LoadOrderHistory("Declined"); // Initial load

        }
        private void LoadOrderHistory(string status)
        {
            dgvOrderHistory.Rows.Clear();
            dgvOrderHistory.Columns.Clear();

            // Add columns to the DataGridView
            dgvOrderHistory.Columns.Add("OrderID", "Order ID");
            dgvOrderHistory.Columns.Add("StudentID", "Student ID");
            dgvOrderHistory.Columns.Add("StudentName", "Student Name");
            dgvOrderHistory.Columns.Add("ProductName", "Product Name");
            dgvOrderHistory.Columns.Add("Size", "Size");
            dgvOrderHistory.Columns.Add("Quantity", "Quantity");
            dgvOrderHistory.Columns.Add("Price", "Price");
            dgvOrderHistory.Columns.Add("Status", "Status");


            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string statusFilter = (status == "All") ? "" : "WHERE O.Status = @Status";
                    string query = $@"
        SELECT O.OrderID, O.StudentID, O.StudentName, I.ProductName, I.Size, I.Quantity, I.Price, O.Status 
        FROM Orders O
        INNER JOIN OrderItems I ON O.OrderID = I.OrderID
        {statusFilter}
        ORDER BY O.OrderDate DESC";

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Status", status);

                        OleDbDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            dgvOrderHistory.Rows.Add(
                                reader["OrderID"],
                                reader["StudentID"],
                                reader["StudentName"],
                                reader["ProductName"],
                                reader["Size"],
                                reader["Quantity"],
                                reader["Price"],
                                reader["Status"] == DBNull.Value ? "Unknown" : reader["Status"]
                            );
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading order history: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbOrderStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedStatus = cmbOrderStatus.SelectedItem.ToString();
            LoadOrderHistory(selectedStatus);
        }
  
        private void button1_Click(object sender, EventArgs e)
        {
            // Show confirmation dialog to ask the user if they want to export to Excel
            var result = MessageBox.Show("Do you want to export the data to Print(Export To Excel)?", "Export Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // If user clicks 'Yes', proceed with export
            if (result == DialogResult.Yes)
            {
                try
                {
                    // Create an instance of the Excel application
                    var excelApp = new Microsoft.Office.Interop.Excel.Application();

                    // Create a new workbook
                    var workbooks = excelApp.Workbooks;
                    var workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);  // Specify template for worksheet

                    // Get the first worksheet in the new workbook
                    var worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];

                    // Set Excel to be visible (optional)
                    excelApp.Visible = true;

                    // Add headers to the worksheet (based on DataGridView columns)
                    for (int i = 0; i < dgvOrderHistory.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i + 1] = dgvOrderHistory.Columns[i].HeaderText;
                    }

                    // Add data to the worksheet (based on DataGridView rows)
                    for (int i = 0; i < dgvOrderHistory.Rows.Count; i++)
                    {
                        for (int j = 0; j < dgvOrderHistory.Columns.Count; j++)
                        {
                            if (dgvOrderHistory.Rows[i].Cells[j].Value != null)
                            {
                                worksheet.Cells[i + 2, j + 1] = dgvOrderHistory.Rows[i].Cells[j].Value.ToString();
                            }
                        }
                    }

                    // Optional: Save the file
                    // string filePath = @"C:\Path\To\Save\File.xlsx";
                    // workbook.SaveAs(filePath);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                // If user clicks 'No', simply return to the interface (no action is taken)
                MessageBox.Show("Export canceled.", "Export Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
    }
    