using BookMaster_34.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookMaster_34.AppData
{
    /// <summary>
    /// Обеспечивает навигацию между книгами.
    /// </summary>
    public class PaginationController
    {
       /// <summary>
       /// Список книг
       /// </summary>
        private List<Book> _books = new();

        /// <summary>
        /// Кол-во книг на странице
        /// </summary>
        private const int PAGE_SIZE = 50;

        /// <summary>
        /// Порядковый номер страницы
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Общее кол-во страниц
        /// </summary>
        public int TotalPages { get; set; }

        /// <summary>
        /// Количество книг
        /// </summary>
        public int BooksCount => _books.Count;

        /// <summary>
        /// Определяет возможен ли переход наа предыдущую страницу
        /// </summary>
        public bool CanGoPrivious => CurrentPage > 1;

        /// <summary>
        /// Определяет возможен ли переход наа следующую страницу
        /// </summary>
        public bool CanGoNext => CurrentPage < TotalPages;

        public void Load(List<Book> books)
        {
            _books = books ?? new List<Book>(); //Если коллекция "books" пустая то в коллекцию _books инициализируем новую коллекцию

            TotalPages = BooksCount == 0 ? 1 : (int)Math.Ceiling(BooksCount / (double)PAGE_SIZE); // Считаем колво страниц относительно количества книг

            CurrentPage = 1; //устанавливаел номер страницы по умолчанию
        }

        public void GoToPAGE(int page)
        {
            CurrentPage = Math.Clamp(page, 1, TotalPages);
        }

        public List<Book> GetCurrentPage()
        {
            return _books.Skip((CurrentPage-1) *PAGE_SIZE).Take(PAGE_SIZE).ToList();
        }

    }
}
