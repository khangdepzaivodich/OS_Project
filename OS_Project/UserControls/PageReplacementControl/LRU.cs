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
    public partial class LRU : UserControl
    {
        public LRU()
        {
            InitializeComponent();

            // --- Style DataGridView cho nền trắng như ảnh gốc ---
            DGV.EnableHeadersVisualStyles = false;
            DGV.BackgroundColor = Color.White;
            DGV.DefaultCellStyle.BackColor = Color.White;
            DGV.DefaultCellStyle.ForeColor = Color.Black;

            DGV.ColumnHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
            DGV.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            DGV.RowHeadersDefaultCellStyle.BackColor = Color.WhiteSmoke;
            DGV.RowHeadersDefaultCellStyle.ForeColor = Color.Black;

            DGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DGV.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;

            lblFaults.Visible = lblHits.Visible = false;
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
            // 1. Lấy và parse input
            var raw = txtInputString.Text.Trim();
            if (string.IsNullOrEmpty(raw))
            {
                MessageBox.Show("Vui lòng nhập chuỗi trang, ví dụ: 7, 0, 1, 2, 0, 3...");
                return;
            }

            string[] parts = raw.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var pages = new List<int>();
            foreach (var p in parts)
            {
                if (!int.TryParse(p, out var x))
                {
                    MessageBox.Show("Chuỗi nhập không hợp lệ. Chỉ nhập số cách nhau bằng dấu phẩy hoặc khoảng trắng.");
                    return;
                }
                pages.Add(x);
            }

            int frameCount = (int)NumFramesCount.Value;
            if (frameCount < 1)
            {
                MessageBox.Show("Số khung trang phải lớn hơn 0.");
                return;
            }

            // 2. Khởi tạo cấu trúc
            var framePages = new List<int>();               // danh sách các trang hiện trong frame
            var lastUsed = new Dictionary<int, int>();      // thời điểm truy cập cuối của từng page
            int pageFaults = 0;
            int pageHits = 0;

            // 3. Chuẩn bị DataGridView
            DGV.Rows.Clear();
            DGV.Columns.Clear();

            for (int i = 0; i < pages.Count; i++)
                DGV.Columns.Add("c" + i, pages[i].ToString());

            // Thêm các hàng: frame 1..frameCount, rồi hàng Fault
            DGV.RowCount = frameCount + 1;
            for (int r = 0; r < frameCount; r++)
                DGV.Rows[r].HeaderCell.Value = "Frame " + (r + 1);
            DGV.Rows[frameCount].HeaderCell.Value = "Fault";

            // 4. Mô phỏng LRU
            for (int i = 0; i < pages.Count; i++)
            {
                int page = pages[i];
                bool hit = framePages.Contains(page);

                if (hit)
                {
                    // nếu đã có → hit
                    pageHits++;
                    // không đánh F
                }
                else
                {
                    if (framePages.Count < frameCount)
                    {
                        // nạp vào frame trống (chưa full) → không replacement
                        framePages.Add(page);
                    }
                    else
                    {
                        // full rồi → tìm và thay thế LRU
                        int lruTime = int.MaxValue, lruPage = framePages[0];
                        foreach (var p in framePages)
                        {
                            if (lastUsed[p] < lruTime)
                            {
                                lruTime = lastUsed[p];
                                lruPage = p;
                            }
                        }
                        // thay thế
                        framePages.Remove(lruPage);
                        framePages.Add(page);

                        // đánh dấu F
                        pageFaults++;
                        DGV.Rows[frameCount].Cells[i].Value = "F";
                    }
                }

                // cập nhật thời điểm cuối cùng trang này được dùng
                lastUsed[page] = i;

                // 5. Điền trạng thái frame vào mỗi ô (cột)
                for (int r = 0; r < frameCount; r++)
                {
                    if (r < framePages.Count)
                        DGV.Rows[r].Cells[i].Value = framePages[r].ToString();
                    else
                        DGV.Rows[r].Cells[i].Value = "";
                }
            }

            // 6. Hiển thị kết quả
            lblFaults.Text = $"Page Faults: {pageFaults}";
            lblHits.Text = $"Page Hits: {pageHits}";
            lblFaults.Visible = lblHits.Visible = true;

            // khoá DataGridView lại và clear chọn
            DGV.Enabled = false;
            DGV.ClearSelection();
            DGV.CurrentCell = null;
        }
    }
}
