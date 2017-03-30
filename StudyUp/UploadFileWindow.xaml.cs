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
using System.Windows.Forms;
using Classes;
using System.Collections.ObjectModel;
using StudyUpController;

namespace StudyUp
{
    /// <summary>
    /// Interaction logic for UploadFileWindow.xaml
    /// </summary>
    public partial class UploadFileWindow : Window
    {
        string src_path;
        

        Controller _controller;
        ObservableCollection<string> _universities;
        ObservableCollection<Courses> _courses;
        ObservableCollection<string> _topics;
        ObservableCollection<string> _tags;
        ObservableCollection<string> _categories;

        ObservableCollection<string> _suggestion;

        public List<string> Topic { get; set; }
        public List<string> Tags { get; set; }

        Field lastFieldEditted = Field.None;


        public UploadFileWindow(IController controller)
        {
            InitializeComponent();
            controller = _controller;
            _universities = new ObservableCollection<string>(_controller.GetAllUniversities());
            _courses = new ObservableCollection<Courses>(_controller.GetAllCourses());
            _topics = new ObservableCollection<string>(_controller.GetAllTopics());
            _tags = new ObservableCollection<string>(_controller.GetAllTags());
            _categories = new ObservableCollection<string>(_controller.GetAllCategories());
            categoryCmbBx.ItemsSource = _categories;
        }

        private void Upload_Click(object sender, RoutedEventArgs e)
        {

            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            src_path = fbd.SelectedPath;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if () ;



            List<string> tags = new List<string>();
            List<string> topic = new List<string>();
            string[] words;
            string lowerQuery = tagsTxtBx.Text.ToLower();
            char[] delimiterChars = { ',', '.', ' ' };
            if(lowerQuery != null)
            {
                words = lowerQuery.Split(delimiterChars);
                tags = words.ToList<string>();
            }
            
            lowerQuery = topicTxtBx.Text.ToLower();
            words = lowerQuery.Split(delimiterChars);
            topic = words.ToList<string>();
            string university = universityTxtBx.Text;
            Courses course = new Courses(university, courseNoTxtBx.Text, courseNameTxtBx.Text);
            Material material = new Material(university, course, titleTxtBx.Text, topic, tags, categoryCmbBx.Text, isPrintedCheckBox.IsChecked, DateTime.Now, src_path);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }

}
