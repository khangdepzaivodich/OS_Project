using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OS_Project.UserControls.PageReplacementControl;

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
            tabControl.TabPages.Add(CreateTab("PAGE_REPLACEMENT - FIFO" , new FIFO()));
            tabControl.TabPages.Add(CreateTab("PAGE_REPLACEMENT - CLOCK", new CLOCK()));
            tabControl.TabPages.Add(CreateTab("PAGE_REPLACEMENT - LRU", new LRU()));
            tabControl.TabPages.Add(CreateTab("PAGE_REPLACEMENT - OPTimal", new OPTimal()));
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
