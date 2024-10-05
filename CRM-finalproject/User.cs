using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using BE;
using BLL;
using System.Runtime.InteropServices;

namespace CRM_finalproject
{
    public partial class Form1 : Form
    {
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

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));


        }
        #endregion

        void FillDataGridView()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = bll.Read();
            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["رمز عبور"].Visible = false;
            dataGridView1.Columns["تصویر کاربر"].Visible = false;

        }
        void ClearTextBoxes()
        {
            textBoxX1.Text = String.Empty;
            textBoxX2.Text = String.Empty;
        }
        UserAccessRole FillAccessRole(string Section, bool CanEnter, bool CanCreate, bool CanUpdate, bool CanDelete)
        {
            UserAccessRole uar = new UserAccessRole();
            uar.Section = Section;
            uar.CanEnter = CanEnter;
            uar.CanCreate = CanCreate;
            uar.CanUpdate = CanUpdate;
            uar.CanDelete = CanDelete;
            return uar;
        }
        int id;
        UserBLL bll = new UserBLL();
        Image pic;
        OpenFileDialog ofd = new OpenFileDialog();
        UserGroupBLL UGbll = new UserGroupBLL();
        string SavePic(string UserName)
        {
            string path = Path.GetDirectoryName(Application.ExecutablePath) + @"\UserPics\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string PicName = UserName + ".JPG";
            try
            {
                string picPath = ofd.FileName;
                File.Copy(picPath, path + PicName,true);
            }
            catch (Exception e)
            {

                MessageBox.Show("سیستم قادر به ذخیره سازی عکس نمیباشد" + e.Message);
            }
            return path + PicName;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            ofd.Filter = "JPG(*.JPG)|*.JPG";
            ofd.Title = "تصویر کاربر را انتخاب کن";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pic = Image.FromFile(ofd.FileName);
                pictureBox1.Image = pic;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxX4_TextChanged(object sender, EventArgs e)
        {
            textBoxX4.PasswordChar = '*';
        }

        private void textBoxX3_TextChanged(object sender, EventArgs e)
        {
            textBoxX3.PasswordChar = '*';
        }

        private void xuiCustomPictureBox2_Click(object sender, EventArgs e)
        {
            User u = new User();
            u.name = textBoxX1.Text;
            u.UserName = textBoxX2.Text;
            u.RegDate = DateTime.Now;
            if (textBoxX3.Text == textBoxX4.Text)
            {
                u.Password = textBoxX3.Text;
            }
            else
            {
                MessageBox.Show("کلمه عبور تکراری میباشد");
            }

            if (label22.Text == "ثبت اطلاعات")
            {
                u.Pic = SavePic(Convert.ToString(pictureBox1.Image));
                MessageBox.Show(bll.Create(u));
                FillDataGridView();
            }
            else
            {
                u.Pic = SavePic(textBoxX2.Text);
                MessageBox.Show(bll.Update(u,id));
                FillDataGridView();

            }
            FillDataGridView();
            ClearTextBoxes();
            
        }

        private void ویراشToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
                User u = bll.Read(id);
                textBoxX1.Text = u.name;
                textBoxX2.Text = u.UserName;
                pictureBox1.Image = Image.FromFile(u.Pic);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                label22.Text = " ویرایش اطلاعات";
            
         
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            contextMenuStrip1.Show(Cursor.Position.X, Cursor.Position.Y);
            id = Convert.ToInt32(dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["id"].Value);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FillDataGridView();
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bll.Delete(id);
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox5.Checked = true;
                checkBox6.Checked = true;
                checkBox7.Checked = true;
                checkBox8.Checked = true;
                checkBox9.Checked = true;
                checkBox10.Checked = true;
                checkBox11.Checked = true;
                checkBox12.Checked = true;
                checkBox13.Checked = true;

            }
            else
            {
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                checkBox7.Checked = false;
                checkBox8.Checked = false;
                checkBox9.Checked = false;
                checkBox10.Checked = false;
                checkBox11.Checked = false;
                checkBox12.Checked = false;
                checkBox13.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox14.Checked = true;
                checkBox22.Checked = true;
                checkBox19.Checked = true;
                checkBox16.Checked = true;
                checkBox18.Checked = true;
                checkBox15.Checked = true;
                checkBox20.Checked = true;
                checkBox21.Checked = true;
                checkBox17.Checked = true;
            }
            else
            {
                checkBox14.Checked = false;
                checkBox22.Checked = false;
                checkBox19.Checked = false;
                checkBox16.Checked = false;
                checkBox18.Checked = false;
                checkBox15.Checked = false;
                checkBox20.Checked = false;
                checkBox21.Checked = false;
                checkBox17.Checked = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox31.Checked = true;
                checkBox29.Checked = true;
                checkBox23.Checked = true;
                checkBox24.Checked = true;
                checkBox25.Checked = true;
                checkBox26.Checked = true;
                checkBox27.Checked = true;
                checkBox28.Checked = true;
                checkBox30.Checked = true;
            }
            else
            {
                checkBox31.Checked = false;
                checkBox29.Checked = false;
                checkBox23.Checked = false;
                checkBox24.Checked = false;
                checkBox25.Checked = false;
                checkBox26.Checked = false;
                checkBox27.Checked = false;
                checkBox28.Checked = false;
                checkBox30.Checked = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                checkBox40.Checked = true;
                checkBox33.Checked = true;
                checkBox36.Checked = true;
                checkBox32.Checked = true;
                checkBox35.Checked = true;
                checkBox37.Checked = true;
                checkBox39.Checked = true;
                checkBox38.Checked = true;
                checkBox34.Checked = true;
            }
            else
            {
                checkBox40.Checked = false;
                checkBox33.Checked = false;
                checkBox36.Checked = false;
                checkBox32.Checked = false;
                checkBox35.Checked = false;
                checkBox37.Checked = false;
                checkBox39.Checked = false;
                checkBox38.Checked = false;
                checkBox34.Checked = false;
            }
        }

        private void xuiCustomPictureBox1_Click(object sender, EventArgs e)
        {
            UserGroup ug = new UserGroup();
            ug.Title = textBoxX6.Text;
            ug.userAccessRoles.Add(FillAccessRole(label20.Text,checkBox13.Checked, checkBox22.Checked, checkBox31.Checked, checkBox40.Checked));
            ug.userAccessRoles.Add(FillAccessRole(label19.Text, checkBox12.Checked, checkBox19.Checked, checkBox29.Checked, checkBox36.Checked));
            ug.userAccessRoles.Add(FillAccessRole(label18.Text, checkBox11.Checked, checkBox16.Checked, checkBox23.Checked, checkBox33.Checked));
            ug.userAccessRoles.Add(FillAccessRole(label14.Text, checkBox10.Checked, checkBox15.Checked, checkBox25.Checked, checkBox32.Checked));
            ug.userAccessRoles.Add(FillAccessRole(label17.Text, checkBox9.Checked, checkBox20.Checked, checkBox24.Checked, checkBox35.Checked));
            ug.userAccessRoles.Add(FillAccessRole(label15.Text, checkBox8.Checked, checkBox14.Checked, checkBox26.Checked, checkBox37.Checked));
            ug.userAccessRoles.Add(FillAccessRole(label5.Text, checkBox7.Checked, checkBox21.Checked, checkBox27.Checked, checkBox39.Checked));
            ug.userAccessRoles.Add(FillAccessRole(label16.Text, checkBox6.Checked, checkBox17.Checked, checkBox28.Checked, checkBox38.Checked));
            ug.userAccessRoles.Add(FillAccessRole(label6.Text, checkBox5.Checked, checkBox18.Checked, checkBox30.Checked, checkBox34.Checked));
            MessageBox.Show(UGbll.Create(ug));
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}