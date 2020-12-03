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

        private WeightTable weightTable;

        private AdjacencyListPanel adListPanel;


        public SaveButton(int width, int height, AdjacencyList adjacencyList, StartForm.DrawForm drawForm, 
            BackToInputFromDrawButton backToInputFromDrawButton, BackToMenuFromDrawButton backToMenuOfDrawButton, WeightTable weightTable,
             AdjacencyListPanel adListPanel)
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

            this.weightTable = weightTable;

            this.adListPanel = adListPanel;

        }


        public void ButtonClick(object sender, EventArgs e)
        {

            SaveFileDialog sfd = new SaveFileDialog();

            bool adListPanelWasClose = false;

            bool weightTableWasClose = false;

            if (sfd.ShowDialog() == DialogResult.OK)
            {

                Path.GetFullPath(sfd.FileName);

                serializeGraph.SaveGraph(converter.ConvertToGraph(adjacencyList), Path.GetFullPath(sfd.FileName));               

                HidingСontrols(ref adListPanelWasClose, ref weightTableWasClose);

                SaveBmpAsPNG(GetControlScreenshot(drawForm), sfd.FileName);

                ShowingСontrols(adListPanelWasClose, weightTableWasClose);

            }
          
        }

        private void HidingСontrols(ref bool adListPanelWasClose, ref bool weightTableWasClose)
        {
            Parent.Hide();

            backToInputFromDrawButton.Hide();

            backToMenuOfDrawButton.Hide();

            if (adListPanel.Visible != false)
            {
                adListPanel.Hide();

                adListPanelWasClose = true;
            }

            if (weightTable.Visible != false)
            {
                weightTable.Hide();

                weightTableWasClose = true;
            }

        }

        private void ShowingСontrols(bool adListPanelWasClose, bool weightTableWasClose)
        {
            backToInputFromDrawButton.Show();

            backToMenuOfDrawButton.Show();

            if (adListPanelWasClose)

                adListPanel.Show();

            if (weightTableWasClose)

                weightTable.Show();

            Parent.Show();

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
