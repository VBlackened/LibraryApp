using LibraryApp.Models;
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
using System.Windows.Shapes;
using LibraryApp.Controllers;

namespace LibraryApp
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class EditBookWindow : Window
    {
        private readonly BookController _controller;
        private readonly BookModel? _editingBook;

        public EditBookWindow(BookController controller, BookModel? editingBook = null)
        {
            InitializeComponent();
            _controller = controller;
            _editingBook = editingBook;

            if (_editingBook != null)
            {
                TitleBox.Text = _editingBook.Title;
                AuthorBox.Text = _editingBook.Author;
                YearBox.Text = _editingBook.YearOfRelease.ToString();
            }

        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {

            if (!int.TryParse(YearBox.Text, out int year))
            {
                MessageBox.Show("Year must be a number.");
                return;
            }

            if (_editingBook != null)
            {
                _editingBook.Title = TitleBox.Text;
                _editingBook.Author = AuthorBox.Text;
                _editingBook.YearOfRelease = year;

                var result = _controller.EditBook(_editingBook);
                if (result != null)
                {
                    MessageBox.Show(result, "Validation error");
                    return;
                }
            }
            else
            {
                var result = _controller.AddBook(TitleBox.Text, AuthorBox.Text, year);
                if (result != null)
                {
                    MessageBox.Show(result, "Validation error");
                    return;
                }
            }

            DialogResult = true;
            Close();
        }
    }
}
