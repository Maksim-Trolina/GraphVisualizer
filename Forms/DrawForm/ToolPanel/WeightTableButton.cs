using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Forms.DrawForm
{
    public class WeightTableButton : ToolStripButton
    {
        private WeightTable weightTable;

        private AdjacencyListPanel adListPanel;

        SaveWeightButton saveWeightButton;

        public WeightTableButton(int width, int height, WeightTable weightTable, AdjacencyListPanel adListPanel
            , SaveWeightButton saveWeightButton)
        {

            Size = new System.Drawing.Size(width, height);

            Dock = DockStyle.Top;

            Click += new EventHandler(ButtonClick);

            Text = "Weight Table";

            this.weightTable = weightTable;

            this.adListPanel = adListPanel;

            this.saveWeightButton = saveWeightButton;
        }

        public void ButtonClick(object sender, EventArgs e)
        {
            adListPanel.Visible = false;

            weightTable.Visible = !weightTable.Visible;

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
