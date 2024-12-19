using System;
using System.Data.OleDb;
using System.Globalization;
using System.Text;
using System.Windows.Forms;


namespace SHOLEI
{
    public partial class UserInterface : Form
    {
        private OleDbConnection connection;
        public UserInterface()
        {
            InitializeComponent();
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Rache\\Desktop\\SHOLEI\\SHOLEI\\bin\\Debug\\Solei.accdb";
            connection = new OleDbConnection(connectionString);

        }
        public void AddToMainDataGridView(string productName, string size, string quantity, string price)
        {
            if (decimal.TryParse(price, out decimal unitPrice) && int.TryParse(quantity, out int qty))
            {
                // Calculate total price for this row
                decimal totalPrice = unitPrice * qty;

                // Check if the product already exists in the DataGridView
                foreach (DataGridViewRow row in dgvOrders.Rows)
                {
                    if (row.Cells["ProductName"].Value?.ToString() == productName && row.Cells["Size"].Value?.ToString() == size)
                    {
                        // Update the existing row
                        row.Cells["Quantity"].Value = quantity;
                        row.Cells["Price"].Value = price;
                        UpdateTotalAmount(); // Recalculate total amount
                        return; // Exit the method after updating

                    }
                }

                // Add new row if the product does not already exist
                int rowIndex = dgvOrders.Rows.Add();
                dgvOrders.Rows[rowIndex].Cells["ProductName"].Value = productName;
                dgvOrders.Rows[rowIndex].Cells["Size"].Value = size;
                dgvOrders.Rows[rowIndex].Cells["Quantity"].Value = quantity;
                dgvOrders.Rows[rowIndex].Cells["Price"].Value = price;
                UpdateTotalAmount();
            }
        }
        public void UpdateTotalAmount()
        {
            decimal totalAmount = 0;

            // Loop through all rows in the DataGridView and sum up the price
            foreach (DataGridViewRow row in dgvOrders.Rows)
            {
                // Check if Price cell has a value
                if (row.Cells["Price"].Value != null)
                {
                    // Add the value of the Price column to the total amount
                    decimal rowTotal = Convert.ToDecimal(row.Cells["Price"].Value.ToString().Trim('$'));
                    totalAmount += rowTotal;
                }
            }

            // Display the total amount in the TextBox
            txtTotalAmount.Text = totalAmount.ToString("C"); // Format as currency (e.g., $100.00)
        }

        public void RemoveRow(string productName, string size)
        {
            foreach (DataGridViewRow row in dgvOrders.Rows)
            {
                if (row.Cells["ProductName"].Value?.ToString() == productName && row.Cells["Size"].Value?.ToString() == size)
                {
                    dgvOrders.Rows.Remove(row); // Remove the matching row
                    break;
                }
            }
            UpdateTotalAmount();
        }
        private void UserInterface_Load(object sender, EventArgs e)
        {
            studentForm studentFormInstance = new studentForm(this);

            // Load the studentForm into the panel
            LoadFormInPanel(studentFormInstance);
        }


        private void LoadFormInPanel(Form form)
        {
            // Clear existing controls in the panel
            productPanel.Controls.Clear();

            // Set the form as a child of the panel
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;

            // Add the form to the panel and display it
            productPanel.Controls.Add(form);
            form.Show();
        }

        private void btnWomensSection_Click(object sender, EventArgs e)
        {
            studentForm studentForm = new studentForm(this); // Pass main form reference
            LoadFormInPanel(studentForm);
        }

        private void btnMensSection_Click(object sender, EventArgs e)
        {
            BoysForm boysForm = new BoysForm(this); // Pass main form reference
            LoadFormInPanel(boysForm);
        }

        private void dgvOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAboutUs_Click(object sender, EventArgs e)
        {
            AboutUs aboutUs = new AboutUs();
            aboutUs.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtStudentID_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is Enter (key code 13)
            if (e.KeyChar == (char)Keys.Enter)
            {
                string studentID = txtStudentID.Text.Trim();

                if (!string.IsNullOrEmpty(studentID))
                {
                    // Call the function to fetch and fill student information based on the StudentID
                    GetStudentInfo(studentID);
                }
                else
                {
                    // Clear the textboxes if no StudentID is entered
                    txtName.Clear();
                    txtCourse.Clear();
                    txtSection.Clear();
                }
            }
        }
        private void GetStudentInfo(string studentID)
        {
            try
            {
                // Query to get student information from the database
                string query = "SELECT Name, Course, Section FROM Students WHERE StudentID = @StudentID";

                using (OleDbCommand cmd = new OleDbCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@StudentID", studentID);

                    // Open the connection
                    connection.Open();

                    // Execute the query and read the data
                    OleDbDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // If a student is found, populate the textboxes with the retrieved values
                        txtName.Text = reader["Name"].ToString();
                        txtCourse.Text = reader["Course"].ToString();
                        txtSection.Text = reader["Section"].ToString();
                    }
                    else
                    {
                        // If no student is found, clear the textboxes and show a message
                        txtName.Clear();
                        txtCourse.Clear();
                        txtSection.Clear();
                        MessageBox.Show("Student not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    // Close the connection
                
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that may occur
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        private void btnSubmitOrders_Click(object sender, EventArgs e)
        {
            // Step 1: Validate that student information fields are not empty
            if (string.IsNullOrWhiteSpace(txtStudentID.Text) ||
                string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtSection.Text) ||
                string.IsNullOrWhiteSpace(txtCourse.Text))
            {
                MessageBox.Show("Please fill in all student details before submitting the order.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Step 2: Validate that there are orders in the DataGridView
            if (dgvOrders.Rows.Count == 0)
            {
                MessageBox.Show("No orders have been placed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string totalAmountText = txtTotalAmount.Text.Trim();
            if (string.IsNullOrWhiteSpace(totalAmountText))
            {
                MessageBox.Show("Total amount is missing. Ensure orders are correctly calculated.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal totalOrderAmount;
            if (!decimal.TryParse(totalAmountText, NumberStyles.Currency, CultureInfo.CurrentCulture, out totalOrderAmount))
            {
                MessageBox.Show("Total amount format is invalid. Please check the entered value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Step 4: Show order summary in a message box for confirmation
            StringBuilder orderSummary = new StringBuilder();
            orderSummary.AppendLine("Your Orders:");

            foreach (DataGridViewRow row in dgvOrders.Rows)
            {
                if (row.IsNewRow) continue; // Skip the new row placeholder

                string productName = row.Cells["ProductName"].Value?.ToString() ?? "N/A";
                string size = row.Cells["Size"].Value?.ToString() ?? "N/A";
                string quantity = row.Cells["Quantity"].Value?.ToString() ?? "N/A";
                string price = row.Cells["Price"].Value?.ToString() ?? "N/A";
                decimal unitPrice = decimal.TryParse(price, out unitPrice) ? unitPrice : 0;
                int qty = int.TryParse(quantity, out qty) ? qty : 0;
                decimal totalPrice = unitPrice * qty;

                orderSummary.AppendLine($"{productName} - {size} - {quantity} pcs - {price} (Total: {totalPrice:C})");
            }

            orderSummary.AppendLine($"\nTotal Order Amount: {totalOrderAmount:C}");
            orderSummary.AppendLine("\nAre you sure you want to place this order?");

            // Step 5: Show confirmation prompt
            DialogResult result = MessageBox.Show(orderSummary.ToString(), "Confirm Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Step 6: Gather student details and date
                string studentID = txtStudentID.Text;
                string studentName = txtName.Text;
                string section = txtSection.Text;
                string course = txtCourse.Text;
                string orderDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                // Step 7: Insert order summary into the Orders table
                string insertOrderQuery = "INSERT INTO Orders (StudentID, StudentName, [Section], [Course], OrderDate) " +
                                          "VALUES (@StudentID, @StudentName, @Section, @Course, @OrderDate)";

                using (OleDbCommand cmd = new OleDbCommand(insertOrderQuery, connection))
                {
                    cmd.Parameters.AddWithValue("@StudentID", studentID);
                    cmd.Parameters.AddWithValue("@StudentName", studentName);
                    cmd.Parameters.AddWithValue("@Section", section);
                    cmd.Parameters.AddWithValue("@Course", course);
                    cmd.Parameters.AddWithValue("@OrderDate", orderDate);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }

                // Step 8: Insert order items into the OrderItems table
                string insertItemQuery = "INSERT INTO OrderItems (OrderID, ProductName, [Size], Quantity, [Price], TotalPrice) " +
                                          "VALUES (@OrderID, @ProductName, @Size, @Quantity, @Price, @TotalPrice)";

                // Retrieve the OrderID of the newly inserted order (assuming the Orders table has an AutoNumber primary key)
                int orderID = GetLastOrderID();  // Method to retrieve the last inserted OrderID (assuming it's AutoNumber)

                foreach (DataGridViewRow row in dgvOrders.Rows)
                {
                    if (row.IsNewRow) continue;

                    string productName = row.Cells["ProductName"].Value?.ToString() ?? "N/A";
                    string size = row.Cells["Size"].Value?.ToString() ?? "N/A";
                    string quantity = row.Cells["Quantity"].Value?.ToString() ?? "0";
                    string price = row.Cells["Price"].Value?.ToString() ?? "0";

                    int qty = int.TryParse(quantity, out qty) ? qty : 0;
                    decimal totalPrice = decimal.TryParse(price, out totalPrice) ? totalPrice : 0;
                    // Insert each order item into the OrderItems table
                    using (OleDbCommand cmd = new OleDbCommand(insertItemQuery, connection))
                    {
                        // Order of parameters must match the SQL query
                        cmd.Parameters.AddWithValue("@OrderID", orderID);         // Ensure orderID is valid
                        cmd.Parameters.AddWithValue("@ProductName", productName); // String
                        cmd.Parameters.AddWithValue("@Size", size);               // String
                        cmd.Parameters.AddWithValue("@Quantity", qty);            // Integer
                        cmd.Parameters.AddWithValue("@Price", totalPrice);        // Decimal
                        cmd.Parameters.AddWithValue("@TotalPrice", totalPrice);   // Decimal (same as Price)

                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }

               
                // Step 10: Pass data to the TransactionDetailsForm
                TransactionDetailsForm transactionForm = new TransactionDetailsForm(
                    dgvOrders,
                    studentID,
                    studentName,
                    section,
                    course,
                    orderDate,
                    totalOrderAmount
                );
                transactionForm.ShowDialog();
                ResetForm();
                
            }
           
        }
        public void ResetForm()
        {
            // Clear the student details
            txtStudentID.Clear();
            txtName.Clear();
            txtSection.Clear();
            txtCourse.Clear();
            

            // Clear the DataGridView (order details)
            dgvOrders.Rows.Clear();

            // Clear the total amount
            txtTotalAmount.Clear();
        }


        private int GetLastOrderID()
        {
            string query = "SELECT MAX(OrderID) FROM Orders"; // Adjust if your table has a different primary key name
            using (OleDbCommand cmd = new OleDbCommand(query, connection))
            {
                connection.Open();
                var result = cmd.ExecuteScalar();
                connection.Close();

                return result != DBNull.Value ? Convert.ToInt32(result) : 0;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(); // Assuming LoginForm is your login form class
            form1.Show();  // Show the login form
            this.Hide();
        }

        private void topPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
