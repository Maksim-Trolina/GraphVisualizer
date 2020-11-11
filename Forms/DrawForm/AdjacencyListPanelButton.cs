using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Forms.DrawForm
{
    class AdjacencyListPanelButton : ToolStripButton
    {
        private bool adListIsHide;

        private AdjacencyListPanel adListPanel;

        public AdjacencyListPanelButton(int width, int height, AdjacencyListPanel adListPanel)
        {
            Size = new System.Drawing.Size(width, height);

            Dock = DockStyle.Top;

            Click += new EventHandler(ButtonClick);

            Text = "Adjacency List";

            adListIsHide = true;

            this.adListPanel = adListPanel;

            adListPanel.Hide();
        }

        public void ButtonClick(object sender, EventArgs e)
        {
            adListIsHide = !adListIsHide;

            if (adListIsHide)
            {
                adListPanel.Hide();
            }
            else
            {
                adListPanel.Show();
            }
        }
    }
}
