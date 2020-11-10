using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Forms.DrawForm
{
    class AdjacencyListButton : ToolStripButton
    {
        private bool adListIsHide;

        private AdjacencyListTable adListTable;

        public AdjacencyListButton(int width, int height, AdjacencyListTable adListTable)
        {
            Size = new System.Drawing.Size(width, height);

            Dock = DockStyle.Top;

            Click += new EventHandler(ButtonClick);

            Text = "Adjacency List";

            adListIsHide = true;

            this.adListTable = adListTable;

            adListTable.Hide();
        }

        public void ButtonClick(object sender, EventArgs e)
        {
            adListIsHide = !adListIsHide;

            if (adListIsHide)
            {
                adListTable.Hide();
            }
            else
            {
                adListTable.Show();
            }
        }
    }
}
