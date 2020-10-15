using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Forms.DrawForm
{
    class WeightTableButton : ToolStripButton
    {

        private WeightTable weightTable;

        private bool tableIsHide;

        public WeightTableButton(int width, int height, WeightTable weightTable)
        {

            Size = new System.Drawing.Size(width, height);

            Dock = DockStyle.Top;

            this.weightTable = weightTable;

            tableIsHide = true;

            weightTable.Hide();

            Click += new EventHandler(ButtonClick);

            Text = "Weight Table";
        }

        public void ButtonClick(object sender, EventArgs e)
        {

            tableIsHide = !tableIsHide;

            if (tableIsHide)
            {
                weightTable.Hide();
            }
            else
            {
                weightTable.Show();
            }

        }
    }
}
