using CraphModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Forms.DrawForm
{
    public class AdjacencyListPanel : Panel
    {
        public AdjacencyListTable AdListTable { get; set; }

        public AdjacencyListPanel(int width, int height, int positionX, int positionY, GraphRepresentation.AdjacencyList adjacencyList)
        {
            Size = new System.Drawing.Size(width, height);

            Location = new System.Drawing.Point(positionX, positionY);

            Dock = DockStyle.Right;

            AutoScroll = true;

            BorderStyle = BorderStyle.Fixed3D;

            AdListTable = new AdjacencyListTable(adjacencyList, this);

            Visible = false;
        }

        public void UpdateIdPanel()
        {
            AdListTable.UpdateRows();
        }

        public void UpdateNodesPanel(int startId, int endId)
        {
            AdListTable.UpdateColumns(startId, endId);
        }

    }

    public class AdjacencyListTable
    {
        private GraphRepresentation.AdjacencyList adjacencyList;

        public List<List<CellAdjacencyList>> Cells { get; set; }

        private AdjacencyListPanel adListPanel;

        public AdjacencyListTable(GraphRepresentation.AdjacencyList adjacencyList, AdjacencyListPanel adListPanel)
        {
            this.adjacencyList = adjacencyList;

            this.adListPanel = adListPanel;

            Cells = new List<List<CellAdjacencyList>>();

            int stepX = 160;

            int stepY = 80;

            for (int i = 0; i < adjacencyList.adjacencyList.Count; ++i)
            {
                Cells.Add(new List<CellAdjacencyList>());

                InfoTextLabel startId = new InfoTextLabel(40, 20, adListPanel.HorizontalScroll.Value, 20 + i * stepY, Convert.ToString(i) + ": ");

                adListPanel.Controls.Add(startId);

                for (int j = 0; j < adjacencyList.adjacencyList[i].Count; ++j)
                {
                    int id = adjacencyList.adjacencyList[i][j].Connectable;

                    int weight = adjacencyList.adjacencyList[i][j].Weight;

                    Cells[i].Add(new CellAdjacencyList(id, weight, 40 + stepX * j, stepY * i));

                    adListPanel.Controls.Add(Cells[i][j]);
                }
            }

            
        }

        public void UpdateRows()
        {
            int stepX = 160;

            int stepY = 80;

            int numberLastKey = adjacencyList.adjacencyList.Count - 1;

            Cells.Add(new List<CellAdjacencyList>());

            InfoTextLabel startId = new InfoTextLabel(40, 20, -adListPanel.HorizontalScroll.Value, 
                20 + numberLastKey * stepY - adListPanel.VerticalScroll.Value, Convert.ToString(numberLastKey) + ": ");

            adListPanel.Controls.Add(startId);

            for (int j = 0; j < adjacencyList.adjacencyList[numberLastKey].Count; ++j)
            {
                int id = adjacencyList.adjacencyList[numberLastKey][j].Connectable;

                int weight = adjacencyList.adjacencyList[numberLastKey][j].Weight;

                Cells[numberLastKey].Add(new CellAdjacencyList(id, weight, 40 + stepX * j - adListPanel.HorizontalScroll.Value
                    , stepY * numberLastKey - adListPanel.VerticalScroll.Value));

                adListPanel.Controls.Add(Cells[numberLastKey][j]);
            }
        }

        public void UpdateColumns(int startId, int endId)
        {
            int stepX = 160;

            int stepY = 80;

            Cells[startId].Add(new CellAdjacencyList(endId, 1, 40 + stepX * Cells[startId].Count - adListPanel.HorizontalScroll.Value
                , stepY * startId - adListPanel.VerticalScroll.Value));

            int numberLastKey = adjacencyList.adjacencyList[startId].Count - 1;

            adListPanel.Controls.Add(Cells[startId][numberLastKey]);
        }
    }

    public class CellAdjacencyList : GroupBox
    {
        private int id;

        public CellBox WeightBox { get; set; }

        InfoTextLabel text;

        public CellAdjacencyList(int id, int weight, int positionX, int positionY)
        {

            this.id = id;

            int x = 10;

            int y = 20;

            int widthText = 60;

            int heightText = 20;

            int widthBox = 60;

            int heightBox = heightText;

            text = new InfoTextLabel(widthText, heightText, x, y, $"id: {id}; w: ");

            WeightBox = new CellBox(widthBox, heightBox, x + widthText, y, weight);

            Controls.Add(WeightBox);

            Controls.Add(text);

            Size = new System.Drawing.Size(2 * x + widthText + widthBox, 2 * y + heightText);

            Location = new System.Drawing.Point(positionX, positionY);
        }

    }

    
}
