﻿namespace OS_Project.UserControls.CpuSchedulingControl
{
    partial class SJF_UC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BtnStartScheduling = new System.Windows.Forms.Button();
            this.PName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PArrivalTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PBurstTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PPriority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PStartTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PFinishTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PWaitTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PTurnAroundTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PRemainingTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblAVGWait = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CheckBoxPreemptive = new System.Windows.Forms.CheckBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblAVGTA = new System.Windows.Forms.Label();
            this.BtnReset = new System.Windows.Forms.Button();
            this.PIsWorking = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProDGV = new System.Windows.Forms.DataGridView();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tlpProDataMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpProFields = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tlpProButtons = new System.Windows.Forms.TableLayoutPanel();
            this.BtnClear = new System.Windows.Forms.Button();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnEdit = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtProName = new System.Windows.Forms.TextBox();
            this.numArrivalTime = new System.Windows.Forms.NumericUpDown();
            this.numBurstTime = new System.Windows.Forms.NumericUpDown();
            this.GbGanttChart = new System.Windows.Forms.GroupBox();
            this.pnlGanttContainer = new System.Windows.Forms.Panel();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProDGV)).BeginInit();
            this.tlpMain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tlpProDataMain.SuspendLayout();
            this.tlpProFields.SuspendLayout();
            this.tlpProButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numArrivalTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBurstTime)).BeginInit();
            this.GbGanttChart.SuspendLayout();
            this.pnlGanttContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnStartScheduling
            // 
            this.BtnStartScheduling.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnStartScheduling.BackColor = System.Drawing.Color.Transparent;
            this.BtnStartScheduling.FlatAppearance.BorderSize = 0;
            this.BtnStartScheduling.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.BtnStartScheduling.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(54)))), ((int)(((byte)(63)))));
            this.BtnStartScheduling.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnStartScheduling.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.BtnStartScheduling.ForeColor = System.Drawing.Color.White;
            this.BtnStartScheduling.Location = new System.Drawing.Point(955, 27);
            this.BtnStartScheduling.Margin = new System.Windows.Forms.Padding(5);
            this.BtnStartScheduling.Name = "BtnStartScheduling";
            this.BtnStartScheduling.Size = new System.Drawing.Size(243, 58);
            this.BtnStartScheduling.TabIndex = 20;
            this.BtnStartScheduling.Text = "Start Scheduling";
            this.BtnStartScheduling.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnStartScheduling.UseVisualStyleBackColor = false;
            this.BtnStartScheduling.Click += new System.EventHandler(this.BtnStartScheduling_Click);
            // 
            // PName
            // 
            this.PName.DataPropertyName = "Name";
            this.PName.HeaderText = "Name";
            this.PName.MinimumWidth = 6;
            this.PName.Name = "PName";
            this.PName.ReadOnly = true;
            this.PName.Width = 146;
            // 
            // PArrivalTime
            // 
            this.PArrivalTime.DataPropertyName = "ArrivalTime";
            this.PArrivalTime.HeaderText = "Arrival Time";
            this.PArrivalTime.MinimumWidth = 6;
            this.PArrivalTime.Name = "PArrivalTime";
            this.PArrivalTime.ReadOnly = true;
            this.PArrivalTime.Width = 237;
            // 
            // PBurstTime
            // 
            this.PBurstTime.DataPropertyName = "BurstTime";
            this.PBurstTime.HeaderText = "Burst Time";
            this.PBurstTime.MinimumWidth = 6;
            this.PBurstTime.Name = "PBurstTime";
            this.PBurstTime.ReadOnly = true;
            this.PBurstTime.Width = 219;
            // 
            // PPriority
            // 
            this.PPriority.DataPropertyName = "Priority";
            this.PPriority.HeaderText = "Priority";
            this.PPriority.MinimumWidth = 6;
            this.PPriority.Name = "PPriority";
            this.PPriority.ReadOnly = true;
            this.PPriority.Visible = false;
            this.PPriority.Width = 143;
            // 
            // PStartTime
            // 
            this.PStartTime.DataPropertyName = "StartTime";
            this.PStartTime.HeaderText = "Start Time";
            this.PStartTime.MinimumWidth = 6;
            this.PStartTime.Name = "PStartTime";
            this.PStartTime.ReadOnly = true;
            this.PStartTime.Visible = false;
            this.PStartTime.Width = 180;
            // 
            // PFinishTime
            // 
            this.PFinishTime.DataPropertyName = "FinishTime";
            this.PFinishTime.HeaderText = "Finish Time";
            this.PFinishTime.MinimumWidth = 6;
            this.PFinishTime.Name = "PFinishTime";
            this.PFinishTime.ReadOnly = true;
            this.PFinishTime.Visible = false;
            this.PFinishTime.Width = 192;
            // 
            // PWaitTime
            // 
            this.PWaitTime.DataPropertyName = "WaitTime";
            this.PWaitTime.HeaderText = "Wait Time";
            this.PWaitTime.MinimumWidth = 6;
            this.PWaitTime.Name = "PWaitTime";
            this.PWaitTime.ReadOnly = true;
            this.PWaitTime.Visible = false;
            this.PWaitTime.Width = 177;
            // 
            // PId
            // 
            this.PId.DataPropertyName = "Id";
            this.PId.HeaderText = "Id";
            this.PId.MinimumWidth = 6;
            this.PId.Name = "PId";
            this.PId.ReadOnly = true;
            this.PId.Visible = false;
            this.PId.Width = 56;
            // 
            // PTurnAroundTime
            // 
            this.PTurnAroundTime.DataPropertyName = "TurnAroundTime";
            this.PTurnAroundTime.HeaderText = "TA Time";
            this.PTurnAroundTime.MinimumWidth = 6;
            this.PTurnAroundTime.Name = "PTurnAroundTime";
            this.PTurnAroundTime.ReadOnly = true;
            this.PTurnAroundTime.Visible = false;
            this.PTurnAroundTime.Width = 151;
            // 
            // PRemainingTime
            // 
            this.PRemainingTime.DataPropertyName = "RemainingTime";
            this.PRemainingTime.HeaderText = "Remaining Time";
            this.PRemainingTime.MinimumWidth = 6;
            this.PRemainingTime.Name = "PRemainingTime";
            this.PRemainingTime.ReadOnly = true;
            this.PRemainingTime.Visible = false;
            this.PRemainingTime.Width = 250;
            // 
            // lblAVGWait
            // 
            this.lblAVGWait.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAVGWait.AutoSize = true;
            this.lblAVGWait.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblAVGWait.ForeColor = System.Drawing.Color.White;
            this.lblAVGWait.Location = new System.Drawing.Point(0, 25);
            this.lblAVGWait.Name = "lblAVGWait";
            this.lblAVGWait.Size = new System.Drawing.Size(202, 29);
            this.lblAVGWait.TabIndex = 22;
            this.lblAVGWait.Text = "Wait Time AVG = ";
            this.lblAVGWait.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CheckBoxPreemptive);
            this.panel1.Controls.Add(this.lblTime);
            this.panel1.Controls.Add(this.lblAVGWait);
            this.panel1.Controls.Add(this.lblAVGTA);
            this.panel1.Controls.Add(this.BtnReset);
            this.panel1.Controls.Add(this.BtnStartScheduling);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 820);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1348, 86);
            this.panel1.TabIndex = 2;
            // 
            // CheckBoxPreemptive
            // 
            this.CheckBoxPreemptive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CheckBoxPreemptive.AutoSize = true;
            this.CheckBoxPreemptive.BackColor = System.Drawing.Color.Black;
            this.CheckBoxPreemptive.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.CheckBoxPreemptive.Location = new System.Drawing.Point(736, 29);
            this.CheckBoxPreemptive.Name = "CheckBoxPreemptive";
            this.CheckBoxPreemptive.Size = new System.Drawing.Size(211, 43);
            this.CheckBoxPreemptive.TabIndex = 25;
            this.CheckBoxPreemptive.Text = "Preemptive";
            this.CheckBoxPreemptive.UseVisualStyleBackColor = false;
            this.CheckBoxPreemptive.CheckedChanged += new System.EventHandler(this.CheckBoxPreemptive_CheckedChanged);
            // 
            // lblTime
            // 
            this.lblTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblTime.ForeColor = System.Drawing.Color.White;
            this.lblTime.Location = new System.Drawing.Point(248, 25);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(304, 29);
            this.lblTime.TabIndex = 24;
            this.lblTime.Text = "Estimated Time = {time}ms";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTime.Visible = false;
            // 
            // lblAVGTA
            // 
            this.lblAVGTA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblAVGTA.AutoSize = true;
            this.lblAVGTA.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lblAVGTA.ForeColor = System.Drawing.Color.White;
            this.lblAVGTA.Location = new System.Drawing.Point(3, 60);
            this.lblAVGTA.Name = "lblAVGTA";
            this.lblAVGTA.Size = new System.Drawing.Size(288, 29);
            this.lblAVGTA.TabIndex = 23;
            this.lblAVGTA.Text = "Turnarround Time AVG = ";
            this.lblAVGTA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnReset
            // 
            this.BtnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnReset.BackColor = System.Drawing.Color.Transparent;
            this.BtnReset.FlatAppearance.BorderSize = 0;
            this.BtnReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.BtnReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(54)))), ((int)(((byte)(63)))));
            this.BtnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.BtnReset.ForeColor = System.Drawing.Color.White;
            this.BtnReset.Location = new System.Drawing.Point(1208, 27);
            this.BtnReset.Margin = new System.Windows.Forms.Padding(5);
            this.BtnReset.Name = "BtnReset";
            this.BtnReset.Size = new System.Drawing.Size(134, 58);
            this.BtnReset.TabIndex = 20;
            this.BtnReset.Text = "Reset";
            this.BtnReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnReset.UseVisualStyleBackColor = false;
            this.BtnReset.Click += new System.EventHandler(this.BtnReset_Click);
            // 
            // PIsWorking
            // 
            this.PIsWorking.DataPropertyName = "IsWorking";
            this.PIsWorking.HeaderText = "IsWorking";
            this.PIsWorking.MinimumWidth = 6;
            this.PIsWorking.Name = "PIsWorking";
            this.PIsWorking.ReadOnly = true;
            this.PIsWorking.Visible = false;
            this.PIsWorking.Width = 181;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(51)))), ((int)(((byte)(4)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(188)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn1.FillWeight = 98.48485F;
            this.dataGridViewTextBoxColumn1.HeaderText = " ";
            this.dataGridViewTextBoxColumn1.MaxInputLength = 10;
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 6;
            // 
            // ProDGV
            // 
            this.ProDGV.AllowUserToAddRows = false;
            this.ProDGV.AllowUserToDeleteRows = false;
            this.ProDGV.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(54)))), ((int)(((byte)(63)))));
            this.ProDGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.ProDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.ProDGV.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(35)))));
            this.ProDGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ProDGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(54)))), ((int)(((byte)(63)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(5);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ProDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ProDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PId,
            this.PName,
            this.PArrivalTime,
            this.PBurstTime,
            this.PPriority,
            this.PStartTime,
            this.PFinishTime,
            this.PWaitTime,
            this.PTurnAroundTime,
            this.PIsWorking,
            this.PRemainingTime});
            this.ProDGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProDGV.EnableHeadersVisualStyles = false;
            this.ProDGV.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(104)))), ((int)(((byte)(104)))));
            this.ProDGV.Location = new System.Drawing.Point(3, 456);
            this.ProDGV.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ProDGV.MultiSelect = false;
            this.ProDGV.Name = "ProDGV";
            this.ProDGV.ReadOnly = true;
            this.ProDGV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ProDGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.ProDGV.RowHeadersVisible = false;
            this.ProDGV.RowHeadersWidth = 51;
            this.ProDGV.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(35)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.RoyalBlue;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.ProDGV.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.ProDGV.RowTemplate.Height = 40;
            this.ProDGV.RowTemplate.ReadOnly = true;
            this.ProDGV.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ProDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ProDGV.Size = new System.Drawing.Size(1348, 359);
            this.ProDGV.TabIndex = 4;
            this.ProDGV.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ProDGV_CellClick);
            // 
            // tlpMain
            // 
            this.tlpMain.BackColor = System.Drawing.Color.Transparent;
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.groupBox1, 0, 0);
            this.tlpMain.Controls.Add(this.ProDGV, 0, 1);
            this.tlpMain.Controls.Add(this.panel1, 0, 2);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlpMain.Size = new System.Drawing.Size(1354, 909);
            this.tlpMain.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tlpProDataMain);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1348, 448);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Processes Data";
            // 
            // tlpProDataMain
            // 
            this.tlpProDataMain.ColumnCount = 2;
            this.tlpProDataMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpProDataMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpProDataMain.Controls.Add(this.tlpProFields, 0, 0);
            this.tlpProDataMain.Controls.Add(this.GbGanttChart, 1, 0);
            this.tlpProDataMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpProDataMain.Location = new System.Drawing.Point(3, 41);
            this.tlpProDataMain.Name = "tlpProDataMain";
            this.tlpProDataMain.RowCount = 1;
            this.tlpProDataMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpProDataMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 411F));
            this.tlpProDataMain.Size = new System.Drawing.Size(1342, 404);
            this.tlpProDataMain.TabIndex = 0;
            // 
            // tlpProFields
            // 
            this.tlpProFields.ColumnCount = 3;
            this.tlpProFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpProFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpProFields.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpProFields.Controls.Add(this.label3, 0, 2);
            this.tlpProFields.Controls.Add(this.label2, 0, 1);
            this.tlpProFields.Controls.Add(this.tlpProButtons, 2, 0);
            this.tlpProFields.Controls.Add(this.label1, 0, 0);
            this.tlpProFields.Controls.Add(this.txtProName, 1, 0);
            this.tlpProFields.Controls.Add(this.numArrivalTime, 1, 1);
            this.tlpProFields.Controls.Add(this.numBurstTime, 1, 2);
            this.tlpProFields.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpProFields.Location = new System.Drawing.Point(3, 3);
            this.tlpProFields.Name = "tlpProFields";
            this.tlpProFields.RowCount = 3;
            this.tlpProFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.00062F));
            this.tlpProFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.00062F));
            this.tlpProFields.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25.00062F));
            this.tlpProFields.Size = new System.Drawing.Size(665, 398);
            this.tlpProFields.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 264);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(193, 134);
            this.label3.TabIndex = 3;
            this.label3.Text = "Burst time*";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 132);
            this.label2.TabIndex = 2;
            this.label2.Text = "Arrival time";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tlpProButtons
            // 
            this.tlpProButtons.ColumnCount = 1;
            this.tlpProButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpProButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpProButtons.Controls.Add(this.BtnClear, 0, 3);
            this.tlpProButtons.Controls.Add(this.BtnDelete, 0, 2);
            this.tlpProButtons.Controls.Add(this.BtnEdit, 0, 1);
            this.tlpProButtons.Controls.Add(this.BtnAdd, 0, 0);
            this.tlpProButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpProButtons.Location = new System.Drawing.Point(468, 3);
            this.tlpProButtons.Name = "tlpProButtons";
            this.tlpProButtons.RowCount = 4;
            this.tlpProFields.SetRowSpan(this.tlpProButtons, 3);
            this.tlpProButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpProButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpProButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpProButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpProButtons.Size = new System.Drawing.Size(194, 392);
            this.tlpProButtons.TabIndex = 4;
            // 
            // BtnClear
            // 
            this.BtnClear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(54)))), ((int)(((byte)(63)))));
            this.BtnClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnClear.FlatAppearance.BorderSize = 0;
            this.BtnClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.BtnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(54)))), ((int)(((byte)(63)))));
            this.BtnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.BtnClear.ForeColor = System.Drawing.Color.White;
            this.BtnClear.Location = new System.Drawing.Point(5, 299);
            this.BtnClear.Margin = new System.Windows.Forms.Padding(5);
            this.BtnClear.Name = "BtnClear";
            this.BtnClear.Size = new System.Drawing.Size(184, 88);
            this.BtnClear.TabIndex = 7;
            this.BtnClear.Text = "Clear";
            this.BtnClear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnClear.UseVisualStyleBackColor = false;
            this.BtnClear.Click += new System.EventHandler(this.BtnClear_Click);
            // 
            // BtnDelete
            // 
            this.BtnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(54)))), ((int)(((byte)(63)))));
            this.BtnDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnDelete.FlatAppearance.BorderSize = 0;
            this.BtnDelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.BtnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(54)))), ((int)(((byte)(63)))));
            this.BtnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.BtnDelete.ForeColor = System.Drawing.Color.White;
            this.BtnDelete.Location = new System.Drawing.Point(5, 201);
            this.BtnDelete.Margin = new System.Windows.Forms.Padding(5);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(184, 88);
            this.BtnDelete.TabIndex = 6;
            this.BtnDelete.Text = "Delete";
            this.BtnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnEdit
            // 
            this.BtnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(54)))), ((int)(((byte)(63)))));
            this.BtnEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnEdit.FlatAppearance.BorderSize = 0;
            this.BtnEdit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.BtnEdit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(54)))), ((int)(((byte)(63)))));
            this.BtnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.BtnEdit.ForeColor = System.Drawing.Color.White;
            this.BtnEdit.Location = new System.Drawing.Point(5, 103);
            this.BtnEdit.Margin = new System.Windows.Forms.Padding(5);
            this.BtnEdit.Name = "BtnEdit";
            this.BtnEdit.Size = new System.Drawing.Size(184, 88);
            this.BtnEdit.TabIndex = 5;
            this.BtnEdit.Text = "Edit";
            this.BtnEdit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnEdit.UseVisualStyleBackColor = false;
            this.BtnEdit.Click += new System.EventHandler(this.BtnEdit_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(54)))), ((int)(((byte)(63)))));
            this.BtnAdd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnAdd.FlatAppearance.BorderSize = 0;
            this.BtnAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(42)))), ((int)(((byte)(49)))));
            this.BtnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(54)))), ((int)(((byte)(63)))));
            this.BtnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.BtnAdd.ForeColor = System.Drawing.Color.White;
            this.BtnAdd.Location = new System.Drawing.Point(5, 5);
            this.BtnAdd.Margin = new System.Windows.Forms.Padding(5);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(184, 88);
            this.BtnAdd.TabIndex = 4;
            this.BtnAdd.Text = "Add";
            this.BtnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 132);
            this.label1.TabIndex = 1;
            this.label1.Text = "Process name*";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtProName
            // 
            this.txtProName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(35)))));
            this.txtProName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProName.ForeColor = System.Drawing.Color.White;
            this.txtProName.Location = new System.Drawing.Point(202, 25);
            this.txtProName.Margin = new System.Windows.Forms.Padding(3, 25, 3, 3);
            this.txtProName.MaxLength = 256;
            this.txtProName.Name = "txtProName";
            this.txtProName.Size = new System.Drawing.Size(260, 45);
            this.txtProName.TabIndex = 1;
            // 
            // numArrivalTime
            // 
            this.numArrivalTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(35)))));
            this.numArrivalTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numArrivalTime.ForeColor = System.Drawing.Color.White;
            this.numArrivalTime.Location = new System.Drawing.Point(202, 157);
            this.numArrivalTime.Margin = new System.Windows.Forms.Padding(3, 25, 3, 3);
            this.numArrivalTime.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numArrivalTime.Name = "numArrivalTime";
            this.numArrivalTime.Size = new System.Drawing.Size(260, 45);
            this.numArrivalTime.TabIndex = 2;
            // 
            // numBurstTime
            // 
            this.numBurstTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(35)))));
            this.numBurstTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numBurstTime.ForeColor = System.Drawing.Color.White;
            this.numBurstTime.Location = new System.Drawing.Point(202, 289);
            this.numBurstTime.Margin = new System.Windows.Forms.Padding(3, 25, 3, 3);
            this.numBurstTime.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numBurstTime.Name = "numBurstTime";
            this.numBurstTime.Size = new System.Drawing.Size(260, 45);
            this.numBurstTime.TabIndex = 3;
            // 
            // GbGanttChart
            // 
            this.GbGanttChart.BackColor = System.Drawing.Color.Transparent;
            this.GbGanttChart.Controls.Add(this.pnlGanttContainer);
            this.GbGanttChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GbGanttChart.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.GbGanttChart.ForeColor = System.Drawing.Color.White;
            this.GbGanttChart.Location = new System.Drawing.Point(674, 3);
            this.GbGanttChart.Name = "GbGanttChart";
            this.GbGanttChart.Size = new System.Drawing.Size(665, 398);
            this.GbGanttChart.TabIndex = 0;
            this.GbGanttChart.TabStop = false;
            this.GbGanttChart.Text = "Gantt Chart";
            // 
            // pnlGanttContainer
            // 
            this.pnlGanttContainer.AutoScroll = true;
            this.pnlGanttContainer.Controls.Add(this.DGV);
            this.pnlGanttContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGanttContainer.Location = new System.Drawing.Point(3, 41);
            this.pnlGanttContainer.Name = "pnlGanttContainer";
            this.pnlGanttContainer.Size = new System.Drawing.Size(659, 354);
            this.pnlGanttContainer.TabIndex = 19;
            // 
            // DGV
            // 
            this.DGV.AllowUserToAddRows = false;
            this.DGV.AllowUserToDeleteRows = false;
            this.DGV.AllowUserToResizeColumns = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(68)))), ((int)(((byte)(5)))));
            dataGridViewCellStyle6.NullValue = "0";
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(188)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.DGV.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            this.DGV.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(35)))));
            this.DGV.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(30)))), ((int)(((byte)(35)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(188)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV.DefaultCellStyle = dataGridViewCellStyle8;
            this.DGV.Enabled = false;
            this.DGV.EnableHeadersVisualStyles = false;
            this.DGV.GridColor = System.Drawing.Color.White;
            this.DGV.Location = new System.Drawing.Point(5, 11);
            this.DGV.Margin = new System.Windows.Forms.Padding(0);
            this.DGV.MultiSelect = false;
            this.DGV.Name = "DGV";
            this.DGV.ReadOnly = true;
            this.DGV.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(68)))), ((int)(((byte)(5)))));
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(135)))), ((int)(((byte)(188)))), ((int)(((byte)(62)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.DGV.RowHeadersVisible = false;
            this.DGV.RowHeadersWidth = 51;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(68)))), ((int)(((byte)(5)))));
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(180)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DGV.RowsDefaultCellStyle = dataGridViewCellStyle10;
            this.DGV.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.DGV.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DGV.RowTemplate.Height = 50;
            this.DGV.RowTemplate.ReadOnly = true;
            this.DGV.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.DGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DGV.Size = new System.Drawing.Size(10, 41);
            this.DGV.TabIndex = 18;
            this.DGV.TabStop = false;
            this.DGV.Visible = false;
            // 
            // SJF_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.tlpMain);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.Name = "SJF_UC";
            this.Size = new System.Drawing.Size(1354, 909);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ProDGV)).EndInit();
            this.tlpMain.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tlpProDataMain.ResumeLayout(false);
            this.tlpProFields.ResumeLayout(false);
            this.tlpProFields.PerformLayout();
            this.tlpProButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numArrivalTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBurstTime)).EndInit();
            this.GbGanttChart.ResumeLayout(false);
            this.pnlGanttContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnStartScheduling;
        private System.Windows.Forms.DataGridViewTextBoxColumn PName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PArrivalTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn PBurstTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn PPriority;
        private System.Windows.Forms.DataGridViewTextBoxColumn PStartTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn PFinishTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn PWaitTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn PId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PTurnAroundTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn PRemainingTime;
        private System.Windows.Forms.Label lblAVGWait;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblAVGTA;
        private System.Windows.Forms.Button BtnReset;
        private System.Windows.Forms.DataGridViewTextBoxColumn PIsWorking;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridView ProDGV;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tlpProDataMain;
        private System.Windows.Forms.TableLayoutPanel tlpProFields;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tlpProButtons;
        private System.Windows.Forms.Button BtnClear;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnEdit;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtProName;
        private System.Windows.Forms.NumericUpDown numArrivalTime;
        private System.Windows.Forms.NumericUpDown numBurstTime;
        private System.Windows.Forms.GroupBox GbGanttChart;
        private System.Windows.Forms.Panel pnlGanttContainer;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.CheckBox CheckBoxPreemptive;
        private System.Windows.Forms.Label lblTime;
    }
}
