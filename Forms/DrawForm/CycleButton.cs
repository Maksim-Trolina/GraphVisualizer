using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Forms.DrawForm
{
    public class CycleButton : ToolStripButton
    {
        private bool isShowCycle;
        public CycleButton(int width,int height)
        {
            Size = new System.Drawing.Size(width, height);

            Dock = DockStyle.Top;

            Text = "Show Cycle";

            Click += new EventHandler(ButtonClick);

            isShowCycle = false;
        }

        public void ButtonClick(object sender,EventArgs e)
        {
            isShowCycle = !isShowCycle;

            if (isShowCycle)
            {

            }
            else
            {

            }
        }
    }
}
