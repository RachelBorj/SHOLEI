using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Data.OleDb;
using System.Security.Cryptography;


namespace SHOLEI
{
    public partial class studentForm : Form
    {
        private OleDbConnection connection;
        private UserInterface mainForm;

        public studentForm(UserInterface parentForm)
        {
            InitializeComponent();
            mainForm = parentForm;
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"C:\\Users\\Rache\\Desktop\\SHOLEI\\SHOLEI\\bin\\Debug\\Solei.accdb\"");
          
           
        }

        private void studentForm_Load(object sender, EventArgs e)
        {
            int blouseProductID = GetProductID("Blouse");
            int skirtProductID = GetProductID("Skirt");

            // Load sizes for Blouse and Skirt using their ProductIDs
            LoadProductSizes(blouseProductID, "Blouse");
            LoadProductSizes(skirtProductID, "Skirt");
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
            if (productName == "Blouse")
            {
                cmbSizeBlouse.Items.Clear();
                while (reader.Read())
                {
                    cmbSizeBlouse.Items.Add(reader["Size"].ToString());
                }
            }
            else if (productName == "Skirt")
            {
                cmbSizeSkirt.Items.Clear();
                while (reader.Read())
                {
                    cmbSizeSkirt.Items.Add(reader["Size"].ToString());
                }
            }

            connection.Close();
        }


        private void cmbSizeBlouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSize = cmbSizeBlouse.SelectedItem.ToString();
            int blouseProductID = GetProductID("Blouse");
            decimal blousePrice = GetProductPrice(blouseProductID, selectedSize);
            tbPriceBlouse.Text = blousePrice.ToString("C");

            txtQtyblouse.Text = "1";
        }

        private void cmbSizeSkirt_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedSize = cmbSizeSkirt.SelectedItem.ToString();
            int skirtProductID = GetProductID("Skirt");
            decimal skirtPrice = GetProductPrice(skirtProductID, selectedSize);
            tbPriceSkirt.Text = skirtPrice.ToString("C");

            txtQtySkirt.Text = "1";
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

        private void btnclearReview_Click(object sender, EventArgs e)
        {
            
           

        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {

        }

      

        private void txtPrice2_TextChanged(object sender, EventArgs e)
        {

        }

        private void chkBlouse_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBlouse.Checked)
            {
                if (string.IsNullOrEmpty(cmbSizeBlouse.Text) || string.IsNullOrEmpty(txtQtyblouse.Text))
                {
                    MessageBox.Show("Please select a size and enter a quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    chkBlouse.Checked = false; // Uncheck the checkbox if validation fails
                    return; // Exit the method to prevent adding the item
                }
                // Add Blouse to Main Form DataGridView
                mainForm.AddToMainDataGridView("Blouse", cmbSizeBlouse.Text, txtQtyblouse.Text, tbPriceBlouse.Text);
            }
            else
            {
                // Remove Blouse from Main Form DataGridView if unchecked
                mainForm.RemoveRow("Blouse", cmbSizeBlouse.Text);
            }
        }

        private void chkSkirt_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSkirt.Checked)
            {
                if (string.IsNullOrEmpty(cmbSizeSkirt.Text) || string.IsNullOrEmpty(txtQtySkirt.Text))
                {
                    MessageBox.Show("Please select a size and enter a quantity.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    chkSkirt.Checked = false; // Uncheck the checkbox if validation fails
                    return; // Exit the method to prevent adding the item
                }
                // Add Skirt to Main Form DataGridView
                mainForm.AddToMainDataGridView("Skirt", cmbSizeSkirt.Text, txtQtySkirt.Text, tbPriceSkirt.Text);
            }
            else
            {
                // Remove Skirt from Main Form DataGridView if unchecked
                mainForm.RemoveRow("Skirt", cmbSizeSkirt.Text);
            }
        }


        private void txtQtyblouse_TextChanged(object sender, EventArgs e)
        {
            UpdatePrice(txtQtyblouse, cmbSizeBlouse, tbPriceBlouse, "Blouse");
        }

        private void txtQtySkirt_TextChanged(object sender, EventArgs e)
        {
            UpdatePrice(txtQtySkirt, cmbSizeSkirt, tbPriceSkirt, "Skirt");
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
            chkBlouse.Checked = false;
            chkSkirt.Checked = false;
            
        }

    }
}
