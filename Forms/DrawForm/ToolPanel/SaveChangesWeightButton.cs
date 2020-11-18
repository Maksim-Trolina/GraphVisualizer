using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using GraphRepresentation;

namespace Forms.DrawForm
{
    class SaveWeightButton : ToolStripButton
    {
        private AdjacencyList adjacencyList;

        private List<List<CellBox>> matrix;

        private WeightTable weightTable;

        private AdjacencyListPanel adListPanel;

        public SaveWeightButton(int width, int height, AdjacencyList adjacencyList, List<List<CellBox>> matrix, WeightTable weightTable, AdjacencyListPanel adListPanel)
        {
            this.adjacencyList = adjacencyList;

            this.matrix = matrix;

            this.weightTable = weightTable;

            this.adListPanel = adListPanel;

            Size = new System.Drawing.Size(width, height);

            Text = "Save Changes";

            Click += new EventHandler(ButtonClick);

            Enabled = false;
        } 

        private void ButtonClick(object sender, EventArgs e)
        {
            if (weightTable.Visible)
            {
                SaveMatrixWeight();
            }

            else if (adListPanel.Visible) {

                SaveAdjacencyListWeight();

            }

            UpdateMatrix();

            UpdateAdjacencyList();
        }

        private void SaveMatrixWeight()
        {
            int value;

            for (int i = 0; i < matrix.Count; ++i)
            {
                for (int j = 0; j < matrix.Count; ++j)
                {
                    try
                    {
                        value = Int32.Parse(matrix[i][j].Text);
                    }
                    catch
                    {
                        value = matrix[i][j].FirstDigit - '0';
                    }

                    if (value != 0)
                    {
                        if (adjacencyList.adjacencyList[i][adjacencyList.FindNumberInList(i, j)].Weight != value)
                        {
                            adjacencyList.ChangeWeight(i, adjacencyList.FindNumberInList(i, j), value);
                        }
                    }
                }
            }
        }

        private void SaveAdjacencyListWeight()
        {
            int value;

            for (int i = 0; i < adListPanel.AdListTable.Cells.Count; ++i)
            {
                for (int j = 0; j < adListPanel.AdListTable.Cells[i].Count; ++j)
                {
                    try
                    {
                        value = Int32.Parse(adListPanel.AdListTable.Cells[i][j].WeightBox.Text);
                    }
                    catch
                    {
                        value = adListPanel.AdListTable.Cells[i][j].WeightBox.FirstDigit - '0';
                    }

                    if (value != 0)
                    {
                        if (adjacencyList.adjacencyList[i][j].Weight != value)
                        {
                            adjacencyList.ChangeWeight(i, j, value);
                        }
                    }
                }
            }
        }

        private void UpdateMatrix()
        {
            int value;

            for (int i = 0; i < matrix.Count; ++i)
            {
                for (int j = 0; j < matrix.Count; ++j)
                {
                    try
                    {
                        value = Int32.Parse(matrix[i][j].Text);
                    }
                    catch
                    {
                        value = matrix[i][j].FirstDigit - '0';
                    }

                    if (value != 0)
                    {
                        matrix[i][j].Text = Convert.ToString(adjacencyList.adjacencyList[i][adjacencyList.FindNumberInList(i,j)].Weight);
                    }
                   
                }
            }
        }

        private void UpdateAdjacencyList()
        {
            int value;

            for (int i = 0; i < adListPanel.AdListTable.Cells.Count; ++i)
            {
                for (int j = 0; j < adListPanel.AdListTable.Cells[i].Count; ++j)
                {
                    try
                    {
                        value = Int32.Parse(adListPanel.AdListTable.Cells[i][j].WeightBox.Text);
                    }
                    catch
                    {
                        value = adListPanel.AdListTable.Cells[i][j].WeightBox.FirstDigit - '0';
                    }

                    if (value != 0)
                    {
                        adListPanel.AdListTable.Cells[i][j].WeightBox.Text = Convert.ToString(adjacencyList.adjacencyList[i][j].Weight);
                    }
                }
            }
        }
    }


}
