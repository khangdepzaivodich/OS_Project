using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OS_Project.UserControls.CpuSchedulingControl.Algorithms
{
    public class Process
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int ArrivalTime { get; set; }
        public int BurstTime { get; set; }
        public int RemainingTime { get; set; }
        public int StartTime { get; set; }
        public int FinishTime { get; set; }
        public int WaitTime { get; set; }
        public int TurnAroundTime { get; set; }
        public bool IsWorking { get; set; }
        public int Priority { get; set; }
    }

    public class GanttChartDrawer
    {
        private Panel _container;
        private int _scale = 20;

        public GanttChartDrawer(Panel container, int scale = 20)
        {
            _container = container;
            _scale = scale;
        }

        public void Draw(List<Process> processList)
        {
            _container.Controls.Clear();

            int startX = 10;
            int startY = 10;
            int height = 30;
            int currentX = startX;

            foreach (var p in processList)
            {
                int duration = p.FinishTime - p.StartTime;
                if (duration <= 0) continue;

                int displayDuration = Math.Max(duration, 2); // đảm bảo không quá nhỏ
                int panelWidth = displayDuration * _scale;

                // Panel tiến trình
                Panel procPanel = new Panel();
                procPanel.BackColor = GetColorForProcess(p.Id);
                procPanel.Height = height;
                procPanel.Width = panelWidth;
                procPanel.Left = currentX;
                procPanel.Top = startY;
                procPanel.BorderStyle = BorderStyle.FixedSingle;

                // Label tên tiến trình
                Label lbl = new Label();
                lbl.Text = p.Name;
                lbl.ForeColor = Color.White;
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Dock = DockStyle.Fill;
                lbl.Font = new Font("Consolas", 10, FontStyle.Bold);
                procPanel.Controls.Add(lbl);

                _container.Controls.Add(procPanel);

                // Thời gian bắt đầu
                Label lblStart = new Label();
                lblStart.Text = p.StartTime.ToString();
                lblStart.AutoSize = true;
                lblStart.Top = procPanel.Bottom + 5;
                lblStart.Left = currentX - lblStart.PreferredWidth / 2;
                _container.Controls.Add(lblStart);

                // Thời gian kết thúc
                Label lblEnd = new Label();
                lblEnd.Text = p.FinishTime.ToString();
                lblEnd.AutoSize = true;
                lblEnd.Top = procPanel.Bottom + 5;
                lblEnd.Left = currentX + panelWidth - lblEnd.PreferredWidth / 2;
                _container.Controls.Add(lblEnd);

                // Cập nhật vị trí vẽ kế tiếp
                currentX += panelWidth;
            }

            _container.Height = startY + height + 40;
        }


        private Color GetColorForProcess(int id)
        {
            Color[] colors = new Color[]
            {
            Color.Blue,
            Color.Green,
            Color.Orange,
            Color.Purple,
            Color.Teal,
            Color.Brown,
            Color.DeepPink,
            Color.Gold,
            Color.CadetBlue
            };

            // Đảm bảo id bắt đầu từ 1
            return colors[(id - 1) % colors.Length];
        }
    }

}
