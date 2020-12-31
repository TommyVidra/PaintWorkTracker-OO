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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private string ids;
        private string position;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox temp = (TextBox)sender;
            position = temp.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            TextBox temp = (TextBox)sender;
            ids = temp.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Connection.addPosition(position);
            DisplayData();

        }

        private void button2_Click(object sender, EventArgs e)
        { 
            Connection.removeByIdMultiple(ids, "Position");
            DisplayData();

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'stariAppDBDataSet5.Position' table. You can move, or remove it, as needed.
            this.positionTableAdapter.Fill(this.stariAppDBDataSet5.Position);
            

        }

        private void DisplayData()
        {

            SqlConnection con = new SqlConnection(Connection.path); 
            con.Open();
            SqlDataAdapter adapt;
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from Position", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
    }
}
