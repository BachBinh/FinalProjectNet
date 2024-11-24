using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace _522H0083
{
    public partial class ChartForm : Form
    {
        private string connectionString = "Data Source=DESKTOP-ME21P7E\\MAY2;Initial Catalog=PiStoreOfCloud;Integrated Security=True"; // Update connection string if needed

        public ChartForm()
        {
            InitializeComponent();
            ChartArea chartArea = new ChartArea();
            buttonLoadChart.Enabled = false;
            dtpFromDate.Enabled = false;
            dtpToDate.Enabled = false;
        }

        public void comboBoxChartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtpFromDate.Value = DateTime.Today;
            dtpToDate.Value = DateTime.Today; 
            buttonLoadChart.Enabled = true;
            dtpFromDate.Enabled = true;
            dtpToDate.Enabled = true;
        }

        private bool ValidateDateRange()
        {
            if (dtpFromDate.Value > DateTime.Now || dtpToDate.Value > DateTime.Now)
            {
                MessageBox.Show("Date cannot be in the future.", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dtpFromDate.Value > dtpToDate.Value)
            {
                MessageBox.Show("From date cannot be later than To date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }


        private void ButtonLoadChart_Click(object sender, EventArgs e)
        {
            if (!ValidateDateRange())
            {
                return;
            }
            if (chart == null)
            {
                MessageBox.Show("Chart has not been initialized.");
                return;
            }
            // Clear existing series and title
            chart.Series.Clear();
            chart.Titles.Clear(); // Clear old titles

            // Get chart type from combo box
            if (comboBoxChartType.SelectedItem != null)
            {
                string selectedChartType = comboBoxChartType.SelectedItem.ToString();

                if (selectedChartType == "Number of products sold")
                {
                    LoadProductSalesChart();
                }
                else if (selectedChartType == "Number of employee orders")
                {
                    LoadEmployeeOrdersChart();
                }
                else if (selectedChartType == "Total spend per customer")
                {
                    LoadClientSpendingChart();
                }
            }
            else
            {
                MessageBox.Show("Please select a chart type."); // Notify if no selection is made
            }
        }

        private void LoadProductSalesChart()
        {
            var series = new Series("Product Sales")
            {
                ChartType = SeriesChartType.Bar
            };

            int maxTotalSold = 0; // Variable to store the maximum sales quantity
            DateTime fromDate = dtpFromDate.Value;
            DateTime toDate = dtpToDate.Value;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT p.ID, p.Name, SUM(oi.Quantity) AS TotalSold " +
                               "FROM Product p " +
                               "JOIN OrderItem oi ON p.ID = oi.ProductID " +
                               "JOIN [Order] o ON oi.OrderID = o.ID " +
                               "WHERE o.OrderDate BETWEEN @FromDate AND @ToDate " + // Filter by OrderDate
                               "GROUP BY p.ID, p.Name";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FromDate", fromDate);
                    command.Parameters.AddWithValue("@ToDate", toDate);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int totalSold = Convert.ToInt32(reader["TotalSold"]);
                            series.Points.AddXY(reader["Name"].ToString(), totalSold);
                            if (totalSold > maxTotalSold)
                                maxTotalSold = totalSold; // Update maximum quantity
                        }
                    }
                }
            }

            chart.Series.Add(series);
            chart.Titles.Add("Number of products sold");

            // Set value range for Y-axis
            chart.ChartAreas[0].AxisY.Maximum = maxTotalSold + (maxTotalSold / 10); // Add 10% to give space on Y-axis
            chart.ChartAreas[0].AxisY.Title = "Sales Quantity";
        }

        private void LoadEmployeeOrdersChart()
        {
            var series = new Series("Employee Orders")
            {
                ChartType = SeriesChartType.Bar
            };

            int maxTotalOrders = 0; // Variable to store the maximum order count
            DateTime fromDate = dtpFromDate.Value;
            DateTime toDate = dtpToDate.Value;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT e.ID, e.Name, COUNT(o.ID) AS TotalOrders " +
                               "FROM Employee e " +
                               "LEFT JOIN [Order] o ON e.ID = o.EmployeeID " +
                               "WHERE o.OrderDate BETWEEN @FromDate AND @ToDate " + // Filter by OrderDate
                               "GROUP BY e.ID, e.Name";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FromDate", fromDate);
                    command.Parameters.AddWithValue("@ToDate", toDate);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int totalOrders = Convert.ToInt32(reader["TotalOrders"]);
                            series.Points.AddXY(reader["Name"].ToString(), totalOrders);
                            if (totalOrders > maxTotalOrders)
                                maxTotalOrders = totalOrders; // Update maximum count
                        }
                    }
                }
            }

            chart.Series.Add(series);
            chart.Titles.Add("Number of employee orders");

            // Set value range for Y-axis
            chart.ChartAreas[0].AxisY.Maximum = maxTotalOrders + (maxTotalOrders / 10); // Add 10% to give space on Y-axis
            chart.ChartAreas[0].AxisY.Title = "Order Count";
        }

        private void LoadClientSpendingChart()
        {
            var series = new Series("Client Spending")
            {
                ChartType = SeriesChartType.Bar
            };

            decimal maxTotalSpent = 0; // Variable to store maximum spending amount
            DateTime fromDate = dtpFromDate.Value;
            DateTime toDate = dtpToDate.Value;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT c.ID, c.Name, SUM(b.TotalPrice) AS TotalSpent " +
                               "FROM Client c " +
                               "JOIN Bill b ON c.ID = b.ClientID " +
                               "WHERE b.BillDate BETWEEN @FromDate AND @ToDate " + // Filter by BillDate
                               "GROUP BY c.ID, c.Name";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FromDate", fromDate);
                    command.Parameters.AddWithValue("@ToDate", toDate);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            decimal totalSpent = Convert.ToDecimal(reader["TotalSpent"]);
                            series.Points.AddXY(reader["Name"].ToString(), totalSpent);
                            if (totalSpent > maxTotalSpent)
                                maxTotalSpent = totalSpent; // Update maximum amount
                        }
                    }
                }
            }

            chart.Series.Add(series);
            chart.Titles.Add("Total spend per customer");

            // Set value range for Y-axis
            chart.ChartAreas[0].AxisY.Maximum = Convert.ToDouble(Math.Ceiling(maxTotalSpent / 1000000) * 1000000); // Round up to the nearest million
            chart.ChartAreas[0].AxisY.Title = "Total Spending (VND)";
        }
    }
}