using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
using static System.Collections.Specialized.BitVector32;

namespace OOPLibrary
{
    public partial class MainWindow : Window
    {
        private Library library;
        

        public MainWindow()
        {
            InitializeComponent();
            library = new Library();
        }

        

        private void btnAddBook_Click(object sender, RoutedEventArgs e)
        {
            string title = tbTitle.Text;
            string author = tbAuthor.Text;
            string isbn = tbISBN.Text;
            int year = int.Parse(tbYear.Text);
            string specific = tbSpecific.Text;
            string bookType = (cbBookType.SelectedItem as ComboBoxItem)?.Content.ToString();
          

            Book book = null;


            if (bookType == "Fiction")
            {
                book = new Fiction(title, author, isbn, year, specific);
            }
            else if (bookType == "Non-Fiction")
            {
                book = new NonFiction(title, author, isbn, year, specific);
            }
            else if (bookType == "Comic")
            {
                book = new Comic(title, author, isbn, year, specific);
            }

            if (book != null)
            {
                library.AddBook(book);
                MessageBox.Show("Book added.");
            }
        }

        private void btnShowList_Click(object sender, RoutedEventArgs e)
        {
            lbBookList.Items.Clear();
            foreach (var book in library.BookList)
            {
                lbBookList.Items.Add(book.ToString());
            }
        }

        private void btnSaveToFile_Click(object sender, RoutedEventArgs e)
        {
            library.SaveToFile("book_list.txt");
            MessageBox.Show("Book list saved.");
   
        }
        

    }

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public string Isbn { get; set; }

        public int Year { get; set; }
    }

    public class Fiction : Book
    { 
    public string Genre { get; set; }

    }
    public class NonFiction : Book 
    { public string Genre { get; set;}
      public string Field { get; set; }
    }

    public class Comic : Book 
    {
        public string Genre { get; set;} 
        public string Illustrator { get; set;}
    }

    public class Library
    {
        public List<Book> BookList { get; set; }

     public void   AddBook()
        {

            
   
        }

       public void ShowBookList(Book book)
        {
            string testList = ".";
            foreach(Book v in BookList)
            {
                testList += v.Title;
            }
        }

      public void  SaveToFile()
        {
            
        }




    }

}