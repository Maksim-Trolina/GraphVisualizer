using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Forms
{
    public class DrawVertexButton : Button
    {
        private InputCountVertexForm inputCountForm;

        private StartForm.DrawForm drawForm;

        public DrawVertexButton(int width, int height, int positionX, int positionY, InputCountVertexForm inputCountForm, StartForm.DrawForm drawForm, 
            string buttonText = "Create vertexs")
        {
            this.Text = buttonText;
            this.Size = new System.Drawing.Size(width, height);
            this.Location = new System.Drawing.Point(positionX, positionY);
            this.inputCountForm = inputCountForm;
            this.drawForm = drawForm;

            Click += new EventHandler(ButtonClick);
        }
        public void ButtonClick(object sender, EventArgs e)
        {
            inputCountForm.Hide();
            drawForm.ShowDialog();
            inputCountForm.Close();
            
        }
    }

}
