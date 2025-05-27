using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS_Project.Algorithms
{
    public class SCANAlgorithm
    {
        public class SCANResult
        {
            public bool IsSuccess { get; set; }
            public string ErrorMessage { get; set; }
            public int TotalSeekTime { get; set; }
            public List<string> Steps { get; set; }
            public List<int> SeekSequence { get; set; }
            public string Direction { get; set; }
        }

        public SCANResult Run(string startHeadInput, string requestsInput, string diskMinInput, string diskMaxInput, string directionInput)
        {
            if (string.IsNullOrWhiteSpace(startHeadInput))
            {
                return new SCANResult { IsSuccess = false, ErrorMessage = "Vui lòng nhập vị trí đầu đọc ban đầu." };
            }

            if (string.IsNullOrWhiteSpace(requestsInput))
            {
                return new SCANResult { IsSuccess = false, ErrorMessage = "Vui lòng nhập các Request." };
            }

            if (!int.TryParse(startHeadInput, out int start))
            {
                return new SCANResult { IsSuccess = false, ErrorMessage = "Vị trí đầu đọc không hợp lệ." };
            }

            if (!int.TryParse(diskMinInput, out int diskMin) ||
                !int.TryParse(diskMaxInput, out int diskMax) ||
                diskMin >= diskMax)
            {
                return new SCANResult { IsSuccess = false, ErrorMessage = "Vui lòng nhập phạm vi đĩa hợp lệ." };
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
                return new SCANResult { IsSuccess = false, ErrorMessage = "Request không hợp lệ." };
            }

            foreach (int req in requests)
            {
                if (req < diskMin || req >= diskMax)
                {
                    return new SCANResult { IsSuccess = false, ErrorMessage = "Request vượt phạm vi đĩa." };
                }
            }

            if (requests.Length == 0)
            {
                return new SCANResult { IsSuccess = false, ErrorMessage = "Vui lòng nhập các Request hợp lệ." };
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
                if (left.Count > 0 && current != diskMin)
                {
                    totalSeek += Math.Abs(current - diskMin);
                    steps.Add($"{current} → {diskMin} ({Math.Abs(current - diskMin)})");
                    current = diskMin;
                    seekSequence.Add(current);
                }

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
                if (right.Count > 0 && current != diskMax)
                {
                    totalSeek += Math.Abs(current - diskMax);
                    steps.Add($"{current} → {diskMax} ({Math.Abs(current - diskMax)})");
                    current = diskMax;
                    seekSequence.Add(current);
                }

                left.Reverse();
                foreach (int r in left)
                {
                    totalSeek += Math.Abs(current - r);
                    steps.Add($"{current} → {r} ({Math.Abs(current - r)})");
                    current = r;
                    seekSequence.Add(current);
                }
            }

            return new SCANResult
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