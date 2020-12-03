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

        private BackToInputFromDrawButton backToInputFromDrawButton;

        private BackToMenuFromDrawButton backToMenuOfDrawButton;


        public SaveButton(int width, int height, AdjacencyList adjacencyList, StartForm.DrawForm drawForm, 
            BackToInputFromDrawButton backToInputFromDrawButton, BackToMenuFromDrawButton backToMenuOfDrawButton)
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

            this.backToInputFromDrawButton = backToInputFromDrawButton;

            this.backToMenuOfDrawButton = backToMenuOfDrawButton;

        }


        public void ButtonClick(object sender, EventArgs e)
        {

            SaveFileDialog sfd = new SaveFileDialog();

            if (sfd.ShowDialog() == DialogResult.OK)
            {

                Path.GetFullPath(sfd.FileName);

                serializeGraph.SaveGraph(converter.ConvertToGraph(adjacencyList), Path.GetFullPath(sfd.FileName));

                Parent.Hide();

                backToInputFromDrawButton.Hide();

                backToMenuOfDrawButton.Hide();

                SaveBmpAsPNG(GetControlScreenshot(drawForm), sfd.FileName);

                backToInputFromDrawButton.Show();

                backToMenuOfDrawButton.Show();

                Parent.Show();

            }
          
        }

        private Bitmap GetControlScreenshot(Control control)
        {

            Size szCurrent = control.Size;
            control.AutoSize = true;

            Rectangle rectangle = new Rectangle();

            rectangle.Width = control.Width;

            rectangle.Height = control.Height;

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
