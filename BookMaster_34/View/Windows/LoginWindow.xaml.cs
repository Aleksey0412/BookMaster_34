using BookMaster_34.AppData;
using BookMaster_34.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BookMaster_34.View.Windows
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Validate())
            {
                Administrator? administrator = App.GetContext().Administrators.FirstOrDefault(administrator => administrator.Username == LoginTb.Text && administrator.Password == PasswordPb.Password);

                if (administrator != null )
                {
                    FeedbackServise.Information("Успешная авторизация");


                    //DialogResult возвращает результат работы диалогового окна
                    DialogResult = true; 
                }
                else
                {
                    FeedbackServise.Error("Пользователь не найден");
                }
            }
          
        }

        private void Calcel_Click(object sender, RoutedEventArgs e)
        {

        }

       private bool Validate()
        {
            if (string.IsNullOrWhiteSpace(LoginTb.Text))
            {
                FeedbackServise.Warning("Введите сообщение");
                LoginTb.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(LoginTb.Text))
            {
                FeedbackServise.Warning("Введите пароль");
                PasswordPb.Focus();
                return false;
            }

            return true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (CredentialsService.AutoLogin && !string.IsNullOrWhiteSpace(CredentialsService.SavedLogin))
            {
                LoginTb.Text = CredentialsService.SavedLogin;
                PasswordPb.Password = CredentialsService.SavedPassword;
                RememberMeCb.IsChecked = CredentialsService.AutoLogin;
            }
        }


    }
}
