using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace BookstoreManagementSystem
{
    public partial class frmCreateAnInvoice : Form
    {
            private Dictionary<string, (string BookName, int Quantity, decimal Price)> selectedBooks =
                new Dictionary<string, (string BookName, int Quantity, decimal Price)>();
        
        public frmCreateAnInvoice()
        {
            InitializeComponent();
            LoadCustomerData();
            LoadBookData();
            loadOrdersData();
        }

        private string connectionString = "Server=MSI\\THANHDAT;Database=BookstoreManagementSystem;Trusted_Connection=True;";

        private void lvOrder_SelectedIndexChanged(object sender, EventArgs e)
        {

            string query = "Select OrderID, CustomerID, EmployeeID, OrderDate," +
                " Status, TotalAmount From Orders";

            SqlConnection conn = new SqlConnection(connectionString);
            {
                SqlCommand command = new SqlCommand(query, conn);
                try
                {
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["OrderID"].ToString());
                        item.SubItems.Add(reader["CustomerID"].ToString());
                        item.SubItems.Add(reader["OrderDate"].ToString());
                        item.SubItems.Add(reader["TotalAmount"].ToString());

                        // Add item to ListView
                        lvCustomer.Items.Add(item);
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }
        private void LoadCustomerData()
        {
            

            // SQL query to fetch order data
            string query = "SELECT * FROM [Customers]";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Create and execute the SQL command
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    // Clear any existing items in the ListView
                    lvCustomer.Items.Clear();

                    // Read data and populate ListView
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["CustomerID"].ToString()); // First column
                        item.SubItems.Add(reader["Name"].ToString());                // Second column
                        lvCustomer.Items.Add(item);
                    }

                    reader.Close(); // Close the reader
                }
            }
            catch (Exception ex)
            {
                // Show error message if any exception occurs
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }
        private void LoadBookData()
        {
            // Connection string to your database

            // SQL query to fetch order data
            string query = "SELECT * FROM [Books]";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Create and execute the SQL command
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    // Clear any existing items in the ListView
                    lvBook.Items.Clear();

                    // Read data and populate ListView
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["BookID"].ToString()); // First column
                        item.SubItems.Add(reader["BookName"].ToString());                // Second column
                        item.SubItems.Add(reader["Author"].ToString()); // Third column
                        item.SubItems.Add(reader["GenreID"].ToString());              // Fourth column
                        item.SubItems.Add(reader["Price"].ToString());              // Fourth column
                        item.SubItems.Add(reader["Stock"].ToString());
                        string bookId = reader["BookID"].ToString();
                        int amount = 0;
                        if (selectedBooks.ContainsKey(bookId))
                          amount = selectedBooks[bookId].Quantity;
                        item.SubItems.Add(amount.ToString());              // Fourth column
                        lvBook.Items.Add(item);
                    }

                    reader.Close(); // Close the reader
                }
            }
            catch (Exception ex)
            {
                // Show error message if any exception occurs
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void lvBook_SelectedIndexChanged(object sender, EventArgs e)
        {
                if (lvBook.SelectedItems.Count > 0)
                {
                    // Get the selected item
                    var selectedItem = lvBook.SelectedItems[0];

                    // Retrieve the BookID, BookName, and Quantity from the selected item
                    string bookID = selectedItem.SubItems[0].Text; // Assuming the first column is BookID
                    string bookName = selectedItem.SubItems[1].Text; // Assuming the second column is BookName
                    int quantity = int.Parse(selectedItem.SubItems[6].Text); // Assuming the third column is Quantity
                    selectedBookId.Text= bookID;
                    selectedBookName.Text= bookName;
                    txtQuantity.Text= quantity.ToString();
                    selectedBookPrice.Text= selectedItem.SubItems[4].Text;
                    // Add or update the dictionary
                    if (selectedBooks.ContainsKey(bookID))
                    {
                        // Update the existing entry
                        selectedBooks[bookID] = (bookName, quantity,decimal.Parse(selectedBookPrice.Text));
                    }
                    else
                    {
                        // Add a new entry
                        selectedBooks.Add(bookID, (bookName, quantity, decimal.Parse(selectedBookPrice.Text)));
                    }

                    // Optional: Display a message or perform additional actions
                }
        }

        private void updateAmount_Click(object sender, EventArgs e)
        {
            string bookID = selectedBookId.Text;
            string bookName = selectedBookName.Text;
            int quantity = Int32.Parse(txtQuantity.Text);
            selectedBooks[bookID] = (bookName, quantity, decimal.Parse(selectedBookPrice.Text));
            LoadBookData();
            orderTotal.Text = selectedBooks.Sum(b => b.Value.Quantity * b.Value.Price).ToString();

            loadOrdersData();
        }

        private void btnInvoice_Click(object sender, EventArgs e)
        {
            // Define your database connection string

            // Retrieve the OrderID from the input field
            string providedOrderID = txtOrderID.Text;

            // Validate that the OrderID is not empty
            if (string.IsNullOrWhiteSpace(providedOrderID))
            {
                MessageBox.Show("Please enter a valid Order ID.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Start a transaction for consistency
                    SqlTransaction transaction = connection.BeginTransaction();

                    // 1. Create a new Order
                    string createOrderQuery = "INSERT INTO [Orders] (OrderID, CustomerID, OrderDate, TotalAmount) VALUES (@OrderID, @CustomerID, @OrderDate, @TotalAmount)";
                    using (SqlCommand createOrderCommand = new SqlCommand(createOrderQuery, connection, transaction))
                    {
                        createOrderCommand.Parameters.AddWithValue("@OrderID", providedOrderID); // Use the provided OrderID
                        createOrderCommand.Parameters.AddWithValue("@CustomerID", cusID.Text);   // Replace with actual CustomerID
                        createOrderCommand.Parameters.AddWithValue("@OrderDate", DateTime.Now);

                        // Calculate total amount from selectedBooks
                        decimal totalAmount = selectedBooks.Sum(b => b.Value.Quantity * b.Value.Price);
                        createOrderCommand.Parameters.AddWithValue("@TotalAmount", totalAmount);

                        // Execute the command
                        createOrderCommand.ExecuteNonQuery();
                    }

                    // 2. Add OrderDetails
                    string createOrderDetailQuery = "INSERT INTO OrderDetails ( OrderID, BookID, Quantity, Price) VALUES ( @OrderID, @BookID, @Quantity, @Price)";
                    foreach (var item in selectedBooks)
                    {
                        if(item.Value.Quantity>0)
                        {
                            string bookID = item.Key;
                            string bookName = item.Value.BookName;
                            int quantity = item.Value.Quantity;
                            decimal price = item.Value.Price; // Use price from the dictionary

                            using (SqlCommand createOrderDetailCommand = new SqlCommand(createOrderDetailQuery, connection, transaction))
                            {
                                createOrderDetailCommand.Parameters.AddWithValue("@OrderID", providedOrderID); // Use the provided OrderID
                                createOrderDetailCommand.Parameters.AddWithValue("@BookID", bookID);
                                createOrderDetailCommand.Parameters.AddWithValue("@Quantity", quantity);
                                createOrderDetailCommand.Parameters.AddWithValue("@Price", price);

                                createOrderDetailCommand.ExecuteNonQuery();
                            }
                        }
                        
                    }

                    // Commit the transaction
                    transaction.Commit();

                    MessageBox.Show($"Order created successfully! Order ID: {providedOrderID}");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error creating order: {ex.Message}");
                }

                loadOrdersData();
            }
        }


        private void lvOrder_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (lvCustomer.SelectedItems.Count > 0)
            {
                var selectedItem = lvCustomer.SelectedItems[0];
                cusID.Text = selectedItem.SubItems[0].Text;
                txtCustomerName.Text = selectedItem.SubItems[1].Text;
            }
        }
        private void loadOrdersData()
        {
            // SQL query to fetch order data
            string query = "SELECT * FROM [Orders]";
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(query, connection);
                        SqlDataReader reader = command.ExecuteReader();

                        // Clear the ListView
                        lvOrders.Items.Clear();

                        while (reader.Read())
                        {
                            // Create ListViewItem
                            ListViewItem item = new ListViewItem(reader["OrderID"].ToString()); // First column
                            item.SubItems.Add(reader["CustomerID"].ToString()); // Second column

                            // Handle null values for OrderDate and TotalAmount
                            item.SubItems.Add(reader["OrderDate"] != DBNull.Value
                                ? Convert.ToDateTime(reader["OrderDate"]).ToString("yyyy-MM-dd")
                                : "N/A");
                            item.SubItems.Add(reader["TotalAmount"] != DBNull.Value
                                ? Convert.ToDecimal(reader["TotalAmount"]).ToString("C2")
                                : "0.00");

                            lvOrders.Items.Add(item); // Add to lvOrders
                        }

                        reader.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message + "\n" + ex.StackTrace);
                }
        }
        private void lvOrders_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lvOrders.SelectedItems.Count > 0)
            {
                // Lấy OrderID từ mục được chọn
                string selectedOrderID = lvOrders.SelectedItems[0].Text; // OrderID ở cột đầu tiên

                // Truy vấn chi tiết đơn hàng
                LoadOrderDetails(selectedOrderID);
            }
                   
        }
        private void LoadOrderDetails(string orderID)
        {
            // SQL query to retrieve order details data
            string query = "SELECT OrderDetailID, BookID, Quantity, Price FROM [OrderDetails] WHERE OrderID = @OrderID";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);

                    // Add the parameter @OrderID to prevent SQL Injection
                    command.Parameters.AddWithValue("@OrderID", orderID);

                    SqlDataReader reader = command.ExecuteReader();

                    // Delete old data in lvOrderDetails
                    lvOrderDetail.Items.Clear();

                    // Read data and add it to lvOrderDetails
                    while (reader.Read())
                    {
                        ListViewItem item = new ListViewItem(reader["OrderDetailID"].ToString()); // First column
                       /* item.SubItems.Add(reader["OrderID"].ToString());*/ // Second column
                        item.SubItems.Add(reader["BookID"].ToString());
                        item.SubItems.Add(reader["Quantity"].ToString()); // Third column
                        item.SubItems.Add(Convert.ToDecimal(reader["Price"]).ToString("C2")); // Currency format

                        lvOrderDetail.Items.Add(item);
                    }

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading order details: " + ex.Message);
            }
        }



        private void frmCreateAnInvoice_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmManageProductcs mainForm = new frmManageProductcs();
            this.Hide(); mainForm.Show();
        }

    }
}






