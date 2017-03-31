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
            AdvancedSearchWindow win1 = new AdvancedSearchWindow(ref _controller);
            if (win1.ShowDialog() == true)
            {
                Dictionary<Material, double> results = _controller.RetreiveMaterialsAdvancedSearch(win1.University, win1.University, win1.CourseNo, win1.CourseName, win1.Title
                    , win1.Topics, win1.Tags, win1.Category, win1.IsPrinted);

                //should open reasults window
                PresentResultsWindow win2 = new PresentResultsWindow(_controller, results);
                win2.ShowDialog();
            }
        }


        private void SimpleSearch_Click(object sender, RoutedEventArgs e)
        {
            if (queryTextBox == null || queryTextBox.Text == "")
                MessageBox.Show("No Query", "Error", MessageBoxButton.OK);
            else
                _controller.RetreiveMaterialsSimpleSearch(queryTextBox.Text);
        }


        private void Upload_Click(object sender, RoutedEventArgs e)
        {
            UploadFileWindow win = new UploadFileWindow(_controller);
            win.ShowDialog();
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Not implemented  yet", "Not implemented", MessageBoxButton.OK);
        }
    }
}
