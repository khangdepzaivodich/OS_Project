using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OS_Project.UserControls.PageReplacementControl
{
    public partial class OPTimal : UserControl
    {
        public OPTimal()
        {
            InitializeComponent();

            // --- Style DataGridView cho nền trắng như mẫu ---
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

        /// <summary>
        /// Tìm index của khung cần thay thế theo thuật toán Optimal
        /// </summary>
        private int Predict(List<int> frames, List<int> futurePages, int startIndex)
        {
            int res = -1;
            int farthest = startIndex;

            for (int i = 0; i < frames.Count; i++)
            {
                int page = frames[i];
                int j;
                for (j = startIndex; j < futurePages.Count; j++)
                {
                    if (futurePages[j] == page)
                    {
                        if (j > farthest)
                        {
                            farthest = j;
                            res = i;
                        }
                        break;
                    }
                }
                // Nếu page này không còn xuất hiện ở tương lai, thay ngay
                if (j == futurePages.Count)
                    return i;
            }
            return (res == -1) ? 0 : res;
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            // 1. Lấy input và parse
            string raw = txtInputString.Text.Trim();
            if (string.IsNullOrEmpty(raw))
            {
                MessageBox.Show("Vui lòng nhập chuỗi trang, ví dụ: 7, 0, 1, 2, 0, 3...");
                return;
            }

            var parts = raw.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var pages = new List<int>();
            foreach (var p in parts)
            {
                if (!int.TryParse(p, out var x))
                {
                    MessageBox.Show("Chuỗi nhập không hợp lệ. Chỉ nhập số nguyên cách nhau bằng dấu phẩy hoặc khoảng trắng.");
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

            // 2. Khởi tạo
            var framePages = new List<int>();  // danh sách các page đang nằm trong frame
            int pageFaults = 0;
            int pageHits = 0;

            // 3. Chuẩn bị DataGridView
            DGV.Rows.Clear();
            DGV.Columns.Clear();
            for (int i = 0; i < pages.Count; i++)
                DGV.Columns.Add("col" + i, pages[i].ToString());

            DGV.RowCount = frameCount + 1;
            for (int r = 0; r < frameCount; r++)
                DGV.Rows[r].HeaderCell.Value = "Frame " + (r + 1);
            DGV.Rows[frameCount].HeaderCell.Value = "Fault";

            // 4. Mô phỏng thuật toán OPTimal
            for (int i = 0; i < pages.Count; i++)
            {
                int page = pages[i];
                bool hit = framePages.Contains(page);

                if (hit)
                {
                    // Hit → tăng hits
                    pageHits++;
                }
                else
                {
                    // Miss
                    if (framePages.Count < frameCount)
                    {
                        // Chưa full → chỉ thêm, chưa thay thế → chưa fault
                        framePages.Add(page);
                    }
                    else
                    {
                        // Full → phải thay thế 1 khung theo OPT
                        int replaceIdx = Predict(framePages, pages, i + 1);
                        framePages[replaceIdx] = page;

                        // Đánh dấu fault
                        pageFaults++;
                        DGV.Rows[frameCount].Cells[i].Value = "F";
                    }
                }

                // 5. Cập nhật trạng thái frame lên mỗi cột
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

            // Khóa bảng và clear selection
            DGV.Enabled = false;
            DGV.ClearSelection();
            DGV.CurrentCell = null;
        }
    }
}
