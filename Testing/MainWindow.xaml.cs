﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Testing
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*string url = @"C:\Users\maayanH\Desktop\justTest.pdf";
            string html = "<!-- saved from url=(0014)about:internet -->\n<html>\n<body>\n<embed src=\"" + url + "\" width=\"100%\" height=\"100%\"/>\n</body>\n</html>";
            webBrowser.NavigateToString(html); // System.Windows.Controls.WebBrowser*/
            sss s = new sss();
            s.SetLast(this);
            s.Show();
            this.Close();
        }
    }
}
