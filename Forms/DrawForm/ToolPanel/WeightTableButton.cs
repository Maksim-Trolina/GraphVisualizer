using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Forms.DrawForm
{
    class WeightTableButton : ToolStripButton
    {
        private WeightTable weightTable;

        private AdjacencyListPanel adListPanel;

        public WeightTableButton(int width, int height, WeightTable weightTable, AdjacencyListPanel adListPanel)
        {

            Size = new System.Drawing.Size(width, height);

            Dock = DockStyle.Top;

            Click += new EventHandler(ButtonClick);

            Text = "Weight Table";

            this.weightTable = weightTable;

            this.adListPanel = adListPanel;

        }

        public void ButtonClick(object sender, EventArgs e)
        {
            adListPanel.Visible = false;

            weightTable.Visible = !weightTable.Visible;
        }
    }
}
