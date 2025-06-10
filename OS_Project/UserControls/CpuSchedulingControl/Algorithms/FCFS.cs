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

        public FCFSScheduler(List<Process> processes)
        {
            InputProcesses = processes
                .Select(p => new Process
                {
                    Id = p.Id,
                    Name = p.Name,
                    ArrivalTime = p.ArrivalTime,
                    BurstTime = p.BurstTime,
                    RemainingTime = p.BurstTime
                }).ToList();

            ResultProcesses = new List<Process>();
        }

        public void Run()
        {
            if (InputProcesses.Count == 0)
                return;

            var queue = InputProcesses.OrderBy(p => p.ArrivalTime).ToList();
            int currentTime = 0;

            while (queue.Count > 0)
            {
                var p = queue[0];

                if (p.ArrivalTime > currentTime)
                {
                    var idle = new Process
                    {
                        Id = -1,
                        Name = "Idle",
                        ArrivalTime = currentTime,
                        StartTime = currentTime,
                        BurstTime = p.ArrivalTime - currentTime,
                        FinishTime = p.ArrivalTime,
                        RemainingTime = 0
                    };
                    ResultProcesses.Add(idle);
                    currentTime = p.ArrivalTime;
                }

                p.StartTime = currentTime;
                p.FinishTime = p.StartTime + p.BurstTime;
                p.WaitTime = p.StartTime - p.ArrivalTime;
                p.TurnAroundTime = p.FinishTime - p.ArrivalTime;
                p.RemainingTime = 0;

                currentTime = p.FinishTime;

                ResultProcesses.Add(p);
                queue.RemoveAt(0);
            }
        }

    }

}
