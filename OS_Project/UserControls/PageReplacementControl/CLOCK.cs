using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace OS_Project.UserControls.PageReplacementControl
{
    public partial class CLOCK : UserControl
    {
        public CLOCK()
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
            // 1. Đọc và parse input chuỗi trang
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

            // 2. Số khung
            int frameCount = (int)NumFramesCount.Value;
            if (frameCount < 1)
            {
                MessageBox.Show("Số khung trang phải > 0.");
                return;
            }

            // 3. Khởi tạo cấu trúc
            var framePages = Enumerable.Repeat(-1, frameCount).ToArray(); // -1 = empty
            var secondChances = new bool[frameCount];
            int clockHand = 0;
            int pageFaults = 0;
            int pageHits = 0;

            // 4. Chuẩn bị DataGridView
            DGV.Rows.Clear();
            DGV.Columns.Clear();
            for (int i = 0; i < pages.Count; i++)
                DGV.Columns.Add("col" + i, pages[i].ToString());
            DGV.RowCount = frameCount + 1;
            DGV.RowHeadersVisible = false;
            for (int r = 0; r < frameCount; r++)
                DGV.Rows[r].HeaderCell.Value = "Frame " + (r + 1);
            DGV.Rows[frameCount].HeaderCell.Value = "Fault";

            // 5. Chạy thuật toán CLOCK
            for (int i = 0; i < pages.Count; i++)
            {
                int page = pages[i];
                bool isHit = false;
                bool isFault = false;

                // a) Kiểm tra hit
                for (int f = 0; f < frameCount; f++)
                {
                    if (framePages[f] == page)
                    {
                        secondChances[f] = true;
                        isHit = true;
                        pageHits++;
                        break;
                    }
                }

                // b) Nếu miss
                if (!isHit)
                {
                    // tìm frame còn trống
                    int emptyIdx = Array.IndexOf(framePages, -1);
                    if (emptyIdx != -1)
                    {
                        // nạp trang vào khung trống, không fault
                        framePages[emptyIdx] = page;
                        secondChances[emptyIdx] = true;
                    }
                    else
                    {
                        // phải thay thế: tìm frame đầu tiên có secondChance==false
                        while (secondChances[clockHand])
                        {
                            secondChances[clockHand] = false;
                            clockHand = (clockHand + 1) % frameCount;
                        }
                        // clockHand giờ trỏ vào frame bị thay
                        framePages[clockHand] = page;
                        secondChances[clockHand] = true;
                        isFault = true;
                        pageFaults++;
                        clockHand = (clockHand + 1) % frameCount;
                    }
                }

                // c) Đổ hàng Fault (F) cho cột i
                DGV.Rows[frameCount].Cells[i].Value = isFault ? "F" : "";

                // d) Vẽ trạng thái mỗi frame ở cột i
                bool allFull = !framePages.Any(v => v == -1);
                // 5. Vẽ trạng thái mỗi frame vào cột i
                // sau khi đã cập nhật framePages[r] và secondChances[r]
                // Trong loop for (int i = 0; i < pages.Count; i++) khi đã xử lý xong pageFaults/secondChances/clockHand...

                // tính xem đã đi qua đủ số cột để bắt đầu xoay đồng hồ chưa
                bool showArrow = (i >= frameCount);

                for (int r = 0; r < frameCount; r++)
                {
                    // 1) Giá trị trang (empty = "")
                    string cellText = framePages[r] == -1
                        ? ""
                        : framePages[r].ToString();

                    // 2) gắn '*' nếu có second chance
                    if (secondChances[r] && framePages[r] != -1)
                        cellText += "*";

                    // 3) chỉ hiển thị mũi tên ở ô (r == clockHand) và chỉ từ cột thứ frameCount trở đi
                    if (showArrow && r == clockHand)
                        cellText = "->" + cellText;

                    DGV.Rows[r].Cells[i].Value = cellText;
                }



            }

            // 6. Hiển thị kết quả
            lblFaults.Text = $"Page Faults: {pageFaults}";
            lblHits.Text = $"Page Hits: {pageHits}";
            lblFaults.Visible = lblHits.Visible = true;

            DGV.Enabled = false;
            DGV.ClearSelection();
            DGV.CurrentCell = null;
        }
    }
}
