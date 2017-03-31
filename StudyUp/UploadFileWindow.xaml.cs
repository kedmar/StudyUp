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
        

        IController _controller;
        ObservableCollection<string> _universities;
        ObservableCollection<Courses> _courses;
        ObservableCollection<string> _topics;
        ObservableCollection<string> _tags;
        ObservableCollection<string> _categories;

        ObservableCollection<string> _suggestion;

        public List<string> Topic { get; set; }
        public List<string> Tags { get; set; }

        Field lastFieldEditted = Field.None;

        bool suggestionTaken = false;

        public UploadFileWindow(IController controller)
        {
            InitializeComponent();
            _controller = controller;
            _universities = new ObservableCollection<string>(_controller.GetAllUniversities());
            _courses = new ObservableCollection<Courses>(_controller.GetAllCourses());
            _topics = new ObservableCollection<string>(_controller.GetAllTopics());
            _tags = new ObservableCollection<string>(_controller.GetAllTags());
            _categories = new ObservableCollection<string>(_controller.GetAllCategories());
            categoryCmbBx.ItemsSource = _categories;
        }

        private void Upload_Click(object sender, RoutedEventArgs e)
        {

            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                return;
            src_path = ofd.FileName;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (universityTxtBx.Text == null || titleTxtBx.Text == null || courseNameTxtBx.Text == null || courseNoTxtBx.Text == null || categoryCmbBx.Text == null)
            {
                System.Windows.MessageBox.Show("", "Error: mandatory queries left empty", System.Windows.MessageBoxButton.OK);
                return;
            }
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
            Material material = new Material(university, course, titleTxtBx.Text, topic, tags, categoryCmbBx.Text, (isPrintedCheckBox.IsChecked == true), src_path);
            _controller.UploadMaterial(material);
            DialogResult = true;
            Close();
        }


        private void universityTxtBoxChanged(object sender, TextChangedEventArgs e)
        {
            if ((lastFieldEditted != Field.University || suggestionsLstBx.Visibility == suggestionsLstBx.Visibility) && universityTxtBx.Text.Length > 0)
            {
                suggestionsLstBx.SetValue(Grid.RowProperty, 4);
                suggestionsLstBx.SetValue(Grid.ColumnProperty, 1);
                UpdateSuggestions(universityTxtBx.Text, _universities);
                suggestionsLstBx.ItemsSource = _suggestion;
                suggestionsLstBx.Visibility = Visibility.Visible;
            }

        }


        private void courseNoChanged(object sender, TextChangedEventArgs e)
        {
            if ((lastFieldEditted != Field.CourseNo || suggestionsLstBx.Visibility == suggestionsLstBx.Visibility) && courseNoTxtBx.Text.Length > 0)
            {
                suggestionsLstBx.SetValue(Grid.RowProperty, 6);
                suggestionsLstBx.SetValue(Grid.ColumnProperty, 1);
                ObservableCollection<string> courseNoToPresent = new ObservableCollection<string>();
                foreach (Courses course in _courses)
                {
                    courseNoToPresent.Add(String.Format("{0} | {1}", course.CourseNo, course.CourseName));
                }
                UpdateSuggestions(courseNoTxtBx.Text, courseNoToPresent);
                suggestionsLstBx.ItemsSource = _suggestion;
                suggestionsLstBx.Visibility = Visibility.Visible;

            }
        }



        private void courseNameChanged(object sender, TextChangedEventArgs e)
        {
            if ((lastFieldEditted != Field.CourseName || suggestionsLstBx.Visibility == suggestionsLstBx.Visibility) && courseNameTxtBx.Text.Length > 0)
            {
                suggestionsLstBx.SetValue(Grid.RowProperty, 8);
                suggestionsLstBx.SetValue(Grid.ColumnProperty, 1);
                ObservableCollection<string> courseNamesToPresent = new ObservableCollection<string>();
                foreach (Courses course in _courses)
                {
                    courseNamesToPresent.Add(String.Format("{0} | {1}", course.CourseName, course.CourseNo));
                }
                UpdateSuggestions(courseNameTxtBx.Text, courseNamesToPresent);
                suggestionsLstBx.ItemsSource = _suggestion;
                suggestionsLstBx.Visibility = Visibility.Visible;
            }
        }


        private void UpdateSuggestions(string input, ObservableCollection<string> source)
        {
            _suggestion = new ObservableCollection<string>();
            input = input.ToLower();
            foreach (string item in source)
            {
                if (item.ToLower().IndexOf(input) >= 0)
                    _suggestion.Add(item);
            }
        }

        private void topicChanged(object sender, TextChangedEventArgs e)
        {
            if ((lastFieldEditted != Field.Topic || suggestionsLstBx.Visibility == suggestionsLstBx.Visibility) && topicTxtBx.Text.Length > 0)
            {
                suggestionsLstBx.SetValue(Grid.RowProperty, 12);
                suggestionsLstBx.SetValue(Grid.ColumnProperty, 1);
                UpdateSuggestions(topicTxtBx.Text, _topics);
                suggestionsLstBx.ItemsSource = _suggestion;
                suggestionsLstBx.Visibility = Visibility.Visible;
            }
        }

        private void tagsChanged(object sender, TextChangedEventArgs e)
        {
            /*if (suggestionTaken)
            {
                suggestionTaken = false;
                return;
            }
            String[] splittedTags = tagsTxtBx.Text.Split(' ');
            List<string> tagsToDelete = new List<string>();
            foreach (string tag in Tags)
            {
                if (!splittedTags.Contains(tag))
                    tagsToDelete.Add(tag);
            }
            foreach (string tagToDelete in tagsToDelete)
                Tags.Remove(tagToDelete);
            foreach (string tag in Tags)
                tagsTxtBx.Text += tag + ' ';
            string lastTag = splittedTags[Math.Max(splittedTags.Length - 1, 0)];
            if ((lastFieldEditted != Field.Topic || suggestionsLstBx.Visibility == suggestionsLstBx.Visibility) && lastTag.Length > 0)
            {
                suggestionsLstBx.SetValue(Grid.RowProperty, 5);
                suggestionsLstBx.SetValue(Grid.ColumnProperty, 6);
                string[] chosenTags = tagsTxtBx.Text.Split(' ');
                UpdateSuggestions(chosenTags[Math.Max(chosenTags.Length - 1, 0)], _tags);
                suggestionsLstBx.ItemsSource = _suggestion;
                suggestionsLstBx.Visibility = Visibility.Visible;
            }*/
        }

        private void suggestionPick_Click(object sender, MouseButtonEventArgs e)
        {
            suggestionsLstBx.Visibility = Visibility.Hidden;
            string chosenInput = (string)suggestionsLstBx.SelectedItem;
            if (lastFieldEditted == Field.University)
                universityTxtBx.Text = chosenInput;
            if (lastFieldEditted == Field.CourseNo)
                courseNoTxtBx.Text = chosenInput;
            if (lastFieldEditted == Field.CourseName)
                courseNameTxtBx.Text = chosenInput;
            if (lastFieldEditted == Field.Topic)
            {
                string[] splittedTagss = tagsTxtBx.Text.Split(' ');
                Tags.Add(splittedTagss[Math.Max(0, splittedTagss.Length - 1)]);
                tagsTxtBx.Text = String.Empty;
                foreach (string tag in Tags)
                {
                    tagsTxtBx.Text += tag + ' ';
                }
            }
            if (lastFieldEditted == Field.Topic)
            {

            }
            suggestionTaken = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }

}
