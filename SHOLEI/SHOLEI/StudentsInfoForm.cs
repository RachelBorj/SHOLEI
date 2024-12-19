using System;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data;

namespace SHOLEI
{
    public partial class StudentsInfoForm : Form
    {
        public StudentsInfoForm()
        {
            InitializeComponent();
        }

        private void StudentsInfoForm_Load(object sender, EventArgs e)
        {
            LoadStudentData();
            PopulateComboBox();
        }
        private void LoadStudentData()
        {
            try
            {
                // Connection string for the Access database
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Rache\Desktop\SHOLEI\SHOLEI\bin\Debug\Solei.accdb";

                // SQL query to retrieve data from the "Students" table
                string query = "SELECT StudentID, [Name], Course, Section FROM Students";

                // Create a connection to the database
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Create a DataAdapter to execute the query and fill the DataTable
                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);

                    // Bind the DataTable to the DataGridView
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void PopulateComboBox()
        {
            try
            {
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Rache\Desktop\SHOLEI\SHOLEI\bin\Debug\Solei.accdb";

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    // Create a DataTable to hold both Course and Section options
                    DataTable optionsTable = new DataTable();
                    optionsTable.Columns.Add("Display");
                    optionsTable.Columns.Add("FilterValue");
                    optionsTable.Columns.Add("FilterType");
                    optionsTable.Rows.Add("Show All", null, "All");

                    // Add Course options
                    string courseQuery = "SELECT DISTINCT Course FROM Students";
                    OleDbDataAdapter courseAdapter = new OleDbDataAdapter(courseQuery, connection);
                    DataTable courseTable = new DataTable();
                    courseAdapter.Fill(courseTable);
                    foreach (DataRow row in courseTable.Rows)
                    {
                        optionsTable.Rows.Add($"Course: {row["Course"]}", row["Course"], "Course");
                    }

                    // Add Section options
                    string sectionQuery = "SELECT DISTINCT Section FROM Students";
                    OleDbDataAdapter sectionAdapter = new OleDbDataAdapter(sectionQuery, connection);
                    DataTable sectionTable = new DataTable();
                    sectionAdapter.Fill(sectionTable);
                    foreach (DataRow row in sectionTable.Rows)
                    {
                        optionsTable.Rows.Add($"Section: {row["Section"]}", row["Section"], "Section");
                    }

                    // Bind the ComboBox
                    cmbFilter.DataSource = optionsTable;
                    cmbFilter.DisplayMember = "Display";
                    cmbFilter.ValueMember = "FilterValue";
                    cmbFilter.SelectedIndex = -1; // No selection by default
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
        private void AddStudent()
        {
            // Insert logic here...

            // Refresh the DataGridView
            LoadStudentData();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Step 1: Select Excel File
                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                    Filter = "Excel Files|*.xls;*.xlsx",
                    Title = "Select Excel File"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string excelFilePath = openFileDialog.FileName;

                    // Step 2: Read Excel Data
                    string excelConnectionString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={excelFilePath};Extended Properties='Excel 12.0 Xml;HDR=YES;'";
                    using (OleDbConnection excelConnection = new OleDbConnection(excelConnectionString))
                    {
                        excelConnection.Open();
                        DataTable sheetData = excelConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                        if (sheetData.Rows.Count > 0)
                        {
                            string firstSheetName = sheetData.Rows[0]["Table_Name"].ToString();
                            string query = $"SELECT * FROM [{firstSheetName}]";

                            OleDbDataAdapter excelAdapter = new OleDbDataAdapter(query, excelConnection);
                            DataTable dataTable = new DataTable();
                            excelAdapter.Fill(dataTable);

                            // Step 3: Import into Access
                            string accessConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=""C:\Users\Rache\Desktop\SHOLEI\SHOLEI\bin\Debug\Solei.accdb""";
                            using (OleDbConnection accessConnection = new OleDbConnection(accessConnectionString))
                            {
                                accessConnection.Open();

                                foreach (DataRow row in dataTable.Rows)
                                {
                                    string insertQuery = "INSERT INTO Students (StudentID, [Name], [Course], [Section]) VALUES (@studentID, @name, @course, @section)";
                                    using (OleDbCommand cmd = new OleDbCommand(insertQuery, accessConnection))
                                    {
                                        cmd.Parameters.AddWithValue("@studentID", row["StudentID"]);
                                        cmd.Parameters.AddWithValue("@name", row["Name"]);
                                        cmd.Parameters.AddWithValue("@course", row["Course"]);
                                        cmd.Parameters.AddWithValue("@section", row["Section"]);
                                        cmd.ExecuteNonQuery();
                                    }
                                }
                            }
                        }

                        MessageBox.Show("Data imported successfully!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

      
        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilter.SelectedIndex != -1) // Ensure a selection was made
            {
                FilterData();
            }
        }
        private void FilterData()
        {
            try
            {
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Rache\Desktop\SHOLEI\SHOLEI\bin\Debug\Solei.accdb";

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    // Get the selected FilterValue and FilterType
                    DataRowView selectedRow = cmbFilter.SelectedItem as DataRowView;
                    string filterValue = selectedRow["FilterValue"].ToString();
                    string filterType = selectedRow["FilterType"].ToString();

                    string query = "SELECT StudentID, [Name], Course, Section FROM Students";
                    if (filterType != "All")
                    {
                        query += " WHERE ";
                        if (filterType == "Course")
                        {
                            query += $"Course = '{filterValue}'";
                        }
                        else if (filterType == "Section")
                        {
                            query += $"Section = '{filterValue}'";
                        }
                    }

                    // Execute the query and bind the results
                    OleDbDataAdapter adapter = new OleDbDataAdapter(query, connection);
                    DataTable filteredTable = new DataTable();
                    adapter.Fill(filteredTable);

                    dataGridView1.DataSource = filteredTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
    
}
