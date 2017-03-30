using System.Collections.Generic;
using System.Windows;
using Classes;
using StudyUpController;
using System.Collections.ObjectModel;
using System;

namespace StudyUp
{
    /// <summary>
    /// Interaction logic for PresentResults.xaml
    /// </summary>
    public partial class PresentResults : Window
    {
        private Dictionary<Material, double> results;
        private IController _controller;

        private ObservableCollection<string> summeriesRes;
        private ObservableCollection<string> lectursRes;
        private ObservableCollection<string> prscticesRes;
        private ObservableCollection<string> formulasRes;
        private ObservableCollection<string> testsRes;
        private ObservableCollection<string> audioRes;
        private ObservableCollection<string> videoRes;


        public PresentResults()
        {
            InitializeComponent();
        }

        public PresentResults(IController _controller, Dictionary<Material, double> results)
        {
            this._controller = _controller;
            this.results = results;

            SplitAndSortResults();
        }

        private void SplitAndSortResults()
        {
            foreach(Material material in results.Keys)
            {
                switch (material.Category)
                {
                     
                }
            }
        }
    }
}
