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
    public partial class Form3 : Form
    {
        private string name;
        private float price;
        private float mass;
        private string metric;


        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            DisplayData();
            // TODO: This line of code loads data into the 'stariAppDBDataSet13.Resource' table. You can move, or remove it, as needed.
            //this.resourceTableAdapter.Fill(this.stariAppDBDataSet13.Resource);
            // TODO: This line of code loads data into the 'stariAppDBDataSet.Resource' table. You can move, or remove it, as needed.

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection.addResource(name, price, mass, metric);
            MessageBox.Show("Resurs je nadodan");
            DisplayData();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Connection.removeResource(name, price, metric);
            MessageBox.Show("Resurs je izbrisan");
            DisplayData();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox temp = (TextBox)sender;
            name = temp.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            TextBox temp = (TextBox)sender;
            price = float.Parse(temp.Text);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            TextBox temp = (TextBox)sender;
            mass = float.Parse(temp.Text);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            TextBox temp = (TextBox)sender;
            metric = temp.Text;
        }

        private void DisplayData()
        {

            SqlConnection con = new SqlConnection(Connection.path);
            con.Open();
            SqlDataAdapter adapt;
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select Id, Name, Price, Mass, Metric from Resource", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
    }
}
