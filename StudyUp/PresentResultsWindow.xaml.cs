using System.Collections.Generic;
using System.Windows;
using Classes;
using StudyUpController;
using System.Collections.ObjectModel;
using System;
using System.Linq;

namespace StudyUp
{
    /// <summary>
    /// Interaction logic for PresentResults.xaml
    /// </summary>
    public partial class PresentResults : Window
    {
        private Dictionary<Material, double> results;
        private IController _controller;

        private ObservableCollection<Material> summeriesRes;
        private ObservableCollection<Material> lectursRes;
        private ObservableCollection<Material> prscticesRes;
        private ObservableCollection<Material> formulasRes;
        private ObservableCollection<Material> testsRes;
        private ObservableCollection<Material> audioRes;
        private ObservableCollection<Material> videoRes;


        public PresentResults()
        {
            InitializeComponent();
        }

        public PresentResults(IController _controller, Dictionary<Material, double> results)
        {
            this._controller = _controller;
            this.results = results;

            SplitAndSortResults();

            summaryDataGrid.ItemsSource = summeriesRes;
            lectureReDataGrid.ItemsSource = lectursRes;
            prscticeDataGrid.ItemsSource = prscticesRes;
            formulaDataGrid.ItemsSource = formulasRes;
            testDataGrid.ItemsSource = testsRes;
            audioDataGrid.ItemsSource = audioRes;
            videoDataGrid.ItemsSource = videoRes;


        }

        private void SplitAndSortResults()
        {
            results = results.OrderBy(i => i.Value).ToDictionary(t => t.Key, t => t.Value);

            foreach (Material material in results.Keys)
            {
                switch (material.Category)
                {
                    case "Summary":
                        summeriesRes.Add(material);
                        break;
                    case "Lecture":
                        lectursRes.Add(material);
                        break;
                    case "Practice":
                        prscticesRes.Add(material);
                        break;
                    case "FormulasPage":
                        formulasRes.Add(material);
                        break;
                    case "Tests":
                        testsRes.Add(material);
                        break;
                    case "AudioClass":
                        audioRes.Add(material);
                        break;
                    case "VideoClass":
                        videoRes.Add(material);
                        break;
                    default:
                        MessageBox.Show("", "Worng Category.", MessageBoxButton.OK);
                        break;
                }
            }
        }
    }
}
