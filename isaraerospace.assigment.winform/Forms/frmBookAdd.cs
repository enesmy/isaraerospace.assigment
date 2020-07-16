using isaraerospace.assigment.entities;
using System;
using System.Windows.Forms;

namespace isaraerospace.assigment.winform.Forms
{
    public partial class frmBookAdd : Form
    {
        internal Book book = new Book();
        public frmBookAdd()
        {
            InitializeComponent();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            book.Title = txtTitle.Text;
            book.Author = txtAuthor.Text;
            book.Year = (int)nudYear.Value;
            book.Price = nudPrice.Value;
            book.Binding = cbBinding.Text;
            book.Description = txtDescription.Text;
            book.InStock = cbInStock.Checked ? "yes" : "no";
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmBookAdd_Load(object sender, EventArgs e)
        {
            nudYear.Value = DateTime.Today.Year;
        }
    }
}
