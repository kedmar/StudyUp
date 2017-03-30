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
using System.Windows.Navigation;
using System.Windows.Shapes;
using StudyUpController;

namespace StudyUp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IController _controller;
        public MainWindow(IController controller)
        {
            InitializeComponent();
            _controller = _controller;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AdvancedSearch_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
