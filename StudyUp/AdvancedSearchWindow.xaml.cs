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
using StudyUpController;
using System.Collections.ObjectModel;
using Classes;

namespace StudyUp
{
    /// <summary>
    /// Interaction logic for AdvancedSearchWindow.xaml
    /// </summary>
    public partial class AdvancedSearchWindow : Window
    {
        Controller _controller;
        ObservableCollection<string> _universities;
        ObservableCollection<Courses> _courses;
        ObservableCollection<string> _topics;
        ObservableCollection<string> _tags;
        ObservableCollection<string> _categories;

        public string University { get; set; }
        public Courses Course { get; set; }


        public string QTitle { get; set; }

        public List<string> Topic { get; set; }
        public List<string> Tags { get; set; }
        public List<string> Categories { get; set; }





        public AdvancedSearchWindow(IController controller)
        {
            InitializeComponent();
            controller = _controller;
            _universities = new ObservableCollection<string>(_controller.GetAllUniversities());
            _courses = new ObservableCollection<Courses>(_controller.GetAllCourses());
            _topics = new ObservableCollection<string>(_controller.GetAllTopics());
            _tags = new ObservableCollection<string>(_controller.GetAllTags());
            _categories = new ObservableCollection<string>(_controller.GetAllCategories());
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            University = universityTxtBx.Text;
            Course = new Courses(University, courseNoTxtBx.Text, courseNameTxtBx.Text);
            QTitle = titleTxtBx.Text;

        }
    }
}
