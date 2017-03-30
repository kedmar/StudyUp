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

    public enum Field { None, University, CourseNo, CourseName, Title, Topic, Tag, IsPrinted };
    public partial class AdvancedSearchWindow : Window
    {
        Controller _controller;
        ObservableCollection<string> _universities;
        ObservableCollection<Courses> _courses;
        ObservableCollection<string> _topics;
        ObservableCollection<string> _tags;
        ObservableCollection<string> _categories;

        ObservableCollection<string> _suggestion;

        public List<string> Tags { get; private set; }


        Field lastFieldEditted = Field.None;

        public Material materialQuery;

        bool suggestionTaken = false;

        public string University { get; private set; }
        public string CourseNo { get; private set; }
        public string CourseName { get; private set; }
        public List<string> Topics { get; private set; }
        public string Category { get; private set; }
        public bool IsPrinted { get; private set; }

        public AdvancedSearchWindow(IController controller)
        {
            InitializeComponent();
            controller = _controller;
            _universities = new ObservableCollection<string>(_controller.GetAllUniversities());
            _courses = new ObservableCollection<Courses>(_controller.GetAllCourses());
            _topics = new ObservableCollection<string>(_controller.GetAllTopics());
            _tags = new ObservableCollection<string>(_controller.GetAllTags());
            _categories = new ObservableCollection<string>(_controller.GetAllCategories());
            categoryCmbBx.ItemsSource = _categories;
            Tags = new List<string>();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            University = universityTxtBx.Text;
            CourseNo = courseNoTxtBx.Text;
            CourseName = courseNameTxtBx.Text;
            Title = titleTxtBx.Text;
            Topics = new List<string>(topicTxtBx.Text.Split(' '));
            Tags = new List<string>(tagsTxtBx.Text.Split(' '));
            Category = (string) categoryCmbBx.SelectedItem;
            IsPrinted = (isPrintedOnlyCheckBox.IsChecked==true);
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
            if (suggestionTaken)
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
            }
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
