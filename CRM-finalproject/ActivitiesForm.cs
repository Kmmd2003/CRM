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
    public partial class ActivitiesForm : Form
    {
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

        public ActivitiesForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));
        }

        void FillDataGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ACbll.Read();
            dataGridView1.Columns["id"].Visible = false;    
        }

        void ClearTextBoxes()
        {
            textBoxX1.Text = String.Empty;
            textBoxX2.Text = String.Empty;
            textBoxX3.Text = String.Empty;
            richTextBox1.Text = String.Empty;
            comboTree1.Text = String.Empty;
        }

        CustomerBLL Cbll = new CustomerBLL();
        UserBLL Ubll = new UserBLL();
        ActivityBLL ACbll = new ActivityBLL();
        ReminderBLL Rbll = new ReminderBLL();
        customer c = new customer();
        User u = new User();
        Activity a = new Activity();
        int id;
        
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void xuiCustomPictureBox3_Click(object sender, EventArgs e)
        {
            c = Cbll.ReadC(textBoxX1.Text);
            textBoxX1.Enabled = false;  
        }

        private void ActivitiesForm_Load(object sender, EventArgs e)
        {
            AutoCompleteStringCollection phone = new AutoCompleteStringCollection();
            foreach (var item in Cbll.ReadPhoneNumber())
            {
                phone.Add(item);
            }
            textBoxX1.AutoCompleteCustomSource = phone;
            AutoCompleteStringCollection names = new AutoCompleteStringCollection();
            foreach (var item in Ubll.ReadUserNameActivity())
            {
                names.Add(item);
            }
            textBoxX2.AutoCompleteCustomSource = names;
            AutoCompleteStringCollection ACnames = new AutoCompleteStringCollection();
            foreach (var item in ACbll.ReadActivityNames())
            {
                ACnames.Add(item);
            }
            textBoxX3.AutoCompleteCustomSource= ACnames;
            FillDataGrid();
        }

        private void xuiCustomPictureBox1_Click(object sender, EventArgs e)
        {
            u = Ubll.ReadSearch(textBoxX2.Text);
            textBoxX2.Enabled = false;
        }

        private void xuiCustomPictureBox2_Click(object sender, EventArgs e)
        {

            if (label3.Text == "ثبت فعالیت جدید")
            {
                a.Title = textBoxX3.Text;
                a.Info = richTextBox1.Text;
                a.RegDate = DateTime.Now;
                a.ActivityCategory = ACbll.ReadByName(comboTree1.Text);

                MessageBox.Show(ACbll.Create(a, u, c, a.ActivityCategory));
                if (checkBox2.Checked)
                {
                    Reminder r = new Reminder();
                    r.Title = textBoxX3.Text;
                    r.ReminderInfo = richTextBox1.Text;
                    r.RegDate = DateTime.Now;
                    r.ReminderDate = dateTimeInput1.Value;
                    MessageBox.Show(Rbll.Create(r));
                }
                FillDataGrid();
            }
            else
            {
                MessageBox.Show(ACbll.Update(a, id));
                FillDataGrid();
            }
            FillDataGrid();
        }

        private void xuiCustomPictureBox4_Click(object sender, EventArgs e)
        {
            a = ACbll.ReadA(comboTree1.Text);
            textBoxX3.Enabled = false;  
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
            id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["id"].Value); 
        }

        private void ویرایشToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Activity a = ACbll.Read(id);
            textBoxX1.Text = c.Name;
            textBoxX2.Text = u.UserName;
            textBoxX3.Text = a.Title;
            richTextBox1.Text = a.Info;
            label3.Text = "ویرایش اطلاعات";
            ClearTextBoxes();
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ACbll.Delete(id));
        }
    }
}