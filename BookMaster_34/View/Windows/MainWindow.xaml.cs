using BookMaster_34.View.Pages;
using BookMaster_34.View.Windows;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookMaster_34
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MainFrame.Navigate(new BrowseCatalogPage());
        }

        private void LogoutMi_Click(object sender, RoutedEventArgs e)
        {
           LogoutWindow logoutWindow = new LogoutWindow();
            //logoutWindow.ShowDialog();

            LibraryMi.Visibility = Visibility.Collapsed;
            LogoutMi.Visibility = Visibility.Collapsed;
            LoginMi.Visibility = Visibility.Visible;
        }

        private void LoginMi_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
          

            if (loginWindow.ShowDialog() == true)
            {
                LibraryMi.Visibility = Visibility.Collapsed;
                LogoutMi.Visibility = Visibility.Visible;
                LoginMi.Visibility = Visibility.Collapsed;
            }

        }

        private void CloseAppMi_Click(object sender, RoutedEventArgs e)
        {
            Close();

        }

        private void ManageCustomersMi_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ManageCustomersPage());
        }

        private void ReportsMi_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ReportsPage());
        }

        private void CirculationMi_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CirculationPage());
        }

        private void CatalogMi_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new BrowseCatalogPage());
        }
    }
}