using DO_AN_PBL3.BLL;
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

namespace DO_AN_PBL3.View
{
    public partial class FormDetailsRevenue : Form
    {
        DateTime now = DateTime.Now;
        public FormDetailsRevenue()
        {
            InitializeComponent();
        }

        public static DateTime GetFistDayInMonth(int year, int month)
        {
            DateTime aDateTime = new DateTime(year, month, 1);

            return aDateTime;
        }

        public static DateTime GetLastDayInMonth(int year, int month)
        {
            DateTime aDateTime = new DateTime(year, month, 1);

            // Cộng thêm 1 tháng và trừ đi một ngày.
            DateTime retDateTime = aDateTime.AddMonths(1).AddDays(-1);

            return retDateTime;
        }

        double[] statistical()
        {
            double[] a = new double[12];
            DateTime fistMonth;
            DateTime endMonth;
            for (int i = 0; i < 12; i++)
            {
                fistMonth = GetFistDayInMonth(DateTime.Now.Year, i + 1);
                endMonth = GetLastDayInMonth(DateTime.Now.Year, i + 1);
                a[i] = HOA_DON_BLL.Instance.getTotalBillInMonth(fistMonth, endMonth);
            }
            return a;
        }


        private void FormDetailsRevenue_Load(object sender, EventArgs e)
        {
            double[] b = new double[12];
            b = statistical();
            double max = b[0];
            chartRevenue.ChartAreas[0].AxisY.Maximum = max;

            for (int i = 0; i < b.Length; i++)
            {
                if (max < b[i]) max = b[i];
            }

            if (chartRevenue.ChartAreas[0].AxisY.Maximum < max) chartRevenue.ChartAreas[0].AxisY.Maximum = max;

            chartRevenue.Series.Clear();
            Series s = new Series();
            for (int i = 0; i < now.Month; i++)
            {
                DataPoint p = new DataPoint();
                p.XValue = i;
                p.SetValueY(b[i]);
                p.AxisLabel = "Tháng " + (i + 1).ToString();
                p.Label = b[i].ToString();
                s.Points.Add(p);
            }
            chartRevenue.Series.Add(s);
            chartRevenue.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
        }
    }
}
