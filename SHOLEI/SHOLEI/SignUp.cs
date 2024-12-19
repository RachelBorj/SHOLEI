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
    public partial class SignUp : Form
    {
        string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""C:\Users\Rache\Desktop\SHOLEI\SHOLEI\bin\Debug\Solei.accdb""";
        public SignUp()
        {
            InitializeComponent();
        }

        private void SignUp_Load(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string email = txtEmail.Text;

            // Validating input fields
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Please fill out all fields!");
                return;
            }

            try
            {
                // Lumikha ng koneksyon sa database
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    // Query para mag-insert ng data sa Users table
                    string query = "INSERT INTO [Users] ([Username], [Password], [Email]) VALUES (?, ?, ?)";

                    // Lumikha ng command object
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        // Add parameters para sa query
                        cmd.Parameters.AddWithValue("?", username);
                        cmd.Parameters.AddWithValue("?", password);
                        cmd.Parameters.AddWithValue("?", email);

                        // I-execute ang query
                        cmd.ExecuteNonQuery();
                    }
                }

                // Kapag successful ang pag-save, magpakita ng success message
                MessageBox.Show("Account created successfully!");


                Form1 form = new Form1();
                form.Show();
                this.Hide();

            }
            catch (OleDbException oleDbEx)
            {
                // I-handle ang specific database errors
                MessageBox.Show("Database error: " + oleDbEx.Message);
            }
            catch (Exception ex)
            {
                // I-handle ang generic errors
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Hide();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }
        private bool isPasswordVisible = false;
        private void btnShowHidePassword_Click(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;

            if (isPasswordVisible)
            {
                txtPassword.PasswordChar = '\0';
                btnShowHidePassword.Text = "Hide password";
            }
            else
            {
                txtPassword.PasswordChar = '*';
                btnShowHidePassword.Text = "sHOW password";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
