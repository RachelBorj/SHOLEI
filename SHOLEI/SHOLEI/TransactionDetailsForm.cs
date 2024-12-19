using System;
using System.Windows.Forms;


namespace SHOLEI
{
    public partial class TransactionDetailsForm : Form
    {
        

        public TransactionDetailsForm(DataGridView orderDetails, string studentID, string studentName, string section, string course, string orderDate, decimal totalOrderAmount)
        {
            InitializeComponent();


            // Set labels with student and order details
            lblStudentID.Text = $"Student ID: {studentID}";
            lblName.Text = $"Name: {studentName}";
            lblSection.Text = $"Section: {section}";
            lblCourse.Text = $"Course: {course}";
            lblOrderDate.Text = $"Order Date: {orderDate}";
            lblTotalAmount.Text = $"Total Amount: {totalOrderAmount.ToString("C")}"; // Format as currency

            // Populate the order details
            foreach (DataGridViewRow row in orderDetails.Rows)
            {
                if (row.IsNewRow) continue; // Skip the new row placeholder
                string productName = row.Cells["ProductName"].Value?.ToString() ?? "N/A";
                string size = row.Cells["Size"].Value?.ToString() ?? "N/A";
                string quantity = row.Cells["Quantity"].Value?.ToString() ?? "N/A";
                string price = row.Cells["Price"].Value?.ToString() ?? "N/A";

                // Add the product details to the data grid in the TransactionDetailsForm
                dataGridViewTransactionDetails.Rows.Add(productName, size, quantity, price);
            }
        }

        private void TransactionDetailsForm_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {

            this.Close();
        }

    }
}
