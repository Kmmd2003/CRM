using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CRM_finalproject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        #region Effect
        void openwinform(Form f)
        {
            Window w = this.FindName("Main") as Window;
            BlurBitmapEffect blurbitmapeffect = new BlurBitmapEffect();
            blurbitmapeffect.Radius = 20;
            w.BitmapEffect = blurbitmapeffect;

            f.ShowDialog();

            blurbitmapeffect.Radius = 0;
            w.BitmapEffect = blurbitmapeffect;
        }
        #endregion

        #region Open Win
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CustomerForm f = new CustomerForm();
            openwinform(f);
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            ManageCustomerForm c = new ManageCustomerForm();
            openwinform(c);
        }

        private void Image_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void TextBlock_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            ManagProductForm p = new ManagProductForm();
            openwinform(p);
        }

        private void TextBlock_MouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
        {
            FactorListForm f = new FactorListForm();
            openwinform(f);
        }

        private void TextBlock_MouseLeftButtonDown_3(object sender, MouseButtonEventArgs e)
        {
            RemindersForm r = new RemindersForm();
            openwinform(r);
        }

        private void TextBlock_MouseLeftButtonDown_4(object sender, MouseButtonEventArgs e)
        {
            ActivitiesForm a = new ActivitiesForm();
            openwinform(a);
        }

        private void TextBlock_MouseLeftButtonDown_5(object sender, MouseButtonEventArgs e)
        {
            SmsPanelForm s = new SmsPanelForm();
            openwinform(s);
        }

        private void TextBlock_MouseLeftButtonDown_6(object sender, MouseButtonEventArgs e)
        {
            Form1 f = new Form1();
            openwinform(f);
        }
    }
    #endregion

}
