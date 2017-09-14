using System.Windows;
using Microsoft.Practices.Unity;

namespace ManagedFbx.Viewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        [Dependency]
        public MainViewModel ViewModel
        {
            get { return this.DataContext as MainViewModel; }
            set { this.DataContext = value; }
        }
    }
}
