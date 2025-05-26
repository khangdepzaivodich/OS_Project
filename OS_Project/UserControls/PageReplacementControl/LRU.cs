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

            // 2. Khởi tạo cấu trúc: dùng List để duy trì thứ tự frame
            List<int> framePages = new List<int>();
            Dictionary<int, int> lastUsed = new Dictionary<int, int>();
            int pageFaults = 0;
            int pageHits = 0;

            // 3. Chuẩn bị DataGridView
            DGV.Rows.Clear();
            DGV.Columns.Clear();
            for (int i = 0; i < pages.Count; i++)
            {
                DGV.Columns.Add("col" + i, pages[i].ToString());
            }
            DGV.RowCount = frameCount + 1;
            for (int r = 0; r < frameCount; r++)
            {
                DGV.Rows[r].HeaderCell.Value = "Frame " + (r + 1);
            }
            DGV.Rows[frameCount].HeaderCell.Value = "Fault";

            // 4. Mô phỏng thuật toán LRU
            for (int i = 0; i < pages.Count; i++)
            {
                int page = pages[i];
                bool hit = framePages.Contains(page);
                bool isFault = false;

                if (!hit)
                {
                    // Nếu chưa đầy frame thì chưa phải fault thay thế
                    if (framePages.Count < frameCount)
                    {
                        framePages.Add(page);
                        pageFaults++;
                        isFault = false; // chưa full, chưa thay thế thì không đánh F
                    }
                    else
                    {
                        // Full rồi, thay thế trang theo LRU
                        int lru = int.MaxValue;
                        int pageToRemove = -1;
                        for (int j = 0; j < framePages.Count; j++)
                        {
                            int p = framePages[j];
                            if (lastUsed[p] < lru)
                            {
                                lru = lastUsed[p];
                                pageToRemove = p;
                            }
                        }

                        if (pageToRemove != -1)
                        {
                            framePages.Remove(pageToRemove);
                        }
                        framePages.Add(page);
                        pageFaults++;
                        isFault = true; // đã full và thay thế -> fault thật sự
                    }
                    DGV.Rows[frameCount].Cells[i].Value = isFault ? "F" : "";
                }
                else
                {
                    pageHits++;
                    DGV.Rows[frameCount].Cells[i].Value = "";
                }

                // Cập nhật thời gian sử dụng
                lastUsed[page] = i;

                // 5. Cập nhật trạng thái frame cố định theo thứ tự framePages
                for (int r = 0; r < frameCount; r++)
                {
                    if (r < framePages.Count)
                        DGV.Rows[r].Cells[i].Value = framePages[r].ToString();
                    else
                        DGV.Rows[r].Cells[i].Value = "";
                }
            }

            // 6. Hiển thị kết quả cuối
            lblFaults.Visible = true;
            lblHits.Visible = true;
            lblFaults.Text = "Page Faults: " + pageFaults;
            lblHits.Text = "Page Hits: " + pageHits;
            DGV.Enabled = false;
            DGV.ClearSelection();
            DGV.CurrentCell = null;
        }



    }
}
