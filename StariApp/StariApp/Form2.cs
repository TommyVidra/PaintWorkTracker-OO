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
    public partial class Form2 : Form
    {
        public string name;
        public string lastName;
        public string position;

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DataTable WorkerTabel = new DataTable();

            WorkerTabel.Columns.Add("Id", typeof(int));

            dataGridView1.DataSource = WorkerTabel;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox temp = (TextBox)sender;
            name = temp.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            TextBox temp = (TextBox)sender;
            lastName = temp.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            TextBox temp = (TextBox)sender;
            position = temp.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection.addWorker(name, lastName, int.Parse(position));
            MessageBox.Show("Zaposlenik uspješno unesen");
            DisplayData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Connection.removeWorker(name, lastName);
            MessageBox.Show("Zaposlenik uspješno izbrisan");
            DisplayData();
        }

        private void DisplayData()
        {

            SqlConnection con = new SqlConnection(Connection.path);
            con.Open();
            SqlDataAdapter adapt;
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from WorkerView", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
    }
}
