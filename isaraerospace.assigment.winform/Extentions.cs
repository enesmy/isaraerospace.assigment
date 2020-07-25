using isaraerospace.assigment.entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace isaraerospace.assigment.winform
{
    public static class Extentions
    {
        public static void SetMaterialDesign(this DataGridView dgv)
        {
            dgv.BorderStyle = BorderStyle.None;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(238, 239, 249);
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgv.DefaultCellStyle.SelectionForeColor = Color.WhiteSmoke;
            dgv.BackgroundColor = Color.White;

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 25, 72);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }


        public static void SetHighLightsAndToolTip(this DataGridView dgv)
        {
            var datasource = (List<Book>)dgv.DataSource;

            var maxPrice = datasource.Max(o => o.Price);
            var minPrice = datasource.Min(o => o.Price);
            decimal diff = maxPrice - minPrice;

            int InStockColumnIndex = dgv.GetColumnIndex("InStock");
            int PriceColumnIndex = dgv.GetColumnIndex("Price");
            if (InStockColumnIndex != -1)
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Cells[InStockColumnIndex].Value != null && row.Cells[InStockColumnIndex].Value.ToString() == "no")
                    {
                        row.DefaultCellStyle.BackColor = Color.Yellow;
                    }
                    else
                    {
                        row.DefaultCellStyle = new DataGridViewCellStyle();
                    }

                    decimal price = (decimal)row.Cells[PriceColumnIndex].Value;

                    int gradian = (int)Math.Round((255 / diff * (price - minPrice)));
                    if (gradian <= 127)
                    {
                        gradian = (gradian) * 2;
                        row.Cells[PriceColumnIndex].Style.BackColor = Color.FromArgb(gradian, 255, gradian);
                    }
                    else
                    {
                        gradian = 255 - gradian;
                        row.Cells[PriceColumnIndex].Style.BackColor = Color.FromArgb(255, gradian, gradian);
                    }




                }
        }

        public static int GetColumnIndex(this DataGridView dgv, string name)
        {
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                if (
                    dgv.Columns[i].DataPropertyName.ToLower() == name.ToLower() || dgv.Columns[i].HeaderText.ToLower() == name.ToLower()

                    ) return i;
            }

            return -1;
        }

    }
}
