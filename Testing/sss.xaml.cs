using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


namespace Testing
{
    /// <summary>
    /// Interaction logic for sss.xaml
    /// </summary>
    public partial class sss : Window
    {
        private Window myLast = null;
        public sss()
        {
            InitializeComponent();
        }

        public void SetLast(Window win)
        {
            myLast = win;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            myLast.Show();
            this.Close();
        }
    }
}
