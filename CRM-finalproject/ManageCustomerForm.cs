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
using BE;
using BLL;


namespace CRM_finalproject
{
    public partial class ManageCustomerForm : Form
    {
        CustomerBLL bll = new CustomerBLL();

        void FillDataGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bll.Read();
            dataGridView1.Columns["آیدی"].Visible = false;
        }

        void ClearTextBoxes()
        {
            textBoxX1.Text = string.Empty;
            textBoxX2.Text = string.Empty;
            textBoxX4.Text = string.Empty;
        }

        int id;

        int Index;

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

        public ManageCustomerForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));


        }
        #endregion

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            customer c = new customer();
            c.Name = textBoxX1.Text;
            c.Phone = textBoxX2.Text;
            c.Regdate = DateTime.Now;
            if (label3.Text == "ثبت اطلاعات")
            {
                MessageBox.Show(bll.Create(c));
            }
            else
            {
                MessageBox.Show(bll.Update(c,id));
                label3.Text = "ثبت اطلاعات";
            }
            FillDataGrid();
            ClearTextBoxes();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void textBoxX4_TextChanged(object sender, EventArgs e)
        {
            if ((checkBox1.Checked && checkBox2.Checked) || (!checkBox1.Checked && !checkBox2.Checked))
            {
                Index = 0;
            }
            else if (checkBox1.Checked && !checkBox2.Checked)
            {
                Index = 1;
            }
            else if (checkBox2.Checked && !checkBox1.Checked)
            {
                Index = 2;
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bll.Raed(textBoxX4.Text,Index);

        }

        private void ManageCustomerForm_Load(object sender, EventArgs e)
        {
            FillDataGrid();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
            id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["آیدی"].Value);
        }

        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            customer c = bll.Read(id);
            textBoxX1.Text = c.Name;
            textBoxX2.Text = c.Phone;
            label3.Text = "ویرایش اطلاعات";
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("آیا از حذف مشتری اطمینان دارید؟","اخطار",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                bll.Delete(id);
            }
            FillDataGrid();
        }
    }
}
