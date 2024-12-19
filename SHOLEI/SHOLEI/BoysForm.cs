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

namespace SHOLEI
{
    public partial class BoysForm : Form
    {
        private OleDbConnection connection;
        private UserInterface mainForm;
        public BoysForm(UserInterface parentForm)
        {
            InitializeComponent();
            mainForm = parentForm;
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"C:\\Users\\Rache\\Desktop\\SHOLEI\\SHOLEI\\bin\\Debug\\Solei.accdb\"");
           

        }

        private void BoysForm_Load(object sender, EventArgs e)
        {
            int poloProductID = GetProductID("Polo");
            int pantsProductID = GetProductID("Pants");

            // Load sizes for Blouse and Skirt using their ProductIDs
            LoadProductSizes(poloProductID, "Polo");
            LoadProductSizes(pantsProductID, "Pants");

        }
        private int GetProductID(string productName)
        {
            string query = "SELECT ProductID FROM Products WHERE ProductName = @ProductName";
            OleDbCommand cmd = new OleDbCommand(query, connection);
            cmd.Parameters.AddWithValue("@ProductName", productName);

            connection.Open();
            int productID = (int)cmd.ExecuteScalar();  // Get ProductID
            connection.Close();

            return productID;
        }
        private void LoadProductSizes(int productID, string productName)
        {
            string query = "SELECT Size, Price FROM Sizes WHERE ProductID = @ProductID";
            OleDbCommand cmd = new OleDbCommand(query, connection);
            cmd.Parameters.AddWithValue("@ProductID", productID);  // Filter by ProductID

            connection.Open();
            OleDbDataReader reader = cmd.ExecuteReader();

            // Clear ComboBox before adding new items
            if (productName == "Polo")
            {
                cmbSizePolo.Items.Clear();
                while (reader.Read())
                {
                    cmbSizePolo.Items.Add(reader["Size"].ToString());
                }
            }
            else if (productName == "Pants")
            {
                cmbSizePants.Items.Clear();
                while (reader.Read())
                {
                    cmbSizePants.Items.Add(reader["Size"].ToString());
                }
            }

            connection.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
          
        }

        private void chkPolo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPolo.Checked)
            {
                if (string.IsNullOrEmpty(cmbSizePolo.Text) || string.IsNullOrEmpty(txtQtyPolo.Text))
                {
                    MessageBox.Show("Please select a size, enter a quantity, and ensure the price is valid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    chkPolo.Checked = false; // Uncheck the checkbox if validation fails
                    return; // Exit the method to prevent adding the item
                }
                // Add Polo to Main Form DataGridView
                mainForm.AddToMainDataGridView("Polo", cmbSizePolo.Text, txtQtyPolo.Text, txtPricePolo.Text);
            }
            else
            {
                // Remove Blouse from Main Form DataGridView if unchecked
                mainForm.RemoveRow("Polo", cmbSizePolo.Text);
            }
        }

        private void cmbSizePolo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSize = cmbSizePolo.SelectedItem.ToString();
            int poloProductID = GetProductID("Polo");
            decimal poloPrice = GetProductPrice(poloProductID, selectedSize);
            txtPricePolo.Text = poloPrice.ToString("C");

            txtQtyPolo.Text = "1";
        }

        private void cmbSizePants_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSize = cmbSizePants.SelectedItem.ToString();
            int pantsProductID = GetProductID("Pants");
            decimal pantsPrice = GetProductPrice(pantsProductID, selectedSize);
            txtPricePants.Text = pantsPrice.ToString("C");

            txtQtyPants.Text = "1";
        }
        private decimal GetProductPrice(int productID, string size)
        {
            string query = "SELECT Price FROM Sizes WHERE ProductID = @ProductID AND Size = @Size";
            OleDbCommand cmd = new OleDbCommand(query, connection);
            cmd.Parameters.AddWithValue("@ProductID", productID);
            cmd.Parameters.AddWithValue("@Size", size);

            connection.Open();
            decimal price = (decimal)cmd.ExecuteScalar();
            connection.Close();

            return price;
        }

        private void chkPants_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPants.Checked)
            {
                if (string.IsNullOrEmpty(cmbSizePants.Text) || string.IsNullOrEmpty(txtQtyPants.Text))
                {
                    MessageBox.Show("Please select a size and enter a quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    chkPants.Checked = false; // Uncheck the checkbox if validation fails
                    return; // Exit the method to prevent adding the item
                }
                // Add Pants to Main Form DataGridView
                mainForm.AddToMainDataGridView("Pants", cmbSizePants.Text, txtQtyPants.Text, txtPricePants.Text);
            }
            else
            {
                // Remove Blouse from Main Form DataGridView if unchecked
                mainForm.RemoveRow("Pants", cmbSizePants.Text);
            }
        }

        private void txtQtyPolo_TextChanged(object sender, EventArgs e)
        {
            UpdatePrice(txtQtyPolo, cmbSizePolo, txtPricePolo, "Polo");
        }

        private void txtQtyPants_TextChanged(object sender, EventArgs e)
        {
            UpdatePrice(txtQtyPants, cmbSizePants, txtPricePants, "Pants");
        }
        private void UpdatePrice(TextBox quantityTextBox, ComboBox sizeComboBox, TextBox priceTextBox, string productName)
        {
            if (int.TryParse(quantityTextBox.Text, out int quantity) && !string.IsNullOrEmpty(sizeComboBox.Text))
            {
                // Fetch the price for the selected size from the database
                decimal unitPrice = GetPriceFromDatabase(productName, sizeComboBox.Text);

                // Calculate the total price
                decimal totalPrice = unitPrice * quantity;

                // Display the total price in the Price TextBox
                priceTextBox.Text = totalPrice.ToString("F2"); // Format to 2 decimal places
            }
            else
            {
                // Clear the Price TextBox if invalid input
                priceTextBox.Clear();
            }
        }

        private decimal GetPriceFromDatabase(string productName, string size)
        {
            decimal price = 0;

            try
            {
                using (OleDbConnection connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"C:\\Users\\Rache\\Desktop\\SHOLEI\\SHOLEI\\bin\\Debug\\Solei.accdb\""))
                {
                    connection.Open();
                    string query = "SELECT Price FROM Sizes WHERE ProductName = @ProductName AND Size = @Size";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProductName", productName);
                        command.Parameters.AddWithValue("@Size", size);
                        object result = command.ExecuteScalar();
                        if (result != null)
                        {
                            price = Convert.ToDecimal(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching price: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return price;
        }
        public void ResetCheckboxes()
        {
            chkPolo.Checked = false;
            chkPants.Checked = false;

        }

        private void txtPricePants_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
