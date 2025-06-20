namespace OS_Project
{
    partial class Semaphores
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.NumericUpDown numericBufferSize;
        private System.Windows.Forms.Button btnInitialize;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.GroupBox groupBoxBuffer;
        private System.Windows.Forms.FlowLayoutPanel flpBuffer;
        private System.Windows.Forms.GroupBox groupBoxSemaphores;
        private System.Windows.Forms.Label lblEmpty;
        private System.Windows.Forms.Label lblEmptyVal;
        private System.Windows.Forms.Label lblFull;
        private System.Windows.Forms.Label lblFullVal;
        private System.Windows.Forms.Label lblMutex;
        private System.Windows.Forms.Label lblMutexVal;
        private System.Windows.Forms.GroupBox groupBoxProducerQueue;
        private System.Windows.Forms.FlowLayoutPanel flpProducerQueue;
        private System.Windows.Forms.GroupBox groupBoxConsumerQueue;
        private System.Windows.Forms.FlowLayoutPanel flpConsumerQueue;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // Numeric Buffer Size
            this.numericBufferSize = new System.Windows.Forms.NumericUpDown();
            this.numericBufferSize.Location = new System.Drawing.Point(12, 12);
            this.numericBufferSize.Size = new System.Drawing.Size(60, 28);
            this.numericBufferSize.Minimum = 1;
            this.numericBufferSize.Maximum = 10;
            this.numericBufferSize.Value = 2;

            // Initialize Button
            this.btnInitialize = new System.Windows.Forms.Button();
            this.btnInitialize.Text = "Initialize";
            this.btnInitialize.Location = new System.Drawing.Point(90, 12);
            this.btnInitialize.Size = new System.Drawing.Size(90, 30);
            this.btnInitialize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInitialize.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnInitialize.Click += new System.EventHandler(this.btnInitialize_Click);

            // Start Button
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStart.Text = "Start";
            this.btnStart.Location = new System.Drawing.Point(190, 12);
            this.btnStart.Size = new System.Drawing.Size(80, 30);
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnStart.ForeColor = System.Drawing.Color.White;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);

            // Stop Button
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStop.Text = "Stop";
            this.btnStop.Location = new System.Drawing.Point(280, 12);
            this.btnStop.Size = new System.Drawing.Size(80, 30);
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(232, 0, 0);
            this.btnStop.ForeColor = System.Drawing.Color.White;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);

            // Buffer GroupBox
            this.groupBoxBuffer = new System.Windows.Forms.GroupBox();
            this.groupBoxBuffer.Text = "Buffer";
            this.groupBoxBuffer.Location = new System.Drawing.Point(12, 50);
            this.groupBoxBuffer.Size = new System.Drawing.Size(576, 100);
            this.flpBuffer = new System.Windows.Forms.FlowLayoutPanel();
            this.flpBuffer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpBuffer.Padding = new System.Windows.Forms.Padding(8);
            this.flpBuffer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBoxBuffer.Controls.Add(this.flpBuffer);

            // Semaphores GroupBox
            this.groupBoxSemaphores = new System.Windows.Forms.GroupBox();
            this.groupBoxSemaphores.Text = "Semaphores";
            this.groupBoxSemaphores.Location = new System.Drawing.Point(12, 160);
            this.groupBoxSemaphores.Size = new System.Drawing.Size(576, 80);

            this.lblEmpty = new System.Windows.Forms.Label();
            this.lblEmpty.Text = "Empty:";
            this.lblEmpty.Location = new System.Drawing.Point(20, 35);
            this.lblEmpty.AutoSize = true;

            this.lblEmptyVal = new System.Windows.Forms.Label();
            this.lblEmptyVal.Text = "0";
            this.lblEmptyVal.Location = new System.Drawing.Point(80, 35);
            this.lblEmptyVal.AutoSize = true;
            this.lblEmptyVal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            this.lblFull = new System.Windows.Forms.Label();
            this.lblFull.Text = "Full:";
            this.lblFull.Location = new System.Drawing.Point(200, 35);
            this.lblFull.AutoSize = true;

            this.lblFullVal = new System.Windows.Forms.Label();
            this.lblFullVal.Text = "0";
            this.lblFullVal.Location = new System.Drawing.Point(250, 35);
            this.lblFullVal.AutoSize = true;
            this.lblFullVal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            this.lblMutex = new System.Windows.Forms.Label();
            this.lblMutex.Text = "Mutex:";
            this.lblMutex.Location = new System.Drawing.Point(360, 35);
            this.lblMutex.AutoSize = true;

            this.lblMutexVal = new System.Windows.Forms.Label();
            this.lblMutexVal.Text = "1";
            this.lblMutexVal.Location = new System.Drawing.Point(420, 35);
            this.lblMutexVal.AutoSize = true;
            this.lblMutexVal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);

            this.groupBoxSemaphores.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.lblEmpty, this.lblEmptyVal,
                this.lblFull, this.lblFullVal,
                this.lblMutex, this.lblMutexVal
            });

            // Producer Queue GroupBox
            this.groupBoxProducerQueue = new System.Windows.Forms.GroupBox();
            this.groupBoxProducerQueue.Text = "Producer Queue";
            this.groupBoxProducerQueue.Location = new System.Drawing.Point(12, 260);
            this.groupBoxProducerQueue.Size = new System.Drawing.Size(280, 220);
            this.flpProducerQueue = new System.Windows.Forms.FlowLayoutPanel();
            this.flpProducerQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpProducerQueue.Padding = new System.Windows.Forms.Padding(8);
            this.flpProducerQueue.AutoScroll = true;
            this.flpProducerQueue.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBoxProducerQueue.Controls.Add(this.flpProducerQueue);

            // Consumer Queue GroupBox
            this.groupBoxConsumerQueue = new System.Windows.Forms.GroupBox();
            this.groupBoxConsumerQueue.Text = "Consumer Queue";
            this.groupBoxConsumerQueue.Location = new System.Drawing.Point(308, 260);
            this.groupBoxConsumerQueue.Size = new System.Drawing.Size(280, 220);
            this.flpConsumerQueue = new System.Windows.Forms.FlowLayoutPanel();
            this.flpConsumerQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpConsumerQueue.Padding = new System.Windows.Forms.Padding(8);
            this.flpConsumerQueue.AutoScroll = true;
            this.flpConsumerQueue.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBoxConsumerQueue.Controls.Add(this.flpConsumerQueue);

            // Add all controls to form
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.numericBufferSize,
                this.btnInitialize,
                this.btnStart,
                this.btnStop,
                this.groupBoxBuffer,
                this.groupBoxSemaphores,
                this.groupBoxProducerQueue,
                this.groupBoxConsumerQueue
            });

            // Final Form Properties (optional, if this file is a Form)
            this.Text = "Semaphore Buffer Simulation";
            this.ClientSize = new System.Drawing.Size(600, 500);
        }
    }
}
