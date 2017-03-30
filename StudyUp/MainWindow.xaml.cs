using System;
using System.Collections.Generic;
using System.Windows;
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
            if(win.ShowDialog() == true)
            {
                Dictionary<Material, double> results = _controller.RetreiveMaterialsAdvancedSearch(win.University, win.University, win.CourseNo, win.CourseName, win.Title
                    , win.Topics, win.Tags, win.Category, win.IsPrinted, DateTime.Now);

                
            }
        }
    }
}
