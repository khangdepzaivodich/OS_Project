using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OS_Project.UserControls.CpuSchedulingControl.Models;

namespace OS_Project.UserControls.CpuSchedulingControl.Schedulers
{
    internal interface SchedulerAlgorithm
    {
        List<ProcessAndTime> schedule(SortedDictionary<int,Process> storage );
    }

    internal class FCFS_Scheduler : SchedulerAlgorithm
    {
        public List<GanttBlock> ganttData = new List<GanttBlock>();
        public List<ProcessAndTime> schedule(SortedDictionary<int,Process> storage )
        {
            List<ProcessAndTime> result = new List<ProcessAndTime>();
            int currentTime = 0;


            foreach (var x in storage)
            {
                int arrival = x.Key;
                var process = x.Value;

                
                int startTime = Math.Max(currentTime, arrival);

                int waitingTime = startTime - arrival;
                int turnaroundTime = waitingTime + process.BurstTime;

                currentTime = startTime + process.BurstTime;

                ganttData.Add(new GanttBlock
                {
                    ProcessId = process.Id,
                    StartTime = startTime,
                    EndTime = currentTime
                });

                TimeScheduling tmp = new TimeScheduling
                {
                    WaitingTime = waitingTime,
                    TurnaroundTime = turnaroundTime
                };

                ProcessAndTime processAndTime = new ProcessAndTime();
                processAndTime.setProcessAndTime(tmp, process, arrival);
                result.Add(processAndTime);
            }

            return result;
        }
    }

    internal class SJF_Scheduler : SchedulerAlgorithm
    {
        public List<GanttBlock> ganttData = new List<GanttBlock>();
        public List<ProcessAndTime> schedule(SortedDictionary<int, Process> storage)
        {
            List<ProcessAndTime> result = new List<ProcessAndTime>();

            var processes = storage.ToList();
            List<(int arrival, Process process)> readyQueue = new List<(int, Process)>();
            int currentTime = 1;

            while (processes.Count > 0 || readyQueue.Count > 0)
            {
                // Đưa các tiến trình đến thời điểm currentTime vào readyQueue
                var arrived = processes.Where(p => p.Key <= currentTime).ToList();
                foreach (var p in arrived)
                {
                    readyQueue.Add((p.Key, p.Value));
                    processes.Remove(p);
                }

                if (readyQueue.Count == 0)
                {
                    // Nếu chưa có tiến trình nào sẵn sàng, nhảy tới thời gian tiến trình sớm nhất còn lại
                    currentTime = processes.Min(p => p.Key);
                    continue;
                }

                // Chọn tiến trình có BurstTime nhỏ nhất trong readyQueue
                var nextProcess = readyQueue.OrderBy(p => p.process.BurstTime).First();
                readyQueue.Remove(nextProcess);

                int waitingTime = currentTime - nextProcess.arrival;
                int turnaroundTime = waitingTime + nextProcess.process.BurstTime;

                ganttData.Add(new GanttBlock
                {
                    ProcessId = nextProcess.process.Id,
                    StartTime = currentTime,
                    EndTime = currentTime + nextProcess.process.BurstTime
                });

                TimeScheduling tmp = new TimeScheduling
                {
                    WaitingTime = waitingTime,
                    TurnaroundTime = turnaroundTime
                };

                ProcessAndTime pat = new ProcessAndTime();
                pat.setProcessAndTime(tmp, nextProcess.process, nextProcess.arrival);
                result.Add(pat);

                currentTime += nextProcess.process.BurstTime;
            }
            return result;
        }
    }

    internal class RR_scheduler : SchedulerAlgorithm
    {
        int rr_size = 2;
        public List<GanttBlock> ganttData = new List<GanttBlock>();
        public void set_rr_size(int i)
        {
            rr_size = i;
        }

        public List<ProcessAndTime> schedule(SortedDictionary<int, Process> storage)
        {
            List<ProcessAndTime> result = new List<ProcessAndTime>();
            var processList = storage.ToList();

            Dictionary<string, int> remainingTime = new Dictionary<string, int>();
            Dictionary<string, int> arrivalTime = new Dictionary<string, int>();
            Dictionary<string, int> completionTime = new Dictionary<string, int>();

            foreach (var p in processList)
            {
                remainingTime[p.Value.Id] = p.Value.BurstTime;
                arrivalTime[p.Value.Id] = p.Key;
            }

            Queue<string> readyQueue = new Queue<string>();
            int currentTime = 0;

            // Khởi tạo ready queue với tiến trình đầu tiên (hoặc tiến trình đến sớm nhất)
            int earliestArrival = processList.Min(p => p.Key);
            currentTime = earliestArrival;
            foreach (var p in processList.Where(p => p.Key == earliestArrival))
            {
                readyQueue.Enqueue(p.Value.Id);
            }

            HashSet<string> visited = new HashSet<string>(readyQueue);

            while (readyQueue.Count > 0)
            {
                string pid = readyQueue.Dequeue();
                int execTime = Math.Min(rr_size, remainingTime[pid]);

                ganttData.Add(new GanttBlock
                {
                    ProcessId = pid,
                    StartTime = currentTime,
                    EndTime = currentTime + execTime
                });

                remainingTime[pid] -= execTime;
                currentTime += execTime;

                // Kiểm tra các tiến trình mới đến trong thời gian execTime vừa rồi
                foreach (var p in processList)
                {
                    if (p.Key > arrivalTime[pid] && p.Key <= currentTime && !visited.Contains(p.Value.Id))
                    {
                        readyQueue.Enqueue(p.Value.Id);
                        visited.Add(p.Value.Id);
                    }
                }

                if (remainingTime[pid] > 0)
                {
                    readyQueue.Enqueue(pid); // quay lại queue nếu chưa xong
                }
                else
                {
                    completionTime[pid] = currentTime;
                }
            }

            // Tính toán WaitingTime và TurnaroundTime cho từng tiến trình
            foreach (var p in processList)
            {
                int tat = completionTime[p.Value.Id] - p.Key; // turnaround time = hoàn thành - đến
                int wt = tat - p.Value.BurstTime; // waiting time = turnaround - burst

                TimeScheduling ts = new TimeScheduling
                {
                    WaitingTime = wt,
                    TurnaroundTime = tat
                };

                ProcessAndTime pat = new ProcessAndTime();
                pat.setProcessAndTime(ts, p.Value, p.Key);
                result.Add(pat);
            }

            return result;
        }
    }
}
