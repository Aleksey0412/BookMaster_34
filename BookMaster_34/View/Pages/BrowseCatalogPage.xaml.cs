using BookMaster_34.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BookMaster_34.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для BrowseCatalogPage.xaml
    /// </summary>
    public partial class BrowseCatalogPage : Page
    {

        //Создадим список для вытягивания данных из таблиц
        private readonly List<BookAuthor> _bookAuthors;

        public BrowseCatalogPage()
        {
            InitializeComponent();

            //Заполняем локальный список
            _bookAuthors = App.GetContext().BookAuthors.ToList();

            LoadData();
        }

        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PriviousPageBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LoadData()
        {
            BookAutorsLv.ItemsSource = _bookAuthors;
        }
    }
}
