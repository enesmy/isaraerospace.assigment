using isaraerospace.assigment.bussines;
using isaraerospace.assigment.entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace isaraerospace.assigment.winform.Forms
{
    public partial class frmMain : Form
    {
        BookStoreFactory factory;
        public frmMain()
        {
            factory = new BookStoreFactory();
            InitializeComponent();

            DescriptionColumnIndex = dgvBooks.GetColumnIndex("Description");
            InStockColumnIndex = dgvBooks.GetColumnIndex("InStock");
            IdColumnIndex = dgvBooks.GetColumnIndex("ID");
            DeleteColumnIndex = dgvBooks.GetColumnIndex("Delete");
        }


        int DescriptionColumnIndex = -1;
        int InStockColumnIndex = -1;
        int IdColumnIndex = -1;
        int DeleteColumnIndex = -1;

        private void LoadGrid()
        {

            dgvBooks.DataSource = new List<Book>();
            dgvBooks.DataSource = factory.Books.GetAll();

            dgvBooks.SetMaterialDesign();
            dgvBooks.SetHighLightsAndToolTip();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void dgvBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;

            if (e.ColumnIndex == DescriptionColumnIndex)
            {
                MessageBox.Show(factory.Books.Filter(o => o.ID == (int)dgvBooks.Rows[e.RowIndex].Cells[IdColumnIndex].Value).First().Description);
            }
            else if (e.ColumnIndex == DeleteColumnIndex)
            {
                if (dgvBooks.Rows[e.RowIndex].Cells[InStockColumnIndex].Value.ToString() == "yes")
                {
                    MessageBox.Show("You can not delete this record! Because this book in the stock!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var answer = MessageBox.Show("Are you sure you want to delete?", "Delete process!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (answer == DialogResult.Yes)
                {

                    factory.Books.Delete((int)dgvBooks.Rows[e.RowIndex].Cells[IdColumnIndex].Value);
                    LoadGrid();
                }
            }
            

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmBookAdd addbook = new frmBookAdd();
            if (addbook.ShowDialog() == DialogResult.OK)
            {
                factory.Books.Add(addbook.book);
                LoadGrid();

            }
        }

        private void dgvBooks_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            var res = ((List<Book>)dgvBooks.DataSource).First(o => o.ID == ((int)dgvBooks.Rows[e.RowIndex].Cells[IdColumnIndex].Value));
            factory.Books.Update(res);
            dgvBooks.SetHighLightsAndToolTip();

        }
    }
}
