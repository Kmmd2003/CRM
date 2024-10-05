using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BE;

namespace CRM_finalproject
{
    public partial class ManagProductForm : Form
    {
        ProductBLL bll = new ProductBLL();

        void FillDataGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bll.Read();
            dataGridView1.Columns["آیدی"].Visible = false;
        }

        void ClearTextBox()
        {
            textBoxX1.Text = string.Empty;
            textBoxX2.Text = string.Empty;
            textBoxX3.Text = string.Empty;
        }

        int id;

        #region Border
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );

        public ManagProductForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
        }
        #endregion

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Product p = new Product();
            p.Name = textBoxX1.Text;
            p.Price = Convert.ToDouble(textBoxX2.Text);
            p.Stock = Convert.ToInt32(textBoxX3.Text);

            if (label3.Text=="ثبت اطلاعات")
            {
               
                MessageBox.Show(bll.Create(p));
               
            }
            else if (label3.Text=="ویرایش اطلاعات")
            {
                MessageBox.Show(bll.Update(p, id));
                label3.Text = "ثبت اطلاعات";
            }
            FillDataGrid();
            ClearTextBox();


        }

        private void ManagProductForm_Load(object sender, EventArgs e)
        {
            FillDataGrid();
        }

        private void textBoxX4_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bll.Read(textBoxX4.Text);
        }

        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Product p = bll.Read(id);
            textBoxX1.Text = p.Name;
            textBoxX2.Text = p.Price.ToString();
            textBoxX3.Text = p.Stock.ToString();
            label3.Text = "ویرایش اطلاعات";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
            id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["آیدی"].Value);
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("آیا از حذف کالای مورد نظر اطمینان دارید؟","اخطار",MessageBoxButtons.YesNo,MessageBoxIcon.Question);  
            if (dr == DialogResult.Yes)
            {
                bll.Delete(id);
                FillDataGrid();

            }
        }
    }
}
