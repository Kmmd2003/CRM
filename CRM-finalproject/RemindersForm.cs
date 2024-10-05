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
    public partial class RemindersForm : Form
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

        public RemindersForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 10, 10));
        }
        customer c = new customer();
        ReminderBLL Rbll = new ReminderBLL();
        UserBLL Ubll = new UserBLL();

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void xuiCustomPictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void RemindersForm_Load(object sender, EventArgs e)
        {
            
            AutoCompleteStringCollection names = new AutoCompleteStringCollection();
            foreach (var item in Ubll.ReadUserNames())
            {
                names.Add(item);
            }
            textBoxX2.AutoCompleteCustomSource = names;
        }

        private void xuiCustomPictureBox1_Click(object sender, EventArgs e)
        {
            //c = Rbll.Read(textBoxX2.Text);
            //textBoxX2.Enabled = false;
        }
    }
}
