using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StariApp
{
    public partial class form1 : Form
    {
        
        public form1()
        {
            InitializeComponent();
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'stariAppDBDataSet6.EventsView' table. You can move, or remove it, as needed.
            //this.eventsViewTableAdapter.Fill(this.stariAppDBDataSet6.EventsView);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form6 form6 = new Form6();
            form6.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            form8.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Id,Name,Last Name,Position");
            sb.Append("\n");
            using (var context = new WorkContext())
            {
                var Workers = (from s in context.Workers orderby s.name select s).ToList<Worker>();
                var Resource = (from s in context.Resources orderby s.name select s).ToList<Resource>();
                var Stocks = (from s in context.Stocks orderby s.resource select s).ToList<Stock>();
                var Works = (from s in context.Works orderby s.Id select s).ToList<Work>();
                var Positions = (from s in context.Positions orderby s.position select s).ToList<Position>();

                

                foreach (var Worker in Workers)
                {
                    var Position = context.Positions
                                    .Where(c => c.Id == Worker.position)
                                    .FirstOrDefault();

                    Console.WriteLine("ID: {0}, Name: {1}, Position: {2}", Worker.Id, Worker.name, Position.position);
                    sb.Append(Worker.Id + "," + Worker.name + "," + Worker.lastName + "," + Position.position);
                    sb.Append("\n");

                }

                //File.WriteAllText("G:\\Projects\\Fax\\OO\\Paint Work Tracker\\PaintWorkTracker\\StariApp\\WorkerTest.csv", sb.ToString(), Encoding.UTF8);
            }
            
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            saveFileDialog1.DefaultExt = "csv";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;
            saveFileDialog1.AddExtension = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var file = new StreamWriter(saveFileDialog1.FileName);
                foreach(String line in sb.ToString().Split('\n'))
                {
                    file.WriteLine(line);
                }
                file.Close();
            }
        }
    }
}
