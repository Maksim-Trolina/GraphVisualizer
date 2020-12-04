using System.Drawing;

namespace Forms
{
    public class InfoTextLabel : System.Windows.Forms.Label
    {
        public InfoTextLabel(int width, int height, int positionX, int positionY, string info = "Enter the number of vertices")
        {
            ForeColor = Color.Black;

            this.BackColor = Color.Orange;

            Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(204)));

            FlatStyle = System.Windows.Forms.FlatStyle.Popup;

            this.Text = info;
            this.Size = new System.Drawing.Size(width, height);
            this.Location = new System.Drawing.Point(positionX, positionY);
        }
    }
}
