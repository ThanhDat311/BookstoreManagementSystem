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
    public partial class frmBookManagement : Form
    {
        public frmBookManagement()
        {
            InitializeComponent();
        }

        private void frmBookManagement_Load(object sender, EventArgs e)
        {
            // SQL command to retrieve data
            string queryBooks = "SELECT BookID, BookName, Author, GenreID, Price, Stock FROM Books";

            // Clear previous items in ListView
            lvBook.Items.Clear();

            // Connection string to the database
            string connectionString = "Server=MSI\\THANHDAT;Database=BookstoreManagementSystem;Integrated Security=True;";

            SqlConnection conn = new SqlConnection(connectionString);
            {
                SqlCommand command = new SqlCommand(queryBooks, conn);
                try
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["BookID"].ToString());
                        item.SubItems.Add(reader["BookName"].ToString());
                        item.SubItems.Add(reader["Author"].ToString());
                        item.SubItems.Add(reader["GenreID"].ToString());
                        item.SubItems.Add(reader["Price"].ToString());
                        item.SubItems.Add(reader["Stock"].ToString());

                        // Add item to ListView
                        lvBook.Items.Add(item);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        // Validate input fields before adding new book
        private bool ValidateInput()
        {
            // Validate BookID: Must be a positive integer
            if (!int.TryParse(txtBookID.Text, out int bookID) || bookID <= 0)
            {
                MessageBox.Show("BookID must be a positive integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBookID.Focus();
                return false;
            }

            // Validate Price: Must be a positive decimal number
            if (!decimal.TryParse(txtPrice.Text, out decimal price) || price <= 0)
            {
                MessageBox.Show("Price must be a positive number.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPrice.Focus();
                return false;
            }

            // Validate Stock: Must be a non-negative integer
            if (!int.TryParse(txtStock.Text, out int stock) || stock < 0)
            {
                MessageBox.Show("Stock must be a non-negative integer.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStock.Focus();
                return false;
            }

            // If all validations pass
            return true;
        }

        private void frmBookManagement_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmManageProductcs mainForm = new frmManageProductcs();
            this.Hide(); mainForm.Show();
        }

        private void lvBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvBook.SelectedItems.Count > 0)
            {
                var selectedItems = lvBook.SelectedItems[0];

                txtBookID.Text = selectedItems.SubItems[0].Text;
                txtBookName.Text = selectedItems.SubItems[1].Text;
                txtAuthor.Text = selectedItems.SubItems[2].Text;
                txtGenreID.Text = selectedItems.SubItems[3].Text;
                txtPrice.Text = selectedItems.SubItems[4].Text;
                txtStock.Text = selectedItems.SubItems[5].Text;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtBookID.Clear();
            txtBookName.Clear();
            txtAuthor.Clear();
            txtGenreID.Clear();
            txtPrice.Clear();
            txtStock.Clear();

            txtBookName.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bool validate = this.ValidateInput();
            if (!validate)
                return;
            // Connection string
            string connectionString = "Server=MSI\\THANHDAT;Database=BookstoreManagementSystem;Integrated Security=True;";

            // SQL query to add data
            string query = "INSERT INTO Books (BookID, BookName, Author, GenreID, Price, Stock) VALUES (@BookID, @BookName, @Author, @GenreID, @Price, @Stock)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, conn);

              

                // Add parameters
                command.Parameters.AddWithValue("@BookID", txtBookID.Text);
                command.Parameters.AddWithValue("@BookName", txtBookName.Text);
                command.Parameters.AddWithValue("@Author", txtAuthor.Text);
                command.Parameters.AddWithValue("@GenreID", txtGenreID.Text);
                command.Parameters.AddWithValue("@Price", txtPrice.Text);
                command.Parameters.AddWithValue("@Stock", txtStock.Text);

                try
                {
                    conn.Open();
                    command.ExecuteNonQuery();

                    // Add to ListView
                    ListViewItem newItem = new ListViewItem(txtBookID.Text);
                    newItem.SubItems.Add(txtBookName.Text);
                    newItem.SubItems.Add(txtAuthor.Text);
                    newItem.SubItems.Add(txtGenreID.Text);
                    newItem.SubItems.Add(txtPrice.Text);
                    newItem.SubItems.Add(txtStock.Text);

                    lvBook.Items.Add(newItem);

                    MessageBox.Show("Added successfully", "Notifications", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear all text boxes
                    txtBookID.Clear();
                    txtBookName.Clear();
                    txtAuthor.Clear();
                    txtGenreID.Clear();
                    txtPrice.Clear();
                    txtStock.Clear();
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            bool validate = this.ValidateInput();
            if (!validate)
                return;
            // Validate the input fields
            if (ValidateInput())
            {
                return; // If validation fails, exit the method
            }

            if (lvBook.SelectedItems.Count > 0)
            {
                var selectedItem = lvBook.SelectedItems[0];

                // Update values in ListView
                selectedItem.SubItems[0].Text = txtBookID.Text;
                selectedItem.SubItems[1].Text = txtBookName.Text;
                selectedItem.SubItems[2].Text = txtAuthor.Text;
                selectedItem.SubItems[3].Text = txtGenreID.Text;
                selectedItem.SubItems[4].Text = txtPrice.Text;
                selectedItem.SubItems[5].Text = txtStock.Text;

                // Update database
                string connectionString = "Server=MSI\\THANHDAT;Database=BookstoreManagementSystem;Integrated Security=True;";

                // SQL query to update data
                string query = "UPDATE Books SET BookName = @BookName, Author = @Author, GenreID = @GenreID, Price = @Price, Stock = @Stock WHERE BookID = @BookID";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, conn);

                    // Add parameters
                    command.Parameters.AddWithValue("@BookID", txtBookID.Text);
                    command.Parameters.AddWithValue("@BookName", txtBookName.Text);
                    command.Parameters.AddWithValue("@Author", txtAuthor.Text);
                    command.Parameters.AddWithValue("@GenreID", txtGenreID.Text);
                    command.Parameters.AddWithValue("@Price", txtPrice.Text);
                    command.Parameters.AddWithValue("@Stock", txtStock.Text);

                    try
                    {
                        conn.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Update successful", "Notifications", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error while updating: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            bool validate = this.ValidateInput();
            if (!validate)
                return;
            if (lvBook.SelectedItems.Count > 0)
            {
                // Get selected item
                var selectedItem = lvBook.SelectedItems[0];
                string selectedItemBookID = selectedItem.SubItems[0].Text;

                // Connection string
                string connectionString = "Server=MSI\\THANHDAT;Database=BookstoreManagementSystem;Integrated Security=True;";

                // SQL query to delete data
                string query = "DELETE FROM Books WHERE BookID = @BookID";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, conn);

                    // Add parameters
                    command.Parameters.AddWithValue("@BookID", selectedItemBookID);

                    try
                    {
                        conn.Open();
                        command.ExecuteNonQuery();

                        // Remove from ListView
                        lvBook.Items.Remove(selectedItem);

                        MessageBox.Show("Deleted successfully!", "Notifications", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

       



        private void btnClose_Click(object sender, EventArgs e)
        {
            frmManageProductcs mainForm = new frmManageProductcs();
            this.Hide();
            mainForm.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Get search keyword
            string searchKeyword = txtSearch.Text.Trim();

            // Database connection string
            string connectionString = "Server=MSI\\THANHDAT;Database=BookstoreManagementSystem;Integrated Security=True;";

            // SQL query to search for books by name
            string query = "SELECT BookID, BookName, Author, GenreID, Price, Stock FROM Books WHERE BookName LIKE @SearchKeyword";

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
                    lvBook.Items.Clear();

                    while (reader.Read())
                    {
                        // Tạo một ListViewItem mới
                        ListViewItem item = new ListViewItem(reader["BookID"].ToString());
                        item.SubItems.Add(reader["BookName"].ToString());
                        item.SubItems.Add(reader["Author"].ToString());
                        item.SubItems.Add(reader["GenreID"].ToString());
                        item.SubItems.Add(reader["Price"].ToString());
                        item.SubItems.Add(reader["Stock"].ToString());

                        // Add item to ListView
                        lvBook.Items.Add(item);
                    }

                    reader.Close();

                    // Display a message if no results are found
                    if (lvBook.Items.Count == 0)
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
    }
}
