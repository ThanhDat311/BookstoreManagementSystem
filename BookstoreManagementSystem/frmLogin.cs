using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BookstoreManagementSystem
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
            // Connection string to connect to the BookStore database
            private string connectionString = "Server=MSI\\THANHDAT;Database=BookstoreManagementSystem;Integrated Security=True;";

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text.Trim();
            string password = txtPassword.Text.Trim();

            if (ValidateLogin(username, password, out string role))
            {
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Proceed to the main application window or next screen
                frmManageProductcs mainForm = new frmManageProductcs();
                // Configure buttons based on the user's role
                if (role != "Admin")
                {
                    mainForm.btnAccountManagement.Visible = false;
                    mainForm.btnEmployeesManagement.Visible = false;
                    mainForm.btnStatistical.Visible = false;
                }

                mainForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool ValidateLogin(string username, string password, out string role)
        {
            role = string.Empty;

            // Check if fields are empty
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // SQL query to retrieve the user's role
            string query = "SELECT Role FROM EmployeeAccount WHERE Username = @Username AND Password = @Password";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        // Use parameters to prevent SQL injection
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Password", password);

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            role = result.ToString();
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to the database: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
          this.Close();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
         txtPassword.PasswordChar = chkShowPassword.Checked ? '\0' : '*';
        }
        
    }
}