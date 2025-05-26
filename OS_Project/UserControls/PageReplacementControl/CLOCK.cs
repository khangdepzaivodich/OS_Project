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
    public partial class CLOCK : UserControl
    {
        public CLOCK()
        {
            InitializeComponent();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            // 1. Lấy input
            string input = txtInputString.Text.Trim();
            if (string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Vui lòng nhập chuỗi trang, ví dụ: 7, 0, 1, 2, 0, 3...");
                return;
            }

            string[] parts = input.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            List<int> pages = new List<int>();
            try
            {
                foreach (string part in parts)
                {
                    pages.Add(int.Parse(part));
                }
            }
            catch
            {
                MessageBox.Show("Chuỗi nhập không hợp lệ. Chỉ nhập số cách nhau bằng dấu phẩy hoặc khoảng trắng.");
                return;
            }

            int frameCount = (int)NumFramesCount.Value;
            if (frameCount <= 0)
            {
                MessageBox.Show("Số khung trang phải lớn hơn 0.");
                return;
            }

            // 2. Khởi tạo cấu trúc lưu trang và cờ second chance
            List<int> framePages = new List<int>(Enumerable.Repeat(-1, frameCount));
            List<bool> secondChances = new List<bool>(new bool[frameCount]);
            int clockHand = 0;
            int pageFaults = 0;
            int pageHits = 0;

            // 3. Chuẩn bị DataGridView
            DGV.Rows.Clear();
            DGV.Columns.Clear();
            for (int i = 0; i < pages.Count; i++)
            {
                DGV.Columns.Add("col" + i, pages[i].ToString());
            }
            DGV.RowCount = frameCount + 1; // +1 dòng cho dòng hiển thị Fault

            for (int r = 0; r < frameCount; r++)
            {
                DGV.Rows[r].HeaderCell.Value = "Frame " + (r + 1);
            }
            DGV.Rows[frameCount].HeaderCell.Value = "Fault";

            // 4. Mô phỏng thuật toán Second Chance
            for (int i = 0; i < pages.Count; i++)
            {
                int page = pages[i];
                bool hit = false;

                // Kiểm tra có trong frame không
                for (int f = 0; f < frameCount; f++)
                {
                    if (framePages[f] == page)
                    {
                        secondChances[f] = true; // cấp cơ hội thứ hai
                        hit = true;
                        pageHits++;
                        break;
                    }
                }

                if (!hit)
                {
                    pageFaults++;

                    // Kiểm tra xem có frame còn trống không
                    int emptyFrameIndex = framePages.IndexOf(-1);
                    if (emptyFrameIndex != -1)
                    {
                        // Thêm trang vào frame trống, không thay thế
                        framePages[emptyFrameIndex] = page;
                        secondChances[emptyFrameIndex] = true;
                        // Không đánh F vì chưa thay thế
                        DGV.Rows[frameCount].Cells[i].Value = "";
                    }
                    else
                    {
                        // Phải thay thế trang cũ
                        while (true)
                        {
                            if (!secondChances[clockHand])
                            {
                                framePages[clockHand] = page;
                                secondChances[clockHand] = true;
                                clockHand = (clockHand + 1) % frameCount;
                                break;
                            }
                            secondChances[clockHand] = false;
                            clockHand = (clockHand + 1) % frameCount;
                        }

                        // Đánh dấu F chỉ khi thay thế
                        DGV.Rows[frameCount].Cells[i].Value = "F";
                    }
                }
                else
                {
                    DGV.Rows[frameCount].Cells[i].Value = "";
                }


                // 5. Cập nhật trạng thái các frame vào DataGridView
                for (int r = 0; r < frameCount; r++)
                {
                    string val = framePages[r] == -1 ? "" : framePages[r].ToString();

                    if (secondChances[r])
                        val += "*";

                    if (r == clockHand)
                        val = "->" + val;

                    DGV.Rows[r].Cells[i].Value = val;
                }
            }

            // 6. Hiển thị kết quả cuối cùng
            lblFaults.Visible = true;
            lblHits.Visible = true;
            lblFaults.Text = "Page Faults: " + pageFaults;
            lblHits.Text = "Page Hits: " + pageHits;
            DGV.Enabled = false;
            DGV.ClearSelection();
            DGV.CurrentCell = null;
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

    }

}
