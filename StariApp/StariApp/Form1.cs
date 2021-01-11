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
using System.Timers;
using System.Configuration;
using static StariApp.DataConfigs;

namespace StariApp
{
    public partial class form1 : Form
    {
        private DataClass CurrentData = DataClass.None;
        private int imageCounter = 0;
        private string slideshowPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName, "slideshow");
        private int progressBarValue = 10;

        private System.Windows.Forms.Timer ProgressBarTimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer SlideShowTimer = new System.Windows.Forms.Timer();

        private Color lastColorButton = new Color();
        private Color buttonSelected = Color.FromArgb(145, 100, 150);
        private List<Button> ListOfButtons = new List<Button>();

        public form1()
        {
            InitializeComponent();

            ListOfButtons.Add(workerButton);
            ListOfButtons.Add(resourceButton);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SlideShowTimer.Interval = 3500;
            progressBar.Visible = false;
            dataTable.Visible = false;

            pictureSlide.ImageLocation = string.Format("{0}\\Image{1}.jpg", slideshowPath, imageCounter);
            SlideShowTimer.Tick += new EventHandler(OnTimedEventPictureSlide);
            SlideShowTimer.Enabled = true;
        }

        private void OnTimedEventPictureSlide(Object source, EventArgs e)
        {
            imageCounter += 1;
            if (imageCounter == 6) imageCounter = 0;
            pictureSlide.ImageLocation = string.Format("{0}\\Image{1}.jpg", slideshowPath, imageCounter);
        }

        private void OnTimedEventProgresBar(Object source, EventArgs e)
        {
            if (progressBar.Value == 100)
            {
                ProgressBarTimer.Tick -= new EventHandler(OnTimedEventProgresBar);
                ProgressBarTimer.Enabled = false;

                loadingLabel.Visible = false;
                loadingLabel.Text = "";

                progressBar.Visible = false;
                ProgressBarTimer.Enabled = false;
                progressBar.Value = 0;

                exportButton.Visible = true;
                dataTable.Visible = true;

            }
            else progressBar.PerformStep();
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void cardButton1_Load(object sender, EventArgs e)
        {

        }

        private void cardButton1_Load_1(object sender, EventArgs e)
        {

        }

        Point lastPoint;
        private void gradientPanel1_MouseMove(object sender, MouseEventArgs e)
        {

            if(e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void gradientPanel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close the application?", "My Application",
            MessageBoxButtons.YesNo) == DialogResult.Yes)
                System.Windows.Forms.Application.Exit();
        }

        private void minimizeButton_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void workerButton_Click(object sender, EventArgs e)
        {
            title.Text = "Popis Radnika";
            dataTable.DataSource = Connection.ListWorkers();

            if (!CurrentData.Equals(DataClass.Worker))
            {
                defineStartingVisablity(DataClass.Worker, "Zaposlenika");
                lastColorButton = workerButton.BackColor;
                workerButton.BackColor = buttonSelected;
            }
        }

        private void pictureSlide_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.chromos-svjetlost.hr/hr/industrija");
        }

        private void resourceButton_Click(object sender, EventArgs e)
        {
            title.Text = "Popis Resursa";
            dataTable.DataSource = Connection.ListResources();

            if (!CurrentData.Equals(DataClass.Resource))
            {
                defineStartingVisablity(DataClass.Resource, "Resursa");
                lastColorButton = resourceButton.BackColor;
                resourceButton.BackColor = buttonSelected;
            }
        }

        private void defineStartingVisablity(DataClass data, string loadingText)
        {
            returnToOriginalColor();

            SlideShowTimer.Enabled = false;
            pictureSlide.Visible = false;

            CurrentData = data;
            dataTable.Visible = false;
            exportButton.Visible = false;

            loadingLabel.Text = string.Format("Učitavanje {0}...", loadingText);
            loadingLabel.Visible = true;

            progressBar.Visible = true;
            ProgressBarTimer.Interval = 100;
            ProgressBarTimer.Tick += new EventHandler(OnTimedEventProgresBar);
            ProgressBarTimer.Enabled = true;
        }

        private void returnToOriginalColor()
        {
            foreach (var button in ListOfButtons) 
            {
                if (button.BackColor.ToArgb().Equals(buttonSelected.ToArgb()))
                    button.BackColor = lastColorButton;
            }
        }
        private void exportButton_Click(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            foreach (DataGridViewColumn headerCell in dataTable.Columns)
                sb.Append(string.Format(",{0}", headerCell.HeaderText.ToString()));

            foreach (DataGridViewRow Row in dataTable.Rows)
            {
                sb.Append("\n");
                foreach (DataGridViewCell cell in Row.Cells)
                    sb.Append(string.Format(",{0}",cell.Value.ToString()));
            }

            saveFileDialog.Filter = "CSV documents|*.csv";
            saveFileDialog.ShowDialog();

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var file = new StreamWriter(saveFileDialog.FileName);
                foreach (var line in sb.ToString().Split('\n'))
                    file.WriteLine(line, Encoding.UTF8);
                file.Close();
            }
        }
    }
}
