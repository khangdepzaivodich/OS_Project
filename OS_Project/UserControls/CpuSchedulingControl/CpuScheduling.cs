using OS_Project.UserControls.CpuSchedulingControl.Models;
using OS_Project.UserControls.CpuSchedulingControl.Schedulers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OS_Project.CpuSchedulingControl.cs
{
    public partial class CpuScheduling : UserControl
    {
        SortedDictionary<int, Process> storage = new SortedDictionary<int, Process>();
        List<GanttBlock> ganttBlocks = new List<GanttBlock>();

        public CpuScheduling()
        {
            
            InitializeComponent();
        }
        int arrivaltime = 0;
        private void AddingClickBT_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ProcessNameTB.Text))
            {
                MessageBox.Show("Textbox Process Name is NULL");
                return;
            }
            string input = BrustTimeTB.Text;
            int burstTime;

            if (!int.TryParse(input, out burstTime))
            {
                MessageBox.Show("Burst Time must be a number");
                return;
            }

            Process process = new Process();
            process.Id = ProcessNameTB.Text.Trim();
            process.BurstTime = burstTime;

            storage[arrivaltime] = process;  // Lưu process với key là arrival time
            ProcessLog.Text += $"Process: {process.Id} Arrival Time: {arrivaltime} Burst Time: {burstTime}\r\n";

            arrivaltime++;
        }
        void clear_grid_cache()
        {
            ProcessGrid.DataSource = null;
            return;
        }
        bool checking_RR_TB()
        {
            if (int.TryParse(RR_Size.Text, out int number))
            {
                if (number >= 1 )
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void cleargantt()
        {
            ganttBlocks.Clear();
            panelDrawing.Invalidate();  
        }
        private void ClearBT_Click(object sender, EventArgs e)
        {
            arrivaltime = 0;
            ProcessLog.Clear();
            storage.Clear();
            ProcessGrid.DataSource = null;
            cleargantt();
        }

        private void FCFS_BT_Click(object sender, EventArgs e)
        {
            clear_grid_cache();
            FCFS_Scheduler scheduler = new FCFS_Scheduler();
            List<ProcessAndTime> result = scheduler.schedule(storage);
            DrawGanttChart(scheduler.ganttData);            
            ProcessGrid.DataSource = result;
        }

        private void CpuScheduling_Load(object sender, EventArgs e)
        {

        }

        private void SJF_BT_Click(object sender, EventArgs e)
        {
            clear_grid_cache();
            SJF_Scheduler scheduler = new SJF_Scheduler();
            List<ProcessAndTime> result = scheduler.schedule(storage);
            DrawGanttChart(scheduler.ganttData);
            ProcessGrid.DataSource = result;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            clear_grid_cache();
            if (!checking_RR_TB())
            {
                MessageBox.Show("Re Entering The Roud Robin TextBox ");
                RR_Size.Clear();
                return;
            }
            int rr_size = Convert.ToInt32(RR_Size.Text);
            RR_scheduler scheduler = new RR_scheduler();
            scheduler.set_rr_size(rr_size);
            List<ProcessAndTime> result = scheduler.schedule(storage);
            DrawGanttChart(scheduler.ganttData);
  
            ProcessGrid.DataSource = result;
            }

        private void DrawGanttChart(List<GanttBlock> blocks)
        {
            ganttBlocks = blocks;

            int unitWidth = 40;
            int totalWidth = blocks.Sum(b => (b.EndTime - b.StartTime) * unitWidth);
            panelDrawing.Width = Math.Max(panelContainer.Width, totalWidth + 20);

            panelDrawing.Invalidate();
        }

        private void panelDrawing_Paint(object sender, PaintEventArgs e)
        {
            if (ganttBlocks == null || ganttBlocks.Count == 0)
                return;

            int unitWidth = 40;
            int x = 10;

            Graphics g = e.Graphics;
            g.Clear(panelDrawing.BackColor);

            Font font = new Font("Arial", 10);
            Pen pen = new Pen(Color.Black);
            Brush brush = Brushes.LightBlue;

            foreach (var block in ganttBlocks)
            {
                int width = (block.EndTime - block.StartTime) * unitWidth;
                Rectangle rect = new Rectangle(x, 20, width, 40);

                g.FillRectangle(brush, rect);
                g.DrawRectangle(pen, rect);
                g.DrawString(block.ProcessId, font, Brushes.Black, x + width / 2 - 10, 30);
                g.DrawString(block.StartTime.ToString(), font, Brushes.Black, x - 5, 65);

                x += width;
            }

            g.DrawString(ganttBlocks.Last().EndTime.ToString(), font, Brushes.Black, x - 5, 65);
        }
    }
}
