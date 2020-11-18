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
        } 

        private void ButtonClick(object sender, EventArgs e)
        {
            if (weightTable.Visible)
            {

            }
            else if (adListPanel.Visible) {

            }
        }

        private void SaveMatrixWeight()
        {

        }

        private void SaveAdjacencyListWeight()
        {

        }
    }
}
