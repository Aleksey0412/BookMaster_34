using BookMaster_34.Models;
using BookMaster_34.View.Windows;
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
        private readonly List<Book> _bookAuthors;

        private Book _selectedBook;
        public BrowseCatalogPage()
        {
            InitializeComponent();

            //Заполняем локальный список
            _bookAuthors = App.GetContext().Books.ToList();

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
            BookAuthorsLv.ItemsSource = _bookAuthors;
        }

        private void PreviousPageBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NextPageBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BookAutorsLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedBook = (Book)BookAuthorsLv.SelectedItem;

            BookDetailsGrid.DataContext = _selectedBook;
        }

        private void BookAutorsDetailisHl_Click(object sender, RoutedEventArgs e)
        {
            if (_selectedBook != null)
            {
                BookAuthorsDetailsWindow bookAuthorsDetailsWindow =
                    new BookAuthorsDetailsWindow(_selectedBook.BookAuthors);
                
                bookAuthorsDetailsWindow.ShowDialog();
            }
        }
    }
}
