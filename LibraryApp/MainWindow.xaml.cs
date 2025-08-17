using LibraryApp.Controllers;
using LibraryApp.Models;
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

namespace LibraryApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BookController _controller;

        public MainWindow()
        {
            InitializeComponent();
            _controller = new BookController();
            BooksDataGrid.ItemsSource = _controller.GetAllBooks();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            var window = new EditBookWindow(_controller);

            if (window.ShowDialog() == true) return;
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            if (BooksDataGrid.SelectedItem is BookModel book)
            {
                _controller.DeleteBook(book);
                //BooksDataGrid.ItemsSource = _controller.GetAllBooks();
            }
            else
            {
                MessageBox.Show("Select a book to delete.");
            }
        }

        private void EditBtn_Click(object sender, RoutedEventArgs e)
        {
            if (BooksDataGrid.SelectedItem is BookModel book)
            {
                var window = new EditBookWindow(_controller, book);

                if (window.ShowDialog() == true)
                {
                    BooksDataGrid.ItemsSource = null;
                    BooksDataGrid.ItemsSource = _controller.GetAllBooks();
                }
            }
            else
            {
                MessageBox.Show("Select a book to edit.");
            }
        }
    }
}