using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS_Project.UserControls.CpuSchedulingControl.Algorithms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class FCFSScheduler
    {
        public List<Process> InputProcesses { get; set; }
        public List<Process> ResultProcesses { get; private set; }

        public FCFSScheduler(IEnumerable<Process> processes)
        {
            // Clone input để không sửa gốc
            InputProcesses = processes
                .Select(p => new Process
                {
                    Id = p.Id,
                    Name = p.Name,
                    ArrivalTime = p.ArrivalTime,
                    BurstTime = p.BurstTime,
                    RemainingTime = p.BurstTime
                })
                .OrderBy(p => p.ArrivalTime)
                .ToList();

            ResultProcesses = new List<Process>();
        }

        public void Run()
        {
            ResultProcesses.Clear();
            if (!InputProcesses.Any())
                return;

            // Khởi currentTime = arrival của process đầu tiên
            int currentTime = InputProcesses[0].ArrivalTime;

            foreach (var p in InputProcesses)
            {
                // Nếu arrival > currentTime ⇒ chèn idle
                if (p.ArrivalTime > currentTime)
                {
                    var idle = new Process
                    {
                        Id = 0,
                        Name = "Idle",
                        ArrivalTime = currentTime,
                        StartTime = currentTime,
                        BurstTime = p.ArrivalTime - currentTime,
                        FinishTime = p.ArrivalTime,
                        RemainingTime = 0,
                        WaitTime = 0,
                        TurnAroundTime = 0
                    };

                    ResultProcesses.Add(idle);
                    currentTime = p.ArrivalTime;
                }

                // Schedule process p
                p.StartTime = currentTime;
                p.FinishTime = p.StartTime + p.BurstTime;
                p.WaitTime = p.StartTime - p.ArrivalTime;
                p.TurnAroundTime = p.FinishTime - p.ArrivalTime;
                p.RemainingTime = 0;

                ResultProcesses.Add(p);
                currentTime = p.FinishTime;
            }
        }
    }


}
