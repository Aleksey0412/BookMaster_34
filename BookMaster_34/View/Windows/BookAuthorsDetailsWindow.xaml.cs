using BookMaster_34.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BookMaster_34.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для BookAuthorsDetailsWindow.xaml
    /// </summary>
    public partial class BookAuthorsDetailsWindow : Window
    {
        public BookAuthorsDetailsWindow(ICollection<BookAuthor> bookAuthors)
        {
            InitializeComponent();

            AuthorsCmb.ItemsSource = bookAuthors;
            AuthorsCmb.DisplayMemberPath = "Author.Name";
            AuthorsCmb.SelectedIndex = 0;
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AuthorsCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataContext = AuthorsCmb.SelectedItem;

            if (AuthorsCmb.SelectedItem is BookAuthor bookAuthor)
            {
                if (string.IsNullOrWhiteSpace(bookAuthor.Author.Wikipedia))
                {
                    //прячем гиперссылку
                    HyperlinkTbl.Visibility = Visibility.Collapsed;
                }
                else
                {
                    //Показываем
                    HyperlinkTbl.Visibility = Visibility.Visible;
                }
            }

        }

        private void WikipediaHl_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            try
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo()
                {
                    FileName = e.Uri.AbsoluteUri,
                    UseShellExecute = true,
                    Verb = "open"
                };
                Process.Start(processStartInfo);
                e.Handled = true;
                
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
