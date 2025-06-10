using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OS_Project.UserControls.CpuSchedulingControl
{
    public partial class CPU_UI_UC : UserControl
    {
        public CPU_UI_UC()
        {
            InitializeComponent();
        }
        private void LoadUserControl(UserControl uc)
        {
            panelMain.Controls.Clear();       // Xóa UC cũ
            uc.Dock = DockStyle.Fill;         // Tự giãn theo panel
            panelMain.Controls.Add(uc);       // Thêm UC mới
        }
        private void btnFCFS_Click(object sender, EventArgs e)
        {
            LoadUserControl(new FCFS_UC());
        }

        private void btnSJF_Click(object sender, EventArgs e)
        {
            LoadUserControl(new SJF_UC());
        }

        private void btnRR_Click(object sender, EventArgs e)
        {
            LoadUserControl(new ROUND_ROBIN_UC());
        }

        private void btnPriority_Click(object sender, EventArgs e)
        {
            LoadUserControl(new Priority_UC());
        }
    }
}
