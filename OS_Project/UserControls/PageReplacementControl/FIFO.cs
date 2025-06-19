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

            string[] parts = input.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            List<int> pages = new List<int>();
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

            HashSet<int> frames = new HashSet<int>(frameCount);
            Queue<int> fifoQueue = new Queue<int>();

            int pageFaults = 0;

            // Setup DataGridView
            DGV.Rows.Clear();
            DGV.Columns.Clear();

            // Bỏ cột "String" - chỉ tạo cột theo số lượng trang
            for (int i = 0; i < pages.Count; i++)
                DGV.Columns.Add($"col{i}", pages[i].ToString());

            DGV.RowCount = frameCount + 1;
            // Nếu RowHeaders có hiển thị, ta có thể để trống header hoặc đặt tên tùy ý
            DGV.RowHeadersVisible = false;

            List<int[]> frameHistory = new List<int[]>();
            List<string> faults = new List<string>();

            foreach (int page in pages)
            {
                bool isFault = false;

                if (frames.Count < frameCount)
                {
                    if (!frames.Contains(page))
                    {
                        frames.Add(page);
                        fifoQueue.Enqueue(page);
                        pageFaults++;
                        isFault = false; // chưa full frame thì không đánh dấu F
                    }
                    else
                    {
                        isFault = false;
                    }
                }
                else
                {
                    if (!frames.Contains(page))
                    {
                        int removed = fifoQueue.Dequeue();
                        frames.Remove(removed);

                        frames.Add(page);
                        fifoQueue.Enqueue(page);
                        pageFaults++;
                        isFault = true; // full frame + fault -> đánh dấu F
                    }
                    else
                    {
                        isFault = false;
                    }
                }

                int[] current = new int[frameCount];
                int idx = 0;
                foreach (int f in fifoQueue)
                {
                    current[idx++] = f;
                }
                frameHistory.Add(current);
                faults.Add(isFault ? "F" : "");
            }
            DGV.RowHeadersVisible = false;

            // Đổ dữ liệu lên DGV như bạn đã có…
            for (int r = 0; r < frameCount; r++)
                for (int c = 0; c < pages.Count; c++)
                    DGV.Rows[r].Cells[c].Value = frameHistory[c][r] == 0 ? "" : frameHistory[c][r].ToString();

            DGV.Rows[frameCount].Height = 25;
            for (int c = 0; c < pages.Count; c++)
                DGV.Rows[frameCount].Cells[c].Value = faults[c];

            lblFaults.Text = $"Page Faults: {pageFaults}";
            DGV.ClearSelection();
            DGV.CurrentCell = null;

        }


    }
}
