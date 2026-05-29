using BookMaster_34.AppData;
using BookMaster_34.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace BookMaster_34.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для ManageCustomerWindow.xaml
    /// </summary>
    public partial class AddEditCustomerWindow : Window
    {


        private List<City> _cities;

        public AddEditCustomerWindow()
        {
            
            InitializeComponent();
            _cities = App.GetContext().Cities.ToList();

            LoadCities();
            Title = "Добаление читателя";
            Visibility = Visibility.Visible;
            EditBtn.Visibility = Visibility.Collapsed;
            IDclienTb.Text = GenerateId();

        }

        public AddEditCustomerWindow(Customer selectedCustomer)
        {
            InitializeComponent();
            _cities = App.GetContext().Cities.ToList();
            LoadCities();
            Title = "Редактировать читателя";
            SaveBtn.Visibility = Visibility.Collapsed;
            EditBtn.Visibility = Visibility.Visible;
            IDclienTb.Text = selectedCustomer.Id;

            DataContext = selectedCustomer;
        }



        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        } 
        private void AddCustomer()
        {
            try
            {
                // Проверяем заполнение всех полей
                if (string.IsNullOrWhiteSpace(ClientNameTb.Text) ||
              string.IsNullOrWhiteSpace(AddressClientTb.Text) ||
              string.IsNullOrWhiteSpace(EmailCostomerTb.Text) ||
               string.IsNullOrWhiteSpace(PhoneCostomerTb.Text))
                {
                    FeedbackServise.Warning("Заполните все поля!");
                }
                else
                {
                    // При заполнении всех полей реализуем добавление.
                    Customer newCustomer = new Customer()
                    {
                        Id = IDclienTb.Text,
                        Name = ClientNameTb.Text,
                        Address = AddressClientTb.Text,
                        CityId = (int)ZipCityCmb.SelectedValue,
                        Phone = PhoneCostomerTb.Text,
                        Email = EmailCostomerTb.Text,
                        Zip = ZipCityTb.Text
                    };
                    App.GetContext().Customers.Add(newCustomer);

                    App.GetContext().SaveChanges();
                    FeedbackServise.Information("Читатель успешно добавлен!");
                    DialogResult = true;
                }

            }
            catch (Exception exception)
            {
                FeedbackServise.Error(exception);
            }
        }

        private void LoadCities()
        {
            ZipCityCmb.ItemsSource = _cities;
        }
        private void EditBtnClick(object sender, EventArgs e)
        {
            EditBtnClick(sender, e);
            try
            {
                App.GetContext().SaveChanges();
                FeedbackServise.Information("Данные читателя успешно изменены!");
            }
            catch (Exception ex)
            {
                FeedbackServise.Error(ex);
            }

        }

        private string GenerateId()
        {
            int lastId = Convert.ToInt32(App.GetContext().Customers.Max(x => x.Id).Substring(1));
            //=> "C1015" => "1015"=>1015

            ++lastId;// =>1015 +1 +>1016
            return $"C{lastId}";//"C1016"
        }

        private void SaveBtn_Click_1(object sender, RoutedEventArgs e)
        {
            AddCustomer();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            AddCustomer();
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}