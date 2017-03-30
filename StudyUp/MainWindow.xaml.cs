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
using Classes;

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
            _controller = controller;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AdvancedSearch_Click(object sender, RoutedEventArgs e)
        {
            AdvancedSearchWindow win = new AdvancedSearchWindow(_controller);
            ;
            if(win.ShowDialog() == true)
            {
                Dictionary<Material, double> results = _controller.RetreiveMaterialsAdvancedSearch(win.University, win.University, win.CourseNo, win.CourseName, win.Title
                    , win.Topics, win.Tags, win.Category, win.IsPrinted);
                PresentResults resWin = new PresentResults(_controller, results);
                resWin.Show();
            }
        }
    }
}
