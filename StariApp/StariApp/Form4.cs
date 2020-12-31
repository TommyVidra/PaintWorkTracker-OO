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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private string note;
        private string dateS;
        private DateTime date;
        private string id;
        private string ids;


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox temp = (TextBox)sender;
            dateS = temp.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            TextBox temp = (TextBox)sender;
            note = temp.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            TextBox temp = (TextBox)sender;
            id = temp.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            date = Convert.ToDateTime(dateS);
            Connection.addNote(note, date, int.Parse(id));
            DisplayData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Connection.removeByIdMultiple(ids, "Note");
            DisplayData();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'stariAppDBDataSet3.NoteView' table. You can move, or remove it, as needed.
            this.noteViewTableAdapter.Fill(this.stariAppDBDataSet3.NoteView);
            // TODO: This line of code loads data into the 'stariAppDBDataSet1.NoteView' table. You can move, or remove it, as needed.
            //this.noteViewTableAdapter.Fill(this.stariAppDBDataSet1.NoteView);

        }

        private void DisplayData()
        {
            SqlConnection con = new SqlConnection(Connection.path);
            con.Open();
            SqlDataAdapter adapt;
            DataTable dt = new DataTable();
            adapt = new SqlDataAdapter("select * from NoteView", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            TextBox temp = (TextBox)sender;
            ids = temp.Text;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
