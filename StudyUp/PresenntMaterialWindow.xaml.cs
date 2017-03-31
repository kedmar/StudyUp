using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using StudyUpController;
using Classes;
using System.Windows.Media;

namespace StudyUp
{
    /// <summary>
    /// Interaction logic for PresenntMaterialWindow.xaml
    /// </summary>
    public partial class PresenntMaterialWindow : Window
    {
        static string[] comments = { "WOW!!!", "Completely off topic", "Helped me a lot", "Interesting :)", "I love you man <3", "Saved my life!!", "Thanksssss", "I can't agree with you", "I realy appreciate your work", "You have made several critical mistakes" };

        IController controler = null;
        Material material = null;
        User user = null;


        public PresenntMaterialWindow(ref IController controler, Material material, User user)
        {
            this.controler = controler;
            this.material = material;
            this.user = user;
            InitializeComponent();
            LoadDoc();
            LoadTags();
            Random rand = new Random();
            likes.Content = material.Score;
            int index1 = rand.Next(0, 10);
            int index2 = rand.Next(0, 10);
            while(index1== index2)
                index2 = rand.Next(0, 10);
            commen1.Content = comments[index1];
            commen1.Content = comments[index2];
        }

        private void LoadTags()
        {
            foreach(string tag in material.Tags)
            {
                Run run = new Run(tag);
              

                Hyperlink hyperlink = new Hyperlink(run);
                hyperlink.Click += delegate (object sender, RoutedEventArgs e)
                {
                    //run advanced shearch with the tag
                    Dictionary<Material, Double> searchResult = controler.RetreiveMaterialsAdvancedSearch(tag);
                    //open results window
                    PresentResultsWindow win = new PresentResultsWindow(controler, searchResult);
                    win.Show();
                    //close this window
                    this.Close();
                };
                TextBlock tb = new TextBlock();
                tb.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                tb.Inlines.Add(hyperlink);

                tagsLinks.Children.Add(tb);
            }

        }

        private void LoadDoc()
        {
            string path = material.File;
            string html = "<!-- saved from url=(0014)about:internet -->\n<html>\n<body>\n<embed src=\"" + path + "\" width=\"100%\" height=\"100%\"/>\n</body>\n</html>";
            webBrowser.NavigateToString(html); // System.Windows.Controls.WebBrowser
        }

        private void LikeButton_Click(object sender, RoutedEventArgs e)
        {
            material.Score++;
            likes.Content = material.Score;
            likes.Foreground = new SolidColorBrush(Colors.DarkTurquoise);
        }

    }
}
