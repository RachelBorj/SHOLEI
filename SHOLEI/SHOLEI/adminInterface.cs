using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SHOLEI
{
    public partial class adminInterface : Form
    {
        public adminInterface()
        {
            InitializeComponent();
            //first form to appear in panel
            PriceForm priceForm = new PriceForm();
            LoadFormInPanel(priceForm);
        }
        //to load form to panel
        private void LoadFormInPanel(Form form)
        {
            // Clear existing controls in the panel
           panel3.Controls.Clear();

            // Set the form as a child of the panel
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;

            // Add the form to the panel and display it
            panel3.Controls.Add(form);
            form.Show();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            PriceForm priceForm = new PriceForm();
            LoadFormInPanel(priceForm);
        }
       
        private void btnOrders_Click(object sender, EventArgs e)
        {
            Orders orders = new Orders();
            LoadFormInPanel(orders);
        }

        private void btnOrderHistory_Click(object sender, EventArgs e)
        {
            OrderHistory orderHistory = new OrderHistory();
            LoadFormInPanel(orderHistory);
        }
        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1(); // Assuming LoginForm is your login form class
            form1.Show();  // Show the login form
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnPendingOrders_Click(object sender, EventArgs e)
        {
            OrdersForm ordersForm = new OrdersForm();
            LoadFormInPanel(ordersForm);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            StudentsInfoForm studentsInfoForm = new StudentsInfoForm();
            LoadFormInPanel(studentsInfoForm);
        }
    }
}
