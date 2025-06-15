namespace OS_Project.UserControls.PageReplacementControl
{
    partial class PAGE_UI
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnOPTimal = new System.Windows.Forms.Button();
            this.btnLRU = new System.Windows.Forms.Button();
            this.btnClock = new System.Windows.Forms.Button();
            this.btnFIFO = new System.Windows.Forms.Button();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.Controls.Add(this.btnOPTimal);
            this.panel2.Controls.Add(this.btnLRU);
            this.panel2.Controls.Add(this.btnClock);
            this.panel2.Controls.Add(this.btnFIFO);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 759);
            this.panel2.TabIndex = 7;
            // 
            // btnOPTimal
            // 
            this.btnOPTimal.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnOPTimal.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnOPTimal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.btnOPTimal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOPTimal.Location = new System.Drawing.Point(0, 189);
            this.btnOPTimal.Name = "btnOPTimal";
            this.btnOPTimal.Size = new System.Drawing.Size(200, 63);
            this.btnOPTimal.TabIndex = 2;
            this.btnOPTimal.Text = "OPTimal";
            this.btnOPTimal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOPTimal.UseVisualStyleBackColor = false;
            this.btnOPTimal.Click += new System.EventHandler(this.btnOPTimal_Click);
            // 
            // btnLRU
            // 
            this.btnLRU.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLRU.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLRU.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.btnLRU.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLRU.Location = new System.Drawing.Point(0, 126);
            this.btnLRU.Name = "btnLRU";
            this.btnLRU.Size = new System.Drawing.Size(200, 63);
            this.btnLRU.TabIndex = 5;
            this.btnLRU.Text = "LRU";
            this.btnLRU.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLRU.UseVisualStyleBackColor = false;
            this.btnLRU.Click += new System.EventHandler(this.btnLRU_Click);
            // 
            // btnClock
            // 
            this.btnClock.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClock.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnClock.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.btnClock.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClock.Location = new System.Drawing.Point(0, 63);
            this.btnClock.Name = "btnClock";
            this.btnClock.Size = new System.Drawing.Size(200, 63);
            this.btnClock.TabIndex = 3;
            this.btnClock.Text = "CLOCK";
            this.btnClock.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClock.UseVisualStyleBackColor = false;
            this.btnClock.Click += new System.EventHandler(this.btnClock_Click);
            // 
            // btnFIFO
            // 
            this.btnFIFO.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnFIFO.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFIFO.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F);
            this.btnFIFO.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnFIFO.Location = new System.Drawing.Point(0, 0);
            this.btnFIFO.Name = "btnFIFO";
            this.btnFIFO.Size = new System.Drawing.Size(200, 63);
            this.btnFIFO.TabIndex = 4;
            this.btnFIFO.Text = "FIFO";
            this.btnFIFO.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFIFO.UseVisualStyleBackColor = false;
            this.btnFIFO.Click += new System.EventHandler(this.btnFIFO_Click);
            // 
            // panelMain
            // 
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(200, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1066, 759);
            this.panelMain.TabIndex = 8;
            // 
            // PAGE_UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panel2);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "PAGE_UI";
            this.Size = new System.Drawing.Size(1266, 759);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnOPTimal;
        private System.Windows.Forms.Button btnLRU;
        private System.Windows.Forms.Button btnClock;
        private System.Windows.Forms.Button btnFIFO;
        private System.Windows.Forms.Panel panelMain;
    }
}
