using System;
using System.Collections.Generic;
using System.Linq;

namespace OS_Project.UserControls.CpuSchedulingControl.Algorithms
{
    public class SJFScheduler
    {
        public List<Process> InputProcesses { get; set; }
        public List<Process> ResultProcesses { get; private set; }
        public bool Preemptive { get; set; }

        public SJFScheduler(List<Process> processes, bool preemptive)
        {
            Preemptive = preemptive;
            InputProcesses = processes.Select(p => new Process
            {
                Id = p.Id,
                Name = p.Name,
                ArrivalTime = p.ArrivalTime,
                BurstTime = p.BurstTime,
                RemainingTime = p.BurstTime,
                StartTime = -1
            }).ToList();

            ResultProcesses = new List<Process>();
        }

        public void Run()
        {
            if (Preemptive)
                RunPreemptive();
            else
                RunNonPreemptive();
        }

        private void RunNonPreemptive()
        {
            var currentTime = 0;
            while (InputProcesses.Count > 0)
            {
                var available = InputProcesses.Where(a => a.ArrivalTime <= currentTime).ToList();

                if (available.Count == 0)
                {
                    currentTime = InputProcesses.Min(a => a.ArrivalTime);
                    continue;
                }

                var p = available.OrderBy(a => a.BurstTime).First();

                p.StartTime = currentTime;
                p.FinishTime = currentTime + p.BurstTime;
                p.WaitTime = p.StartTime - p.ArrivalTime;
                p.TurnAroundTime = p.FinishTime - p.ArrivalTime;
                p.RemainingTime = 0;

                currentTime = p.FinishTime;
                ResultProcesses.Add(p);
                InputProcesses.Remove(p);
            }
        }

        private void RunPreemptive()
        {
            int currentTime = 0;
            var processQueue = new List<Process>(InputProcesses);
            Process currentProcess = null;
            int lastExecutionStartTime = -1;

            while (processQueue.Count > 0 || currentProcess != null)
            {
                var available = processQueue.Where(p => p.ArrivalTime <= currentTime).ToList();

                if (available.Count == 0 && currentProcess == null)
                {
                    currentTime++;
                    continue;
                }

                var nextProcess = available.OrderBy(p => p.RemainingTime).ThenBy(p => p.ArrivalTime).FirstOrDefault();

                // Nếu đổi tiến trình đang chạy
                if (currentProcess != null && currentProcess != nextProcess)
                {
                    ResultProcesses.Add(new Process
                    {
                        Id = currentProcess.Id,
                        Name = currentProcess.Name,
                        ArrivalTime = currentProcess.ArrivalTime,
                        BurstTime = currentProcess.BurstTime,
                        StartTime = lastExecutionStartTime,
                        FinishTime = currentTime
                    });

                    currentProcess = null;
                }

                // Nếu chưa có tiến trình đang chạy
                if (currentProcess == null && nextProcess != null)
                {
                    currentProcess = nextProcess;
                    if (currentProcess.StartTime == -1)
                        currentProcess.StartTime = currentTime;

                    lastExecutionStartTime = currentTime;
                }

                // Thực thi
                if (currentProcess != null)
                {
                    currentProcess.RemainingTime--;
                    currentTime++;

                    // Nếu xong → đưa vào kết quả
                    if (currentProcess.RemainingTime == 0)
                    {
                        ResultProcesses.Add(new Process
                        {
                            Id = currentProcess.Id,
                            Name = currentProcess.Name,
                            ArrivalTime = currentProcess.ArrivalTime,
                            BurstTime = currentProcess.BurstTime,
                            StartTime = lastExecutionStartTime,
                            FinishTime = currentTime,
                            TurnAroundTime = currentTime - currentProcess.ArrivalTime,
                            WaitTime = (currentTime - currentProcess.ArrivalTime) - currentProcess.BurstTime
                        });

                        processQueue.Remove(currentProcess);
                        currentProcess = null;
                    }
                }
                else
                {
                    currentTime++; // nếu không có tiến trình nào chạy
                }
            }
        }
    }
}