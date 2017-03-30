using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using StudyUpController;
using Classes;

namespace StudyUp
{
    /// <summary>
    /// Interaction logic for PresenntMaterialWindow.xaml
    /// </summary>
    public partial class PresenntMaterialWindow : Window
    {
        delegate void Hyperlink_Click(object sender, RoutedEventArgs e);

        private class TagLink
        {
            Hyperlink hyperlink;
            Hyperlink_Click hyperlinkClick;

            public TagLink(Hyperlink hyperlink, Hyperlink_Click hyperlinkClick)
            {
                this.hyperlink = hyperlink;
                this.hyperlinkClick = hyperlinkClick;
            }
        }


        IController controler = null;
        Material material = null;
        List<TextBlock> tagLinks = new List<TextBlock>();
       



        public PresenntMaterialWindow(ref IController controler, Material material)
        {
            this.controler = controler;
            this.material = material;
            InitializeComponent();
            LoadDoc();
            LoadTags();

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
                    List<Material> searchResult = controler.RetreiveMaterialsAdvancedSearch(tag);
                    //open resukts window

                    //close this window
                    this.Close();
                };
                TextBlock tb = new TextBlock();
                tb.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                tb.Inlines.Add(hyperlink);
            }
        }

        private void LoadDoc()
        {
            string path = material.File;
            string html = "<!-- saved from url=(0014)about:internet -->\n<html>\n<body>\n<embed src=\"" + path + "\" width=\"100%\" height=\"100%\"/>\n</body>\n</html>";
            webBrowser.NavigateToString(html); // System.Windows.Controls.WebBrowser
        }




    }
}
