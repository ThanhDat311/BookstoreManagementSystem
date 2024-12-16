using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;

namespace BookstoreManagementSystem
{
    public partial class frmStatistical : Form
    {
        private string connectionString = "Server=MSI\\THANHDAT;Database=BookstoreManagementSystem;Trusted_Connection=True;";
        public frmStatistical()
        {
            InitializeComponent();
            try
            {
                LoadChartData();
                LoadLabelData();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            RoundCorners(pnTotalRevenue, 20);
            RoundCorners(plTotalOrder, 20);
            RoundCorners(pnTotalProduct, 20);
            RoundCorners(pnTotalCustomer, 20);
        }

        public static void RoundCorners(Panel panel, int cornerRadius)
        {
            if (cornerRadius < 1) return;

            GraphicsPath path = new GraphicsPath();
            Rectangle bounds = new Rectangle(0, 0, panel.Width, panel.Height);

            path.AddArc(bounds.X, bounds.Y, cornerRadius * 2, cornerRadius * 2, 180, 90);
            path.AddArc(bounds.Right - cornerRadius * 2, bounds.Y, cornerRadius * 2, cornerRadius * 2, 270, 90);
            path.AddArc(bounds.Right - cornerRadius * 2, bounds.Bottom - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
            path.CloseAllFigures();

            panel.Region = new Region(path);
        }

        private void LoadChartData()
        {
            string query = @"
                SELECT 
                    o.OrderDate, 
                    SUM(od.Quantity * od.Price) AS TotalRevenue, 
                    COUNT(DISTINCT o.OrderID) AS TotalOrders, 
                    COUNT(DISTINCT c.CustomerID) AS TotalCustomers, 
                    COUNT(DISTINCT b.BookID) AS TotalProducts
                FROM Orders o
                JOIN OrderDetails od ON o.OrderID = od.OrderID
                JOIN Books b ON od.BookID = b.BookID
                JOIN Customers c ON o.CustomerID = c.CustomerID
                GROUP BY o.OrderDate
                ORDER BY o.OrderDate;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                chart1.Series["Total Revenue"].Points.Clear();
                chart1.Series["Total Orders"].Points.Clear();
                chart1.Series["Total Customers"].Points.Clear();
                chart1.Series["Total Products"].Points.Clear();

                foreach (DataRow row in dataTable.Rows)
                {
                    DateTime orderDate = (DateTime)row["OrderDate"];
                    decimal totalRevenue = Convert.ToDecimal(row["TotalRevenue"]);
                    int totalOrders = Convert.ToInt32(row["TotalOrders"]);
                    int totalCustomers = Convert.ToInt32(row["TotalCustomers"]);
                    int totalProducts = Convert.ToInt32(row["TotalProducts"]);

                    chart1.Series["Total Revenue"].Points.AddXY(orderDate, totalRevenue);
                    chart1.Series["Total Orders"].Points.AddXY(orderDate, totalOrders);
                    chart1.Series["Total Customers"].Points.AddXY(orderDate, totalCustomers);
                    chart1.Series["Total Products"].Points.AddXY(orderDate, totalProducts);
                }

                chart1.Series["Total Orders"].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
                chart1.Series["Total Customers"].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;
                chart1.Series["Total Products"].YAxisType = System.Windows.Forms.DataVisualization.Charting.AxisType.Secondary;

                chart1.ChartAreas[0].AxisY2.Enabled = System.Windows.Forms.DataVisualization.Charting.AxisEnabled.True;
            }
        }

        private void LoadLabelData()
        {
            string query = @"
                SELECT 
                    YEAR(o.OrderDate) AS Year, 
                    MONTH(o.OrderDate) AS Month, 
                    SUM(od.Quantity * od.Price) AS TotalRevenue, 
                    COUNT(DISTINCT o.OrderID) AS TotalOrders, 
                    COUNT(DISTINCT c.CustomerID) AS TotalCustomers, 
                    COUNT(DISTINCT b.BookID) AS TotalProducts
                FROM Orders o
                JOIN OrderDetails od ON o.OrderID = od.OrderID
                JOIN Books b ON od.BookID = b.BookID
                JOIN Customers c ON o.CustomerID = c.CustomerID
                GROUP BY YEAR(o.OrderDate), MONTH(o.OrderDate)
                ORDER BY Year DESC, Month DESC;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    DataRow currentMonthRow = dataTable.Rows[0];
                    decimal currentRevenue = Convert.ToDecimal(currentMonthRow["TotalRevenue"]);
                    int currentOrders = Convert.ToInt32(currentMonthRow["TotalOrders"]);
                    int currentCustomers = Convert.ToInt32(currentMonthRow["TotalCustomers"]);
                    int currentProducts = Convert.ToInt32(currentMonthRow["TotalProducts"]);

                    lblRevenueMoney.Text = currentRevenue.ToString("C", new CultureInfo("en-US"));
                    lblTtOrderNum.Text = currentOrders.ToString();
                    lblTtProductNum.Text = currentProducts.ToString();
                    lblTtCustomerNum.Text = currentCustomers.ToString();

                    lblRevenueMoney.ForeColor = Color.LimeGreen;
                    lblTtOrderNum.ForeColor = Color.LimeGreen;
                    lblTtProductNum.ForeColor = Color.LimeGreen;
                    lblTtCustomerNum.ForeColor = Color.LimeGreen;

                    if (dataTable.Rows.Count > 1)
                    {
                        DataRow previousMonthRow = dataTable.Rows[1];
                        decimal previousRevenue = Convert.ToDecimal(previousMonthRow["TotalRevenue"]);
                        int previousOrders = Convert.ToInt32(previousMonthRow["TotalOrders"]);
                        int previousCustomers = Convert.ToInt32(previousMonthRow["TotalCustomers"]);
                        int previousProducts = Convert.ToInt32(previousMonthRow["TotalProducts"]);

                        lblRevenueMoney.ForeColor = currentRevenue > previousRevenue ? Color.LimeGreen : Color.Red;
                        lblTtOrderNum.ForeColor = currentOrders > previousOrders ? Color.LimeGreen : Color.Red;
                        lblTtProductNum.ForeColor = currentProducts > previousProducts ? Color.LimeGreen : Color.Red;
                        lblTtCustomerNum.ForeColor = currentCustomers > previousCustomers ? Color.LimeGreen : Color.Red;
                    }
                }
                else
                {
                    lblRevenueMoney.Text = "$0.00";
                    lblTtOrderNum.Text = "0";
                    lblTtProductNum.Text = "0";
                    lblTtCustomerNum.Text = "0";

                    lblRevenueMoney.ForeColor = Color.Gray;
                    lblTtOrderNum.ForeColor = Color.Gray;
                    lblTtProductNum.ForeColor = Color.Gray;
                    lblTtCustomerNum.ForeColor = Color.Gray;
                }
            }
        }

        private void frmStatistical_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmManageProductcs mainForm = new frmManageProductcs();
            this.Hide();
            mainForm.ShowDialog();
        }
    }
}
