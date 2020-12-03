using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Forms.DrawForm
{
    public class ShortestPathPanelButton : ToolStripButton
    {
        private ShortestPathPanel shortestPathPanel;

        public ShortestPathPanelButton(int width, int height, ShortestPathPanel shortestPathPanel)
        {
            Size = new System.Drawing.Size(width, height);

            Dock = DockStyle.Top;

            Click += new EventHandler(ButtonClick);

            Text = "Shortest Path";

            this.shortestPathPanel = shortestPathPanel;
        }

        private void ButtonClick(object sender, EventArgs e)
        {
            shortestPathPanel.Visible = !shortestPathPanel.Visible;
        }
    }
}
