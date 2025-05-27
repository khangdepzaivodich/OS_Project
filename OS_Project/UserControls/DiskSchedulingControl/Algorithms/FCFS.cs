using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OS_Project.Algorithms
{
    public class FCFSAlgorithm
    {
        public class FCFSResult
        {
            public bool IsSuccess { get; set; }
            public string ErrorMessage { get; set; }
            public int TotalSeekTime { get; set; }
            public List<string> Steps { get; set; }
            public List<int> SeekSequence { get; set; }
        }

        public FCFSResult Run(string startHeadInput, string requestsInput)
        {
            if (string.IsNullOrWhiteSpace(startHeadInput))
            {
                return new FCFSResult { IsSuccess = false, ErrorMessage = "Vui lòng nhập vị trí đầu đọc ban đầu." };
            }

            if (string.IsNullOrWhiteSpace(requestsInput))
            {
                return new FCFSResult { IsSuccess = false, ErrorMessage = "Vui lòng nhập các Request." };
            }

            if (!int.TryParse(startHeadInput, out int start))
            {
                return new FCFSResult { IsSuccess = false, ErrorMessage = "Vị trí đầu đọc không hợp lệ." };
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
                return new FCFSResult { IsSuccess = false, ErrorMessage = "Request không hợp lệ." };
            }

            int totalSeek = 0;
            int current = start;
            List<string> steps = new List<string>();
            List<int> seekSequence = new List<int> { start };

            foreach (int req in requests)
            {
                totalSeek += Math.Abs(req - current);
                steps.Add($"{current} → {req} ({Math.Abs(req - current)})");
                current = req;
                seekSequence.Add(current);
            }

            return new FCFSResult
            {
                IsSuccess = true,
                TotalSeekTime = totalSeek,
                Steps = steps,
                SeekSequence = seekSequence
            };
        }
    }
}
