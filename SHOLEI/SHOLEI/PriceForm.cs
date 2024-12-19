using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;


namespace SHOLEI
{
    public partial class PriceForm : Form
    {
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""C:\Users\Rache\Desktop\SHOLEI\SHOLEI\bin\Debug\Solei.accdb""";

        public PriceForm()
        {
            InitializeComponent();           
        }

        //Load event ng form
        private void PriceForm_Load(object sender, EventArgs e)
        {
            LoadProducts();
            lstSizePrice.SelectedIndex = -1;
        }

        //Load products from the database
        private void LoadProducts()
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = "SELECT ProductID, ProductName, Description FROM Products";
                OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                DataTable productsTable = new DataTable();
                adapter.Fill(productsTable);

                cboProducts.DataSource = productsTable;
                cboProducts.DisplayMember = "ProductName";
                cboProducts.ValueMember = "ProductID";
            }
        }
        //Load sizes for a specific product
        private void LoadSizes(int productId)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = "SELECT SizeID, Size, Price FROM Sizes WHERE ProductID = @ProductID";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("@ProductID", productId);

                OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                DataTable sizesTable = new DataTable();
                adapter.Fill(sizesTable);

                lstSizePrice.DataSource = sizesTable;
                lstSizePrice.DisplayMember = "Size";
                lstSizePrice.ValueMember = "SizeID";
            }
        }
        //Event pag may napiling product
        private void cboProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProducts.SelectedValue != null && int.TryParse(cboProducts.SelectedValue.ToString(), out int productId))
            {
                LoadSizes(productId);
                LoadProductDetails(productId);
            }
        }
        //Load product details
        private void LoadProductDetails(int productId)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = "SELECT Description FROM Products WHERE ProductID = @ProductID";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("@ProductID", productId);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    txtDescription.Text = reader["Description"].ToString();
                }
            }
        }
        //Add size and price
        private void btnAddSizePrice_Click(object sender, EventArgs e)
        {
            // Check if Product is selected
            if (cboProducts.SelectedValue == null)
            {
                MessageBox.Show("Please select a product.");
                return;
            }

            // Validate Size field
            if (string.IsNullOrEmpty(txtSize.Text.Trim()))
            {
                MessageBox.Show("Please enter a size.");
                return;
            }

            // Validate Price field
            if (!decimal.TryParse(txtPrice.Text.Trim(), out decimal price) || price <= 0)
            {
                MessageBox.Show("Please enter a valid price (greater than 0).");
                return;
            }

            // Proceed to database operation
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    string duplicateCheckQuery = "SELECT COUNT(*) FROM Sizes WHERE ProductID = @ProductID AND [Size] = @Size";
                    using (OleDbCommand duplicateCheckCommand = new OleDbCommand(duplicateCheckQuery, connection))
                    {
                        duplicateCheckCommand.Parameters.AddWithValue("@ProductID", cboProducts.SelectedValue);
                        duplicateCheckCommand.Parameters.AddWithValue("@Size", txtSize.Text.Trim());

                        connection.Open();
                        int count = (int)duplicateCheckCommand.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("This size already exists for the selected product.");
                            return;
                        }
                    }

                    // Proceed with Insert after duplicate check
                    string query = "INSERT INTO Sizes (ProductID, [Size], [Price]) VALUES (@ProductID, @Size, @Price)";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductID", cboProducts.SelectedValue);
                        command.Parameters.AddWithValue("@Size", txtSize.Text.Trim());
                        command.Parameters.AddWithValue("@Price", price);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Size added successfully!");
                        LoadSizes(Convert.ToInt32(cboProducts.SelectedValue));
                        //clear size and price in textbox after adding
                        txtSize.Clear();
                        txtPrice.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }
        //Delete size
        private void btndelete_Click(object sender, EventArgs e)
        {
            if (lstSizePrice.SelectedValue != null)
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    string query = "DELETE FROM Sizes WHERE SizeID = @SizeID";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("@SizeID", lstSizePrice.SelectedValue);

                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Size deleted successfully!");

                    LoadSizes(Convert.ToInt32(cboProducts.SelectedValue));
                }
            }
            else
            {
                MessageBox.Show("Please select a size to delete.");
            }
        }
        //Save product details
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cboProducts.SelectedValue != null && !string.IsNullOrEmpty(txtDescription.Text))
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    string query = "UPDATE Products SET Description = @Description WHERE ProductID = @ProductID";
                    OleDbCommand command = new OleDbCommand(query, connection);

                    command.Parameters.AddWithValue("@Description", txtDescription.Text);
                    command.Parameters.AddWithValue("@ProductID", cboProducts.SelectedValue);

                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Product details saved successfully!");
                }
            }
            else
            {
                MessageBox.Show("Please select a product and provide a description.");
            }
        }

       //select info in listbox
        private void lstSizePrice_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if a size is selected from the list
            if (lstSizePrice.SelectedItem != null)
            {
                // Get the selected DataRowView from the ListBox
                DataRowView selectedRow = lstSizePrice.SelectedItem as DataRowView;

                if (selectedRow != null)
                {
                    // Get the SizeID from the DataRowView
                    int selectedSizeID = Convert.ToInt32(selectedRow["SizeID"]);

                    // Load the corresponding size and price into the textboxes
                    LoadSizeDetails(selectedSizeID);
                }
            }
            else
            {
                // Clear textboxes when no item is selected
                txtSize.Clear();
                txtPrice.Clear();
            }
        }
        //load size details
        private void LoadSizeDetails(int sizeID)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                string query = "SELECT Size, Price FROM Sizes WHERE SizeID = @SizeID";
                OleDbCommand command = new OleDbCommand(query, connection);
                command.Parameters.AddWithValue("@SizeID", sizeID);

                connection.Open();
                OleDbDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    txtSize.Text = reader["Size"].ToString();
                    txtPrice.Text = reader["Price"].ToString();
                }
            }
        }
        //update size price
        private void btnUpdateSizePrice_Click(object sender, EventArgs e)
        {
            // Validate user input
            if (lstSizePrice.SelectedValue == null)
            {
                MessageBox.Show("Please select a size to update.");
                return;
            }

            if (string.IsNullOrEmpty(txtSize.Text.Trim()) || string.IsNullOrEmpty(txtPrice.Text.Trim()))
            {
                MessageBox.Show("Please fill in both size and price fields.");
                return;
            }

            // Parse the price to ensure it's a valid decimal number
            if (!decimal.TryParse(txtPrice.Text.Trim(), out decimal price) || price <= 0)
            {
                MessageBox.Show("Please enter a valid price (greater than 0).");
                return;
            }

            // Proceed to update the record
            try
            {
                int selectedSizeID = Convert.ToInt32(lstSizePrice.SelectedValue);
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    string query = "UPDATE Sizes SET [Size] = @Size, [Price] = @Price WHERE SizeID = @SizeID";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Size", txtSize.Text.Trim());
                        command.Parameters.AddWithValue("@Price", price);
                        command.Parameters.AddWithValue("@SizeID", selectedSizeID);

                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Size and Price updated successfully!");

                        // Refresh the sizes list
                        LoadSizes(Convert.ToInt32(cboProducts.SelectedValue));

                        // Clear the textboxes after updating
                        txtSize.Clear();
                        txtPrice.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
