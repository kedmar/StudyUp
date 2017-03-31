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
        public MainWindow(ref Controller controller)
        {
            InitializeComponent();
            _controller = controller;
        }


        private void AdvancedSearch_Click(object sender, RoutedEventArgs e)
        {
            AdvancedSearchWindow win = new AdvancedSearchWindow(ref _controller);
            if (win.ShowDialog() == true)
            {
                Dictionary<Material, double> results = _controller.RetreiveMaterialsAdvancedSearch(win.University, win.University, win.CourseNo, win.CourseName, win.Title
                    , win.Topics, win.Tags, win.Category, win.IsPrinted);

                //should open reasults window

            }
        }


        private void SimpleSearch_Click(object sender, RoutedEventArgs e)
        {
            if (queryTextBox == null || queryTextBox.Text == "")
                MessageBox.Show("", "No Query", MessageBoxButton.OK);
            else
                _controller.RetreiveMaterialsSimpleSearch(queryTextBox.Text);
        }


        private void Upload_Click(object sender, RoutedEventArgs e)
        {
            UploadFileWindow win = new UploadFileWindow(_controller);
            win.ShowDialog();
        }

    }
}
