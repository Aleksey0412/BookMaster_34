using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BookMaster_34.AppData
{
    public static class FeedbackServise
    {
        public static void Error(string message)
        {
            MessageBox.Show(message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public static void Error(Exception exception)
        {
            MessageBox.Show(exception.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public static void Warning(string message)
        {
            MessageBox.Show(message, "Предупреждение", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public static void Information(string message)
        {
            MessageBox.Show(message, "Сообщение", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public static MessageBoxResult Question(string message)
        {
            return MessageBox.Show(message, "Вопрос", MessageBoxButton.YesNo, MessageBoxImage.Question);
           
        }
    }
}
