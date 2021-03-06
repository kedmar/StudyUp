﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using StudyUpController;
using StudyUpModel;

namespace StudyUp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        void OnStartup(object sender, StartupEventArgs e)
        {
            Model model = new Model();
            IController controller = new FakeController();
            //controller.SetModel(model);
            MainWindow win = new StudyUp.MainWindow(ref controller);
            win.Show();

        }
    }
}
