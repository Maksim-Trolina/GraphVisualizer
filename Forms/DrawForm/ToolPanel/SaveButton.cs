using System;
using System.Windows.Forms;
using Serializing;
using GraphRepresentation;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;


namespace Forms.DrawForm
{
    public class SaveButton : ToolStripButton
    {
        private AdjacencyList adjacencyList;

        private SerializeGraph serializeGraph;

        private Converter converter;

        private StartForm.DrawForm drawForm;


        public SaveButton(int width, int height, AdjacencyList adjacencyList, StartForm.DrawForm drawForm)
        {

            Size = new System.Drawing.Size(width, height);

            Dock = DockStyle.Top;

            Text = "Save that graph";

            Size = new System.Drawing.Size(150, 30);

            Anchor = (AnchorStyles.Bottom | AnchorStyles.Right); // anchorage to place

            Click += new EventHandler(ButtonClick);         

            serializeGraph = new SerializeGraph();

            converter = new Converter();

            this.adjacencyList = adjacencyList;

            this.drawForm = drawForm;

        }


        public void ButtonClick(object sender, EventArgs e)
        {

            SaveFileDialog sfd = new SaveFileDialog();

            if (sfd.ShowDialog() == DialogResult.OK)
            {

                Path.GetFullPath(sfd.FileName);

                serializeGraph.SaveGraph(converter.ConvertToGraph(adjacencyList), Path.GetFullPath(sfd.FileName));               

                HidingСontrols();

                SaveBmpAsPNG(GetControlScreenshot(drawForm), sfd.FileName);

                ShowingСontrols();

            }
          
        }

        private void HidingСontrols()
        {

            drawForm.FormBorderStyle = FormBorderStyle.None;

            foreach (Control control in drawForm.Controls)
            {
                control.Tag = false;

                if (control.Visible) 
                {
                    control.Tag = true;

                    control.Visible = false;
                }
              
            }

        }

        private void ShowingСontrols()
        {

            drawForm.FormBorderStyle = FormBorderStyle.FixedDialog;

            foreach (Control control in drawForm.Controls)
            {

                if ((bool)control.Tag)
                {
                    control.Tag = false;

                    control.Visible = true;
                }

            }

        }


        private Bitmap GetControlScreenshot(Control control)
        {

            Size szCurrent = control.Size;
            control.AutoSize = true;

            Rectangle rectangle = new Rectangle{Width = control.Width, Height = control.Height};

            Bitmap bmp = new Bitmap(rectangle.Width, rectangle.Height);

            control.DrawToBitmap(bmp, rectangle);

            control.AutoSize = false;
            control.Size = szCurrent;

            return bmp;
        }

        private void SaveBmpAsPNG(Bitmap bmp, string FilePath)
        {            
            bmp.Save(string.Concat(FilePath, ".png"), ImageFormat.Png);
        }
    }
}
