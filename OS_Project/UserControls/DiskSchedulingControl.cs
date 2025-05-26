using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OS_Project
{
    public partial class DiskSchedulingControl : UserControl
    {
        private List<int> lastSeekSequence = new List<int>();

        public DiskSchedulingControl()
        {
            InitializeComponent();

            comboBox1.Items.AddRange(new string[]
            {
                "FCFS",
                "SSTF",
                "SCAN",
                "LOOK",
                "C-SCAN",
                "C-LOOK"
            });
            comboBox1.SelectedIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            comboBox2.Items.AddRange(new string[]
            {
                "Left",
                "Right"
            });
            comboBox2.SelectedIndex = 0;

            btnRun.Click += BtnRun_Click;
            panelChart.Paint += PanelChart_Paint;
            rtbResult.Font = new Font("Arial", 10);
        }
        private void BtnRun_Click(object sender, EventArgs e)
        {
            string algorithm = comboBox1.SelectedItem.ToString();

            switch (algorithm)
            {
                case "FCFS":
                    RunFCFS();
                    break;
                case "SSTF":
                    RunSSTF();
                    break;
                case "SCAN":
                    RunSCAN();
                    break;
                case "LOOK":
                    RunLOOK();
                    break;
                case "C-SCAN":
                    RunCSCAN();
                    break;
                case "C-LOOK":
                    RunCLOOK();
                    break;
                default:
                    //MessageBox.Show("Thuật toán chưa được hỗ trợ.");
                    break;
            }
        }
        private void RunFCFS()
        {
            if (string.IsNullOrWhiteSpace(txtStartHead.Text))
            {
                MessageBox.Show("Vui lòng nhập vị trí đầu đọc ban đầu.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtRequests.Text))
            {
                MessageBox.Show("Vui lòng nhập các Request.");
                return;
            }

            int start;
            if (!int.TryParse(txtStartHead.Text, out start))
            {
                MessageBox.Show("Vị trí đầu đọc không hợp lệ.");
                return;
            }

            int[] requests;
            try
            {
                requests = txtRequests.Text.Split(',')
                                           .Select(r => int.Parse(r.Trim()))
                                           .ToArray();
            }
            catch
            {
                MessageBox.Show("Request không hợp lệ.");
                return;
            }

            int totalSeek = 0;
            int current = start;
            List<string> steps = new List<string>();
            List<int> seekSequence = new List<int> { start };

            foreach (int req in requests)
            {
                totalSeek += Math.Abs(req - current);
                steps.Add($"{current} → {req} ({Math.Abs(req - current)})");
                current = req;
                seekSequence.Add(current);
            }

            rtbResult.Text = $"Thuật toán First-Come, First-Served\n\nTổng seek time: {totalSeek}\n\nChi tiết:\n{string.Join("\n", steps)}";
            lastSeekSequence = seekSequence;
            panelChart.Invalidate();
        }
        private void RunSSTF()
        {
            if (string.IsNullOrWhiteSpace(txtStartHead.Text))
            {
                MessageBox.Show("Vui lòng nhập vị trí đầu đọc ban đầu.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtRequests.Text))
            {
                MessageBox.Show("Vui lòng nhập các Request.");
                return;
            }

            int start;
            if (!int.TryParse(txtStartHead.Text, out start))
            {
                MessageBox.Show("Vị trí đầu đọc không hợp lệ.");
                return;
            }

            int[] requests;
            try
            {
                requests = txtRequests.Text.Split(',')
                                           .Select(r => int.Parse(r.Trim()))
                                           .ToArray();
            }
            catch
            {
                MessageBox.Show("Request không hợp lệ.");
                return;
            }

            List<int> remaining = new List<int>(requests);
            List<string> steps = new List<string>();
            List<int> seekSequence = new List<int> { start };
            int totalSeek = 0;
            int current = start;

            while (remaining.Count > 0)
            {
                int closest = remaining.OrderBy(r => Math.Abs(r - current)).First();
                int distance = Math.Abs(closest - current);
                totalSeek += distance;
                steps.Add($"{current} → {closest} ({distance})");
                current = closest;
                seekSequence.Add(current);
                remaining.Remove(closest);
            }
            rtbResult.Text = $"Thuật toán Shortest Seek Time First\n\nTổng seek time: {totalSeek}\n\nChi tiết:\n{string.Join("\n", steps)}";
            lastSeekSequence = seekSequence;
            panelChart.Invalidate();
        }
        private void RunSCAN()
        {
            if (string.IsNullOrWhiteSpace(txtStartHead.Text))
            {
                MessageBox.Show("Vui lòng nhập vị trí đầu đọc ban đầu.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtRequests.Text))
            {
                MessageBox.Show("Vui lòng nhập các Request.");
                return;
            }

            int start;
            if (!int.TryParse(txtStartHead.Text, out start))
            {
                MessageBox.Show("Vị trí đầu đọc không hợp lệ.");
                return;
            }
            if (!int.TryParse(txtFrom.Text, out int diskMin) ||
                !int.TryParse(txtTo.Text, out int diskMax) ||
                diskMin >= diskMax)
            {
                MessageBox.Show("Vui lòng nhập phạm vi đĩa hợp lệ.");
                return;
            }

            int[] requests;
            try
            {
                requests = txtRequests.Text.Split(',')
                                           .Select(r => int.Parse(r.Trim()))
                                           .ToArray();
            }
            catch
            {
                MessageBox.Show("Request không hợp lệ.");
                return;
            }

            foreach (int req in requests)
            {
                if (req < diskMin || req >= diskMax)
                {
                    MessageBox.Show($"Request vượt phạm vi đĩa.");
                    return;
                }
            }
            if (requests.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập các Request hợp lệ.");
                return;
            }

            string direction = comboBox2.SelectedItem?.ToString() ?? "Right";
            int current = start;
            int totalSeek = 0;
            List<int> seekSequence = new List<int> { start };
            List<string> steps = new List<string>();

            Array.Sort(requests);
            List<int> left = requests.Where(r => r < current).ToList();
            List<int> right = requests.Where(r => r >= current).ToList();

            if (direction == "Left")
            {
                left.Reverse();
                foreach (int r in left)
                {
                    totalSeek += Math.Abs(current - r);
                    steps.Add($"{current} → {r} ({Math.Abs(current - r)})");
                    current = r;
                    seekSequence.Add(current);
                }
                if (left.Count > 0 && current != diskMin)
                {
                    totalSeek += Math.Abs(current - diskMin);
                    steps.Add($"{current} → {diskMin} ({Math.Abs(current - diskMin)})");
                    current = diskMin;
                    seekSequence.Add(current);
                }

                foreach (int r in right)
                {
                    totalSeek += Math.Abs(current - r);
                    steps.Add($"{current} → {r} ({Math.Abs(current - r)})");
                    current = r;
                    seekSequence.Add(current);
                }
            }
            else
            {
                foreach (int r in right)
                {
                    totalSeek += Math.Abs(current - r);
                    steps.Add($"{current} → {r} ({Math.Abs(current - r)})");
                    current = r;
                    seekSequence.Add(current);
                }
                if (right.Count > 0 && current != diskMax)
                {
                    totalSeek += Math.Abs(current - diskMax);
                    steps.Add($"{current} → {diskMax} ({Math.Abs(current - diskMax)})");
                    current = diskMax;
                    seekSequence.Add(current);
                }

                left.Reverse();
                foreach (int r in left)
                {
                    totalSeek += Math.Abs(current - r);
                    steps.Add($"{current} → {r} ({Math.Abs(current - r)})");
                    current = r;
                    seekSequence.Add(current);
                }
            }

            rtbResult.Text = $"Thuật toán SCAN (Hướng: {direction})\n\nTổng seek time: {totalSeek}\n\nChi tiết:\n{string.Join("\n", steps)}";
            lastSeekSequence = seekSequence;
            panelChart.Invalidate();
        }
        private void RunLOOK()
        {
            if (string.IsNullOrWhiteSpace(txtStartHead.Text))
            {
                MessageBox.Show("Vui lòng nhập vị trí đầu đọc ban đầu.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtRequests.Text))
            {
                MessageBox.Show("Vui lòng nhập các Request.");
                return;
            }
            if (!int.TryParse(txtStartHead.Text, out int start))
            {
                MessageBox.Show("Vị trí đầu đọc không hợp lệ.");
                return;
            }
            
            int[] requests;
            try
            {
                requests = txtRequests.Text.Split(',')
                                           .Select(r => int.Parse(r.Trim()))
                                           .ToArray();
            }
            catch
            {
                MessageBox.Show("Request không hợp lệ.");
                return;
            }

            if (requests.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập các Request hợp lệ.");
                return;
            }

            string direction = comboBox2.SelectedItem?.ToString() ?? "Right";
            int current = start;
            int totalSeek = 0;
            List<int> seekSequence = new List<int> { start };
            List<string> steps = new List<string>();

            Array.Sort(requests);
            List<int> left = requests.Where(r => r < current).ToList();
            List<int> right = requests.Where(r => r >= current).ToList();

            if (direction == "Left")
            {
                left.Reverse();
                foreach (int r in left)
                {
                    totalSeek += Math.Abs(current - r);
                    steps.Add($"{current} → {r} ({Math.Abs(current - r)})");
                    current = r;
                    seekSequence.Add(current);
                }
                foreach (int r in right)
                {
                    totalSeek += Math.Abs(current - r);
                    steps.Add($"{current} → {r} ({Math.Abs(current - r)})");
                    current = r;
                    seekSequence.Add(current);
                }
            }
            else
            {
                foreach (int r in right)
                {
                    totalSeek += Math.Abs(current - r);
                    steps.Add($"{current} → {r} ({Math.Abs(current - r)})");
                    current = r;
                    seekSequence.Add(current);
                }
                left.Reverse();
                foreach (int r in left)
                {
                    totalSeek += Math.Abs(current - r);
                    steps.Add($"{current} → {r} ({Math.Abs(current - r)})");
                    current = r;
                    seekSequence.Add(current);
                }
            }

            rtbResult.Text = $"Thuật toán LOOK (Hướng: {direction})\n\nTổng seek time: {totalSeek}\n\nChi tiết:\n{string.Join("\n", steps)}";
            lastSeekSequence = seekSequence;
            panelChart.Invalidate();
        }
        private void RunCSCAN()
        {
            if (string.IsNullOrWhiteSpace(txtStartHead.Text))
            {
                MessageBox.Show("Vui lòng nhập vị trí đầu đọc ban đầu.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtRequests.Text))
            {
                MessageBox.Show("Vui lòng nhập các Request.");
                return;
            }

            int start;
            if (!int.TryParse(txtStartHead.Text, out start))
            {
                MessageBox.Show("Vị trí đầu đọc không hợp lệ.");
                return;
            }
            if (!int.TryParse(txtFrom.Text, out int diskMin) ||
                !int.TryParse(txtTo.Text, out int diskMax) ||
                diskMin >= diskMax)
            {
                MessageBox.Show("Vui lòng nhập phạm vi đĩa hợp lệ.");
                return;
            }

            int[] requests;
            try
            {
                requests = txtRequests.Text.Split(',')
                                           .Select(r => int.Parse(r.Trim()))
                                           .ToArray();
            }
            catch
            {
                MessageBox.Show("Request không hợp lệ.");
                return;
            }

            foreach (int req in requests)
            {
                if (req < diskMin || req >= diskMax)
                {
                    MessageBox.Show($"Request vượt phạm vi đĩa.");
                    return;
                }
            }
            if (requests.Length == 0)
            {
                MessageBox.Show("Vui lòng nhập các Request hợp lệ.");
                return;
            }

            string direction = comboBox2.SelectedItem?.ToString() ?? "Right";

            int current = start;
            int totalSeek = 0;
            List<int> seekSequence = new List<int> { start };
            List<string> steps = new List<string>();

            Array.Sort(requests);

            List<int> left = requests.Where(r => r < current).ToList();
            List<int> right = requests.Where(r => r >= current).ToList();

            if (direction == "Left")
            {
                left.Reverse();
                foreach (int r in left)
                {
                    totalSeek += Math.Abs(current - r);
                    steps.Add($"{current} → {r} ({Math.Abs(current - r)})");
                    current = r;
                    seekSequence.Add(current);
                }

                if (current != diskMin)
                {
                    totalSeek += Math.Abs(current - diskMin);
                    steps.Add($"{current} → {diskMin} ({Math.Abs(current - diskMin)})");
                    current = diskMin;
                    seekSequence.Add(current);
                }

                steps.Add($"{diskMin} → {diskMax} (0)");
                current = diskMax;
                seekSequence.Add(current);

                right.Reverse();
                foreach (int r in right)
                {
                    totalSeek += Math.Abs(current - r);
                    steps.Add($"{current} → {r} ({Math.Abs(current - r)})");
                    current = r;
                    seekSequence.Add(current);
                }
            }
            else 
            {
                foreach (int r in right)
                {
                    totalSeek += Math.Abs(current - r);
                    steps.Add($"{current} → {r} ({Math.Abs(current - r)})");
                    current = r;
                    seekSequence.Add(current);
                }

                if (current != diskMax)
                {
                    totalSeek += Math.Abs(diskMax - current);
                    steps.Add($"{current} → {diskMax} ({Math.Abs(diskMax - current)})");
                    current = diskMax;
                    seekSequence.Add(current);
                }

                steps.Add($"{diskMax} → {diskMin} (0)");
                current = diskMin;
                seekSequence.Add(current);

                foreach (int r in left)
                {
                    totalSeek += Math.Abs(current - r);
                    steps.Add($"{current} → {r} ({Math.Abs(current - r)})");
                    current = r;
                    seekSequence.Add(current);
                }
            }


            rtbResult.Text = $"Thuật toán Circular-SCAN (Hướng: {direction})\n\nTổng seek time: {totalSeek}\n\nChi tiết:\n{string.Join("\n", steps)}";

            lastSeekSequence = seekSequence;
            panelChart.Invalidate();
        }
        private void RunCLOOK()
        {
            if (string.IsNullOrWhiteSpace(txtStartHead.Text))
            {
                MessageBox.Show("Vui lòng nhập vị trí đầu đọc ban đầu.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtRequests.Text))
            {
                MessageBox.Show("Vui lòng nhập các Request.");
                return;
            }
            if (!int.TryParse(txtStartHead.Text, out int start))
            {
                MessageBox.Show("Vị trí đầu đọc không hợp lệ.");
                return;
            }
            int[] requests = txtRequests.Text.Split(',')
                                      .Select(r => int.Parse(r.Trim()))
                                      .ToArray();

            string direction = comboBox2.SelectedItem.ToString();
            int current = start;
            int totalSeek = 0;
            List<int> seekSequence = new List<int> { start };
            List<string> steps = new List<string>();

            Array.Sort(requests);
            List<int> left = requests.Where(r => r < current).ToList();
            List<int> right = requests.Where(r => r >= current).ToList();

            if (direction == "Left")
            {
                left.Reverse();
                foreach (int r in left)
                {
                    totalSeek += Math.Abs(current - r);
                    steps.Add($"{current} → {r} ({Math.Abs(current - r)})");
                    current = r;
                    seekSequence.Add(current);
                }
                if (left.Count > 0 && right.Count > 0)
                {
                    totalSeek += Math.Abs(current - right.Last());
                    steps.Add($"{current} → {right.Last()} ({Math.Abs(current - right.Last())})");
                    current = right.Last();
                    seekSequence.Add(current);
                    right.RemoveAt(right.Count - 1);
                }
                right.Reverse();
                foreach (int r in right)
                {
                    totalSeek += Math.Abs(current - r);
                    steps.Add($"{current} → {r} ({Math.Abs(current - r)})");
                    current = r;
                    seekSequence.Add(current);
                }
            }
            else
            {
                foreach (int r in right)
                {
                    totalSeek += Math.Abs(current - r);
                    steps.Add($"{current} → {r} ({Math.Abs(current - r)})");
                    current = r;
                    seekSequence.Add(current);
                }
                if (right.Count > 0 && left.Count > 0)
                {
                    totalSeek += Math.Abs(current - left.First());
                    steps.Add($"{current} → {left.First()} ({Math.Abs(current - left.First())})");
                    current = left.First();
                    seekSequence.Add(current);
                    left.RemoveAt(0);
                }
                foreach (int r in left)
                {
                    totalSeek += Math.Abs(current - r);
                    steps.Add($"{current} → {r} ({Math.Abs(current - r)})");
                    current = r;
                    seekSequence.Add(current);
                }
            }

            rtbResult.Text = $"Thuật toán Circular-LOOK (Hướng: {direction})\n\nTổng seek time: {totalSeek}\n\nChi tiết:\n{string.Join("\n", steps)}";

            lastSeekSequence = seekSequence;
            panelChart.Invalidate();
        }
        private void PanelChart_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);

            if (lastSeekSequence.Count == 0) return;

            DrawSeekChart(g, lastSeekSequence);
        }
        private void DrawSeekChart(Graphics g, List<int> sequence)
        {
            int marginLeft = 50;
            int marginTop = 30;
            int marginBottom = 50;
            int marginRight = 20;

            int width = panelChart.Width - marginLeft - marginRight;
            int height = panelChart.Height - marginTop - marginBottom;
            if (width <= 0 || height <= 0) return;

            Pen axisPen = Pens.Black;
            Pen linePen = new Pen(Color.Red, 2);
            Font font = new Font("Arial", 8);
            Brush textBrush = Brushes.Black;

            var uniqueSectors = sequence.Distinct().OrderBy(s => s).ToList();
            int sectorCount = uniqueSectors.Count;

            int startX = marginLeft;
            int startY = marginTop + height;

            g.DrawLine(axisPen, startX, startY, startX + width, startY);
            g.DrawLine(axisPen, startX, marginTop, startX, startY);

            int xTicks = sequence.Count;
            for (int i = 0; i < xTicks; i++)
            {
                float x = startX + i * (width / (float)(xTicks - 1));
                int tickSize = 5;

                g.DrawLine(axisPen, x, startY, x, startY + tickSize);

                string stepLabel = i.ToString();
                SizeF stepSize = g.MeasureString(stepLabel, font);
                g.DrawString(stepLabel, font, textBrush, x - stepSize.Width / 2, startY + tickSize + 2);
            }

            for (int i = 0; i < sectorCount; i++)
            {
                float y = marginTop + height - i * (height / (float)(sectorCount - 1 == 0 ? 1 : sectorCount - 1));
                int tickSize = 5;

                g.DrawLine(axisPen, startX - tickSize, y, startX, y);

                string valLabel = uniqueSectors[i].ToString();
                SizeF valSize = g.MeasureString(valLabel, font);
                g.DrawString(valLabel, font, textBrush, startX - tickSize - valSize.Width - 2, y - valSize.Height / 2);
            }

            for (int i = 0; i < sequence.Count; i++)
            {
                float x = startX + i * (width / (float)(sequence.Count - 1));

                int sectorIndex = uniqueSectors.IndexOf(sequence[i]);
                float y = marginTop + height - sectorIndex * (height / (float)(sectorCount - 1 == 0 ? 1 : sectorCount - 1));

                g.FillEllipse(Brushes.Blue, x - 4, y - 4, 8, 8);

                string sectorText = sequence[i].ToString();
                SizeF sectorSize = g.MeasureString(sectorText, font);
                float textX = x - sectorSize.Width / 2 + 10;
                g.DrawString(sectorText, font, textBrush, textX, y - sectorSize.Height - 5);

                if (i < sequence.Count - 1)
                {
                    float xNext = startX + (i + 1) * (width / (float)(sequence.Count - 1));
                    int nextSectorIndex = uniqueSectors.IndexOf(sequence[i + 1]);
                    float yNext = marginTop + height - nextSectorIndex * (height / (float)(sectorCount - 1 == 0 ? 1 : sectorCount - 1));
                    g.DrawLine(linePen, x, y, xNext, yNext);
                }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = comboBox1.SelectedItem?.ToString();
            bool showDirection = (selected == "SCAN" || selected == "LOOK" || selected == "C-SCAN" || selected == "C-LOOK");
            lblDirection.Visible = showDirection;
            comboBox2.Visible = showDirection;
        }

        private void txtStartHead_TextChanged(object sender, EventArgs e)
        {

        }

        private void panelChart_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void btnRun_Click_1(object sender, EventArgs e)
        {

        }
    }
}

