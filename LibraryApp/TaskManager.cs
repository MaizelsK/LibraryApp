using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace LibraryApp
{
    public class TaskManager
    {
        DataGrid Grid { get; set; }
        Label Label { get; set; }

        public TaskManager(DataGrid grid, Label label)
        {
            Grid = grid;
            Label = label;
        }

        public void Task1()
        {
            Label.Content = "Список должников";

            using (var context = new LibraryContext())
            {
                // Выборка посетителей с задолжностью более недели
                var innerQuaery = from c in context.Customers_books
                                  where DbFunctions.DiffDays(c.Order_date, DateTime.Now) > 7
                                  select c.Customer_id;

                var quaery = from c in context.Customers
                             where innerQuaery.Contains(c.Id)
                             select c;

                Grid.ItemsSource = quaery.ToList();
            }
        }

        public void Task2()
        {
            Label.Content = "Список авторов, написавших книгу №3 с таблицы Books";

            using (var context = new LibraryContext())
            {
                List<Author> authors = context.Books.ToArray()[2].Authors.ToList();

                Grid.ItemsSource = authors;
            }
        }

        public void Task3()
        {
            Label.Content = "Cписок книг, которые доступны в данный момент";

            using (var context = new LibraryContext())
            {
                var books = from b in context.Customers_books
                            select b.Book;

                var freeBooks = context.Books.Except(books).ToList();

                Grid.ItemsSource = freeBooks;
            }
        }

        public void Task4()
        {
            Label.Content = "Cписок книг, которые на руках у пользователя №2";

            using (var context = new LibraryContext())
            {
                var customerId = context.Customers.ToArray()[1].Id;

                var currentBooks = from b in context.Customers_books
                                   where b.Customer_id == customerId
                                   select b.Book;

                Grid.ItemsSource = currentBooks.ToList();
            }
        }

        public void Task5()
        {
            Label.Content = "Обнулите задолженности всех должников";

            using (var context = new LibraryContext())
            {
                var customers = from c in context.Customers_books
                                where DbFunctions.DiffDays(c.Order_date, DateTime.Now) > 7
                                select c;

                context.Customers_books.RemoveRange(customers.AsEnumerable());
            }

            MessageBox.Show("Все задолженности обнулены");
        }

        public int GetDays(DateTime day)
        {
            return (day - DateTime.Now).Days;
        }
    }
}
