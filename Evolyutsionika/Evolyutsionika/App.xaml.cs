using Evolyutsionika.ViewModels;
using Evolyutsionika.Views;
using System;
using System.Diagnostics;
using System.Windows;

namespace Evolyutsionika
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                var mainViewModel = new MainViewModel();
                var mainView = new MainView();
                mainViewModel.View = mainView;
                mainView.Show();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        protected override void OnExit(ExitEventArgs e)
        {
            Evolyutsionika.Properties.Settings.Default.Save();
            base.OnExit(e);
        }
    }
}
