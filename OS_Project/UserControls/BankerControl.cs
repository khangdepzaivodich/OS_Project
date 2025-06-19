using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OS_Project
{
    public partial class BankerControl : UserControl
    {
        public BankerControl()
        {
            InitializeComponent();
            NoResources.Leave += UserInputChanged;
            NoProcesses.Leave += UserInputChanged;

            InitializeBankerDemo();
        }

        private DataTable allocationTable;
        private DataTable maxTable;
        private DataTable totalResourcesTable;
        private DataTable availableTable;
        private DataTable needTable;

        private void UserInputChanged(object sender, EventArgs e)
        {
            InitializeBankerDemo();
        }

        private void InitializeBankerDemo()
        {
            int resources = 0, processes = 0;
            if (!int.TryParse(NoResources.Text, out resources) || resources < 0)
            {
                resources = 0;
                NoResources.Text = "0";
            }

            if (!int.TryParse(NoProcesses.Text, out processes) || processes < 0)
            {
                processes = 0;
                NoProcesses.Text = "0";
            }

            allocationTable = new DataTable();
            maxTable = new DataTable();
            totalResourcesTable = new DataTable();
            availableTable = new DataTable();
            needTable = new DataTable();

            for (int i = 0; i < resources; i++)
            {
                string colName = "R" + i;
                allocationTable.Columns.Add(colName);
                maxTable.Columns.Add(colName);
                totalResourcesTable.Columns.Add(colName);
                availableTable.Columns.Add(colName);
                needTable.Columns.Add(colName);
            }

            for (int i = 0; i < processes; i++)
            {
                allocationTable.Rows.Add(allocationTable.NewRow());
                maxTable.Rows.Add(maxTable.NewRow());
                needTable.Rows.Add(needTable.NewRow());
            }

            totalResourcesTable.Rows.Add(totalResourcesTable.NewRow());
            availableTable.Rows.Add(availableTable.NewRow());

            dgvAllocation.DataSource = allocationTable;
            dgvMax.DataSource = maxTable;
            dgvTotalResources.DataSource = totalResourcesTable;
            dgvAvailable.DataSource = availableTable;
            dgvNeed.DataSource = needTable;

            lblStatus.Text = "";
        }

        private async void btnCheckSafety_Click(object sender, EventArgs e)
        {
            if (allocationTable.Rows.Count == 0 || allocationTable.Columns.Count == 0)
            {
                lblStatus.Text = "Please enter valid resources and processes.";
                return;
            }

            if (!TryGetMatrixFromTable(allocationTable, out int[,] allocation))
            {
                lblStatus.Text = "Invalid Allocation matrix values!";
                return;
            }

            if (!TryGetMatrixFromTable(maxTable, out int[,] max))
            {
                lblStatus.Text = "Invalid Max matrix values!";
                return;
            }

            if (!TryGetVectorFromTable(totalResourcesTable, out int[] totalResources))
            {
                lblStatus.Text = "Invalid Total Resources values!";
                return;
            }

            int[] available = CalculateAvailable(allocation, totalResources);

            for (int j = 0; j < available.Length; j++)
                availableTable.Rows[0][j] = available[j];

            int[,] need = CalculateNeedMatrix(allocation, max);
            FillTableFromMatrix(needTable, need);

            dgvAvailable.ClearSelection();
            dgvNeed.ClearSelection();

            bool safe = await IsSystemSafeStepByStepAsync(allocation, max, available);

            ResetHighlight(dgvAvailable);
            ResetHighlight(dgvNeed);
            ResetHighlight(dgvAllocation);

            if (!safe)
                lblStatus.Text = "System is NOT in a safe state!";
        }

        private bool TryGetMatrixFromTable(DataTable table, out int[,] matrix)
        {
            int rows = table.Rows.Count;
            int cols = table.Columns.Count;
            matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    string valStr = table.Rows[i][j]?.ToString().Trim();

                    if (string.IsNullOrEmpty(valStr))
                    {
                        matrix[i, j] = 0; 
                    }
                    else if (!int.TryParse(valStr, out int val) || val < 0)
                    {
                        return false; 
                    }
                    else
                    {
                        matrix[i, j] = val;
                    }
                }
            }
            return true;
        }

        private bool TryGetVectorFromTable(DataTable table, out int[] vector)
        {
            int cols = table.Columns.Count;
            vector = new int[cols];

            if (table.Rows.Count == 0)
                return false;

            for (int j = 0; j < cols; j++)
            {
                string valStr = table.Rows[0][j]?.ToString().Trim();

                if (string.IsNullOrEmpty(valStr))
                {
                    vector[j] = 0; 
                }
                else if (!int.TryParse(valStr, out int val) || val < 0)
                {
                    return false; 
                }
                else
                {
                    vector[j] = val;
                }
            }

            return true;
        }

        private int[] CalculateAvailable(int[,] allocation, int[] totalResources)
        {
            int m = allocation.GetLength(1);
            int[] available = new int[m];

            for (int j = 0; j < m; j++)
                available[j] = totalResources[j];

            for (int i = 0; i < allocation.GetLength(0); i++)
                for (int j = 0; j < m; j++)
                    available[j] -= allocation[i, j];

            return available;
        }

        private int[,] CalculateNeedMatrix(int[,] allocation, int[,] max)
        {
            int n = allocation.GetLength(0);
            int m = allocation.GetLength(1);
            int[,] need = new int[n, m];

            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    need[i, j] = max[i, j] - allocation[i, j];

            return need;
        }

        private void FillTableFromMatrix(DataTable table, int[,] matrix)
        {
            table.Rows.Clear();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                DataRow row = table.NewRow();
                for (int j = 0; j < matrix.GetLength(1); j++)
                    row[j] = matrix[i, j];
                table.Rows.Add(row);
            }
        }

        private async Task<bool> IsSystemSafeStepByStepAsync(int[,] allocation, int[,] max, int[] available)
        {
            int n = allocation.GetLength(0);
            int m = allocation.GetLength(1);
            bool[] finish = new bool[n];
            int[] work = (int[])available.Clone();

            int[,] need = CalculateNeedMatrix(allocation, max);

            var safeSequence = new System.Collections.Generic.List<int>();
            bool[] doneHighlight = new bool[n];

            for (int count = 0; count < n; count++)
            {
                bool found = false;
                for (int p = 0; p < n; p++)
                {
                    if (!finish[p])
                    {
                        HighlightRow(dgvNeed, p, Color.LightYellow);

                        bool canProceed = true;
                        for (int r = 0; r < m; r++)
                        {
                            if (need[p, r] > work[r])
                            {
                                canProceed = false;
                                break;
                            }
                        }

                        await Task.Delay(1000);

                        if (canProceed)
                        {
                            HighlightRow(dgvNeed, p, Color.LightGreen);
                            HighlightRow(dgvAllocation, p, Color.LightGreen);
                            HighlightRow(dgvAvailable, 0, Color.LightGreen);

                            await Task.Delay(1000);

                            for (int r = 0; r < m; r++)
                                work[r] += allocation[p, r];
                            finish[p] = true;

                            for (int j = 0; j < m; j++)
                                availableTable.Rows[0][j] = work[j];

                            safeSequence.Add(p);
                            HighlightRow(dgvNeed, p, Color.LightGray);
                            HighlightRow(dgvAllocation, p, Color.LightGray);
                            doneHighlight[p] = true;

                            ResetHighlight(dgvAvailable);

                            found = true;
                            break;
                        }

                        ResetHighlight(dgvNeed);
                        ResetHighlight(dgvAvailable);
                        for (int i = 0; i < n; i++)
                        {
                            if (doneHighlight[i])
                            {
                                HighlightRow(dgvNeed, i, Color.LightGray);
                                HighlightRow(dgvAllocation, i, Color.LightGray);
                            }
                        }
                    }
                }
                if (!found)
                    break;
            }

            if (safeSequence.Count == n)
            {
                lblStatus.Text = "Safe Sequence: " + string.Join(" -> ", safeSequence.ConvertAll(p => "P" + p));
                return true;
            }
            else
            {
                return false;
            }
        }

        private void HighlightRow(DataGridView dgv, int rowIndex, Color color)
        {
            if (rowIndex < 0 || rowIndex >= dgv.Rows.Count)
                return;

            dgv.ClearSelection();
            foreach (DataGridViewCell cell in dgv.Rows[rowIndex].Cells)
                cell.Style.BackColor = color;
        }

        private void ResetHighlight(DataGridView dgv)
        {
            foreach (DataGridViewRow row in dgv.Rows)
                foreach (DataGridViewCell cell in row.Cells)
                    cell.Style.BackColor = Color.White;
            dgv.ClearSelection();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
