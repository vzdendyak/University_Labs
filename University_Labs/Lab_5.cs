using AOS_LabsHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace University_Labs
{
    public class Lab_5
    {
        public void Start_p1(Chart chart)
        {
            var l5c = new Lab5Calculator();
            var values = l5c.Calculate_1_N();
            foreach (var item in values)
            {
                if (!Double.IsNaN(item.Value))
                {
                    chart.Series[0].Points.AddXY(item.Key, item.Value);
                    chart.Series[1].Points.AddXY(l5c.Get_n(), item.Value);
                }
            }
        }

        public void Start_p2(Chart chart)
        {
            var l5c = new Lab5Calculator();
            var values = l5c.Calculate_2_Lambda();
            foreach (var item in values)
            {
                if (!Double.IsNaN(item.Value))
                {
                    chart.Series[0].Points.AddXY(item.Key, item.Value);
                    chart.Series[1].Points.AddXY(l5c.Get_Lambda(), item.Value);
                }
            }
        }

        public void Start_p3(Chart chart)
        {
            var l5c = new Lab5Calculator();
            var values = l5c.Calculate_3_t_obs();
            foreach (var item in values)
            {
                if (!Double.IsNaN(item.Value))
                {
                    chart.Series[0].Points.AddXY(item.Key, item.Value);
                    chart.Series[1].Points.AddXY(l5c.Get_t_obs(), item.Value);
                }
            }
        }
    }
}