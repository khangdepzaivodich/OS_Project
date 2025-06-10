using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OS_Project.UserControls.CpuSchedulingControl.Algorithms;

namespace OS_Project.UserControls.CpuSchedulingControl
{
    public partial class Priority_UC : UserControl
    {
        public Priority_UC()
        {
            InitializeComponent();
        }

        private int selectedRowIndex = -1;

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string processName = txtProName.Text.Trim();

            if (string.IsNullOrEmpty(processName))
            {
                MessageBox.Show("Vui lòng nhập tên tiến trình!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProName.Focus();
                return;
            }

            // Kiểm tra trùng tên (không phân biệt hoa thường)
            foreach (DataGridViewRow row in ProDGV.Rows)
            {
                if (row.Cells[1].Value != null &&
                    string.Equals(row.Cells[1].Value.ToString(), processName, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Tên tiến trình đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtProName.Focus();
                    return;
                }
            }
            if (numBurstTime.Value == 0)
            {
                MessageBox.Show("Bạn chưa nhập BurstTime!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                numBurstTime.Focus();
                return;
            }

            

            
            var process = new Process
            {
                Id = ProDGV.Rows.Count + 1,
                Name = processName,
                ArrivalTime = Convert.ToInt32(numArrivalTime.Value),
                BurstTime = Convert.ToInt32(numBurstTime.Value),
                RemainingTime = Convert.ToInt32(numBurstTime.Value),
                StartTime = -1,
                Priority = Convert.ToInt32(numPriority.Value),
            };
            // Tạo tiến trình mới và thêm vào DataGridView
            int newId = ProDGV.Rows.Count + 1;
            ProDGV.Rows.Add(newId, processName, (int)numArrivalTime.Value, (int)numBurstTime.Value, (int)numPriority.Value);

            // Reset input
            txtProName.Clear();
            numArrivalTime.Value = 0;
            numBurstTime.Value = 0;
            numPriority.Value = 1;  // có thể để mặc định priority 1
            txtProName.Focus();
        }



        void VisualiseProDGV(bool showColumns)
        {
            ProDGV.Columns["PStartTime"].Visible = showColumns;
            ProDGV.Columns["PFinishTime"].Visible = showColumns;
            ProDGV.Columns["PWaitTime"].Visible = showColumns;
            ProDGV.Columns["PTurnAroundTime"].Visible = showColumns;
            lblAVGTA.Visible = lblAVGWait.Visible = lblTime.Visible = showColumns;

            ProDGV.Columns["PName"].DisplayIndex = 0;
            ProDGV.Columns["PArrivalTime"].DisplayIndex = 1;
            ProDGV.Columns["PBurstTime"].DisplayIndex = 2;

            if (showColumns)
            {
                ProDGV.Columns["PStartTime"].DisplayIndex = 3;
                ProDGV.Columns["PFinishTime"].DisplayIndex = 4;
                ProDGV.Columns["PWaitTime"].DisplayIndex = 5;
                ProDGV.Columns["PTurnAroundTime"].DisplayIndex = 6;
            }
        }
        private void ProDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = ProDGV.Rows[e.RowIndex];

                txtProName.Text = row.Cells[1].Value.ToString();
                numArrivalTime.Value = Convert.ToInt32(row.Cells[2].Value);
                numBurstTime.Value = Convert.ToInt32(row.Cells[3].Value);

                // Lưu chỉ số dòng đang chọn để sử dụng khi chỉnh sửa
                selectedRowIndex = e.RowIndex;
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex < 0 || selectedRowIndex >= ProDGV.Rows.Count)
            {
                MessageBox.Show("Vui lòng chọn tiến trình để chỉnh sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string newName = txtProName.Text.Trim();

            // Kiểm tra rỗng
            if (string.IsNullOrEmpty(newName))
            {
                MessageBox.Show("Vui lòng nhập tên tiến trình!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProName.Focus();
                return;
            }

            // Kiểm tra trùng tên (trừ dòng đang chọn)
            for (int i = 0; i < ProDGV.Rows.Count; i++)
            {
                if (i != selectedRowIndex &&
                    string.Equals(ProDGV.Rows[i].Cells[1].Value.ToString(), newName, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Tên tiến trình đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }


            // Cập nhật lại thông tin dòng đang chọn
            DataGridViewRow row = ProDGV.Rows[selectedRowIndex];
            row.Cells[1].Value = newName;
            row.Cells[2].Value = Convert.ToInt32(numArrivalTime.Value);
            row.Cells[3].Value = Convert.ToInt32(numBurstTime.Value);

            // Optional: reset trạng thái
            txtProName.Clear();
            numArrivalTime.Value = 0;
            numBurstTime.Value = 0;
            selectedRowIndex = -1;
        }


        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex < 0 || selectedRowIndex >= ProDGV.Rows.Count)
            {
                MessageBox.Show("Vui lòng chọn tiến trình để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Xác nhận trước khi xóa
            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa tiến trình này?",
                                                "Xác nhận xóa",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                // Xóa dòng khỏi DataGridView
                ProDGV.Rows.RemoveAt(selectedRowIndex);

                // Cập nhật lại ID các tiến trình sau khi xóa
                for (int i = 0; i < ProDGV.Rows.Count; i++)
                {
                    ProDGV.Rows[i].Cells[0].Value = i + 1; // Cột ID
                }

                // Reset input
                txtProName.Clear();
                numArrivalTime.Value = 0;
                numBurstTime.Value = 1;
                selectedRowIndex = -1;
            }
        }


        private void BtnClear_Click(object sender, EventArgs e)
        {
            txtProName.Clear();
            numArrivalTime.Value = 0;
            numBurstTime.Value = 0;
            selectedRowIndex = -1;
            txtProName.Focus();
        }


        private void BtnStartScheduling_Click(object sender, EventArgs e)
        {
            if (ProDGV.Rows.Count == 0)
            {
                MessageBox.Show("Chưa có tiến trình nào để mô phỏng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Tạo danh sách tiến trình từ DataGridView
            List<Process> processList = new List<Process>();
            foreach (DataGridViewRow row in ProDGV.Rows)
            {
                if (row.IsNewRow) continue;

                int priority = (int)numPriority.Value; // mặc định priority nếu không có trong ô Priority
               
                processList.Add(new Process
                {
                    Id = Convert.ToInt32(row.Cells[0].Value),
                    Name = row.Cells[1].Value.ToString(),
                    ArrivalTime = Convert.ToInt32(row.Cells[2].Value),
                    BurstTime = Convert.ToInt32(row.Cells[3].Value),
                    RemainingTime = Convert.ToInt32(row.Cells[3].Value),
                    StartTime = -1,
                    Priority = Convert.ToInt32(row.Cells[4].Value),
                });
            }

            // Bạn không cần sắp xếp ở đây nếu Scheduler đã xử lý
            // processList = processList.OrderBy(p => p.ArrivalTime).ThenBy(p => p.Priority).ToList();
            processList = processList.OrderBy(p => p.ArrivalTime).ThenBy(p => p.Priority).ToList();
            // Thêm cột nếu chưa có
            if (!ProDGV.Columns.Contains("PWaitTime"))
                ProDGV.Columns.Add("PWaitTime", "Waiting");
            if (!ProDGV.Columns.Contains("PTurnAroundTime"))
                ProDGV.Columns.Add("PTurnAroundTime", "Turnaround");

            // Tạo scheduler PriorityScheduler với cờ Preemptive hay không
            var scheduler = new PriorityScheduler(processList, CheckBoxPreemptive.Checked);
            scheduler.Run();

            // Vẽ Gantt chart
            var drawer = new GanttChartDrawer(pnlGanttContainer);
            drawer.Draw(scheduler.ResultProcesses);

            PWaitTime.Visible = true;
            PTurnAroundTime.Visible = true;

            // Tạo dictionary id -> process để cập nhật DataGridView nhanh hơn
            var processDict = scheduler.ResultProcesses
                .GroupBy(p => p.Id)
                .Select(g => g.Last()) // hoặc First() nếu cần lần đầu
                .ToDictionary(p => p.Id);


            foreach (DataGridViewRow row in ProDGV.Rows)
            {
                if (row.IsNewRow) continue;
                int id = Convert.ToInt32(row.Cells[0].Value);
                if (processDict.ContainsKey(id))
                {
                    var p = processDict[id];
                    row.Cells["PWaitTime"].Value = p.WaitTime;
                    row.Cells["PTurnAroundTime"].Value = p.TurnAroundTime;
                }
            }

            // Tính trung bình
            double avgWait = scheduler.ResultProcesses.Average(p => p.WaitTime);
            double avgTAT = scheduler.ResultProcesses.Average(p => p.TurnAroundTime);

            lblAVGWait.Text = $"Avg Wait Time: {avgWait:F2}";
            lblAVGTA.Text = $"Avg Turnaround Time: {avgTAT:F2}";
        }




        private void BtnReset_Click(object sender, EventArgs e)
        {
            PWaitTime.Visible = false;
            PTurnAroundTime.Visible = false;
            ProDGV.Rows.Clear();
            pnlGanttContainer.Controls.Clear();
            VisualiseProDGV(false);
            txtProName.Clear();
            numArrivalTime.Value = 0;
            numBurstTime.Value = 0;
            numPriority.Value = 0;
            selectedRowIndex = -1;
        }

    }
}
