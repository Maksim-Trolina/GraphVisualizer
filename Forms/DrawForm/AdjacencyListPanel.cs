using CraphModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Forms.DrawForm
{
    class AdjacencyListPanel : Panel
    {
        private AdjacencyListTable adListTable;

        public AdjacencyListPanel(int width, int height, int positionX, int positionY, GraphRepresentation.AdjacencyList adjacencyList)
        {
            Size = new System.Drawing.Size(width, height);

            Location = new System.Drawing.Point(positionX, positionY);

            Dock = DockStyle.Right;

            AutoScroll = true;

            BorderStyle = BorderStyle.Fixed3D;

            adListTable = new AdjacencyListTable(adjacencyList, this);
        }

        public void UpdateIdPanel()
        {
            adListTable.UpdateRows();
        }

        public void UpdateNodesPanel(int startId, int endId)
        {
            adListTable.UpdateColumns(startId, endId);
        }
    }

    class AdjacencyListTable
    {
        private GraphRepresentation.AdjacencyList adjacencyList;

        private List<List<CellAdjacencyList>> cells;

        private AdjacencyListPanel adListPanel;

        public AdjacencyListTable(GraphRepresentation.AdjacencyList adjacencyList, AdjacencyListPanel adListPanel)
        {
            this.adjacencyList = adjacencyList;

            this.adListPanel = adListPanel;

            cells = new List<List<CellAdjacencyList>>();

            int stepX = 160;

            int stepY = 80;

            for (int i = 0; i < adjacencyList.adjacencyList.Count; ++i)
            {
                cells.Add(new List<CellAdjacencyList>());

                InfoTextLabel startId = new InfoTextLabel(40, 20, 0, 20 + i * stepY, Convert.ToString(i) + ": ");

                adListPanel.Controls.Add(startId);

                for (int j = 0; j < adjacencyList.adjacencyList[i].Count; ++j)
                {
                    int id = adjacencyList.adjacencyList[i][j].Connectable;

                    int weight = adjacencyList.adjacencyList[i][j].Weight;

                    cells[i].Add(new CellAdjacencyList(id, weight, 40 + stepX * j, stepY * i));

                    adListPanel.Controls.Add(cells[i][j]);
                }
            }

            
        }

        public void UpdateRows()
        {
            int stepX = 160;

            int stepY = 80;

            int numberLastKey = adjacencyList.adjacencyList.Count - 1;

            cells.Add(new List<CellAdjacencyList>());

            InfoTextLabel startId = new InfoTextLabel(40, 20, 0, 20 + numberLastKey * stepY
                , Convert.ToString(numberLastKey) + ": ");

            adListPanel.Controls.Add(startId);

            for (int j = 0; j < adjacencyList.adjacencyList[numberLastKey].Count; ++j)
            {
                int id = adjacencyList.adjacencyList[numberLastKey][j].Connectable;

                int weight = adjacencyList.adjacencyList[numberLastKey][j].Weight;

                cells[numberLastKey].Add(new CellAdjacencyList(id, weight, 40 + stepX * j, stepY * numberLastKey));

                adListPanel.Controls.Add(cells[numberLastKey][j]);
            }
        }

        public void UpdateColumns(int startId, int endId)
        {
            int stepX = 160;

            int stepY = 80;

            cells[startId].Add(new CellAdjacencyList(endId, 0, 40 + stepX * cells[startId].Count, stepY * startId));

            int numberLastKey = adjacencyList.adjacencyList[startId].Count - 1;

            adListPanel.Controls.Add(cells[startId][numberLastKey]);


        }
    }

    class CellAdjacencyList : GroupBox
    {
        private int id;

        private InputCountBox weightBox;

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

            weightBox = new InputCountBox(widthBox, heightBox, x + widthText, y, Convert.ToString(weight));

            Controls.Add(weightBox);

            Controls.Add(text);

            Size = new System.Drawing.Size(2 * x + widthText + widthBox, 2 * y + heightText);

            Location = new System.Drawing.Point(positionX, positionY);
        }

    }
}
