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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private string workerIds;
        private string duration;
        private string date;
        private string ids;
        
        private void Form6_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'stariAppDBDataSet10.WorkersView' table. You can move, or remove it, as needed.
            //this.workersViewTableAdapter.Fill(this.stariAppDBDataSet10.WorkersView);
            // TODO: This line of code loads data into the 'stariAppDBDataSet9.WorkView' table. You can move, or remove it, as needed.
            //this.workViewTableAdapter.Fill(this.stariAppDBDataSet9.WorkView);
            // TODO: This line of code loads data into the 'stariAppDBDataSet8.WorkView' table. You can move, or remove it, as needed.
            //this.workViewTableAdapter.Fill(this.stariAppDBDataSet8.WorkView);
            DisplayData();
            DisplayDataForWorker();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection.addWork(Convert.ToDateTime(date), workerIds, float.Parse(duration));
            DisplayData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Connection.removeByIdMultiple(ids, "Work");
            DisplayData();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox temp = (TextBox)sender;
            workerIds = temp.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            TextBox temp = (TextBox)sender;
            duration = temp.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            TextBox temp = (TextBox)sender;
            date = temp.Text;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            TextBox temp = (TextBox)sender;
            ids = temp.Text;
        }

        private void DisplayData()
        {

            SqlConnection con = new SqlConnection(Connection.path); 
            con.Open();
            SqlDataAdapter adapt;
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from WorkView", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void DisplayDataForWorker()
        {

            SqlConnection con = new SqlConnection(Connection.path);
            con.Open();
            SqlDataAdapter adapt1;
            DataTable dt1 = new DataTable();
            adapt1 = new SqlDataAdapter("select sum(Duration) as 'Trajanje u h', Worker as 'Worker Id' from Work group by Worker ", con);
            adapt1.Fill(dt1);
            dataGridView2.DataSource = dt1;
            con.Close();
        }

    }
}
