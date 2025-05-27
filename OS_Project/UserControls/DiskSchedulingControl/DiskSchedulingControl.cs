using OS_Project.Algorithms;
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
            var fcfs = new FCFSAlgorithm();
            var result = fcfs.Run(txtStartHead.Text, txtRequests.Text);

            if (!result.IsSuccess)
            {
                MessageBox.Show(result.ErrorMessage);
                return;
            }

            rtbResult.Text = $"Thuật toán First-Come, First-Served\n\nTổng seek time: {result.TotalSeekTime}\n\nChi tiết:\n{string.Join("\n", result.Steps)}";

            lastSeekSequence = result.SeekSequence;
            panelChart.Invalidate();
        }
        private void RunSSTF()
        {
            var sstf = new SSTFAlgorithm();
            var result = sstf.Run(txtStartHead.Text, txtRequests.Text);

            if (!result.IsSuccess)
            {
                MessageBox.Show(result.ErrorMessage);
                return;
            }

            rtbResult.Text = $"Thuật toán Shortest Seek Time First\n\nTổng seek time: {result.TotalSeekTime}\n\nChi tiết:\n{string.Join("\n", result.Steps)}";

            lastSeekSequence = result.SeekSequence;
            panelChart.Invalidate();
        }
        private void RunSCAN()
        {
            var scan = new SCANAlgorithm();
            var result = scan.Run(
                txtStartHead.Text,
                txtRequests.Text,
                txtFrom.Text,
                txtTo.Text,
                comboBox2.SelectedItem?.ToString() ?? "Right"
            );

            if (!result.IsSuccess)
            {
                MessageBox.Show(result.ErrorMessage);
                return;
            }

            rtbResult.Text = $"Thuật toán SCAN (Hướng: {result.Direction})\n\n" +
                             $"Tổng seek time: {result.TotalSeekTime}\n\n" +
                             $"Chi tiết:\n{string.Join("\n", result.Steps)}";

            lastSeekSequence = result.SeekSequence;
            panelChart.Invalidate();
        }
        private void RunLOOK()
        {
            var look = new LOOKAlgorithm();
            var result = look.Run(
                txtStartHead.Text,
                txtRequests.Text,
                comboBox2.SelectedItem?.ToString() ?? "Right"
            );

            if (!result.IsSuccess)
            {
                MessageBox.Show(result.ErrorMessage);
                return;
            }

            rtbResult.Text = $"Thuật toán LOOK (Hướng: {result.Direction})\n\n" +
                             $"Tổng seek time: {result.TotalSeekTime}\n\n" +
                             $"Chi tiết:\n{string.Join("\n", result.Steps)}";

            lastSeekSequence = result.SeekSequence;
            panelChart.Invalidate();
        }
        private void RunCSCAN()
        {
            var cscan = new CSCANAlgorithm();
            var result = cscan.Run(
                txtStartHead.Text,
                txtRequests.Text,
                txtFrom.Text,
                txtTo.Text,
                comboBox2.SelectedItem?.ToString() ?? "Right"
            );

            if (!result.IsSuccess)
            {
                MessageBox.Show(result.ErrorMessage);
                return;
            }

            rtbResult.Text = $"Thuật toán Circular-SCAN (Hướng: {result.Direction})\n\n" +
                             $"Tổng seek time: {result.TotalSeekTime}\n\n" +
                             $"Chi tiết:\n{string.Join("\n", result.Steps)}";

            lastSeekSequence = result.SeekSequence;
            panelChart.Invalidate();
        }
        private void RunCLOOK()
        {
            var clook = new CLOOKAlgorithm();
            var result = clook.Run(
                txtStartHead.Text,
                txtRequests.Text,
                comboBox2.SelectedItem?.ToString() ?? "Right"
            );

            if (!result.IsSuccess)
            {
                MessageBox.Show(result.ErrorMessage);
                return;
            }

            rtbResult.Text = $"Thuật toán Circular-LOOK (Hướng: {result.Direction})\n\n" +
                             $"Tổng seek time: {result.TotalSeekTime}\n\n" +
                             $"Chi tiết:\n{string.Join("\n", result.Steps)}";

            lastSeekSequence = result.SeekSequence;
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
    }
}

