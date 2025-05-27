using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS_Project.Algorithms
{
    public class CSCANAlgorithm
    {
        public class CSCANResult
        {
            public bool IsSuccess { get; set; }
            public string ErrorMessage { get; set; }
            public int TotalSeekTime { get; set; }
            public List<string> Steps { get; set; }
            public List<int> SeekSequence { get; set; }
            public string Direction { get; set; }
        }

        public CSCANResult Run(string startHeadInput, string requestsInput, string fromInput, string toInput, string directionInput)
        {
            if (string.IsNullOrWhiteSpace(startHeadInput))
            {
                return new CSCANResult { IsSuccess = false, ErrorMessage = "Vui lòng nhập vị trí đầu đọc ban đầu." };
            }

            if (string.IsNullOrWhiteSpace(requestsInput))
            {
                return new CSCANResult { IsSuccess = false, ErrorMessage = "Vui lòng nhập các Request." };
            }

            if (!int.TryParse(startHeadInput, out int start))
            {
                return new CSCANResult { IsSuccess = false, ErrorMessage = "Vị trí đầu đọc không hợp lệ." };
            }

            if (!int.TryParse(fromInput, out int diskMin) ||
                !int.TryParse(toInput, out int diskMax) ||
                diskMin >= diskMax)
            {
                return new CSCANResult { IsSuccess = false, ErrorMessage = "Vui lòng nhập phạm vi đĩa hợp lệ." };
            }

            int[] requests;
            try
            {
                requests = requestsInput.Split(',')
                                        .Select(r => int.Parse(r.Trim()))
                                        .ToArray();
            }
            catch
            {
                return new CSCANResult { IsSuccess = false, ErrorMessage = "Request không hợp lệ." };
            }

            foreach (int req in requests)
            {
                if (req < diskMin || req >= diskMax)
                {
                    return new CSCANResult { IsSuccess = false, ErrorMessage = $"Request vượt phạm vi đĩa." };
                }
            }

            if (requests.Length == 0)
            {
                return new CSCANResult { IsSuccess = false, ErrorMessage = "Vui lòng nhập các Request hợp lệ." };
            }

            string direction = directionInput;
            int current = start;
            int totalSeek = 0;
            List<int> seekSequence = new List<int> { start };
            List<string> steps = new List<string>();

            Array.Sort(requests);

            List<int> left = requests.Where(r => r < current).ToList();
            List<int> right = requests.Where(r => r >= current).ToList();

            if (direction == "Left")
            {
                left.Reverse();
                foreach (int r in left)
                {
                    totalSeek += Math.Abs(current - r);
                    steps.Add($"{current} → {r} ({Math.Abs(current - r)})");
                    current = r;
                    seekSequence.Add(current);
                }

                if (current != diskMin)
                {
                    totalSeek += Math.Abs(current - diskMin);
                    steps.Add($"{current} → {diskMin} ({Math.Abs(current - diskMin)})");
                    current = diskMin;
                    seekSequence.Add(current);
                }

                steps.Add($"{diskMin} → {diskMax} (0)");
                current = diskMax;
                seekSequence.Add(current);

                right.Reverse();
                foreach (int r in right)
                {
                    totalSeek += Math.Abs(current - r);
                    steps.Add($"{current} → {r} ({Math.Abs(current - r)})");
                    current = r;
                    seekSequence.Add(current);
                }
            }
            else
            {
                foreach (int r in right)
                {
                    totalSeek += Math.Abs(current - r);
                    steps.Add($"{current} → {r} ({Math.Abs(current - r)})");
                    current = r;
                    seekSequence.Add(current);
                }

                if (current != diskMax)
                {
                    totalSeek += Math.Abs(diskMax - current);
                    steps.Add($"{current} → {diskMax} ({Math.Abs(diskMax - current)})");
                    current = diskMax;
                    seekSequence.Add(current);
                }

                steps.Add($"{diskMax} → {diskMin} (0)");
                current = diskMin;
                seekSequence.Add(current);

                foreach (int r in left)
                {
                    totalSeek += Math.Abs(current - r);
                    steps.Add($"{current} → {r} ({Math.Abs(current - r)})");
                    current = r;
                    seekSequence.Add(current);
                }
            }

            return new CSCANResult
            {
                IsSuccess = true,
                TotalSeekTime = totalSeek,
                Steps = steps,
                SeekSequence = seekSequence,
                Direction = direction
            };
        }
    }
}
