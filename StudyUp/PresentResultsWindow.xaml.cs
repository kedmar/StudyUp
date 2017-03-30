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
using Classes;
using StudyUpController;
using
using System.Collections.ObjectModel;

namespace StudyUp
{
    /// <summary>
    /// Interaction logic for PresentResults.xaml
    /// </summary>
    public partial class PresentResults : Window
    {
        private Dictionary<Material, double> results;
        private IController _controller;
        ObservableCollection<Material> summariesResults;
        ObservableCollection<Material> lecturesResults;
        ObservableCollection<Material> practiceResults;
        ObservableCollection<Material> formulasResults;
        ObservableCollection<Material> testResults;
        ObservableCollection<Material> audioResults;
        ObservableCollection<Material> videoResults;




        public PresentResults()
        {
            InitializeComponent();
        }

        public PresentResults(IController _controller, Dictionary<Material, double> results)
        {
            this._controller = _controller;
            this.results = results;

            SortResultsByCategory();

        }
    }
}
