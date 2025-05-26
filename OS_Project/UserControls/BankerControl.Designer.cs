using System.Windows.Forms;

namespace OS_Project
{
    partial class BankerControl
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
            this.lblAvailable = new System.Windows.Forms.Label();
            this.lblMax = new System.Windows.Forms.Label();
            this.lblAllocation = new System.Windows.Forms.Label();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.dgvAllocation = new System.Windows.Forms.DataGridView();
            this.dgvMax = new System.Windows.Forms.DataGridView();
            this.dgvNeed = new System.Windows.Forms.DataGridView();
            this.dgvAvailable = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTotalResources = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnCheckSafety = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.NoResources = new System.Windows.Forms.TextBox();
            this.NoProcesses = new System.Windows.Forms.TextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNeed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalResources)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAvailable
            // 
            this.lblAvailable.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAvailable.AutoSize = true;
            this.lblAvailable.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAvailable.Location = new System.Drawing.Point(455, 2);
            this.lblAvailable.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAvailable.Name = "lblAvailable";
            this.lblAvailable.Size = new System.Drawing.Size(45, 19);
            this.lblAvailable.TabIndex = 2;
            this.lblAvailable.Text = "Need";
            // 
            // lblMax
            // 
            this.lblMax.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMax.AutoSize = true;
            this.lblMax.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblMax.Location = new System.Drawing.Point(266, 2);
            this.lblMax.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMax.Name = "lblMax";
            this.lblMax.Size = new System.Drawing.Size(38, 19);
            this.lblMax.TabIndex = 1;
            this.lblMax.Text = "Max";
            // 
            // lblAllocation
            // 
            this.lblAllocation.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAllocation.AutoSize = true;
            this.lblAllocation.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblAllocation.Location = new System.Drawing.Point(56, 2);
            this.lblAllocation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAllocation.Name = "lblAllocation";
            this.lblAllocation.Size = new System.Drawing.Size(77, 19);
            this.lblAllocation.TabIndex = 0;
            this.lblAllocation.Text = "Allocation";
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 5;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.29239F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.78378F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 212F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 157F));
            this.tableLayoutPanel.Controls.Add(this.lblAllocation, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.lblMax, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.lblAvailable, 2, 0);
            this.tableLayoutPanel.Controls.Add(this.dgvAllocation, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.dgvMax, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.dgvNeed, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.dgvAvailable, 3, 1);
            this.tableLayoutPanel.Controls.Add(this.label1, 3, 0);
            this.tableLayoutPanel.Controls.Add(this.dgvTotalResources, 4, 1);
            this.tableLayoutPanel.Controls.Add(this.label2, 4, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(946, 652);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // dgvAllocation
            // 
            this.dgvAllocation.AllowUserToAddRows = false;
            this.dgvAllocation.AllowUserToDeleteRows = false;
            this.dgvAllocation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAllocation.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvAllocation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAllocation.Location = new System.Drawing.Point(2, 26);
            this.dgvAllocation.Margin = new System.Windows.Forms.Padding(2);
            this.dgvAllocation.Name = "dgvAllocation";
            this.dgvAllocation.RowHeadersVisible = false;
            this.dgvAllocation.RowHeadersWidth = 51;
            this.dgvAllocation.Size = new System.Drawing.Size(186, 624);
            this.dgvAllocation.TabIndex = 3;
            // 
            // dgvMax
            // 
            this.dgvMax.AllowUserToAddRows = false;
            this.dgvMax.AllowUserToDeleteRows = false;
            this.dgvMax.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMax.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvMax.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMax.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMax.Location = new System.Drawing.Point(192, 26);
            this.dgvMax.Margin = new System.Windows.Forms.Padding(2);
            this.dgvMax.Name = "dgvMax";
            this.dgvMax.RowHeadersVisible = false;
            this.dgvMax.RowHeadersWidth = 51;
            this.dgvMax.Size = new System.Drawing.Size(187, 624);
            this.dgvMax.TabIndex = 4;
            // 
            // dgvNeed
            // 
            this.dgvNeed.AllowUserToAddRows = false;
            this.dgvNeed.AllowUserToDeleteRows = false;
            this.dgvNeed.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNeed.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvNeed.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNeed.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNeed.Location = new System.Drawing.Point(383, 26);
            this.dgvNeed.Margin = new System.Windows.Forms.Padding(2);
            this.dgvNeed.Name = "dgvNeed";
            this.dgvNeed.ReadOnly = true;
            this.dgvNeed.RowHeadersVisible = false;
            this.dgvNeed.RowHeadersWidth = 51;
            this.dgvNeed.Size = new System.Drawing.Size(190, 624);
            this.dgvNeed.TabIndex = 5;
            // 
            // dgvAvailable
            // 
            this.dgvAvailable.AllowUserToAddRows = false;
            this.dgvAvailable.AllowUserToDeleteRows = false;
            this.dgvAvailable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvAvailable.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvAvailable.ColumnHeadersHeight = 29;
            this.dgvAvailable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAvailable.Location = new System.Drawing.Point(577, 26);
            this.dgvAvailable.Margin = new System.Windows.Forms.Padding(2);
            this.dgvAvailable.Name = "dgvAvailable";
            this.dgvAvailable.ReadOnly = true;
            this.dgvAvailable.RowHeadersVisible = false;
            this.dgvAvailable.RowHeadersWidth = 51;
            this.dgvAvailable.RowTemplate.Height = 24;
            this.dgvAvailable.Size = new System.Drawing.Size(208, 624);
            this.dgvAvailable.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(645, 2);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 19);
            this.label1.TabIndex = 8;
            this.label1.Text = "Available";
            // 
            // dgvTotalResources
            // 
            this.dgvTotalResources.AllowUserToAddRows = false;
            this.dgvTotalResources.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTotalResources.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvTotalResources.ColumnHeadersHeight = 29;
            this.dgvTotalResources.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTotalResources.Location = new System.Drawing.Point(789, 26);
            this.dgvTotalResources.Margin = new System.Windows.Forms.Padding(2);
            this.dgvTotalResources.Name = "dgvTotalResources";
            this.dgvTotalResources.RowHeadersVisible = false;
            this.dgvTotalResources.RowHeadersWidth = 51;
            this.dgvTotalResources.RowTemplate.Height = 24;
            this.dgvTotalResources.Size = new System.Drawing.Size(155, 624);
            this.dgvTotalResources.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(810, 2);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 19);
            this.label2.TabIndex = 11;
            this.label2.Text = "Total Resources";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Green;
            this.lblStatus.Location = new System.Drawing.Point(317, 84);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(66, 24);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Status";
            // 
            // btnCheckSafety
            // 
            this.btnCheckSafety.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCheckSafety.BackColor = System.Drawing.Color.SteelBlue;
            this.btnCheckSafety.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheckSafety.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCheckSafety.ForeColor = System.Drawing.Color.White;
            this.btnCheckSafety.Location = new System.Drawing.Point(167, 74);
            this.btnCheckSafety.Margin = new System.Windows.Forms.Padding(2);
            this.btnCheckSafety.Name = "btnCheckSafety";
            this.btnCheckSafety.Size = new System.Drawing.Size(116, 40);
            this.btnCheckSafety.TabIndex = 6;
            this.btnCheckSafety.Text = "Check Safety";
            this.btnCheckSafety.UseVisualStyleBackColor = false;
            this.btnCheckSafety.Click += new System.EventHandler(this.btnCheckSafety_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.NoResources);
            this.groupBox1.Controls.Add(this.NoProcesses);
            this.groupBox1.Controls.Add(this.btnCheckSafety);
            this.groupBox1.Controls.Add(this.lblStatus);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 447);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(946, 205);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Control";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 93);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "No Resources";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 28);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "No Processes";
            // 
            // NoResources
            // 
            this.NoResources.Location = new System.Drawing.Point(38, 114);
            this.NoResources.Margin = new System.Windows.Forms.Padding(2);
            this.NoResources.Name = "NoResources";
            this.NoResources.Size = new System.Drawing.Size(77, 20);
            this.NoResources.TabIndex = 9;
            // 
            // NoProcesses
            // 
            this.NoProcesses.Location = new System.Drawing.Point(38, 51);
            this.NoProcesses.Margin = new System.Windows.Forms.Padding(2);
            this.NoProcesses.Name = "NoProcesses";
            this.NoProcesses.Size = new System.Drawing.Size(77, 20);
            this.NoProcesses.TabIndex = 8;
            // 
            // BankerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tableLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BankerControl";
            this.Size = new System.Drawing.Size(946, 652);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNeed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAvailable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTotalResources)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label lblAllocation;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Label lblAvailable;
        private System.Windows.Forms.DataGridView dgvAllocation;
        private System.Windows.Forms.DataGridView dgvMax;
        private System.Windows.Forms.DataGridView dgvNeed;
        private System.Windows.Forms.Label label1;
        private Label lblStatus;
        private Button btnCheckSafety;
        private GroupBox groupBox1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DataGridView dgvAvailable;
        private DataGridView dgvTotalResources;
        private Label label2;
        private TextBox NoProcesses;
        private Label label4;
        private Label label3;
        private TextBox NoResources;
    }
}
