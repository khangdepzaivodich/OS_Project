using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS_Project.UserControls.CpuSchedulingControl.Algorithms
{
    public class PriorityScheduler
    {
        public List<Process> InputProcesses { get; set; }
        public List<Process> ResultProcesses { get; private set; } = new List<Process>(); // Thống kê WT, TAT

        public List<Process> ExecutingSegments { get; private set; } = new List<Process>(); // Dùng vẽ Gantt
        public bool Preemptive { get; set; }
        public List<Process> ProcessList { get; }

        public PriorityScheduler(List<Process> processes, bool preemptive)
        {
            Preemptive = preemptive;
            InputProcesses = processes.Select(p => new Process
            {
                Id = p.Id,
                Name = p.Name,
                ArrivalTime = p.ArrivalTime,
                BurstTime = p.BurstTime,
                RemainingTime = p.BurstTime,
                StartTime = -1,
                Priority = p.Priority,
            }).ToList();

        }

        public void Run()
        {
            if (Preemptive)
            {
                RunPreemptive();
            }
            else RunNonPreemptive();
        }

        private void RunNonPreemptive()
        {
            int currentTime = 0;

            while (InputProcesses.Count > 0)
            {
                // Lấy danh sách các process đã đến (đã arrive)
                var available = InputProcesses.Where(a => a.ArrivalTime <= currentTime).ToList();

                if (available.Count == 0)
                {
                    // Nếu chưa có process nào arrive, nhảy tới thời điểm process arrive sớm nhất
                    currentTime = InputProcesses.Min(a => a.ArrivalTime);
                    continue;
                }


                available = available.OrderBy(a => a.Priority).ToList(); // Lấy process có priority cao nhất
                var p = available.FirstOrDefault();
                

                // Cập nhật thời gian bắt đầu, kết thúc, chờ và hoàn thành
                p.StartTime = currentTime;
                p.FinishTime = currentTime + p.BurstTime;
                p.WaitTime = p.StartTime - p.ArrivalTime;
                p.TurnAroundTime = p.FinishTime - p.ArrivalTime;
                p.RemainingTime = 0;
                
                currentTime = p.FinishTime;

                // Thêm process vào kết quả
                ResultProcesses.Add(p);

                // Loại bỏ process này khỏi danh sách chờ
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

                var nextProcess = available.OrderBy(a => a.Priority).ThenBy(a => a.ArrivalTime).FirstOrDefault();

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

                if (currentProcess == null && nextProcess != null)
                {
                    currentProcess = nextProcess;
                    if (currentProcess.StartTime == -1)
                        currentProcess.StartTime = currentTime;

                    lastExecutionStartTime = currentTime;
                }

                if (currentProcess != null)
                {
                    currentProcess.RemainingTime--;
                    currentTime++;

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
                    currentTime++;
                }
            }
        }
    }




}
