using System;
using System.Drawing;
using System.Windows.Forms;

namespace _522H0083
{
    public partial class CliForm : Form
    {
        public CliForm()
        {
            InitializeComponent();
        }


        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            PlaceOrderForm placeOrderForm = new PlaceOrderForm();
            placeOrderForm.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchForm searchForm = new SearchForm();
            searchForm.Show();
        }

        private void btnExportToCSV_Click(object sender, EventArgs e)
        {
            ExportToCSVForm exportToCSVForm = new ExportToCSVForm();
            exportToCSVForm.Show();
        }
    }
}

