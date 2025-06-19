using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace OS_Project
{
    public partial class Semaphores : Form
    {
        private int[] buffer;
        private int bufferSize, empty, full, mutex;
        private Dictionary<string, bool> producerWaiting;
        private Dictionary<string, bool> consumerWaiting;
        private List<Timer> producerTimers;
        private List<Timer> consumerTimers;
        private Timer unblockTimer;

        public Semaphores()
        {
            InitializeComponent();
            // Khởi tạo các cấu trúc dữ liệu
            producerWaiting = new Dictionary<string, bool>();
            consumerWaiting = new Dictionary<string, bool>();
            producerTimers = new List<Timer>();
            consumerTimers = new List<Timer>();
            Init();
        }

        private void btnInitialize_Click(object sender, EventArgs e)
            => Init();

        private void btnStart_Click(object sender, EventArgs e)
            => StartSimulation();

        private void btnStop_Click(object sender, EventArgs e)
            => StopSimulation();

        private void Init()
        {
            // Dừng mọi timer đang chạy (nếu có)
            StopSimulation();

            // Thiết lập lại buffer và semaphore
            bufferSize = (int)numericBufferSize.Value;
            buffer = new int[bufferSize];  // các giá trị 0 nghĩa là empty
            empty = bufferSize;
            full = 0;
            mutex = 1;

            // Đánh dấu tất cả producer/consumer chưa chờ
            producerWaiting["1"] = false;
            producerWaiting["2"] = false;
            consumerWaiting["1"] = false;
            consumerWaiting["2"] = false;

            // Render UI
            RenderBuffer();
            UpdateSemaphores();
            flpProducerQueue.Controls.Clear();
            flpConsumerQueue.Controls.Clear();
        }

        private void StartSimulation()
        {
            Init();

            // Timer cho Producer 1/2
            producerTimers.Add(CreateTimer(1000, (s, ev) => TryProduce("1")));
            producerTimers.Add(CreateTimer(1200, (s, ev) => TryProduce("2")));

            // Timer cho Consumer 1/2
            consumerTimers.Add(CreateTimer(1500, (s, ev) => TryConsume("1")));
            consumerTimers.Add(CreateTimer(1700, (s, ev) => TryConsume("2")));

            // Timer kiểm tra lại các queue (unblock)
            unblockTimer = CreateTimer(400, (s, ev) => {
                foreach (var id in new[] { "1", "2" })
                {
                    if (producerWaiting[id]) TryProduce(id);
                    if (consumerWaiting[id]) TryConsume(id);
                }
            });
        }

        private void StopSimulation()
        {
            // Dừng và xóa tất cả timers
            foreach (var t in producerTimers) t.Stop();
            foreach (var t in consumerTimers) t.Stop();
            unblockTimer?.Stop();

            producerTimers.Clear();
            consumerTimers.Clear();
        }

        private Timer CreateTimer(int interval, EventHandler handler)
        {
            var t = new Timer { Interval = interval };
            t.Tick += handler;
            t.Start();
            return t;
        }

        private void TryProduce(string id)
        {
            if (empty > 0 && mutex > 0)
            {
                // Enter critical section
                mutex = 0;
                var item = new Random().Next(10, 100);
                for (int i = 0; i < bufferSize; i++)
                {
                    if (buffer[i] == 0)
                    {
                        buffer[i] = item;
                        break;
                    }
                }
                empty--;
                full++;
                mutex = 1; // Exit critical section

                // Nếu đang chờ, bỏ chờ
                producerWaiting[id] = false;
                DequeueProcess(flpProducerQueue, $"P{id}");
                RenderBuffer();
                UpdateSemaphores();
            }
            else if (!producerWaiting[id])
            {
                // Chưa chờ thì thêm vào hàng đợi
                producerWaiting[id] = true;
                EnqueueProcess(flpProducerQueue, $"P{id}");
            }
        }

        private void TryConsume(string id)
        {
            if (full > 0 && mutex > 0)
            {
                mutex = 0;
                for (int i = 0; i < bufferSize; i++)
                {
                    if (buffer[i] != 0)
                    {
                        buffer[i] = 0;
                        break;
                    }
                }
                full--;
                empty++;
                mutex = 1;

                consumerWaiting[id] = false;
                DequeueProcess(flpConsumerQueue, $"C{id}");
                RenderBuffer();
                UpdateSemaphores();
            }
            else if (!consumerWaiting[id])
            {
                consumerWaiting[id] = true;
                EnqueueProcess(flpConsumerQueue, $"C{id}");
            }
        }

        private void RenderBuffer()
        {
            flpBuffer.Controls.Clear();
            for (int i = 0; i < bufferSize; i++)
            {
                var lbl = new Label
                {
                    Text = buffer[i] != 0 ? buffer[i].ToString() : "",
                    TextAlign = ContentAlignment.MiddleCenter,
                    BackColor = buffer[i] != 0 ? Color.Green : Color.LightGray,
                    ForeColor = buffer[i] != 0 ? Color.White : Color.Black,
                    BorderStyle = BorderStyle.FixedSingle,
                    Size = new Size(60, 60),
                    Margin = new Padding(5)
                };
                flpBuffer.Controls.Add(lbl);
            }
        }

        private void UpdateSemaphores()
        {
            lblEmptyVal.Text = empty.ToString();
            lblFullVal.Text = full.ToString();
            lblMutexVal.Text = mutex.ToString();
        }

        private void EnqueueProcess(FlowLayoutPanel panel, string label)
        {
            var lbl = new Label
            {
                Name = $"lbl{label}",
                Text = label,
                AutoSize = false,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Orange,
                ForeColor = Color.White,
                Padding = new Padding(4),
                Margin = new Padding(2),
                Width = panel.ClientSize.Width - 10
            };
            panel.Controls.Add(lbl);
        }

        private void DequeueProcess(FlowLayoutPanel panel, string label)
        {
            var ctl = panel.Controls.Find($"lbl{label}", false).FirstOrDefault();
            if (ctl != null)
                panel.Controls.Remove(ctl);
        }
    }
}
