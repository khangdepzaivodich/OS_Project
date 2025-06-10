using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS_Project.UserControls.CpuSchedulingControl.Algorithms
{
    // Round Robin Scheduler
    public class RoundRobinScheduler
    {
        
        public List<Process> InputProcesses { get; set; }
        public List<Process> ResultProcesses { get; private set; } = new List<Process>(); // Thống kê WT, TAT
        public List<Process> ExecutingSegments { get; private set; } = new List<Process>(); // Dùng vẽ Gantt
        public int Quantum { get; set; }
        public List<Process> ProcessList { get; }

        public RoundRobinScheduler(List<Process> processes, int quantum)
        {
            Quantum = quantum;
            InputProcesses = processes.Select(p => new Process
            {
                Id = p.Id,
                Name = p.Name,
                ArrivalTime = p.ArrivalTime,
                BurstTime = p.BurstTime,
                RemainingTime = p.BurstTime,
                StartTime = -1
            }).ToList();
        }
 

        public void Run()
        {
            int currentTime = 0;
            var queue = new Queue<Process>();
            var processes = new List<Process>(InputProcesses);

            while (processes.Any() || queue.Any())
            {
                // Đưa các tiến trình đến hàng đợi nếu đã đến thời điểm
                foreach (var p in processes.Where(p => p.ArrivalTime <= currentTime).ToList())
                {
                    queue.Enqueue(p);
                    processes.Remove(p);
                }

                if (!queue.Any())
                {
                    currentTime++;
                    continue;
                }

                var a = queue.Dequeue();

                if (a.StartTime == -1)
                    a.StartTime = currentTime;

                int execTime = Math.Min(Quantum, a.RemainingTime);

                // Lưu đoạn thực thi cho sơ đồ Gantt
                ExecutingSegments.Add(new Process
                {
                    Id = a.Id,
                    Name = a.Name,
                    ArrivalTime = a.ArrivalTime,
                    BurstTime = a.BurstTime,
                    StartTime = currentTime,
                    FinishTime = currentTime + execTime
                });

                currentTime += execTime;
                a.RemainingTime -= execTime;

                // Thêm các tiến trình mới vào hàng đợi (nếu đến trong khi chạy)
                foreach (var proc in processes.Where(x => x.ArrivalTime <= currentTime).ToList())
                {
                    queue.Enqueue(proc);
                    processes.Remove(proc);
                }

                // Nếu tiến trình chưa xong thì đưa lại vào hàng đợi
                if (a.RemainingTime > 0)
                {
                    queue.Enqueue(a);
                }
            }

            // Tính toán thống kê: FinishTime, TAT, WaitTime
            foreach (var p in InputProcesses)
            {
                var segments = ExecutingSegments.Where(s => s.Id == p.Id).ToList();
                if (segments.Any())
                {
                    p.FinishTime = segments.Last().FinishTime;
                    int totalExecution = segments.Sum(s => s.FinishTime - s.StartTime);
                    p.TurnAroundTime = p.FinishTime - p.ArrivalTime;
                    p.WaitTime = p.TurnAroundTime - totalExecution;

                    ResultProcesses.Add(p);
                }
            }
        }
    }


}
