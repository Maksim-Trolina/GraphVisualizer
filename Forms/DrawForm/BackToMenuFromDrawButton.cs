using System;
using System.Collections.Generic;
using GraphModelDraw;
using GraphRepresentation;
using System.Drawing;

namespace Forms.DrawForm
{
    class BackToMenuFromDrawButton : BackButton
    {
        private AdjacencyList adjacencyList;

        private List<VertexDraw> vertexDraws;

        private List<EdgeDraw> edgeDraws;

        private StartForm.DrawForm drawForm;

        private AdjacencyListPanel adjacencyListPanel;

        private WeightTable weightTable;

        private List<List<CellBox>> matrix;

        private List<List<CellAdjacencyList>> cells;

        private StartForm.StartForm startForm;

        public BackToMenuFromDrawButton(AdjacencyList adjacencyList, List<VertexDraw> vertexDraws, 
            List<EdgeDraw> edgeDraws, StartForm.DrawForm drawForm, AdjacencyListPanel adjacencyListPanel, 
            WeightTable weightTable, List<List<CellBox>> matrix, List<List<CellAdjacencyList>> cells, 
            StartForm.StartForm startForm, string buttonText = "Menu") : base(buttonText)
        {
            ForeColor = Color.Black;

            this.BackColor = Color.Orange;

            Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));

            FlatStyle = System.Windows.Forms.FlatStyle.Popup;

            Text = buttonText;

            Location = new System.Drawing.Point(300, 410);

            this.adjacencyList = adjacencyList;

            this.vertexDraws = vertexDraws;

            this.edgeDraws = edgeDraws;

            this.drawForm = drawForm;

            this.weightTable = weightTable;

            this.adjacencyListPanel = adjacencyListPanel;

            this.matrix = matrix;

            this.cells = cells;

            this.startForm = startForm;

    }

        public override void ButtonClick(object sender, EventArgs e)
        {

            adjacencyList.adjacencyList.Clear();
            vertexDraws.Clear();
            edgeDraws.Clear();
            matrix.Clear();
            cells.Clear();

            adjacencyListPanel.Controls.Clear();
            weightTable.Controls.Clear();
           
            startForm.Show();
            drawForm.Close();
        }

    }
}
