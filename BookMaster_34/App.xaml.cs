using BookMaster_34.Models;
using System.Configuration;
using System.Data;
using System.Windows;

namespace BookMaster_34
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static BookmasterContext _context;

        public static BookmasterContext GetContext()
        {
            if (_context == null)
            {
                _context = new BookmasterContext();
            }
            return _context;
        }
    }

}
