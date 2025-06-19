using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OS_Project.UserControls.PageReplacementControl
{
    public partial class FIFO : UserControl
    {
        public FIFO()
        {
            InitializeComponent();
        }
        private void BtnReset_Click(object sender, EventArgs e)
        {
            // Xóa bảng hiển thị
            DGV.DataSource = null;
            DGV.Rows.Clear();
            DGV.Columns.Clear();

            // Đặt lại các label
            lblHits.Text = "Hits:";
            lblFaults.Text = "Page Faults:";
            lblTime.Text = "Time:";

            lblHits.Visible = false;
            lblFaults.Visible = false;
            lblTime.Visible = false;

            // Reset ô nhập chuỗi và số khung
            txtInputString.Text = "";
            NumFramesCount.Value = 0;

            // Cho phép nhập lại
            GbInput.Enabled = true;
            BtnStart.Enabled = true;
        }



        private void BtnStart_Click(object sender, EventArgs e)
        {
            // 1. Lấy input
            string input = txtInputString.Text.Trim();
            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Vui lòng nhập chuỗi trang truy cập");
                return;
            }

            string[] parts = input
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var pages = new List<int>();
            try
            {
                foreach (var p in parts)
                    pages.Add(int.Parse(p));
            }
            catch
            {
                MessageBox.Show("Chuỗi nhập không hợp lệ.");
                return;
            }

            int frameCount = (int)NumFramesCount.Value;
            if (frameCount <= 0)
            {
                MessageBox.Show("Số khung trang phải lớn hơn 0.");
                return;
            }

            // 2. Khởi tạo cấu trúc FIFO
            var frames = new HashSet<int>(frameCount);
            var fifoQueue = new Queue<int>();
            int pageFaults = 0;
            int pageHits = 0;

            // 3. Chuẩn bị DataGridView
            DGV.Rows.Clear();
            DGV.Columns.Clear();
            for (int i = 0; i < pages.Count; i++)
                DGV.Columns.Add($"col{i}", pages[i].ToString());

            DGV.RowCount = frameCount + 1;
            DGV.RowHeadersVisible = false;

            // Lưu lại lịch sử frame + đánh dấu F
            var frameHistory = new List<int[]>();
            var faults = new List<string>();

            // 4. Chạy thuật toán FIFO
            foreach (var page in pages)
            {
                bool isHit = frames.Contains(page);
                bool isFault = false;

                if (isHit)
                {
                    // Hit thì tăng đếm
                    pageHits++;
                }
                else
                {
                    // Miss
                    if (frames.Count < frameCount)
                    {
                        // Chưa full ⇒ chỉ nạp, không fault
                        frames.Add(page);
                        fifoQueue.Enqueue(page);
                    }
                    else
                    {
                        // Full ⇒ phải thay thế
                        int removed = fifoQueue.Dequeue();
                        frames.Remove(removed);

                        frames.Add(page);
                        fifoQueue.Enqueue(page);

                        pageFaults++;
                        isFault = true;
                    }
                }

                // Ghi lại trạng thái hiện tại của các frame
                var snapshot = new int[frameCount];
                int idx = 0;
                foreach (var f in fifoQueue)
                    snapshot[idx++] = f;
                frameHistory.Add(snapshot);

                // Ghi lại F hay không
                faults.Add(isFault ? "F" : "");
            }

            // 5. Đổ lịch sử ra DataGridView
            for (int r = 0; r < frameCount; r++)
            {
                for (int c = 0; c < pages.Count; c++)
                {
                    int v = frameHistory[c][r];
                    DGV.Rows[r].Cells[c].Value = v == 0 ? "" : v.ToString();
                }
            }

            // Hàng Fault
            for (int c = 0; c < pages.Count; c++)
                DGV.Rows[frameCount].Cells[c].Value = faults[c];

            // 6. Hiển thị kết quả
            lblFaults.Text = $"Page Faults: {pageFaults}";
            lblHits.Text = $"Page Hits: {pageHits}";
            lblFaults.Visible = lblHits.Visible = true;

            DGV.ClearSelection();
            DGV.CurrentCell = null;
        }



    }
}
