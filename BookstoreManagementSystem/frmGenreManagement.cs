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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BookstoreManagementSystem
{
    public partial class frmGenreManagement : Form
    {
        public frmGenreManagement()
        {
            InitializeComponent();
        }

        private void frmGenreManagement_Load(object sender, EventArgs e)
        {
            // SQL statement to retrieve data
            string query = "SELECT GenreID, GenreName, Description FROM Genre";

            lvGenre.Items.Clear();

            string connectionString = "Server=MSI\\THANHDAT;Database=BookstoreManagementSystem;Integrated Security=True;";

            SqlConnection conn = new SqlConnection(connectionString);
            {
                SqlCommand Command = new SqlCommand(query, conn);
                try
                {
                    conn.Open();
                    SqlDataReader reader = Command.ExecuteReader();
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["GenreID"].ToString());
                        item.SubItems.Add(reader["GenreName"].ToString());
                        item.SubItems.Add(reader["Description"].ToString());

                        lvGenre.Items.Add(item);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error" + ex.Message);
                }
            }
        }

        private bool ValidateGenreInputs()
        {
            if (string.IsNullOrWhiteSpace(txtGenreID.Text))
            {
                MessageBox.Show("Genre ID cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGenreID.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Genre Name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (txtName.Text.Length > 50)
            {
                MessageBox.Show("Genre Name cannot exceed 50 characters.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }

            if (!int.TryParse(txtGenreID.Text, out _))
            {
                MessageBox.Show("Genre ID must be a valid number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGenreID.Focus();
                return false;
            }

            return true;
        }

        private void frmGenreManagement_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmManageProductcs mainForm = new frmManageProductcs();
            this.Hide(); mainForm.Show();
        }

        private void lvGenre_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvGenre.SelectedItems.Count > 0)
            {
                // Get the first item (the selected item)
                ListViewItem selectedItem = lvGenre.SelectedItems[0];

                // Suppose the ListView has 3 columns, and you have 3 corresponding TextBoxes
                txtGenreID.Text = selectedItem.SubItems[0].Text; 
                txtName.Text = selectedItem.SubItems[1].Text; 
                txtDescription.Text = selectedItem.SubItems[2].Text; 
            }
            else
            {
                // If no item is selected, clear the TextBoxes
                txtGenreID.Clear();
                txtName.Clear();
                txtDescription.Clear();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtGenreID.Clear();
            txtName.Clear();
            txtDescription.Clear();

            txtName.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool Validate = this.ValidateGenreInputs();
            if (!Validate)
                return;
            // Database connection string
            string connectionString = "Server=MSI\\THANHDAT;Database=BookstoreManagementSystem;Integrated Security=True;";

            // SQL statement to insert data
            string query = "INSERT INTO Genre (GenreID, GenreName, Description) VALUES (@GenreID, @GenreName, @Description)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);

                // Add parameter
                command.Parameters.AddWithValue("@GenreID", txtGenreID.Text);
                command.Parameters.AddWithValue("@GenreName", txtName.Text);
                command.Parameters.AddWithValue("@Description", txtDescription.Text);

                try
                {
                    conn.Open();
                    command.ExecuteNonQuery();

                    // Add to ListView
                    ListViewItem newItem = new ListViewItem(txtGenreID.Text);
                    newItem.SubItems.Add(txtName.Text);
                    newItem.SubItems.Add(txtDescription.Text);

                    lvGenre.Items.Add(newItem);

                    MessageBox.Show("More success", "Notifications", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Clear all TextBoxes
                    txtGenreID.Clear();
                    txtName.Clear();
                    txtDescription.Clear();
                }
                catch (Exception ex) { MessageBox.Show("Error" + ex.Message); }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool Validate = this.ValidateGenreInputs();
            if (!Validate)
                return;
            if (lvGenre.SelectedItems.Count > 0)
            {
                var selectedItem = lvGenre.SelectedItems[0];
                // Update values in ListView
                selectedItem.SubItems[0].Text = txtGenreID.Text;
                selectedItem.SubItems[1].Text = txtName.Text;
                selectedItem.SubItems[2].Text = txtDescription.Text;

                // Database connection string
                string connectionString = "Server=MSI\\THANHDAT;Database=BookstoreManagementSystem;Integrated Security=True;";

                string query = "UPDATE Genre SET GenreName = @GenreName, Description = @Description WHERE GenreID = @GenreID";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, conn);

                    // Add parameter
                    command.Parameters.AddWithValue("@GenreID", txtGenreID.Text);
                    command.Parameters.AddWithValue("@GenreName", txtName.Text);
                    command.Parameters.AddWithValue("@Description", txtDescription.Text);


                    try
                    {
                        conn.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Update successful", "Notifications", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        txtGenreID.Clear();
                        txtName.Clear();
                        txtDescription.Clear();

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
            bool Validate = this.ValidateGenreInputs();
            if (!Validate)
                return;
            if (lvGenre.SelectedItems.Count > 0)
            {
                // Get the selected item
                var selectedItem = lvGenre.SelectedItems[0];
                string selectedItemGenreID = selectedItem.SubItems[0].Text;

                // Database connection string
                string connectionString = "Server=MSI\\THANHDAT;Database=BookstoreManagementSystem;Integrated Security=True;";

                // SQL statement to delete
                string query = "DELETE FROM Genre WHERE GenreID = @GenreID";


                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, conn);

                    // Add parameter
                    command.Parameters.Add("@GenreID", SqlDbType.Int).Value = int.Parse(selectedItemGenreID);


                    try
                    {
                        conn.Open();
                        command.ExecuteNonQuery();

                        // Remove from ListView
                        lvGenre.Items.Remove(selectedItem);

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

            txtGenreID.Clear();
            txtName.Clear();
            txtDescription.Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            bool Validate = this.ValidateGenreInputs();
            if (!Validate)
                return;
            // Get the search keyword
            string searchKeyword = txtSearch.Text.Trim();

            // Database connection string
            string connectionString = "Server=MSI\\THANHDAT;Database=BookstoreManagementSystem;Integrated Security=True;";

            // SQL statement to search by name 'GenreName'
            string query = "SELECT GenreID, GenreName, Description FROM Genre WHERE GenreName LIKE @SearchKeyword";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);

                // Add parameter with wildcard character %
                command.Parameters.AddWithValue("@SearchKeyword", "%" + searchKeyword + "%");

                try
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    // Remove old items from ListView
                    lvGenre.Items.Clear();

                    while (reader.Read())
                    {
                        // Create a new ListViewItem
                        ListViewItem item = new ListViewItem(reader["GenreID"].ToString());
                        item.SubItems.Add(reader["GenreName"].ToString());
                        item.SubItems.Add(reader["Description"].ToString());


                        // Add item to ListView
                        lvGenre.Items.Add(item);
                    }

                    reader.Close();

                    // Show a message if no results are found
                    if (lvGenre.Items.Count == 0)
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
