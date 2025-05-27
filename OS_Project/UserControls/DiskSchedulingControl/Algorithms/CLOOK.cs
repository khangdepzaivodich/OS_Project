using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS_Project.Algorithms
{
    public class CLOOKAlgorithm
    {
        public class CLOOKResult
        {
            public bool IsSuccess { get; set; }
            public string ErrorMessage { get; set; }
            public int TotalSeekTime { get; set; }
            public List<string> Steps { get; set; }
            public List<int> SeekSequence { get; set; }
            public string Direction { get; set; }
        }

        public CLOOKResult Run(string startHeadInput, string requestsInput, string directionInput)
        {
            if (string.IsNullOrWhiteSpace(startHeadInput))
            {
                return new CLOOKResult { IsSuccess = false, ErrorMessage = "Vui lòng nhập vị trí đầu đọc ban đầu." };
            }
            if (string.IsNullOrWhiteSpace(requestsInput))
            {
                return new CLOOKResult { IsSuccess = false, ErrorMessage = "Vui lòng nhập các Request." };
            }
            if (!int.TryParse(startHeadInput, out int start))
            {
                return new CLOOKResult { IsSuccess = false, ErrorMessage = "Vị trí đầu đọc không hợp lệ." };
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
                return new CLOOKResult { IsSuccess = false, ErrorMessage = "Request không hợp lệ." };
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

                if (left.Count > 0 && right.Count > 0)
                {
                    int lastRight = right.Last();
                    totalSeek += Math.Abs(current - lastRight);
                    steps.Add($"{current} → {lastRight} ({Math.Abs(current - lastRight)})");
                    current = lastRight;
                    seekSequence.Add(current);
                    right.RemoveAt(right.Count - 1);
                }

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

                if (right.Count > 0 && left.Count > 0)
                {
                    int firstLeft = left.First();
                    totalSeek += Math.Abs(current - firstLeft);
                    steps.Add($"{current} → {firstLeft} ({Math.Abs(current - firstLeft)})");
                    current = firstLeft;
                    seekSequence.Add(current);
                    left.RemoveAt(0);
                }

                foreach (int r in left)
                {
                    totalSeek += Math.Abs(current - r);
                    steps.Add($"{current} → {r} ({Math.Abs(current - r)})");
                    current = r;
                    seekSequence.Add(current);
                }
            }

            return new CLOOKResult
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
