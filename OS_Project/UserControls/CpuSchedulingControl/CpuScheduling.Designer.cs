using System.Windows.Forms;

namespace OS_Project.CpuSchedulingControl.cs
{
    partial class CpuScheduling
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
            this.ProcessLog = new System.Windows.Forms.TextBox();
            this.Process_TimeLB = new System.Windows.Forms.Label();
            this.ProcessNameLB = new System.Windows.Forms.Label();
            this.ProcessNameTB = new System.Windows.Forms.TextBox();
            this.BrustTimeTB = new System.Windows.Forms.TextBox();
            this.FCFS_BT = new System.Windows.Forms.Button();
            this.SJF_BT = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.AddingClickBT = new System.Windows.Forms.Button();
            this.ClearBT = new System.Windows.Forms.Button();
            this.ProcessGrid = new System.Windows.Forms.DataGridView();
            this.RR_Size = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelContainer = new System.Windows.Forms.Panel();
            this.panelDrawing = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.ProcessGrid)).BeginInit();
            this.panelContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProcessLog
            // 
            this.ProcessLog.Location = new System.Drawing.Point(904, 0);
            this.ProcessLog.Multiline = true;
            this.ProcessLog.Name = "ProcessLog";
            this.ProcessLog.ReadOnly = true;
            this.ProcessLog.Size = new System.Drawing.Size(368, 640);
            this.ProcessLog.TabIndex = 0;
            // 
            // Process_TimeLB
            // 
            this.Process_TimeLB.AutoSize = true;
            this.Process_TimeLB.Location = new System.Drawing.Point(557, 25);
            this.Process_TimeLB.Name = "Process_TimeLB";
            this.Process_TimeLB.Size = new System.Drawing.Size(57, 13);
            this.Process_TimeLB.TabIndex = 1;
            this.Process_TimeLB.Text = "Brust Time";
            // 
            // ProcessNameLB
            // 
            this.ProcessNameLB.AutoSize = true;
            this.ProcessNameLB.Location = new System.Drawing.Point(124, 25);
            this.ProcessNameLB.Name = "ProcessNameLB";
            this.ProcessNameLB.Size = new System.Drawing.Size(76, 13);
            this.ProcessNameLB.TabIndex = 2;
            this.ProcessNameLB.Text = "Process Name";
            // 
            // ProcessNameTB
            // 
            this.ProcessNameTB.Location = new System.Drawing.Point(51, 68);
            this.ProcessNameTB.Name = "ProcessNameTB";
            this.ProcessNameTB.Size = new System.Drawing.Size(213, 20);
            this.ProcessNameTB.TabIndex = 3;
            // 
            // BrustTimeTB
            // 
            this.BrustTimeTB.Location = new System.Drawing.Point(488, 68);
            this.BrustTimeTB.Name = "BrustTimeTB";
            this.BrustTimeTB.Size = new System.Drawing.Size(213, 20);
            this.BrustTimeTB.TabIndex = 4;
            // 
            // FCFS_BT
            // 
            this.FCFS_BT.Location = new System.Drawing.Point(51, 152);
            this.FCFS_BT.Name = "FCFS_BT";
            this.FCFS_BT.Size = new System.Drawing.Size(106, 58);
            this.FCFS_BT.TabIndex = 5;
            this.FCFS_BT.Text = "First Come First Serve ";
            this.FCFS_BT.UseVisualStyleBackColor = true;
            this.FCFS_BT.Click += new System.EventHandler(this.FCFS_BT_Click);
            // 
            // SJF_BT
            // 
            this.SJF_BT.Location = new System.Drawing.Point(302, 152);
            this.SJF_BT.Name = "SJF_BT";
            this.SJF_BT.Size = new System.Drawing.Size(106, 58);
            this.SJF_BT.TabIndex = 6;
            this.SJF_BT.Text = "Shortest Job First";
            this.SJF_BT.UseVisualStyleBackColor = true;
            this.SJF_BT.Click += new System.EventHandler(this.SJF_BT_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(508, 152);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(106, 58);
            this.button3.TabIndex = 7;
            this.button3.Text = "Round Robin";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // AddingClickBT
            // 
            this.AddingClickBT.Location = new System.Drawing.Point(771, 30);
            this.AddingClickBT.Name = "AddingClickBT";
            this.AddingClickBT.Size = new System.Drawing.Size(106, 58);
            this.AddingClickBT.TabIndex = 9;
            this.AddingClickBT.Text = "Adding Process";
            this.AddingClickBT.UseVisualStyleBackColor = true;
            this.AddingClickBT.Click += new System.EventHandler(this.AddingClickBT_Click);
            // 
            // ClearBT
            // 
            this.ClearBT.Location = new System.Drawing.Point(771, 152);
            this.ClearBT.Name = "ClearBT";
            this.ClearBT.Size = new System.Drawing.Size(106, 58);
            this.ClearBT.TabIndex = 10;
            this.ClearBT.Text = "Clear";
            this.ClearBT.UseVisualStyleBackColor = true;
            this.ClearBT.Click += new System.EventHandler(this.ClearBT_Click);
            // 
            // ProcessGrid
            // 
            this.ProcessGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.ProcessGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ProcessGrid.Location = new System.Drawing.Point(51, 322);
            this.ProcessGrid.Name = "ProcessGrid";
            this.ProcessGrid.Size = new System.Drawing.Size(826, 318);
            this.ProcessGrid.TabIndex = 11;
            // 
            // RR_Size
            // 
            this.RR_Size.Location = new System.Drawing.Point(488, 112);
            this.RR_Size.Name = "RR_Size";
            this.RR_Size.Size = new System.Drawing.Size(213, 20);
            this.RR_Size.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(557, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Round Robin";
            // 
            // panelContainer
            // 
            this.panelContainer.AutoScroll = true;
            this.panelContainer.Controls.Add(this.panelDrawing);
            this.panelContainer.Location = new System.Drawing.Point(51, 237);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(826, 79);
            this.panelContainer.TabIndex = 14;
            // 
            // panelDrawing
            // 
            this.panelDrawing.Location = new System.Drawing.Point(17, 14);
            this.panelDrawing.Name = "panelDrawing";
            this.panelDrawing.Size = new System.Drawing.Size(790, 50);
            this.panelDrawing.TabIndex = 0;
            this.panelDrawing.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDrawing_Paint);
            // 
            // CpuScheduling
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelContainer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RR_Size);
            this.Controls.Add(this.ProcessGrid);
            this.Controls.Add(this.ClearBT);
            this.Controls.Add(this.AddingClickBT);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.SJF_BT);
            this.Controls.Add(this.FCFS_BT);
            this.Controls.Add(this.BrustTimeTB);
            this.Controls.Add(this.ProcessNameTB);
            this.Controls.Add(this.ProcessNameLB);
            this.Controls.Add(this.Process_TimeLB);
            this.Controls.Add(this.ProcessLog);
            this.Name = "CpuScheduling";
            this.Size = new System.Drawing.Size(1491, 678);
            this.Load += new System.EventHandler(this.CpuScheduling_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ProcessGrid)).EndInit();
            this.panelContainer.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ProcessLog;
        private System.Windows.Forms.Label Process_TimeLB;
        private System.Windows.Forms.Label ProcessNameLB;
        private System.Windows.Forms.TextBox ProcessNameTB;
        private System.Windows.Forms.TextBox BrustTimeTB;
        private System.Windows.Forms.Button FCFS_BT;
        private System.Windows.Forms.Button SJF_BT;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button AddingClickBT;
        private System.Windows.Forms.Button ClearBT;
        private System.Windows.Forms.DataGridView ProcessGrid;
        private TextBox RR_Size;
        private Label label1;
        private Panel panelContainer;
        private Panel panelDrawing;
    }
}
