using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Forms.DrawForm
{
    class AdjacencyListPanelButton : ToolStripButton
    {
        private AdjacencyListPanel adListPanel;

        private WeightTable weightTable;

        private SaveWeightButton saveWeightButton;

        public AdjacencyListPanelButton(int width, int height, AdjacencyListPanel adListPanel, WeightTable weightTable
            , SaveWeightButton saveWeightButton)
        {
            Size = new System.Drawing.Size(width, height);

            Dock = DockStyle.Top;

            Click += new EventHandler(ButtonClick);

            Text = "Adjacency List";

            this.adListPanel = adListPanel;

            this.weightTable = weightTable;

            this.saveWeightButton = saveWeightButton;
        }

        public void ButtonClick(object sender, EventArgs e)
        {
            weightTable.Visible = false;

            adListPanel.Visible = !adListPanel.Visible;

            if (!adListPanel.Visible && !weightTable.Visible)
            {
                saveWeightButton.Enabled = false;
            }
            else
            {
                saveWeightButton.Enabled = true;
            }
        }
    }
}
