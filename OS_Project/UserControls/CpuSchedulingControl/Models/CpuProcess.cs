using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS_Project.UserControls.CpuSchedulingControl.Models
{
        public class TimeScheduling
        {
            public int WaitingTime { get; set; }
            public int TurnaroundTime { get; set; }
        }
        public class Process
        {
            public string Id { get; set; }
            public int BurstTime { get; set; }
        }

        public class ProcessAndTime
        {
            public int arrival_time { get; set; }
            public string process_Name { get; set; }
            public int burst_time { get; set; }
            public int waiting_time { get; set; }
            public int turnaroundtime { get; set; }
            public void setProcessAndTime(TimeScheduling ts, Process p, int i)
            {
                arrival_time = i;
                process_Name = p.Id;
                burst_time = p.BurstTime;
                waiting_time = ts.WaitingTime;
                turnaroundtime = ts.TurnaroundTime;
            }
        }
        public class GanttBlock
        {
            public string ProcessId { get; set; }
            public int StartTime { get; set; }
            public int EndTime { get; set; }
        }
}
