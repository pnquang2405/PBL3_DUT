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

namespace DO_AN_PBL3.View
{
    public partial class FormDetailsRevenue : Form
    {
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

            for (int i = 0; i < 12; i++)
            {
                chartRevenue.Series["Doanh thu"].Points.AddXY("Tháng" + (i + 1), b[i]);
                chartRevenue.Series["Doanh thu"].Points[i].Label = b[i].ToString();
            }
        }
    }
}
