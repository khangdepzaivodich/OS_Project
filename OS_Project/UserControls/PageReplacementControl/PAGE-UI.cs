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
    public partial class PAGE_UI : UserControl
    {
        public PAGE_UI()
        {
            InitializeComponent();
        }
        private void LoadUserControl(UserControl uc)
        {
            panelMain.Controls.Clear();       // Xóa UC cũ
            uc.Dock = DockStyle.Fill;         // Tự giãn theo panel
            panelMain.Controls.Add(uc);       // Thêm UC mới
        }

        private void btnFIFO_Click(object sender, EventArgs e)
        {
            LoadUserControl(new FIFO());
        }

        private void btnClock_Click(object sender, EventArgs e)
        {
            LoadUserControl(new CLOCK());
        }

        private void btnLRU_Click(object sender, EventArgs e)
        {
            LoadUserControl(new LRU());
        }

        private void btnOPTimal_Click(object sender, EventArgs e)
        {
            LoadUserControl(new OPTimal());
        }
    }
}
