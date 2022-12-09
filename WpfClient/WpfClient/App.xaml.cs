using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfClient.ViewModel;

namespace WpfClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private SportItemViewModel _viewModel;
        public App()
        {
            _viewModel = new SportItemViewModel();
            var window = new MainWindow() { DataContext = _viewModel };
            window.Show();
        }
    }
}
