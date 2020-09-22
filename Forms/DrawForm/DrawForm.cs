using System.Windows.Forms;
using Forms.DrawForm;
using CraphModel;



namespace StartForm
{
    public partial class DrawForm : Form
    {
        public DrawForm()
        {
            InitializeComponent();
         
            Book book = new Book();
            book.Author = "Kingo";
            book.Name = "It";
            book.Price = 69;


            SaveButton saveButton = new SaveButton() { book = book};

            Controls.Add(saveButton);
        }
    }
}
