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
using System.Threading;
using static StariApp.Connection;
using System.Text.RegularExpressions;

namespace StariApp
{
    public partial class form1 : Form
    {
        private DataClass CurrentData = DataClass.None;
        private int imageCounter = 0;
        private string slideshowPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName, "slideshow");
        private int value = 0;
        private string loadingText = "";

        private System.Windows.Forms.Timer ProgressBarTimer = new System.Windows.Forms.Timer();
        private System.Windows.Forms.Timer SlideShowTimer = new System.Windows.Forms.Timer();

        private Color lastColorButton = new Color();
        private Color buttonSelected = Color.FromArgb(145, 100, 150);
        private List<Button> ListOfButtons = new List<Button>();

        private int dataTable1MaxHeight = 510;
        private int dataTable1PeriodHeight = 250;
        private int dataTabelsWidth = 650;

        private static WorkContext context = new WorkContext();

        Point lastPoint;

        public form1()
        {
            InitializeComponent();

            ProgressBarTimer.Interval = 10;
            SlideShowTimer.Interval = 3500;

            ListOfButtons.Add(workerButton);
            ListOfButtons.Add(resourceButton);
            ListOfButtons.Add(positionsButton);
            ListOfButtons.Add(periodButton);
            ListOfButtons.Add(notesButton);
            ListOfButtons.Add(stockButton);
            ListOfButtons.Add(worksButton);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            progressBar.Visible = false;
            dataTable1.Visible = false;

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

            loadingLabel.Text = string.Format("Učitavanje svih {0}... {1}%", loadingText, progressBar.Value);
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
                dataTable1.Visible = true;
                addButton.Visible = true;

                if (CurrentData.Equals(DataClass.Period) || CurrentData.Equals(DataClass.Note))
                {
                    if (CurrentData.Equals(DataClass.Period))
                    { 
                        dataTable2.Visible = true;
                        addButton.Visible = false;
                    }

                    dateTimePicker1.Visible = true;
                    dateTimePicker2.Visible = true;
                    searchButton.Visible = true;
                }


                if (ProgressBarTimer.Interval <= 6) ProgressBarTimer.Interval = 6;
                else ProgressBarTimer.Interval -= 1;
                value = 0;

            }
            else 
            {
                value = (value + 1);
                Invoke((MethodInvoker)delegate ()
                {
                    if (value >= 100) progressBar.Value = 100;

                    else 
                    {
                        progressBar.Value = value;
                        progressBar.Value -= 1;
                    }
                });
            } 
        }

        private void gradientPanel1_MouseMove(object sender, MouseEventArgs e)
        {

            if(e.Button == MouseButtons.Left)
            {
                Left += e.X - lastPoint.X;
                Top += e.Y - lastPoint.Y;
            }
        }

        private void gradientPanel1_MouseDown(object sender, MouseEventArgs e) { lastPoint = new Point(e.X, e.Y); }

        private void closeButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to close the application?", "Work App", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Connection.DissposeContext();
                Application.Exit();
            }
        }

        private void minimizeButton_Click(object sender, EventArgs e) { WindowState = FormWindowState.Minimized; }

        private void workerButton_Click(object sender, EventArgs e)
        {
            title.Text = "Popis Radnika";
            dataTable1.Size = new Size(dataTabelsWidth, dataTable1MaxHeight);
            dataTable1.DataSource = Connection.ListWorkers();

            if (!CurrentData.Equals(DataClass.Worker))
            {
                loadingText = "Zaposlenika";
                defineStartingVisablity(DataClass.Worker);
                lastColorButton = workerButton.BackColor;
                workerButton.BackColor = buttonSelected;
            }
        }

        private void resourceButton_Click(object sender, EventArgs e)
        {
            title.Text = "Popis Resursa";
            dataTable1.DataSource = Connection.ListResources();
            dataTable1.Size = new Size(dataTabelsWidth, dataTable1MaxHeight);

            if (!CurrentData.Equals(DataClass.Resource))
            {
                loadingText = "Resursa";
                defineStartingVisablity(DataClass.Resource);
                lastColorButton = resourceButton.BackColor;
                resourceButton.BackColor = buttonSelected;
            }
        }

        private void positionsButton_Click(object sender, EventArgs e)
        {

            title.Text = "Popis Pozicija";
            dataTable1.Size = new Size(dataTabelsWidth, dataTable1MaxHeight);
            dataTable1.DataSource = Connection.ListPositions();

            if (!CurrentData.Equals(DataClass.Position))
            {
                loadingText = "Pozicija";
                defineStartingVisablity(DataClass.Position);
                lastColorButton = positionsButton.BackColor;
                positionsButton.BackColor = buttonSelected;
            }

        }

        private void periodButton_Click(object sender, EventArgs e)
        {
            title.Text = "Periodi Vremena";
            dataTable1.Size = new Size(dataTabelsWidth, dataTable1PeriodHeight);

            dataTable1.DataSource = Connection.ListWorksPeriods(dateTimePicker1.Value, dateTimePicker2.Value);
            dataTable2.DataSource = Connection.ListResourcePeriods(dateTimePicker1.Value, dateTimePicker2.Value);

            if (!CurrentData.Equals(DataClass.Period))
            {
                loadingText = "Perioda Vremena";
                defineStartingVisablity(DataClass.Period);
                lastColorButton = periodButton.BackColor;
                periodButton.BackColor = buttonSelected;
            }
        }

        private void notesButton_Click(object sender, EventArgs e)
        {
            title.Text = "Popis Napomena";
            dataTable1.Size = new Size(dataTabelsWidth, dataTable1MaxHeight);
            dataTable1.DataSource = Connection.ListNotes(dateTimePicker1.Value, dateTimePicker2.Value);

            if (!CurrentData.Equals(DataClass.Note))
            {
                loadingText = "Napomena";
                defineStartingVisablity(DataClass.Note);
                lastColorButton = notesButton.BackColor;
                notesButton.BackColor = buttonSelected;
            }
        }

        private void worksButton_Click(object sender, EventArgs e)
        {
            title.Text = "Popis Poslova";
            dataTable1.Size = new Size(dataTabelsWidth, dataTable1MaxHeight);
            dataTable1.DataSource = Connection.ListWorksPeriods(DateTime.MinValue, DateTime.MaxValue);

            if (!CurrentData.Equals(DataClass.Work))
            {
                loadingText = "Poslova";
                defineStartingVisablity(DataClass.Work);
                lastColorButton = worksButton.BackColor;
                worksButton.BackColor = buttonSelected;
            }
        }

        private void stockButton_Click(object sender, EventArgs e)
        {
            title.Text = "Zapisi o Resursima";
            dataTable1.Size = new Size(dataTabelsWidth, dataTable1MaxHeight);
            dataTable1.DataSource = Connection.ListResourcePeriods(DateTime.MinValue, DateTime.MaxValue);

            if (!CurrentData.Equals(DataClass.Stock))
            {
                loadingText = "Zapisa o Resursima";
                defineStartingVisablity(DataClass.Stock);
                lastColorButton = stockButton.BackColor;
                stockButton.BackColor = buttonSelected;
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            if (CurrentData.Equals(DataClass.Period))
            {
                dataTable1.DataSource = Connection.ListWorksPeriods(dateTimePicker1.Value, dateTimePicker2.Value);
                dataTable2.DataSource = Connection.ListResourcePeriods(dateTimePicker1.Value, dateTimePicker2.Value);
            }
            else dataTable1.DataSource = Connection.ListNotes(dateTimePicker1.Value, dateTimePicker2.Value);
        }

        private void pictureSlide_Click(object sender, EventArgs e) { System.Diagnostics.Process.Start("https://www.chromos-svjetlost.hr/hr/industrija"); }

        private void addButton_Click(object sender, EventArgs e)
        {
            InputBox input = new InputBox(CurrentData);
            input.Show();
            input.FormClosed += new FormClosedEventHandler(InputBoxClosed);
        }

        private void defineStartingVisablity(DataClass data)
        {
            returnToOriginalColor();

            title.Visible = true;
            SlideShowTimer.Enabled = false;
            pictureSlide.Visible = false;
            saveButton.Visible = false;
            cancelButton.Visible = false;
            deleteButton.Visible = false;

            CurrentData = data;
            dataTable1.Visible = false;
            exportButton.Visible = false;
            dataTable2.Visible = false;
            addButton.Visible = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            exportButton.Visible = false;
            searchButton.Visible = false;

            progressBar.Visible = true;
            ProgressBarTimer.Tick += new EventHandler(OnTimedEventProgresBar);
            ProgressBarTimer.Enabled = true;
            loadingLabel.Visible = true;
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

            foreach (DataGridViewColumn headerCell in dataTable1.Columns)
                sb.Append(string.Format(",{0}", headerCell.HeaderText.ToString()));

            foreach (DataGridViewRow Row in dataTable1.Rows)
            {
                sb.Append("\n");
                foreach (DataGridViewCell cell in Row.Cells)
                    sb.Append(string.Format(",{0}",cell.Value.ToString()));
            }

            saveFileDialog.Filter = "CSV documents|*.csv";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var file = new StreamWriter(saveFileDialog.FileName);
                foreach (var line in sb.ToString().Split('\n'))
                    file.WriteLine(line, Encoding.UTF8);
                file.Close();
            }
        }

        private void dataTable_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            saveButton.Visible = true;
            cancelButton.Visible = true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Jeste li sigurni da želite spremiti nove izmjene?", "Modifier window question", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                StringBuilder sb = new StringBuilder();
                foreach (DataGridViewRow Row in dataTable1.Rows)
                {
                    foreach (DataGridViewCell cell in Row.Cells)
                        sb.Append(string.Format("{0},", cell.Value.ToString()));
                    sb.Append("_");
                }

                String[] seperators = { "_" };
                switch(CurrentData)
                {
                    case DataClass.Worker:
                        List<WorkerView> Workers = new List<WorkerView>();

                        foreach(string line in sb.ToString().Split(seperators, StringSplitOptions.RemoveEmptyEntries))
                        {
                            var args = line.Split(',');
                            WorkerView View = new WorkerView { Id = Int32.Parse(args[0]), Ime = args[1], Prezime = args[2], Pozicija = args[3] };
                            Workers.Add(View);
                        }
                        Connection.ModifyWorker(Workers);
                        saveButton.Visible = false;
                        RefreshData();
                        break;

                    case DataClass.Resource:
                        List<Resource> Resources = new List<Resource>();

                        foreach (string line in sb.ToString().Split(seperators, StringSplitOptions.RemoveEmptyEntries))
                        {
                            var args = line.Split(',');
                            try
                            {
                                double price = Double.Parse(args[2]);
                                double mass = Double.Parse(args[3]);
                            }
                            catch(FormatException exe)
                            {
                                MessageBox.Show("Polje nema cijelobrojnu vrijednost!", "Modify Resource Error");
                            }
                            Resources.Add(new Resource { Id = Int32.Parse(args[0]), name = args[1], price = Double.Parse(args[2]), mass = Double.Parse(args[3]), metric = args[4] });
                        }
                        Connection.ModifyResource(Resources);
                        saveButton.Visible = false;
                        RefreshData();
                        break;

                    case DataClass.Position:
                        List<Position> Positions = new List<Position>();

                        foreach (string line in sb.ToString().Split(seperators, StringSplitOptions.RemoveEmptyEntries))
                        {
                            var args = line.Split(',');
                            Positions.Add(new Position { Id = Int32.Parse(args[0]), position = args[1] });
                        }
                        Connection.ModifyPosition(Positions);
                        saveButton.Visible = false;
                        RefreshData();
                        break;

                    case DataClass.Note:
                        List<NotesView> Notes = new List<NotesView>();

                        foreach (string line in sb.ToString().Split(seperators, StringSplitOptions.RemoveEmptyEntries))
                        {
                            var args = line.Split(',');
                            try
                            {
                                DateTime testDate = DateTime.Parse(args[1]);
                            }
                            catch (FormatException exe)
                            {
                                MessageBox.Show("Polje nema vrijednost Datuma!", "Modify Note Error");
                            }
                            Notes.Add(new NotesView { Id = Int32.Parse(args[0]), Datum = DateTime.Parse(args[1]), Ime = args[2], Prezime = args[3], Napomena = args[4] });
                        }
                        Connection.ModifyNote(Notes);
                        saveButton.Visible = false;
                        RefreshData();
                        break;

                    case DataClass.Work:
                        List<PeriodWorkView> Work = new List<PeriodWorkView>();

                        foreach (string line in sb.ToString().Split(seperators, StringSplitOptions.RemoveEmptyEntries))
                        {
                            var args = line.Split(',');
                            try
                            {
                                DateTime testDate = DateTime.Parse(args[1]);
                                double testDouble = Double.Parse(args[4]);
                            }
                            catch (FormatException exe)
                            {
                                MessageBox.Show("Polje nema vrijednost Datuma ili cijelog broja!", "Modify Work Error");
                            }
                            Work.Add(new PeriodWorkView { Id = Int32.Parse(args[0]), Datum = DateTime.Parse(args[1]), Ime = args[2], Prezime = args[3], Trajanje = Double.Parse(args[4]) });
                        }
                        Connection.ModifyWork(Work);
                        saveButton.Visible = false;
                        RefreshData();
                        break;

                    case DataClass.Stock:
                        List<PeriodResourceView> Stock = new List<PeriodResourceView>();

                        foreach (string line in sb.ToString().Split(seperators, StringSplitOptions.RemoveEmptyEntries))
                        {
                            var args = line.Split(',');
                            try
                            {
                                DateTime testDate = DateTime.Parse(args[1]);
                                double testDouble = Double.Parse(args[4]);
                                double testDouble1 = Double.Parse(args[3]);
                            }
                            catch (FormatException exe)
                            {
                                MessageBox.Show("Polje nema vrijednost Datuma ili cijelog broja!", "Modify Stock Error");
                            }
                            Stock.Add(new PeriodResourceView { Id = Int32.Parse(args[0]), Datum = DateTime.Parse(args[1]), Resurs = args[2], Količina = Double.Parse(args[3]), Cijena = Double.Parse(args[4]) });
                        }
                        Connection.ModifyStock(Stock);
                        saveButton.Visible = false;
                        RefreshData();
                        break;
                }
            }
            else
            {
                saveButton.Visible = false;
                RefreshData();
            }
        } 

        void InputBoxClosed(object sender, FormClosedEventArgs e) { RefreshData(); }

        private void RefreshData()
        {
            switch (CurrentData)
            {
                case DataClass.Worker:
                    dataTable1.DataSource = Connection.ListWorkers();
                    break;

                case DataClass.Resource:
                    dataTable1.DataSource = Connection.ListResources();
                    break;

                case DataClass.Position:
                    dataTable1.DataSource = Connection.ListPositions();
                    break;

                case DataClass.Note:
                    dataTable1.DataSource = Connection.ListNotes(dateTimePicker1.Value, dateTimePicker2.Value);
                    break;

                case DataClass.Stock:
                    dataTable1.DataSource = Connection.ListResourcePeriods(DateTime.MinValue, DateTime.MaxValue);
                    break;

                case DataClass.Work:
                    dataTable1.DataSource = Connection.ListWorksPeriods(DateTime.MinValue, DateTime.MaxValue);
                    break;

            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
           
            dataTable1.ClearSelection();
            dataTable2.ClearSelection();
            saveButton.Visible = false;
            cancelButton.Visible = false;
            deleteButton.Visible = false;
            RefreshData();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if(dataTable1.SelectedCells.Count == 0 && dataTable2.SelectedCells.Count == 0 )
            {
                MessageBox.Show("Nije odabrano niti jedno polje", "Delete info window");
                saveButton.Visible = false;
                cancelButton.Visible = false;
                deleteButton.Visible = false;
                RefreshData();
            }

            else
            {
                String[] seperators = { "_" };

                StringBuilder sb = new StringBuilder();
                foreach (DataGridViewRow Row in dataTable1.Rows)
                {
                    foreach (DataGridViewCell cell in Row.Cells)
                    {
                        if (cell.Selected)
                            sb.Append(string.Format("{0},", cell.Value.ToString()));
                    }
                    sb.Append("_");
                }

                string message = "Jeste li sigurni da želite izbrisati ";
                switch (CurrentData)
                {
                    case DataClass.Worker:

                        foreach (string line in sb.ToString().Split(seperators, StringSplitOptions.RemoveEmptyEntries))
                        {
                            var args = line.Split(',');
                            int Id;
                            try
                            {
                                Id = int.Parse(args[0]);
                            }
                            catch(FormatException exe)
                            {
                                MessageBox.Show("Nije odabran redak ili Id zaposlenika", "Delete error message");
                                return;
                            }
                            if (MessageBox.Show(string.Format(message,"zaposlenika s Id-jem: {0}?", Id), "Delete worker window question", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                Connection.RemoveWorker(Id);
                        }
                        RefreshData();
                        break;

                    case DataClass.Resource:

                        foreach (string line in sb.ToString().Split(seperators, StringSplitOptions.RemoveEmptyEntries))
                        {
                            var args = line.Split(',');
                            int Id;
                            try
                            {
                                Id = int.Parse(args[0]);
                            }
                            catch (FormatException exe)
                            {
                                MessageBox.Show("Nije odabran redak ili Id resursa", "Delete error message");
                                return;
                            }

                            if (MessageBox.Show(string.Format(message, "resurs s Id-jem: {0}?", Id), "Delete resource window question", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                Connection.RemoveResource(Id);
                        }
                        RefreshData();
                        break;

                    case DataClass.Position:

                        foreach (string line in sb.ToString().Split(seperators, StringSplitOptions.RemoveEmptyEntries))
                        {
                            var args = line.Split(',');
                            int Id;
                            try
                            {
                                Id = int.Parse(args[0]);
                            }
                            catch (FormatException exe)
                            {
                                MessageBox.Show("Nije odabran redak ili Id pozicije", "Delete error message");
                                return;
                            }

                            if (MessageBox.Show(string.Format(message, "poziciju s Id-jem: {0}?", Id), "Delete resource window question", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                Connection.RemovePosition(Id);
                        }
                        RefreshData();
                        break;

                    case DataClass.Note:

                        foreach (string line in sb.ToString().Split(seperators, StringSplitOptions.RemoveEmptyEntries))
                        {
                            var args = line.Split(',');
                            int Id;
                            try
                            {
                                Id = int.Parse(args[0]);
                            }
                            catch (FormatException exe)
                            {
                                MessageBox.Show("Nije odabran redak ili Id Napomene", "Delete error message");
                                return;
                            }

                            if (MessageBox.Show(string.Format(message, "napomenu s Id-jem: {0}?", Id), "Delete note window question", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                Connection.RemoveNote(Id);
                        }
                        RefreshData();
                        break;

                    case DataClass.Work:

                        foreach (string line in sb.ToString().Split(seperators, StringSplitOptions.RemoveEmptyEntries))
                        {
                            var args = line.Split(',');
                            int Id;
                            try
                            {
                                Id = int.Parse(args[0]);
                            }
                            catch (FormatException exe)
                            {
                                MessageBox.Show("Nije odabran redak ili Id Posla", "Delete error message");
                                return;
                            }

                            if (MessageBox.Show(string.Format(message, "posao s Id-jem: {0}?", Id), "Delete note window question", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                Connection.RemoveWork(Id);
                        }
                        RefreshData();
                        break;

                    case DataClass.Stock:

                        foreach (string line in sb.ToString().Split(seperators, StringSplitOptions.RemoveEmptyEntries))
                        {
                            var args = line.Split(',');
                            int Id;
                            try
                            {
                                Id = int.Parse(args[0]);
                            }
                            catch (FormatException exe)
                            {
                                MessageBox.Show("Nije odabran redak ili Id Zapisa o resursu", "Delete error message");
                                return;
                            }

                            if (MessageBox.Show(string.Format(message, "zapis s Id-jem: {0}?", Id), "Delete stock window question", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                Connection.RemoveStock(Id);
                        }
                        RefreshData();
                        break;
                }
            }

        }

        private void dataTable1_CellContentClick(object sender, DataGridViewCellEventArgs e){ deleteButton.Visible = true; }

        private void dataTable1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e) { deleteButton.Visible = true; }

        private void dataTable1_DataError(object sender, DataGridViewDataErrorEventArgs anError)
        {
            MessageBox.Show("Dogodila se greška: krivi format unosa\nProvjerie vrijednosti svih čelija", "Modify Error Window");
        }
    }
}
