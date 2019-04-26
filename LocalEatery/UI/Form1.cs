using MenuLogic;
using Revenue;
using System;
using System.Collections.Generic;
using System.Drawing;
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
            MessageBox.Show("Order Submitted", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            foreach (int i in checkedListBox1.CheckedIndices)
            {
                checkedListBox1.SetItemCheckState(i, CheckState.Unchecked);
            }

            this.Table1_Status.Text = "Occupied";
            this.Table1_Status.BackColor = Color.Yellow;
            
            Dictionary<int, Dish> Dishname = new Dictionary<int, Dish>();
            //Ignore snippet below, it's just something I found online

            List<Dish> TheOrder = new List<Dish>();
            Ingredient I1 = new Ingredient("Eggs", 0.0, 0.0);
            Ingredient I2 = new Ingredient("Bacon", 0.0, 0.0);
            Ingredient I3 = new Ingredient("Flour", 0.0, 0.0);


            TimeSpan ts = new TimeSpan(0);
            List<Ingredient> L1 = new List<Ingredient>();
            List<Ingredient> L2 = new List<Ingredient>();
            List<Ingredient> L3 = new List<Ingredient>();
            L1.Add(I1);
            L2.Add(I2);
            L3.Add(I3);

            Dish d1 = new Dish("Waffles", 5.99, ts, null, L1);
            Dish d2 = new Dish("Bacon", 6.00, ts, null, L2);
            Dish d3 = new Dish("Pancakes", 5.99, ts, null, L3);

            Dishname.Add(1, d1);
            Dishname.Add(2, d2);
            Dishname.Add(3, d3);

            string option;
            Console.WriteLine("Choose From the following Menu: \n");
            foreach (KeyValuePair<int, Dish> entry in Dishname)
            {
                string Display = string.Format("Dish: {0} DishObject: {1}", entry.Key, entry.Value);
                Console.WriteLine(Display);
                Console.WriteLine("Information On Dish: ");
                entry.Value.DishSummary(entry.Value);
                Console.WriteLine("------------------------------------------------------------------------");
            }
            Console.WriteLine("Enter Option...");
            option = Console.ReadLine();
            int.TryParse(option, out int choice);

            if (choice == 1)
            {
                Dishname.Add(1, d1);
            }
            else if (choice == 2)
            {
                Dishname.Add(2, d2);
            }
            else if (choice == 3)
            {
                Dishname.Add(3, d3);
            }
            else
            {
                Console.WriteLine("Not a valid choice.\n");
            }
        }

        /// <summary>
        /// Fires when user clicks Update Revenue
        /// </summary>
        /// <param name="sender">Update Revenue button</param>
        /// <param name="e">event arguments</param>
        private void UpdateRevenueClicked(object sender, EventArgs e)
        {
            Series revenueSeries = this.chart1.Series.FindByName("DailyRevenue");

            if (Data.dailyRevenue != null)
            {
                foreach (Amount amount in Data.dailyRevenue)
                {
                    UIRevenue.Add(amount);
                }
            }           

            foreach (Amount amount in this.UIRevenue)
            {
                revenueSeries.Points.AddXY(amount.dateRange, amount.totalReceived);
            }
        }

        /// <summary>
        /// Fires when user clicks view tables
        /// </summary>
        /// <param name="sender">View table button</param>
        /// <param name="e">event arguments</param>
        private void ViewTablesClicked(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab = this.tabPage1;
        }

        /// <summary>
        /// Fires when user clicks view kitchen
        /// </summary>
        /// <param name="sender">View kitchen button</param>
        /// <param name="e">event arguments</param>
        private void ViewKitchenClicked(object sender, EventArgs e)
        {
            this.tabControl1.SelectedTab = this.tabPage3;
        }

        private void Table1_Status_Click(object sender, EventArgs e)
        {

        }
    }
}
