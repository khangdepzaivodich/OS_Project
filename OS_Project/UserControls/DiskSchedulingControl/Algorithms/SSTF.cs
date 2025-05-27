using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OS_Project.Algorithms
{
    public class SSTFAlgorithm
    {
        public class SSTFResult
        {
            public bool IsSuccess { get; set; }
            public string ErrorMessage { get; set; }
            public int TotalSeekTime { get; set; }
            public List<string> Steps { get; set; }
            public List<int> SeekSequence { get; set; }
        }

        public SSTFResult Run(string startHeadInput, string requestsInput)
        {
            if (string.IsNullOrWhiteSpace(startHeadInput))
            {
                return new SSTFResult { IsSuccess = false, ErrorMessage = "Vui lòng nhập vị trí đầu đọc ban đầu." };
            }

            if (string.IsNullOrWhiteSpace(requestsInput))
            {
                return new SSTFResult { IsSuccess = false, ErrorMessage = "Vui lòng nhập các Request." };
            }

            if (!int.TryParse(startHeadInput, out int start))
            {
                return new SSTFResult { IsSuccess = false, ErrorMessage = "Vị trí đầu đọc không hợp lệ." };
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
                return new SSTFResult { IsSuccess = false, ErrorMessage = "Request không hợp lệ." };
            }

            List<int> remaining = new List<int>(requests);
            List<string> steps = new List<string>();
            List<int> seekSequence = new List<int> { start };
            int totalSeek = 0;
            int current = start;

            while (remaining.Count > 0)
            {
                int closest = remaining.OrderBy(r => Math.Abs(r - current)).First();
                int distance = Math.Abs(closest - current);
                totalSeek += distance;
                steps.Add($"{current} → {closest} ({distance})");
                current = closest;
                seekSequence.Add(current);
                remaining.Remove(closest);
            }

            return new SSTFResult
            {
                IsSuccess = true,
                TotalSeekTime = totalSeek,
                Steps = steps,
                SeekSequence = seekSequence
            };
        }
    }
}
