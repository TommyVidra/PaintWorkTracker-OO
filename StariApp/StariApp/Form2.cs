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
using static StariApp.Connection;
using static StariApp.DataConfigs;

namespace StariApp
{
    public partial class InputBox : Form
    {
        private Dictionary<Label, TextBox> UsedForms = new Dictionary<Label, TextBox>();
        private DataClass TmpDataClass;
        private Point lastPoint;

        public InputBox(DataClass dataClass)
        {
            InitializeComponent();
            TmpDataClass = dataClass;
            switch(TmpDataClass)
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

                    UsedForms.Add(label1, textBox1);
                    UsedForms.Add(label2, textBox2);
                    UsedForms.Add(label3, textBox3);

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

                    UsedForms.Add(label1, textBox1);
                    UsedForms.Add(label2, textBox2);
                    UsedForms.Add(label3, textBox3);
                    UsedForms.Add(label4, textBox4);
                    break;

                case DataClass.Position:
                    label1.Text = "Pozicija";

                    textBox1.Tag = "string";

                    label2.Visible = false;
                    label3.Visible = false;
                    label4.Visible = false;
                    label5.Visible = false;
                    label6.Visible = false;
                    textBox2.Visible = false;
                    textBox3.Visible = false;
                    textBox4.Visible = false;
                    textBox5.Visible = false;
                    dateTimePicker.Visible = false;

                    UsedForms.Add(label1, textBox1);
                    break;

                case DataClass.Note:
                    label1.Text = "Ime";
                    label2.Text = "Prezime";
                    label3.Text = "Napomena";

                    textBox1.Tag = "string";
                    textBox2.Tag = "string";
                    textBox3.Tag = "string";

                    label4.Visible = false;
                    label5.Visible = false;
                    label6.Visible = false;
                    textBox5.Visible = false;
                    textBox4.Visible = false;
                    dateTimePicker.Visible = true;

                    UsedForms.Add(label1, textBox1);
                    UsedForms.Add(label2, textBox2);
                    UsedForms.Add(label3, textBox3);
                    break;

                case DataClass.Work:
                    label1.Text = "Ime";
                    label2.Text = "Prezime";
                    label3.Text = "Trajanje";

                    textBox1.Tag = "string";
                    textBox2.Tag = "string";
                    textBox3.Tag = "double";

                    label4.Visible = false;
                    label5.Visible = false;
                    label6.Visible = false;
                    textBox5.Visible = false;
                    textBox4.Visible = false;
                    dateTimePicker.Visible = true;

                    UsedForms.Add(label1, textBox1);
                    UsedForms.Add(label2, textBox2);
                    UsedForms.Add(label3, textBox3);
                    break;

                case DataClass.Stock:
                    label1.Text = "Ime Resursa";
                    label2.Text = "Količina";
                    label3.Text = "Cijena";

                    textBox1.Tag = "string";
                    textBox2.Tag = "double";
                    textBox3.Tag = "double";

                    label4.Visible = false;
                    label5.Visible = false;
                    label6.Visible = false;
                    textBox5.Visible = false;
                    textBox4.Visible = false;
                    dateTimePicker.Visible = true;

                    UsedForms.Add(label1, textBox1);
                    UsedForms.Add(label2, textBox2);
                    UsedForms.Add(label3, textBox3);
                    break;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void gradientPanel1_MouseMove(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void gradientPanel1_MouseDown(object sender, MouseEventArgs e){ lastPoint = new Point(e.X, e.Y); }

        private void closeButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close the input window?", "Input data window", MessageBoxButtons.YesNo) == DialogResult.Yes)
                this.Close();
        }

        private void cancleButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close the input window?", "Input data window", MessageBoxButtons.YesNo) == DialogResult.Yes)
                this.Close();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if(AreTheParmsOK())
            {
                switch(TmpDataClass)
                {
                    case DataClass.Worker:
                        Connection.AddWorker(new WorkerView {Id = 0, Ime = textBox1.Text, Prezime = textBox2.Text, Pozicija = textBox3.Text });
                        this.Close();
                        break;

                    case DataClass.Resource:
                        Connection.AddResource(new Resource { Id = 0, name = textBox1.Text, mass = double.Parse(textBox3.Text), price = double.Parse(textBox2.Text), metric = textBox4.Text });
                        this.Close();
                        break;

                    case DataClass.Position:
                        Connection.AddPosition(new Position { Id = 0, position = textBox1.Text });
                        this.Close();
                        break;

                    case DataClass.Note:
                        Connection.AddNote(new NotesView { Id = 0, Datum = dateTimePicker.Value, Ime = textBox1.Text, Prezime = textBox2.Text, Napomena = textBox3.Text});
                        this.Close();
                        break;

                    case DataClass.Work:
                        Connection.AddWork(new PeriodWorkView { Id = 0, Datum = dateTimePicker.Value, Ime = textBox1.Text, Prezime = textBox2.Text, Trajanje = Double.Parse(textBox3.Text) });
                        this.Close();
                        break;

                    case DataClass.Stock:
                        Connection.AddStock(new PeriodResourceView { Id = 0, Datum = dateTimePicker.Value, Resurs = textBox1.Text, Količina = Double.Parse(textBox2.Text), Cijena = Double.Parse(textBox3.Text) });
                        this.Close();
                        break;
                }
            }

        }

        private bool AreTheParmsOK()
        {
            foreach(var key in UsedForms.Keys)
            {
                if(string.IsNullOrEmpty(UsedForms[key].Text))
                {
                    MessageBox.Show(string.Format("Polje : {0} nema vrijednost definiranu", key.Text), "Error input window");
                    return false;
                }
                if(UsedForms[key].Tag.Equals("double"))
                {
                    try
                    {
                        double.Parse(UsedForms[key].Text);
                    }
                    catch (FormatException e)
                    {
                        MessageBox.Show(string.Format("Polje : {0} nema ispravnu vrijednost - treba biti cijeli broj", key.Text), "Error input window");
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
