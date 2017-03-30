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

namespace StudyUp
{
    /// <summary>
    /// Interaction logic for UploadFileWindow.xaml
    /// </summary>
    public partial class UploadFileWindow : Window
    {
        string src_path;
        public UploadFileWindow()
        {
            InitializeComponent();
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
            string lowerQuery = tagsTxtBx.Text.ToLower();
            char[] delimiterChars = { ',', '.', ' ' };
            string[] words = lowerQuery.Split(delimiterChars);
            List<string> tags = words.ToList<string>();
            lowerQuery = topicTxtBx.Text.ToLower();
            words = lowerQuery.Split(delimiterChars);
            List<string> topic = words.ToList<string>();
            string university = universityTxtBx.Text;
            Courses course = new Courses(university, courseNoTxtBx.Text, courseNameTxtBx.Text);
            CategoryEnum category = 
            Material material = new Material(university, userEmailTxtBx.Text, titleTxtBx.Text, topic, tags, category);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }

}
