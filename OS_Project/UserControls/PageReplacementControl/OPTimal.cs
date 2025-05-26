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
    public partial class OPTimal : UserControl
    {
        public OPTimal()
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
                    pages.Add(int.Parse(part));
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

            // Hàm tìm vị trí trang bị thay thế theo thuật toán Optimal
            int Predict(List<int> frames, List<int> pageList, int currentIndex)
            {
                int res = -1;
                int farthest = currentIndex;

                for (int i = 0; i < frames.Count; i++)
                {
                    int page = frames[i];
                    int j;
                    for (j = currentIndex; j < pageList.Count; j++)
                    {
                        if (page == pageList[j])
                        {
                            if (j > farthest)
                            {
                                farthest = j;
                                res = i;
                            }
                            break;
                        }
                    }
                    // Nếu trang không còn xuất hiện trong tương lai thì trả về luôn vị trí này
                    if (j == pageList.Count)
                        return i;
                }
                return (res == -1) ? 0 : res;
            }

            // 3. Khởi tạo các cấu trúc lưu trữ
            List<int> framePages = new List<int>();
            int pageFaults = 0;
            int pageHits = 0;

            // 4. Chuẩn bị DataGridView
            DGV.Rows.Clear();
            DGV.Columns.Clear();
            for (int i = 0; i < pages.Count; i++)
            {
                DGV.Columns.Add("col" + i, pages[i].ToString());
            }
            DGV.RowCount = frameCount + 1;  // +1 dòng cho Fault
            for (int r = 0; r < frameCount; r++)
            {
                DGV.Rows[r].HeaderCell.Value = "Frame " + (r + 1);
            }
            DGV.Rows[frameCount].HeaderCell.Value = "Fault";

            // 5. Mô phỏng thuật toán Optimal
            for (int i = 0; i < pages.Count; i++)
            {
                int page = pages[i];
                bool hit = framePages.Contains(page);

                if (hit)
                {
                    pageHits++;
                    DGV.Rows[frameCount].Cells[i].Value = ""; // Không fault
                }
                else
                {
                    pageFaults++;
                    if (framePages.Count < frameCount)
                    {
                        // Thêm trang vào frame, chưa thay thế ai => KHÔNG đánh F
                        framePages.Add(page);
                        DGV.Rows[frameCount].Cells[i].Value = ""; // Không fault
                    }
                    else
                    {
                        // Phải thay thế trang => đánh dấu fault bằng chữ F
                        int replaceIndex = Predict(framePages, pages, i + 1);
                        framePages[replaceIndex] = page;
                        DGV.Rows[frameCount].Cells[i].Value = "F";
                    }
                }

                // 6. Cập nhật trạng thái frame vào DataGridView
                for (int r = 0; r < frameCount; r++)
                {
                    if (r < framePages.Count)
                        DGV.Rows[r].Cells[i].Value = framePages[r].ToString();
                    else
                        DGV.Rows[r].Cells[i].Value = "";
                }
            }

            // 7. Hiển thị kết quả cuối cùng
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
