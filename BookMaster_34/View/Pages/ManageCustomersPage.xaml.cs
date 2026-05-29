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
    /// Логика взаимодействия для ManageCustomersPage.xaml
    /// </summary>
    public partial class ManageCustomersPage : Page
    {
        private List<Customer> _customers;
        private Customer _selectedCustomer;

        public ManageCustomersPage()
        {
            InitializeComponent();

            // Заполняем локальный список
            _customers = App.GetContext().Customers.ToList();

            // Привязка списка к ListView в XAML (CustomersLv)
            CustomersLv.ItemsSource = _customers;
        }

        private void CustomerLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Приведение выбранного элемента к типу Customer
            _selectedCustomer = (Customer)CustomersLv.SelectedItem;


        }



        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddEditCustomerWindow(); // customer = null → режим добавления
            if (window.ShowDialog() == true)
            {
                CustomersLv.ItemsSource = App.GetContext().Customers.ToList();
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            var selected = CustomersLv.SelectedItem as Customer;
            if (selected == null)
            {
                MessageBox.Show("Выберите клиента для редактирования.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            var window = new AddEditCustomerWindow(selected); // режим редактирования
            if (window.ShowDialog() == true)
            {
                CustomersLv.ItemsSource = App.GetContext().Customers.ToList();
            }
        }

        private void CustomersLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void SearchBtn1_Click(object sender, RoutedEventArgs e)
        {
            // Берём исходный список клиентов
            List<Customer> source = App.GetContext().Customers.ToList();

            // Получаем введённые значения
            string idFilter = CustomerIdTb.Text;
            string nameFilter = CustomerNameTb.Text;

            bool hasIdFilter = !string.IsNullOrEmpty(idFilter);
            bool hasNameFilter = !string.IsNullOrEmpty(nameFilter);

            // Фильтруем
            List<Customer> filtered;

            if (!hasIdFilter && !hasNameFilter)
            {
                // Если ничего не введено — показать всех
                filtered = source;
            }
            else
            {
                filtered = source.Where(c =>
                {
                    bool matchesId = true;
                    bool matchesName = true;

                    if (hasIdFilter)
                        matchesId = c.Id.Equals(idFilter, StringComparison.OrdinalIgnoreCase);

                    if (hasNameFilter)
                        matchesName = c.Name?.Contains(nameFilter, StringComparison.OrdinalIgnoreCase) == true;

                    return matchesId && matchesName;
                }).ToList();
            }

            // Обновляем источник ListView
            CustomersLv.ItemsSource = filtered;
        }
    }
}
