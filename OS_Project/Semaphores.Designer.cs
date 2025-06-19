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
        private System.Windows.Forms.GroupBox groupBoxConsumerQueue;
        private System.Windows.Forms.FlowLayoutPanel flpProducerQueue;
        private System.Windows.Forms.FlowLayoutPanel flpConsumerQueue;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            // Form
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(600, 500);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Semaphore Visualizer";

            // numericBufferSize
            numericBufferSize = new System.Windows.Forms.NumericUpDown
            {
                Location = new System.Drawing.Point(12, 12),
                Size = new System.Drawing.Size(60, 28),
                Minimum = 1,
                Maximum = 10,
                Value = 2
            };

            // Buttons
            btnInitialize = new System.Windows.Forms.Button
            {
                Text = "Initialize",
                Location = new System.Drawing.Point(90, 12),
                Size = new System.Drawing.Size(90, 30),
                FlatStyle = System.Windows.Forms.FlatStyle.Flat
            };
            btnInitialize.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            btnInitialize.Click += btnInitialize_Click;

            btnStart = new System.Windows.Forms.Button
            {
                Text = "Start",
                Location = new System.Drawing.Point(190, 12),
                Size = new System.Drawing.Size(80, 30),
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                BackColor = System.Drawing.Color.FromArgb(0, 120, 215),
                ForeColor = System.Drawing.Color.White
            };
            btnStart.Click += btnStart_Click;

            btnStop = new System.Windows.Forms.Button
            {
                Text = "Stop",
                Location = new System.Drawing.Point(280, 12),
                Size = new System.Drawing.Size(80, 30),
                FlatStyle = System.Windows.Forms.FlatStyle.Flat,
                BackColor = System.Drawing.Color.FromArgb(232, 0, 0),
                ForeColor = System.Drawing.Color.White
            };
            btnStop.Click += btnStop_Click;

            // Buffer GroupBox
            groupBoxBuffer = new System.Windows.Forms.GroupBox
            {
                Text = "Buffer",
                Location = new System.Drawing.Point(12, 50),
                Size = new System.Drawing.Size(576, 100),
                Font = this.Font,
                ForeColor = System.Drawing.Color.FromArgb(40, 40, 40)
            };
            flpBuffer = new System.Windows.Forms.FlowLayoutPanel
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                Padding = new System.Windows.Forms.Padding(8),
                BackColor = System.Drawing.Color.WhiteSmoke
            };
            groupBoxBuffer.Controls.Add(flpBuffer);

            // Semaphores GroupBox
            groupBoxSemaphores = new System.Windows.Forms.GroupBox
            {
                Text = "Semaphores",
                Location = new System.Drawing.Point(12, 160),
                Size = new System.Drawing.Size(576, 80),
                Font = this.Font,
                ForeColor = System.Drawing.Color.FromArgb(40, 40, 40)
            };
            // Labels inside
            lblEmpty = new System.Windows.Forms.Label
            {
                Text = "Empty:",
                Location = new System.Drawing.Point(20, 35),
                AutoSize = true
            };
            lblEmptyVal = new System.Windows.Forms.Label
            {
                Text = "0",
                Location = new System.Drawing.Point(80, 35),
                AutoSize = true,
                Font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Bold)
            };
            lblFull = new System.Windows.Forms.Label
            {
                Text = "Full:",
                Location = new System.Drawing.Point(200, 35),
                AutoSize = true
            };
            lblFullVal = new System.Windows.Forms.Label
            {
                Text = "0",
                Location = new System.Drawing.Point(250, 35),
                AutoSize = true,
                Font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Bold)
            };
            lblMutex = new System.Windows.Forms.Label
            {
                Text = "Mutex:",
                Location = new System.Drawing.Point(360, 35),
                AutoSize = true
            };
            lblMutexVal = new System.Windows.Forms.Label
            {
                Text = "1",
                Location = new System.Drawing.Point(420, 35),
                AutoSize = true,
                Font = new System.Drawing.Font(this.Font, System.Drawing.FontStyle.Bold)
            };
            groupBoxSemaphores.Controls.AddRange(new System.Windows.Forms.Control[]{
                lblEmpty, lblEmptyVal, lblFull, lblFullVal, lblMutex, lblMutexVal
            });

            // Producer Queue
            groupBoxProducerQueue = new System.Windows.Forms.GroupBox
            {
                Text = "Producer Queue",
                Location = new System.Drawing.Point(12, 260),
                Size = new System.Drawing.Size(280, 220),
                Font = this.Font,
                ForeColor = System.Drawing.Color.FromArgb(40, 40, 40)
            };
            flpProducerQueue = new System.Windows.Forms.FlowLayoutPanel
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                Padding = new System.Windows.Forms.Padding(8),
                AutoScroll = true,
                BackColor = System.Drawing.Color.WhiteSmoke
            };
            groupBoxProducerQueue.Controls.Add(flpProducerQueue);

            // Consumer Queue
            groupBoxConsumerQueue = new System.Windows.Forms.GroupBox
            {
                Text = "Consumer Queue",
                Location = new System.Drawing.Point(308, 260),
                Size = new System.Drawing.Size(280, 220),
                Font = this.Font,
                ForeColor = System.Drawing.Color.FromArgb(40, 40, 40)
            };
            flpConsumerQueue = new System.Windows.Forms.FlowLayoutPanel
            {
                Dock = System.Windows.Forms.DockStyle.Fill,
                Padding = new System.Windows.Forms.Padding(8),
                AutoScroll = true,
                BackColor = System.Drawing.Color.WhiteSmoke
            };
            groupBoxConsumerQueue.Controls.Add(flpConsumerQueue);

            // Add all controls
            this.Controls.AddRange(new System.Windows.Forms.Control[]{
                numericBufferSize, btnInitialize, btnStart, btnStop,
                groupBoxBuffer, groupBoxSemaphores,
                groupBoxProducerQueue, groupBoxConsumerQueue
            });
        }
    }
}