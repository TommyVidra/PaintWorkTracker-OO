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
using static StariApp.DataConfigs;

namespace StariApp
{
    public partial class InputBox : Form
    {
        public InputBox(DataClass dataClass)
        {
            InitializeComponent();
            switch(dataClass)
            {
                case DataClass.Worker:
                    label1.Text = "Ime";
                    label2.Text = "Prezime";
                    label3.Text = "Pozicija";

                    textBox1.Tag = "string";
                    textBox2.Tag = "string";
                    textBox3.Tag = "string";

                    label4.Visible = false;
                    label5.Visible = false;
                    label6.Visible = false;
                    textBox4.Visible = false;
                    textBox5.Visible = false;
                    dateTimePicker.Visible = false;
                    break;

                case DataClass.Resource:
                    label1.Text = "Resurs";
                    label2.Text = "Cijena po metrici";
                    label3.Text = "Količina";
                    label4.Text = "Metrika";

                    textBox1.Tag = "string";
                    textBox2.Tag = "double";
                    textBox3.Tag = "double";
                    textBox4.Tag = "string";

                    label5.Visible = false;
                    label6.Visible = false;
                    textBox5.Visible = false;
                    dateTimePicker.Visible = false;
                    break;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close the input window?", "Input Window", MessageBoxButtons.YesNo) == DialogResult.Yes)
                this.Close();
        }

        private void cancleButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close the input window?", "Input Window", MessageBoxButtons.YesNo) == DialogResult.Yes)
                this.Close();
        }
    }
}
