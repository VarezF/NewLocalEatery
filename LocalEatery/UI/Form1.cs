using Revenue;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace UI
{
    public partial class LocalEatery : Form
    {

        List<Amount> UIRevenue = new List<Amount>();


        public LocalEatery()
        {
            InitializeComponent();

            UIRevenue.Add(new Amount(21.00, 2.00, 1.98, 14.00));
            UIRevenue.Add(new Amount(19.99, 1.50, 1.78, 12.00));
            UIRevenue.Add(new Amount(9.99,  2.50, 0.78,  4.00));
            UIRevenue.Add(new Amount(10.21, 3.50, 2.11,  7.00));
            UIRevenue.Add(new Amount(15.99, 1.50, 1.78,  8.00));

            this.chart1.DataSource = this.UIRevenue;
            Series revenueSeries = new Series("DailyRevenue");
            chart1.Series.Add(revenueSeries);
            chart1.ChartAreas[0].AxisX.Title = "Date";
            chart1.ChartAreas[0].AxisY.Title = "Dollars ($)";
            chart1.ChartAreas[0].AxisX.TitleFont = new Font(DefaultFont, FontStyle.Bold);
            chart1.ChartAreas[0].AxisY.TitleFont = new Font(DefaultFont, FontStyle.Bold);

            foreach (Amount amount in UIRevenue)
            {
                revenueSeries.Points.AddXY(amount.dateRange, amount.totalReceived);
            }         
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Table1_Order_Click(object sender, EventArgs e)
        {
            this.orderDialog(1);
        }

        /// <summary>
        /// Prompt for dishes to order through UI for specified table number
        /// Create Order <see cref="MenuLogic.Order"/>
        /// send Order to cook
        /// </summary>
        private void orderDialog(int tableNo)
        {
            //Ignore snippet below, it's just something I found online
            MessageBox.Show("Choose Dish", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }

        private void UpdateRevenueClicked(object sender, EventArgs e)
        {

        }


        private void ViewTablesClicked(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab = this.tabPage1;
        }

        private void ViewKitchenClicked(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab = this.tabPage3;
        }


    }
}
