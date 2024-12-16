using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace BookstoreManagementSystem
{
    public partial class frmEmployeeAccount : Form
    {
        private string connectionString = "Server=MSI\\THANHDAT;Database=BookstoreManagementSystem;Integrated Security=True;";

        public frmEmployeeAccount()
        {
            InitializeComponent();
        }

        private void frmEmployeeAccount_Load(object sender, EventArgs e)
        {
            LoadAccounts();
        }

        private void LoadAccounts()
        {
            string query = "SELECT AccountID, EmployeeID, UserName, Role FROM EmployeeAccount";
            lvAccount.Items.Clear();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                try
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(Convert.ToString(reader["AccountID"]));
                        item.SubItems.Add(Convert.ToString(reader["EmployeeID"]));
                        item.SubItems.Add(Convert.ToString(reader["UserName"]));
                        item.SubItems.Add("***"); // Masked password display
                        item.SubItems.Add(Convert.ToString(reader["Role"]));

                        lvAccount.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading accounts: " + ex.Message);
                }
            }
        }

        private string EncryptPassword(string password)
        {
            if (string.IsNullOrEmpty(password)) return string.Empty;

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO EmployeeAccount " +
                "(AccountID, EmployeeID, UserName, Password, Role) " +
                "VALUES (@AccountID, @EmployeeID, @UserName, @Password, @Role)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);

                command.Parameters.AddWithValue("@AccountID", txtAccountID.Text);
                command.Parameters.AddWithValue("@EmployeeID", txtEmployeeID.Text);
                command.Parameters.AddWithValue("@UserName", txtUserName.Text);
                command.Parameters.AddWithValue("@Password", EncryptPassword(txtPassword.Text));
                command.Parameters.AddWithValue("@Role", txtRole.Text);

                try
                {
                    conn.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Account added successfully.", 
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAccounts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error adding account: " + ex.Message);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lvAccount.SelectedItems.Count > 0)
            {
                var selectedItem = lvAccount.SelectedItems[0];
                string query = "UPDATE EmployeeAccount SET EmployeeID = @EmployeeID, UserName = @UserName, Password = @Password, Role = @Role WHERE AccountID = @AccountID";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, conn);

                    command.Parameters.AddWithValue("@AccountID", txtAccountID.Text);
                    command.Parameters.AddWithValue("@EmployeeID", txtEmployeeID.Text);
                    command.Parameters.AddWithValue("@UserName", txtUserName.Text);
                    command.Parameters.AddWithValue("@Password", EncryptPassword(txtPassword.Text));
                    command.Parameters.AddWithValue("@Role", txtRole.Text);

                    try
                    {
                        conn.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Account updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAccounts();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error updating account: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an account to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchKeyword = txtSearch.Text.Trim();
            string query = "SELECT AccountID, EmployeeID, UserName, Role FROM EmployeeAccount WHERE UserName LIKE @SearchKeyword";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@SearchKeyword", "%" + searchKeyword + "%");

                try
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    lvAccount.Items.Clear();

                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(Convert.ToString(reader["AccountID"]));
                        item.SubItems.Add(Convert.ToString(reader["EmployeeID"]));
                        item.SubItems.Add(Convert.ToString(reader["UserName"]));
                        item.SubItems.Add("***"); // Masked password display
                        item.SubItems.Add(Convert.ToString(reader["Role"]));

                        lvAccount.Items.Add(item);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error searching accounts: " + ex.Message);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvAccount.SelectedItems.Count > 0)
            {
                var selectedItem = lvAccount.SelectedItems[0];
                string query = "DELETE FROM EmployeeAccount WHERE AccountID = @AccountID";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, conn);
                    command.Parameters.AddWithValue("@AccountID", selectedItem.SubItems[0].Text);

                    try
                    {
                        conn.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Account deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadAccounts();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error deleting account: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an account to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void lvAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvAccount.SelectedItems.Count > 0)
            {
                var selectedItems = lvAccount.SelectedItems[0];

                txtAccountID.Text = selectedItems.SubItems[0].Text;
                txtEmployeeID.Text = selectedItems.SubItems[1].Text;
                txtUserName.Text = selectedItems.SubItems[2].Text;
                txtPassword.Text = selectedItems.SubItems[3].Text;
                txtRole.Text = selectedItems.SubItems[4].Text;
            }
        }
    }
}
