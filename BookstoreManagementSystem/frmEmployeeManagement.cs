using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BookstoreManagementSystem
{
    public partial class frmEmployeeManagement : Form
    {
        public frmEmployeeManagement()
        {
            InitializeComponent();
        }

        private void frmEmployeeManagement_Load(object sender, EventArgs e)
        {
            // SQL statement to retrieve data
            string queryEmployee = "SELECT EmployeeID, Name, Phone, Email, Address, Position, HireDate FROM Employee";

            // Remove old items in the ListView to avoid duplication
            lvEmployees.Items.Clear();

            // Connection string to the database
            string connectionString = "Server=MSI\\THANHDAT;Database=BookstoreManagementSystem;Integrated Security=True;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryEmployee, conn);
                try
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        // Create a new ListViewItem for each data row
                        ListViewItem item = new ListViewItem(reader["EmployeeID"].ToString());
                        item.SubItems.Add(reader["Name"].ToString());
                        item.SubItems.Add(reader["Phone"].ToString());
                        item.SubItems.Add(reader["Email"].ToString());
                        item.SubItems.Add(reader["Address"].ToString());
                        item.SubItems.Add(reader["Position"].ToString());
                        item.SubItems.Add(Convert.ToDateTime(reader["HireDate"]).ToString("dd/MM/yyyy")); // Date format

                        // Add item to ListView
                        lvEmployees.Items.Add(item);
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    // Display an error message if an issue occurs
                    MessageBox.Show("Error: " + ex.Message, "message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Method to validate the employee input
        private bool  EmployeeInput()
        {
            // Validate EmployeeID: Must be a positive integer
            if (!int.TryParse(txtEmployeeID.Text, out int employeeID) || employeeID <= 0)
            {
                MessageBox.Show("Employee ID must be a positive integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmployeeID.Focus();
                return false;
            }

            // Validate Name: Must not be empty
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return false;
            }

            // Validate Phone: Must be a valid phone number (simple check for digits and length)
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtPhone.Text, @"^\d{10}$"))
            {
                MessageBox.Show("Phone number must be 10 digits.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPhone.Focus();
                return false;
            }

            // Validate Email: Must be a valid email address format
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("Email is not in a valid format.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtEmail.Focus();
                return false;
            }

            // Validate Address: Must not be empty
            if (string.IsNullOrWhiteSpace(txtAddress.Text))
            {
                MessageBox.Show("Address cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAddress.Focus();
                return false;
            }

            // Validate Position: Must not be empty
            if (string.IsNullOrWhiteSpace(txtPosition.Text))
            {
                MessageBox.Show("Position cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPosition.Focus();
                return false;
            }

            // Validate HireDate: Must be a valid date
            if (!DateTime.TryParse(dtpHireDate.Text, out DateTime hireDate))
            {
                MessageBox.Show("Invalid hire date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpHireDate.Focus();
                return false;
            }

            // If all validations pass
            return true;
        }



        private void frmEmployeeManagement_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmManageProductcs mainForm = new frmManageProductcs();
            this.Hide(); mainForm.Show();
        }

        private void lvEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvEmployees.SelectedIndices.Count > 0)
            {
                var selectedItems = lvEmployees.SelectedItems[0];

                txtEmployeeID.Text = selectedItems.SubItems[0].Text;
                txtName.Text = selectedItems.SubItems[1].Text;
                txtPhone.Text = selectedItems.SubItems[2].Text;
                txtEmail.Text = selectedItems.SubItems[3].Text;
                txtAddress.Text = selectedItems.SubItems[4].Text;
                txtPosition.Text = selectedItems.SubItems[5].Text;
                dtpHireDate.Text = selectedItems.SubItems[6].Text;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtEmployeeID.Clear();
            txtName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            txtPosition.Clear();

            txtName.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool Validate = this.EmployeeInput();
            if (!Validate)
                return;
            // Connection string
            string connectionString = "Server=MSI\\THANHDAT;Database=BookstoreManagementSystem;Integrated Security=True;";

            // Database connection string
            string query = "INSERT INTO Employee (EmployeeID, Name, Phone, Email, Address, Position, HireDate) VALUES (@EmployeeID, @Name, @Phone, @Email, @Address, @Position, @HireDate)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);

                // Add parameter
                command.Parameters.AddWithValue("@EmployeeID", txtEmployeeID.Text);
                command.Parameters.AddWithValue("@Name", txtName.Text);
                command.Parameters.AddWithValue("@Phone", txtPhone.Text);
                command.Parameters.AddWithValue("@Email", txtEmail.Text);
                command.Parameters.AddWithValue("@Address", txtAddress.Text);
                command.Parameters.AddWithValue("@Position", txtPosition.Text);
                command.Parameters.AddWithValue("@HireDate", dtpHireDate.Text);

                try
                {
                    conn.Open();
                    command.ExecuteNonQuery();

                    // Add to ListView
                    ListViewItem newItem = new ListViewItem(txtEmployeeID.Text);
                    newItem.SubItems.Add(txtName.Text);
                    newItem.SubItems.Add(txtPhone.Text);
                    newItem.SubItems.Add(txtEmail.Text);
                    newItem.SubItems.Add(txtAddress.Text);
                    newItem.SubItems.Add(txtPosition.Text);
                    newItem.SubItems.Add(dtpHireDate.Text);

                    //lvEmployee.Items.Add(newItem);

                    MessageBox.Show("More success", "Notifications", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex) { MessageBox.Show("Error" + ex.Message); }

                //Delete all the txt
                txtEmployeeID.Clear();
                txtName.Clear();
                txtPhone.Clear();
                txtEmail.Clear();
                txtAddress.Clear();
                txtPosition.Clear();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool Validate = this.EmployeeInput();
            if (!Validate)
                return;
            // Database connection string
            string connectionString = "Server=MSI\\THANHDAT;Database=BookstoreManagementSystem;Integrated Security=True;";

            // SQL statement to update data
            string query = "UPDATE Employee SET Name = @Name, Phone = @Phone, Email = @Email, Address = @Address, Position = @Position, HireDate = @HireDate WHERE EmployeeID = @EmployeeID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);

                // Add parameter
                command.Parameters.AddWithValue("@EmployeeID", txtEmployeeID.Text);
                command.Parameters.AddWithValue("@Name", txtName.Text);
                command.Parameters.AddWithValue("@Phone", txtPhone.Text);
                command.Parameters.AddWithValue("@Email", txtEmail.Text);
                command.Parameters.AddWithValue("@Address", txtAddress.Text);
                command.Parameters.AddWithValue("@Position", txtPosition.Text);
                command.Parameters.AddWithValue("@HireDate", dtpHireDate.Text);

                try
                {
                    conn.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Update the ListView
                        foreach (ListViewItem item in lvEmployees.Items)
                        {
                            if (item.Text == txtEmployeeID.Text) // Compare EmployeeID
                            {
                                item.SubItems[1].Text = txtName.Text;
                                item.SubItems[2].Text = txtPhone.Text;
                                item.SubItems[3].Text = txtEmail.Text;
                                item.SubItems[4].Text = txtAddress.Text;
                                item.SubItems[5].Text = txtPosition.Text;
                                item.SubItems[6].Text = dtpHireDate.Text;
                                break;
                            }
                        }

                        MessageBox.Show("Update successful", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Employee ID not found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

                // Clear all TextBoxes
                txtEmployeeID.Clear();
                txtName.Clear();
                txtPhone.Clear();
                txtEmail.Clear();
                txtAddress.Clear();
                txtPosition.Clear();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bool Validate = this.EmployeeInput();
            if (!Validate)
                return;
            // Database connection string
            string connectionString = "Server=MSI\\THANHDAT;Database=BookstoreManagementSystem;Integrated Security=True;";

            // SQL statement to delete data
            string query = "DELETE FROM Employee WHERE EmployeeID = @EmployeeID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);

                // Add parameter
                command.Parameters.AddWithValue("@EmployeeID", txtEmployeeID.Text);

                try
                {
                    conn.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Delete from ListView
                        foreach (ListViewItem item in lvEmployees.Items)
                        {
                            if (item.Text == txtEmployeeID.Text) // Compare EmployeeID
                            {
                                lvEmployees.Items.Remove(item);
                                break;
                            }
                        }

                        MessageBox.Show("Delete successful", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Employee ID not found", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }

                // Clear all TextBoxes
                txtEmployeeID.Clear();
                txtName.Clear();
                txtPhone.Clear();
                txtEmail.Clear();
                txtAddress.Clear();
                txtPosition.Clear();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Get the search keyword
            string searchKeyword = txtSearch.Text.Trim();

            // Database connection string
            string connectionString = "Server=MSI\\THANHDAT;Database=BookstoreManagementSystem;Integrated Security=True;";

            // SQL statement to search for an employee by name
            string query = "SELECT EmployeeID, Name, Phone, Email, Address, Position, HireDate FROM Employee WHERE Name LIKE @SearchKeyword";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);

                // Add parameter with wildcard character %
                command.Parameters.AddWithValue("@SearchKeyword", "%" + searchKeyword + "%");

                try
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    // Delete old items in ListView
                    lvEmployees.Items.Clear();

                    while (reader.Read())
                    {
                        // Create a new ListViewItem
                        ListViewItem item = new ListViewItem(reader["EmployeeID"].ToString());
                        item.SubItems.Add(reader["Name"].ToString());
                        item.SubItems.Add(reader["Phone"].ToString());
                        item.SubItems.Add(reader["Email"].ToString());
                        item.SubItems.Add(reader["Address"].ToString());
                        item.SubItems.Add(reader["Position"].ToString());
                        item.SubItems.Add(reader["HireDate"].ToString());

                        // Add item to ListView
                        lvEmployees.Items.Add(item);
                    }

                    reader.Close();

                    // Display a message if no results are found
                    if (lvEmployees.Items.Count == 0)
                    {
                        MessageBox.Show("No matching results found!", "Notifications", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error while searching: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            frmManageProductcs mainForm = new frmManageProductcs();
            this.Hide(); mainForm.Show();
        }
    }
}
