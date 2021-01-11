namespace StariApp
{
    partial class form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form1));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.workerButton = new System.Windows.Forms.Button();
            this.resourceButton = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.positionsButton = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.eventsViewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.title = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.minimizeButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.mainContainer = new System.Windows.Forms.Panel();
            this.loadingLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.dataTable = new System.Windows.Forms.DataGridView();
            this.pictureSlide = new System.Windows.Forms.PictureBox();
            this.addButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.gradientPanel1 = new StariApp.GradientPanel();
            ((System.ComponentModel.ISupportInitialize)(this.eventsViewBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.mainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSlide)).BeginInit();
            this.SuspendLayout();
            // 
            // workerButton
            // 
            this.workerButton.BackColor = System.Drawing.Color.SteelBlue;
            this.workerButton.FlatAppearance.BorderSize = 0;
            this.workerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.workerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.workerButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(233)))), ((int)(((byte)(242)))));
            this.workerButton.Image = ((System.Drawing.Image)(resources.GetObject("workerButton.Image")));
            this.workerButton.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.workerButton.Location = new System.Drawing.Point(0, 0);
            this.workerButton.Name = "workerButton";
            this.workerButton.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.workerButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.workerButton.Size = new System.Drawing.Size(250, 100);
            this.workerButton.TabIndex = 0;
            this.workerButton.Text = "Zaposlenici";
            this.workerButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.workerButton.UseVisualStyleBackColor = false;
            this.workerButton.Click += new System.EventHandler(this.workerButton_Click);
            // 
            // resourceButton
            // 
            this.resourceButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(120)))), ((int)(((byte)(166)))));
            this.resourceButton.FlatAppearance.BorderSize = 0;
            this.resourceButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.resourceButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.resourceButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(233)))), ((int)(((byte)(242)))));
            this.resourceButton.Image = ((System.Drawing.Image)(resources.GetObject("resourceButton.Image")));
            this.resourceButton.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.resourceButton.Location = new System.Drawing.Point(0, 100);
            this.resourceButton.Name = "resourceButton";
            this.resourceButton.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.resourceButton.Size = new System.Drawing.Size(250, 100);
            this.resourceButton.TabIndex = 1;
            this.resourceButton.Text = "Resursi";
            this.resourceButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.resourceButton.UseVisualStyleBackColor = false;
            this.resourceButton.Click += new System.EventHandler(this.resourceButton_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(101)))), ((int)(((byte)(138)))));
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.button4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(233)))), ((int)(((byte)(242)))));
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.button4.Location = new System.Drawing.Point(0, 300);
            this.button4.Name = "button4";
            this.button4.Padding = new System.Windows.Forms.Padding(0, 8, 0, 2);
            this.button4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button4.Size = new System.Drawing.Size(250, 100);
            this.button4.TabIndex = 2;
            this.button4.Text = "Napomene";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // positionsButton
            // 
            this.positionsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(111)))), ((int)(((byte)(152)))));
            this.positionsButton.FlatAppearance.BorderSize = 0;
            this.positionsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.positionsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.positionsButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(233)))), ((int)(((byte)(242)))));
            this.positionsButton.Image = ((System.Drawing.Image)(resources.GetObject("positionsButton.Image")));
            this.positionsButton.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.positionsButton.Location = new System.Drawing.Point(0, 200);
            this.positionsButton.Name = "positionsButton";
            this.positionsButton.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.positionsButton.Size = new System.Drawing.Size(250, 100);
            this.positionsButton.TabIndex = 3;
            this.positionsButton.Text = "Pozicije";
            this.positionsButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.positionsButton.UseVisualStyleBackColor = false;
            this.positionsButton.Click += new System.EventHandler(this.positionsButton_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(92)))), ((int)(((byte)(125)))));
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.button5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(233)))), ((int)(((byte)(242)))));
            this.button5.Image = ((System.Drawing.Image)(resources.GetObject("button5.Image")));
            this.button5.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.button5.Location = new System.Drawing.Point(0, 400);
            this.button5.Name = "button5";
            this.button5.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.button5.Size = new System.Drawing.Size(250, 100);
            this.button5.TabIndex = 4;
            this.button5.Text = "Radovi";
            this.button5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // exportButton
            // 
            this.exportButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(141)))), ((int)(((byte)(87)))));
            this.exportButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.exportButton.FlatAppearance.BorderSize = 0;
            this.exportButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exportButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.exportButton.ForeColor = System.Drawing.Color.White;
            this.exportButton.Image = ((System.Drawing.Image)(resources.GetObject("exportButton.Image")));
            this.exportButton.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.exportButton.Location = new System.Drawing.Point(20, 390);
            this.exportButton.Name = "exportButton";
            this.exportButton.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.exportButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.exportButton.Size = new System.Drawing.Size(135, 135);
            this.exportButton.TabIndex = 8;
            this.exportButton.Text = "Export to CSV";
            this.exportButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.exportButton.UseVisualStyleBackColor = false;
            this.exportButton.Visible = false;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // button7
            // 
            this.button7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(73)))), ((int)(((byte)(99)))));
            this.button7.FlatAppearance.BorderSize = 0;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.button7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(233)))), ((int)(((byte)(242)))));
            this.button7.Image = ((System.Drawing.Image)(resources.GetObject("button7.Image")));
            this.button7.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.button7.Location = new System.Drawing.Point(0, 600);
            this.button7.Name = "button7";
            this.button7.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.button7.Size = new System.Drawing.Size(250, 100);
            this.button7.TabIndex = 7;
            this.button7.Text = "Period";
            this.button7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.UseVisualStyleBackColor = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(82)))), ((int)(((byte)(111)))));
            this.button6.FlatAppearance.BorderSize = 0;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.button6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(233)))), ((int)(((byte)(242)))));
            this.button6.Image = ((System.Drawing.Image)(resources.GetObject("button6.Image")));
            this.button6.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.button6.Location = new System.Drawing.Point(0, 500);
            this.button6.Name = "button6";
            this.button6.Padding = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.button6.Size = new System.Drawing.Size(250, 100);
            this.button6.TabIndex = 5;
            this.button6.Text = "Skladište";
            this.button6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // eventsViewBindingSource
            // 
            this.eventsViewBindingSource.DataMember = "EventsView";
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.DefaultExt = "csv";
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.BackColor = System.Drawing.Color.Transparent;
            this.title.Font = new System.Drawing.Font("Century Gothic", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(27)))), ((int)(((byte)(29)))));
            this.title.Location = new System.Drawing.Point(14, 15);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(153, 32);
            this.title.TabIndex = 10;
            this.title.Text = "WORK APP";
            this.title.Visible = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(64)))), ((int)(((byte)(86)))));
            this.panel1.Controls.Add(this.minimizeButton);
            this.panel1.Controls.Add(this.closeButton);
            this.panel1.Location = new System.Drawing.Point(1196, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(46, 101);
            this.panel1.TabIndex = 12;
            // 
            // minimizeButton
            // 
            this.minimizeButton.FlatAppearance.BorderSize = 0;
            this.minimizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.minimizeButton.Image = ((System.Drawing.Image)(resources.GetObject("minimizeButton.Image")));
            this.minimizeButton.Location = new System.Drawing.Point(8, 48);
            this.minimizeButton.Name = "minimizeButton";
            this.minimizeButton.Size = new System.Drawing.Size(35, 28);
            this.minimizeButton.TabIndex = 1;
            this.minimizeButton.UseVisualStyleBackColor = true;
            this.minimizeButton.Click += new System.EventHandler(this.minimizeButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Image = ((System.Drawing.Image)(resources.GetObject("closeButton.Image")));
            this.closeButton.Location = new System.Drawing.Point(8, 13);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(35, 28);
            this.closeButton.TabIndex = 0;
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // mainContainer
            // 
            this.mainContainer.Controls.Add(this.title);
            this.mainContainer.Controls.Add(this.cancelButton);
            this.mainContainer.Controls.Add(this.saveButton);
            this.mainContainer.Controls.Add(this.addButton);
            this.mainContainer.Controls.Add(this.exportButton);
            this.mainContainer.Controls.Add(this.loadingLabel);
            this.mainContainer.Controls.Add(this.progressBar);
            this.mainContainer.Controls.Add(this.dataTable);
            this.mainContainer.Controls.Add(this.pictureSlide);
            this.mainContainer.Location = new System.Drawing.Point(256, 151);
            this.mainContainer.Name = "mainContainer";
            this.mainContainer.Size = new System.Drawing.Size(973, 538);
            this.mainContainer.TabIndex = 13;
            // 
            // loadingLabel
            // 
            this.loadingLabel.AutoSize = true;
            this.loadingLabel.BackColor = System.Drawing.Color.Transparent;
            this.loadingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadingLabel.Location = new System.Drawing.Point(290, 267);
            this.loadingLabel.Name = "loadingLabel";
            this.loadingLabel.Size = new System.Drawing.Size(70, 24);
            this.loadingLabel.TabIndex = 3;
            this.loadingLabel.Text = "Lapsus";
            this.loadingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.loadingLabel.Visible = false;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(185, 302);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(462, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 1;
            this.progressBar.UseWaitCursor = true;
            this.progressBar.Visible = false;
            // 
            // dataTable
            // 
            this.dataTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Honeydew;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataTable.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataTable.Location = new System.Drawing.Point(256, 15);
            this.dataTable.Name = "dataTable";
            this.dataTable.Size = new System.Drawing.Size(689, 510);
            this.dataTable.TabIndex = 2;
            // 
            // pictureSlide
            // 
            this.pictureSlide.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureSlide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureSlide.Location = new System.Drawing.Point(0, 0);
            this.pictureSlide.Name = "pictureSlide";
            this.pictureSlide.Size = new System.Drawing.Size(973, 538);
            this.pictureSlide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureSlide.TabIndex = 0;
            this.pictureSlide.TabStop = false;
            this.pictureSlide.Click += new System.EventHandler(this.pictureSlide_Click);
            // 
            // addButton
            // 
            this.addButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(141)))), ((int)(((byte)(87)))));
            this.addButton.FlatAppearance.BorderSize = 0;
            this.addButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.addButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(233)))), ((int)(((byte)(242)))));
            this.addButton.Location = new System.Drawing.Point(20, 349);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(135, 35);
            this.addButton.TabIndex = 9;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = false;
            this.addButton.Visible = false;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(141)))), ((int)(((byte)(87)))));
            this.saveButton.FlatAppearance.BorderSize = 0;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.saveButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(233)))), ((int)(((byte)(242)))));
            this.saveButton.Location = new System.Drawing.Point(20, 267);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(135, 35);
            this.saveButton.TabIndex = 10;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Visible = false;
            // 
            // cancelButton
            // 
            this.cancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(145)))), ((int)(((byte)(100)))), ((int)(((byte)(150)))));
            this.cancelButton.FlatAppearance.BorderSize = 0;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.cancelButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(233)))), ((int)(((byte)(242)))));
            this.cancelButton.Location = new System.Drawing.Point(20, 308);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(135, 35);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = false;
            this.cancelButton.Visible = false;
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gradientPanel1.Angle = 0F;
            this.gradientPanel1.AutoSize = true;
            this.gradientPanel1.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.gradientPanel1.FirstColor = System.Drawing.Color.SteelBlue;
            this.gradientPanel1.Location = new System.Drawing.Point(249, -1);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.SecondColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(64)))), ((int)(((byte)(86)))));
            this.gradientPanel1.Size = new System.Drawing.Size(952, 101);
            this.gradientPanel1.TabIndex = 1;
            this.gradientPanel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gradientPanel1_MouseDown);
            this.gradientPanel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.gradientPanel1_MouseMove);
            // 
            // form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(220)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(1241, 698);
            this.ControlBox = false;
            this.Controls.Add(this.mainContainer);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.positionsButton);
            this.Controls.Add(this.resourceButton);
            this.Controls.Add(this.workerButton);
            this.Controls.Add(this.gradientPanel1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1257, 717);
            this.MinimumSize = new System.Drawing.Size(521, 426);
            this.Name = "form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Program Rada";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.eventsViewBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.mainContainer.ResumeLayout(false);
            this.mainContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureSlide)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource eventsViewBindingSource;
        private System.Windows.Forms.Button workerButton;
        private System.Windows.Forms.Button resourceButton;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button positionsButton;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private GradientPanel gradientPanel1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button minimizeButton;
        private System.Windows.Forms.Panel mainContainer;
        private System.Windows.Forms.PictureBox pictureSlide;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.DataGridView dataTable;
        private System.Windows.Forms.Label loadingLabel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
    }
}

