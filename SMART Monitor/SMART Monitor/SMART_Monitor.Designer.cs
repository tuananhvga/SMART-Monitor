

namespace SMART_Monitor
{
    partial class SMART_Monitor
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
            this.TabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgvSmart = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Attribute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Current = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Worst = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Threshold = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lSmartView = new System.Windows.Forms.Label();
            this.dgvSmartView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLoadMostRecent = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mtbScheduleTime = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbScheduleUnit = new System.Windows.Forms.ComboBox();
            this.nudInterval = new System.Windows.Forms.NumericUpDown();
            this.cbIntervalUnit = new System.Windows.Forms.ComboBox();
            this.rbUpdateManually = new System.Windows.Forms.RadioButton();
            this.rbUpdateSchedule = new System.Windows.Forms.RadioButton();
            this.rbUpdateInterval = new System.Windows.Forms.RadioButton();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.label1 = new System.Windows.Forms.Label();
            this.cbDrives = new System.Windows.Forms.ComboBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lInfo = new System.Windows.Forms.Label();
            this.TabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSmart)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSmartView)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // TabControl
            // 
            this.TabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TabControl.Controls.Add(this.tabPage1);
            this.TabControl.Controls.Add(this.tabPage2);
            this.TabControl.Controls.Add(this.tabPage3);
            this.TabControl.Location = new System.Drawing.Point(12, 12);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(586, 335);
            this.TabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dgvSmart);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(578, 309);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Smart Monitor";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dgvSmart
            // 
            this.dgvSmart.AllowUserToAddRows = false;
            this.dgvSmart.AllowUserToDeleteRows = false;
            this.dgvSmart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSmart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSmart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Attribute,
            this.Current,
            this.Worst,
            this.Threshold,
            this.Data,
            this.Status});
            this.dgvSmart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSmart.Location = new System.Drawing.Point(3, 3);
            this.dgvSmart.Name = "dgvSmart";
            this.dgvSmart.ReadOnly = true;
            this.dgvSmart.RowHeadersVisible = false;
            this.dgvSmart.Size = new System.Drawing.Size(572, 303);
            this.dgvSmart.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 43;
            // 
            // Attribute
            // 
            this.Attribute.HeaderText = "Attribute";
            this.Attribute.Name = "Attribute";
            this.Attribute.ReadOnly = true;
            // 
            // Current
            // 
            this.Current.HeaderText = "Current";
            this.Current.Name = "Current";
            this.Current.ReadOnly = true;
            // 
            // Worst
            // 
            this.Worst.HeaderText = "Worst";
            this.Worst.Name = "Worst";
            this.Worst.ReadOnly = true;
            // 
            // Threshold
            // 
            this.Threshold.HeaderText = "Threshold";
            this.Threshold.Name = "Threshold";
            this.Threshold.ReadOnly = true;
            // 
            // Data
            // 
            this.Data.HeaderText = "Data";
            this.Data.Name = "Data";
            this.Data.ReadOnly = true;
            // 
            // Status
            // 
            this.Status.HeaderText = "Status";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.btnApply);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(578, 309);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Option";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lSmartView);
            this.groupBox2.Controls.Add(this.dgvSmartView);
            this.groupBox2.Controls.Add(this.btnLoadMostRecent);
            this.groupBox2.Location = new System.Drawing.Point(6, 101);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(539, 202);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Logging";
            // 
            // lSmartView
            // 
            this.lSmartView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lSmartView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lSmartView.Location = new System.Drawing.Point(421, 48);
            this.lSmartView.Name = "lSmartView";
            this.lSmartView.Size = new System.Drawing.Size(118, 148);
            this.lSmartView.TabIndex = 9;
            this.lSmartView.Text = "None";
            // 
            // dgvSmartView
            // 
            this.dgvSmartView.AllowUserToAddRows = false;
            this.dgvSmartView.AllowUserToDeleteRows = false;
            this.dgvSmartView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSmartView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSmartView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSmartView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            this.dgvSmartView.Location = new System.Drawing.Point(0, 48);
            this.dgvSmartView.Name = "dgvSmartView";
            this.dgvSmartView.ReadOnly = true;
            this.dgvSmartView.RowHeadersVisible = false;
            this.dgvSmartView.Size = new System.Drawing.Size(412, 148);
            this.dgvSmartView.TabIndex = 8;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 43;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Attribute";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Current";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Worst";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "Threshold";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "Data";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "Status";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // btnLoadMostRecent
            // 
            this.btnLoadMostRecent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadMostRecent.Location = new System.Drawing.Point(6, 19);
            this.btnLoadMostRecent.Name = "btnLoadMostRecent";
            this.btnLoadMostRecent.Size = new System.Drawing.Size(406, 23);
            this.btnLoadMostRecent.TabIndex = 2;
            this.btnLoadMostRecent.Text = "Load most recent";
            this.btnLoadMostRecent.UseVisualStyleBackColor = true;
            this.btnLoadMostRecent.Click += new System.EventHandler(this.btnLoadMostRecent_Click);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnApply.Location = new System.Drawing.Point(470, 6);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mtbScheduleTime);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbScheduleUnit);
            this.groupBox1.Controls.Add(this.nudInterval);
            this.groupBox1.Controls.Add(this.cbIntervalUnit);
            this.groupBox1.Controls.Add(this.rbUpdateManually);
            this.groupBox1.Controls.Add(this.rbUpdateSchedule);
            this.groupBox1.Controls.Add(this.rbUpdateInterval);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 89);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Update Options";
            // 
            // mtbScheduleTime
            // 
            this.mtbScheduleTime.Enabled = false;
            this.mtbScheduleTime.Location = new System.Drawing.Point(169, 39);
            this.mtbScheduleTime.Mask = "00:00";
            this.mtbScheduleTime.Name = "mtbScheduleTime";
            this.mtbScheduleTime.Size = new System.Drawing.Size(104, 20);
            this.mtbScheduleTime.TabIndex = 1;
            this.mtbScheduleTime.ValidatingType = typeof(System.DateTime);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(144, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "At";
            // 
            // cbScheduleUnit
            // 
            this.cbScheduleUnit.Enabled = false;
            this.cbScheduleUnit.FormattingEnabled = true;
            this.cbScheduleUnit.Items.AddRange(new object[] {
            "Yearly",
            "Monthly",
            "Daily"});
            this.cbScheduleUnit.Location = new System.Drawing.Point(69, 39);
            this.cbScheduleUnit.Name = "cbScheduleUnit";
            this.cbScheduleUnit.Size = new System.Drawing.Size(69, 21);
            this.cbScheduleUnit.TabIndex = 5;
            this.cbScheduleUnit.Text = "Daily";
            // 
            // nudInterval
            // 
            this.nudInterval.Location = new System.Drawing.Point(110, 15);
            this.nudInterval.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.nudInterval.Name = "nudInterval";
            this.nudInterval.Size = new System.Drawing.Size(76, 20);
            this.nudInterval.TabIndex = 1;
            this.nudInterval.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // cbIntervalUnit
            // 
            this.cbIntervalUnit.FormattingEnabled = true;
            this.cbIntervalUnit.Items.AddRange(new object[] {
            "Hour(s)",
            "Minute(s)",
            "Second(s)"});
            this.cbIntervalUnit.Location = new System.Drawing.Point(192, 15);
            this.cbIntervalUnit.Name = "cbIntervalUnit";
            this.cbIntervalUnit.Size = new System.Drawing.Size(83, 21);
            this.cbIntervalUnit.TabIndex = 4;
            this.cbIntervalUnit.Text = "Minute(s)";
            // 
            // rbUpdateManually
            // 
            this.rbUpdateManually.AutoSize = true;
            this.rbUpdateManually.Location = new System.Drawing.Point(6, 64);
            this.rbUpdateManually.Name = "rbUpdateManually";
            this.rbUpdateManually.Size = new System.Drawing.Size(105, 17);
            this.rbUpdateManually.TabIndex = 2;
            this.rbUpdateManually.Text = "Update Manually";
            this.rbUpdateManually.UseVisualStyleBackColor = true;
            this.rbUpdateManually.CheckedChanged += new System.EventHandler(this.rbUpdateManually_CheckedChanged);
            // 
            // rbUpdateSchedule
            // 
            this.rbUpdateSchedule.AutoSize = true;
            this.rbUpdateSchedule.Location = new System.Drawing.Point(6, 41);
            this.rbUpdateSchedule.Name = "rbUpdateSchedule";
            this.rbUpdateSchedule.Size = new System.Drawing.Size(60, 17);
            this.rbUpdateSchedule.TabIndex = 1;
            this.rbUpdateSchedule.Text = "Update";
            this.rbUpdateSchedule.UseVisualStyleBackColor = true;
            this.rbUpdateSchedule.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // rbUpdateInterval
            // 
            this.rbUpdateInterval.AutoSize = true;
            this.rbUpdateInterval.Checked = true;
            this.rbUpdateInterval.Location = new System.Drawing.Point(6, 18);
            this.rbUpdateInterval.Name = "rbUpdateInterval";
            this.rbUpdateInterval.Size = new System.Drawing.Size(98, 17);
            this.rbUpdateInterval.TabIndex = 0;
            this.rbUpdateInterval.TabStop = true;
            this.rbUpdateInterval.Text = "Update Interval";
            this.rbUpdateInterval.UseVisualStyleBackColor = true;
            this.rbUpdateInterval.CheckedChanged += new System.EventHandler(this.rbUpdateInterval_CheckedChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.Transparent;
            this.tabPage3.Controls.Add(this.webBrowser1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(578, 309);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Report";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(3, 3);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(569, 303);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.Url = new System.Uri("http://vga-pc/Reports_SQLEXPRESS/Pages/Report.aspx?ItemPath=%2fMainReport", System.UriKind.Absolute);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(604, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select HDD : ";
            // 
            // cbDrives
            // 
            this.cbDrives.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDrives.FormattingEnabled = true;
            this.cbDrives.Location = new System.Drawing.Point(607, 55);
            this.cbDrives.Name = "cbDrives";
            this.cbDrives.Size = new System.Drawing.Size(220, 21);
            this.cbDrives.TabIndex = 2;
            this.cbDrives.SelectedIndexChanged += new System.EventHandler(this.cbDrives_SelectedIndexChanged);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnExit.Location = new System.Drawing.Point(752, 324);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(618, 324);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(604, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Basic Info : ";
            // 
            // lInfo
            // 
            this.lInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lInfo.Location = new System.Drawing.Point(604, 104);
            this.lInfo.Name = "lInfo";
            this.lInfo.Size = new System.Drawing.Size(223, 217);
            this.lInfo.TabIndex = 6;
            this.lInfo.Text = "None";
            // 
            // SMART_Monitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(853, 358);
            this.Controls.Add(this.lInfo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.cbDrives);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SMART_Monitor";
            this.Text = "SMART Monitor";
            this.Load += new System.EventHandler(this.SMART_Monitor_Load);
            this.TabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSmart)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSmartView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudInterval)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbDrives;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.DataGridView dgvSmart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Attribute;
        private System.Windows.Forms.DataGridViewTextBoxColumn Current;
        private System.Windows.Forms.DataGridViewTextBoxColumn Worst;
        private System.Windows.Forms.DataGridViewTextBoxColumn Threshold;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbUpdateManually;
        private System.Windows.Forms.RadioButton rbUpdateSchedule;
        private System.Windows.Forms.RadioButton rbUpdateInterval;
        private System.Windows.Forms.ComboBox cbIntervalUnit;
        private System.Windows.Forms.NumericUpDown nudInterval;
        private System.Windows.Forms.ComboBox cbScheduleUnit;
        private System.Windows.Forms.MaskedTextBox mtbScheduleTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnLoadMostRecent;
        private System.Windows.Forms.DataGridView dgvSmartView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.Label lSmartView;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.WebBrowser webBrowser1;




    }
}

