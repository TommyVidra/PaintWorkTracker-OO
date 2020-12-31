using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StariApp
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private string startDate;
        private string endDate;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox temp = (TextBox)sender;
            startDate = temp.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            TextBox temp = (TextBox)sender;
            endDate = temp.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(Connection.path); con.Open();
            SqlDataAdapter adapt;
            SqlDataAdapter adapt1;
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            adapt = new SqlDataAdapter("select Sum(Duration) as 'Trajanje posla u h', @start as 'Početni datum', @end as 'Konačni datum' " +
                "from WorkPeriodView where Date >= @start and Date <= @end ", con);

            adapt1 = new SqlDataAdapter("select (Sum(Amount)*-1) as 'Potrošeno resursa', Ime as 'Ime resursa', Metrica, @start as 'Početni datum', @end as 'Konačni datum' " +
                "from StockPeriodView where Date >= @start and Date <= @end and Amount < 0" +
                " group by Ime, Metrica", con);

            List<SqlParameter> para1 = new List<SqlParameter>()
            {
                new SqlParameter("@start", SqlDbType.Date) {Value = Convert.ToDateTime(startDate).Date},
                new SqlParameter("@end", SqlDbType.Date) {Value = Convert.ToDateTime(endDate).Date},
            };
            List<SqlParameter> para2 = new List<SqlParameter>()
            {
                new SqlParameter("@start", SqlDbType.Date) {Value = Convert.ToDateTime(startDate).Date},
                new SqlParameter("@end", SqlDbType.Date) {Value = Convert.ToDateTime(endDate).Date},
            };

            adapt.SelectCommand.Parameters.AddRange(para1.ToArray());
            adapt1.SelectCommand.Parameters.AddRange(para2.ToArray());
            adapt.Fill(dt);
            adapt1.Fill(dt2);
            dataGridView2.DataSource = dt2;
            dataGridView1.DataSource = dt;
            con.Close();
        }
    }
}
