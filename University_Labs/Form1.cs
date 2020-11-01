using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace University_Labs
{
    public partial class Form1 : Form
    {
        private Lab_5 l5;

        public Form1()
        {
            InitializeComponent();
            start();
            l5 = new Lab_5();
        }

        private void start()
        {
            //Lab_1 l1 = new Lab_1();
            //l1.calculateMain(this.chart1);
            this.chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            this.chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = true;
        }

        private void chart1_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }

            l5.Start_p1(this.chart1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            l5.Start_p2(this.chart1);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (var series in chart1.Series)
            {
                series.Points.Clear();
            }
            l5.Start_p3(this.chart1);
        }
    }
}