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
using System.Net.Mail;
using System.Net;
using Microsoft.VisualBasic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SHOLEI
{
    public partial class Form1 : Form
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""C:\Users\Rache\Desktop\SHOLEI\SHOLEI\bin\Debug\Solei.accdb"""; 

        // Global role variable to store the user role (admin or user)
        private string type = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Check if the "Remember Me" checkbox was checked previously
            if (Properties.Settings.Default.RememberMe)
            {
                txtUsername.Text = Properties.Settings.Default.Username;
                txtPassword.Text = Properties.Settings.Default.Password;
                chkRememberMe.Checked = true;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }


        private bool SendPasswordResetEmail(string email)
        {
            try
            {
                // Create SMTP client and configure email settings
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("your-email@gmail.com", "your-email-password"),
                    EnableSsl = true
                };

                // Create the email message
                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress("Jj4655705@gmail.com"),
                    Subject = "Password Reset Request",
                    Body = "Click here to reset your password: https://example.com/resetpassword",
                    IsBodyHtml = true
                };
                mailMessage.To.Add(email);

                // Send the email
                smtpClient.Send(mailMessage);

                return true; // Simulate successful email sending
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending email: {ex.Message}");
                return false;
            }
        }
        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Check if the username and password fields are empty
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            // Authenticate the user
            if (AuthenticateUser(username, password))
            {
                if (chkRememberMe.Checked)
                {
                    Properties.Settings.Default.Username = username;
                    Properties.Settings.Default.Password = password;
                    Properties.Settings.Default.RememberMe = true;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    Properties.Settings.Default.Username = string.Empty;
                    Properties.Settings.Default.Password = string.Empty;
                    Properties.Settings.Default.RememberMe = false;
                    Properties.Settings.Default.Save();
                }

                MessageBox.Show("Login successful!");

              

                // Role-based welcome message
                if (type == "Admin")
                {
                    adminInterface adminInterface = new adminInterface();
                    adminInterface.Show();
                    this.Hide();
                    MessageBox.Show("Welcome, Admin!");



                }
                else
                {
                    UserInterface userInterface = new UserInterface();
                    userInterface.Show();
                    this.Hide();
                    MessageBox.Show("Welcome, User!");
                    // Redirect to user dashboard or interface
                }
            }
            else
            {
                MessageBox.Show("Invalid credentials. Please try again.");
            }
        }
        private bool AuthenticateUser(string username, string password)
        {
            bool isAuthenticated = false;
            type = string.Empty;  // Reset role

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT Type FROM Users WHERE Username = @username AND Password = @password";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("?", username);
                        cmd.Parameters.AddWithValue("?", password);

                        // Execute the query and get the role
                        object result = cmd.ExecuteScalar();
                        if (result != null)
                        {
                            type = result.ToString();  // Assign the role value from the database
                            isAuthenticated = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }

            return isAuthenticated;
        }

        private bool isPasswordVisible = false;
        private void btnShowHidePassword_Click_1(object sender, EventArgs e)
        {
            isPasswordVisible = !isPasswordVisible;

            if (isPasswordVisible)
            {
                txtPassword.PasswordChar = '\0';
                btnShowHidePassword.Text = "Hide";
            }
            else
            {
                txtPassword.PasswordChar = '*';
                btnShowHidePassword.Text = "SHOW";
            }
        }

        private void linkLabel2_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string email = Interaction.InputBox("Please enter your registered email address to reset your password:", "Forgot Password");

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Email address cannot be empty.");
                return;
            }

            if (SendPasswordResetEmail(email))
            {
                MessageBox.Show("A password reset link has been sent to your email.");
            }
            else
            {
                MessageBox.Show("Email address not found.");
            }
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUp signUpForm = new SignUp();
            signUpForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

