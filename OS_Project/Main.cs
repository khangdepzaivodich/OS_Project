using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OS_Project
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            var tabControl = new TabControl
            {
                Dock = DockStyle.Fill
            };

            tabControl.TabPages.Add(CreateTab("Banker Algorithm", new BankerControl()));
            tabControl.TabPages.Add(CreateTab("CPU Scheduling", new CpuSchedulingControl()));
            tabControl.TabPages.Add(CreateTab("Page Replacement", new PageReplacementControl()));
            tabControl.TabPages.Add(CreateTab("Disk Scheduling", new DiskSchedulingControl()));

            Controls.Add(tabControl);
        }

        private TabPage CreateTab(string title, UserControl control)
        {
            var tabPage = new TabPage(title);
            control.Dock = DockStyle.Fill;
            tabPage.Controls.Add(control);
            return tabPage;
        }
    }
}
