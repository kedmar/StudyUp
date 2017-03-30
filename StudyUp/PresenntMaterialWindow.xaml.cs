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

namespace StudyUp
{
    /// <summary>
    /// Interaction logic for PresenntMaterialWindow.xaml
    /// </summary>
    public partial class PresenntMaterialWindow : Window
    {
        public PresenntMaterialWindow()
        {
            InitializeComponent();
        }


        public void DocPath(string path)
        {
            
            string html = "<!-- saved from url=(0014)about:internet -->\n<html>\n<body>\n<embed src=\"" + path + "\" width=\"100%\" height=\"100%\"/>\n</body>\n</html>";
            webBrowser.NavigateToString(html); // System.Windows.Controls.WebBrowser
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}
