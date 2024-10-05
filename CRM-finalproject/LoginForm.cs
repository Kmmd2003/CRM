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
    public partial class LoginForm : Form
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

        public LoginForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));


        }
        #endregion

        Timer t1 = new Timer();
        Timer t2 = new Timer();
        UserBLL Ubll = new UserBLL();
        List<String> usernames = new List<string>();
        RegisterAdmin r = new RegisterAdmin();
        private void LoginForm_Load(object sender, EventArgs e)
        {
            label1.Visible = true;
            t1.Enabled = true;
            t1.Interval = 10;
            t1.Tick += Timer_Tick;
            t1.Start();
            this.Controls.Add(r);
            this.Controls["RegisterAdmin"].Location = new Point(400, 830);

        }
        private void Timer_Tick(object sender,EventArgs e)
        {
            if (progressBarX1.Value >= 100)
            {
                t1.Stop();
                progressBarX1.Visible = false;
                label1.Visible = false;
                label3.Visible = true;
                t2.Enabled = true;
                t2.Interval = 1;
                t2.Tick += Timer2_Tick;
                t2.Start();
            }
            else if (progressBarX1.Value == 67)
            {
                usernames = Ubll.ReadUserNames();
                progressBarX1.Value++;
            }
            else
            {
                progressBarX1.Value++;
            }
        }
        private void Timer2_Tick(object sender,EventArgs e)
        {

        }
    }
}
