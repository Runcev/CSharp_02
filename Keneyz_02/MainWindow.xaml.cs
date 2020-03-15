using System.Windows;
using Keneyz_02.ViewModel;


namespace Keneyz_02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }

        private void UserView_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
