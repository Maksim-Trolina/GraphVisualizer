using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Forms.DrawForm
{
    class WeightTableButton : ToolStripButton
    {
        public WeightTableButton(int width, int height)

        {
            Size = new System.Drawing.Size(width, height);

            Dock = DockStyle.Top;

            Click += new EventHandler(ButtonClick);

            Text = "Weight Table";
        }

        public void ButtonClick(object sender, EventArgs e)
        {

        }
    }
}
