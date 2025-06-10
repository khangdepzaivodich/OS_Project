namespace OS_Project.UserControls.CpuSchedulingControl
{
    partial class CPU_UI_UC
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPriority = new System.Windows.Forms.Button();
            this.btnRR = new System.Windows.Forms.Button();
            this.btnSJF = new System.Windows.Forms.Button();
            this.btnFCFS = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(200, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1167, 896);
            this.panelMain.TabIndex = 10;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.Controls.Add(this.btnPriority);
            this.panel2.Controls.Add(this.btnRR);
            this.panel2.Controls.Add(this.btnSJF);
            this.panel2.Controls.Add(this.btnFCFS);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 896);
            this.panel2.TabIndex = 9;
            // 
            // btnPriority
            // 
            this.btnPriority.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPriority.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPriority.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.btnPriority.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPriority.Location = new System.Drawing.Point(0, 189);
            this.btnPriority.Name = "btnPriority";
            this.btnPriority.Size = new System.Drawing.Size(200, 63);
            this.btnPriority.TabIndex = 6;
            this.btnPriority.Text = "PRIORITY";
            this.btnPriority.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPriority.UseVisualStyleBackColor = false;
            this.btnPriority.Click += new System.EventHandler(this.btnPriority_Click);
            // 
            // btnRR
            // 
            this.btnRR.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRR.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnRR.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.btnRR.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRR.Location = new System.Drawing.Point(0, 126);
            this.btnRR.Name = "btnRR";
            this.btnRR.Size = new System.Drawing.Size(200, 63);
            this.btnRR.TabIndex = 2;
            this.btnRR.Text = "ROUND ROBIN";
            this.btnRR.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRR.UseVisualStyleBackColor = false;
            this.btnRR.Click += new System.EventHandler(this.btnRR_Click);
            // 
            // btnSJF
            // 
            this.btnSJF.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSJF.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSJF.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.btnSJF.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSJF.Location = new System.Drawing.Point(0, 63);
            this.btnSJF.Name = "btnSJF";
            this.btnSJF.Size = new System.Drawing.Size(200, 63);
            this.btnSJF.TabIndex = 3;
            this.btnSJF.Text = "SJF AND STRF";
            this.btnSJF.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSJF.UseVisualStyleBackColor = false;
            this.btnSJF.Click += new System.EventHandler(this.btnSJF_Click);
            // 
            // btnFCFS
            // 
            this.btnFCFS.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnFCFS.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFCFS.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.btnFCFS.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnFCFS.Location = new System.Drawing.Point(0, 0);
            this.btnFCFS.Name = "btnFCFS";
            this.btnFCFS.Size = new System.Drawing.Size(200, 63);
            this.btnFCFS.TabIndex = 4;
            this.btnFCFS.Text = "FCFS";
            this.btnFCFS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFCFS.UseVisualStyleBackColor = false;
            this.btnFCFS.Click += new System.EventHandler(this.btnFCFS_Click);
            // 
            // CPU_UI_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panel2);
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.Name = "CPU_UI_UC";
            this.Size = new System.Drawing.Size(1367, 896);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnRR;
        private System.Windows.Forms.Button btnSJF;
        private System.Windows.Forms.Button btnFCFS;
        private System.Windows.Forms.Button btnPriority;
    }
}
