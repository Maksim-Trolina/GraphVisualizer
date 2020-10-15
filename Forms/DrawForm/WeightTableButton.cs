using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Forms.DrawForm
{
    class WeightTableButton : ToolStripButton
    {
<<<<<<< HEAD
<<<<<<< HEAD
        private WeightTable weightTable;

        private bool tableIsHide;

        public WeightTableButton(int width, int height, WeightTable weightTable)
        {

=======
        public WeightTableButton(int width, int height)

        {
>>>>>>> 444f41d2ba555fcf67a33771d2c4e667fc17e1ba
=======
        public WeightTableButton(int width, int height)

        {
>>>>>>> 444f41d2ba555fcf67a33771d2c4e667fc17e1ba
            Size = new System.Drawing.Size(width, height);

            Dock = DockStyle.Top;

<<<<<<< HEAD
<<<<<<< HEAD
            this.weightTable = weightTable;

            tableIsHide = true;

            weightTable.Hide();

=======
>>>>>>> 444f41d2ba555fcf67a33771d2c4e667fc17e1ba
=======
>>>>>>> 444f41d2ba555fcf67a33771d2c4e667fc17e1ba
            Click += new EventHandler(ButtonClick);

            Text = "Weight Table";
        }

        public void ButtonClick(object sender, EventArgs e)
        {
<<<<<<< HEAD
<<<<<<< HEAD
            tableIsHide = !tableIsHide;

            if (tableIsHide)
            {
                weightTable.Hide();
            }
            else
            {
                weightTable.Show();
            }

           
=======

>>>>>>> 444f41d2ba555fcf67a33771d2c4e667fc17e1ba
=======

>>>>>>> 444f41d2ba555fcf67a33771d2c4e667fc17e1ba
        }
    }
}
