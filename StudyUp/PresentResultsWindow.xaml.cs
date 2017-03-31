using System.Collections.Generic;
using System.Windows;
using Classes;
using StudyUpController;
using System.Collections.ObjectModel;
using System;
using System.Linq;
using System.Windows.Controls;

namespace StudyUp
{
    /// <summary>
    /// Interaction logic for PresentResults.xaml
    /// </summary>
    public partial class PresentResultsWindow : Window
    {
        private IController _controller;

        private ObservableCollection<Material> summeriesRes;
        private ObservableCollection<Material> lectursRes;
        private ObservableCollection<Material> prscticesRes;
        private ObservableCollection<Material> formulasRes;
        private ObservableCollection<Material> testsRes;
        private ObservableCollection<Material> audioRes;
        private ObservableCollection<Material> videoRes;


        public PresentResultsWindow()
        {
            InitializeComponent();
        }

        public PresentResultsWindow(IController _controller, Dictionary<Material, double> results)
        {
            InitializeComponent();
            summeriesRes = new ObservableCollection<Material>();
            lectursRes = new ObservableCollection<Material>();

            prscticesRes = new ObservableCollection<Material>();
            formulasRes = new ObservableCollection<Material>();
            testsRes = new ObservableCollection<Material>();
            summeriesRes = new ObservableCollection<Material>();
            audioRes = new ObservableCollection<Material>();
            videoRes = new ObservableCollection<Material>();
            this._controller = _controller;

            SplitAndSortResults(results);


            if (summeriesRes.Count != 0)
                summaryDataGrid.ItemsSource = summeriesRes;
            if (lectursRes.Count != 0)
                lectureReDataGrid.ItemsSource = lectursRes;
            if (prscticesRes.Count != 0)
                prscticeDataGrid.ItemsSource = prscticesRes;
            if (formulasRes.Count != 0)
                formulaDataGrid.ItemsSource = formulasRes;
            if (testsRes.Count != 0)
                testDataGrid.ItemsSource = testsRes;
            /*if (audioRes.Count != 0)
                audioDataGrid.ItemsSource = audioRes;
            if (videoRes.Count != 0)
                videoDataGrid.ItemsSource = videoRes;*/


        }


    

        private void SplitAndSortResults(Dictionary<Material, double> results)
        {
            results = results.OrderBy(i => i.Value).ToDictionary(t => t.Key, t => t.Value);

            for(int i=0; i< results.Count; i++)
            {
                Material material = results.ElementAt(i).Key;
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



        public void DG_Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            Material m = ((FrameworkElement)sender).DataContext as Material;
            User user = new User(12345, "Lior Perry");
            PresenntMaterialWindow win = new PresenntMaterialWindow(ref _controller, m, user);
            win.Show();
        }
    }
}
