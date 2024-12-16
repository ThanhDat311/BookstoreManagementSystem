using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookstoreManagementSystem
{
    public partial class frmCustomerManagement : Form
    {
        public frmCustomerManagement()
        {
            InitializeComponent();
            ValidateCustomerInput();
        }

        private void frmCustomerManagement_Load(object sender, EventArgs e)
        {
            string queryCustomers = "SELECT CustomerID, Name, Email, Phone, Address FROM Customers";

            lvCustomer.Items.Clear();

            string connectionString = "Server=MSI\\THANHDAT;Database=BookstoreManagementSystem;Integrated Security=True;";

            SqlConnection conn = new SqlConnection(connectionString);
            {
                SqlCommand Command = new SqlCommand(queryCustomers, conn);
                try
                {
                    conn.Open();
                    SqlDataReader reader = Command.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["CustomerID"].ToString());
                        item.SubItems.Add(reader["Name"].ToString());
                        item.SubItems.Add(reader["Email"].ToString());
                        item.SubItems.Add(reader["Phone"].ToString());
                        item.SubItems.Add(reader["Address"].ToString());

                        lvCustomer.Items.Add(item);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.Message);
                }
            }
        }

        // Method to validate the Customer input
        private bool ValidateCustomerInput()
        {
            // Validate Phone: Must be a valid phone number (simple check for digits and length)
            if (System.Text.RegularExpressions.Regex.IsMatch(txtPhone.Text, @"^\d{11}$"))
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
            // If all validations pass
            return true;
        }

        private void frmCustomerManagement_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmManageProductcs mainForm = new frmManageProductcs();
            this.Hide(); mainForm.Show();
        }

        private void lvCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvCustomer.SelectedItems.Count > 0)
            {
                var selectedItems = lvCustomer.SelectedItems[0];

                txtCustomerID.Text = selectedItems.SubItems[0].Text;
                txtName.Text = selectedItems.SubItems[1].Text;
                txtEmail.Text = selectedItems.SubItems[2].Text;
                txtPhone.Text = selectedItems.SubItems[3].Text;
                txtAddress.Text = selectedItems.SubItems[4].Text;
            }    
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtCustomerID.Clear();
            txtName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            txtAddress.Clear();

            txtName.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool validate = this.ValidateCustomerInput();
            if (!validate)
                return;
            // Database connection string
            string connectionString = "Server=MSI\\THANHDAT;Database=BookstoreManagementSystem;Integrated Security=True;";

            // SQL statement to insert data
            string query = "INSERT INTO Customers (CustomerID, Name, Email, Phone, Address) VALUES (@CustomerID, @Name, @Email, @Phone, @Address)";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, conn);

                // Add parameter
                command.Parameters.AddWithValue("@CustomerID", txtCustomerID.Text);
                    command.Parameters.AddWithValue("@Name", txtName.Text);
                    command.Parameters.AddWithValue("@Email", txtEmail.Text);
                    command.Parameters.AddWithValue("@Phone", txtPhone.Text);
                    command.Parameters.AddWithValue("@Address", txtAddress.Text);

                    try
                    {
                        conn.Open();
                        command.ExecuteNonQuery();

                    // Add to ListView
                    ListViewItem newItem = new ListViewItem(txtCustomerID.Text);
                        newItem.SubItems.Add(txtName.Text);
                        newItem.SubItems.Add(txtEmail.Text);
                        newItem.SubItems.Add(txtPhone.Text);
                        newItem.SubItems.Add(txtAddress.Text);

                        lvCustomer.Items.Add(newItem);

                        MessageBox.Show("More success", "Notifications", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Clear all textboxes
                    txtCustomerID.Clear();
                        txtName.Clear();
                        txtEmail.Clear();
                        txtPhone.Clear();
                        txtAddress.Clear();
                    }
                    catch (Exception ex) { MessageBox.Show("Error" + ex.Message); }
                }
              
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool validate = this.ValidateCustomerInput();
            if (!validate)
                return;

            if (lvCustomer.SelectedItems.Count > 0)
            {

                    var selectedItem = lvCustomer.SelectedItems[0];

                    // cap nhat cac gia tri trong ListView
                    selectedItem.SubItems[0].Text = txtCustomerID.Text;
                    selectedItem.SubItems[1].Text = txtName.Text;
                    selectedItem.SubItems[2].Text = txtEmail.Text;
                    selectedItem.SubItems[3].Text = txtPhone.Text;
                    selectedItem.SubItems[4].Text = txtAddress.Text;

                // Update values in ListView
                string connectionString = "Server=MSI\\THANHDAT;Database=BookstoreManagementSystem;Integrated Security=True;";

                    string query = "UPDATE Customers SET Name = @Name, Email = @Email, Phone = @Phone, Address = @Address WHERE CustomerID = @CustomerID";

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(query, conn);

                    // Add parameter
                    command.Parameters.AddWithValue("@CustomerID", txtCustomerID.Text);
                        command.Parameters.AddWithValue("@Name", txtName.Text);
                        command.Parameters.AddWithValue("@Email", txtEmail.Text);
                        command.Parameters.AddWithValue("@Phone", txtPhone.Text);
                        command.Parameters.AddWithValue("@Address", txtAddress.Text);

                        try
                        {
                            conn.Open();
                            command.ExecuteNonQuery();
                            MessageBox.Show("Update successful", "Notifications", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error while updating" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }

            }
                else
                {
                    MessageBox.Show("Please select an item to update!", "Notifications", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvCustomer.SelectedItems.Count > 0)
            {
                // Get the selected item
                var selectedItem = lvCustomer.SelectedItems[0];
                string selectedItemCustomerID = selectedItem.SubItems[0].Text;

                //Database connection string
                string connectionString = "Server=MSI\\THANHDAT;Database=BookstoreManagementSystem;Integrated Security=True;";

                // SQL statement to delete
                string query = "DELETE FROM Customers WHERE CustomerID = @CustomerID";


                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, conn);

                    // Add parameter
                    command.Parameters.AddWithValue("@CustomerID", selectedItemCustomerID);

                    try
                    {
                        conn.Open();
                        command.ExecuteNonQuery();

                        // Remove from ListView
                        lvCustomer.Items.Remove(selectedItem);

                        MessageBox.Show("Delete successful!", "Notifications", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error while deleting: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an item to delete!", "Notifications", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Get search keyword
            string searchKeyword = txtSearch.Text.Trim();

            // Database connection string
            string connectionString = "Server=MSI\\THANHDAT;Database=BookstoreManagementSystem;Integrated Security=True;";

            // SQL query to search by name
            string query = "SELECT CustomerID, Name, Email, Phone, Address FROM Customers WHERE Name LIKE @SearchKeyword";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);

                // Add parameter with wildcard character %
                command.Parameters.Add("@SearchKeyword", SqlDbType.NVarChar, 255).Value = "%" + searchKeyword + "%";

                try
                {
                    conn.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    lvCustomer.Items.Clear();
                    bool foundResults = false;

                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["CustomerID"].ToString());
                        item.SubItems.Add(reader["Name"].ToString());
                        item.SubItems.Add(reader["Email"].ToString());
                        item.SubItems.Add(reader["Phone"].ToString());
                        item.SubItems.Add(reader["Address"].ToString());
                        lvCustomer.Items.Add(item);

                        foundResults = true;
                    }

                    reader.Close();

                    if (!foundResults)
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
