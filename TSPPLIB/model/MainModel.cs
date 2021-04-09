using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSPP2.model;

namespace TSPPLIB.model
{
    class MainModel
    {

        public MainModel()
        {
            selectedBooks = FileReader.OpenFile();
            allBooks = FileReader.OpenFile();

        }
        //editors funct
        private List<Book> selectedBooks = new List<Book>();
        private List<Book> allBooks = new List<Book>();
        private int year;
        private string name;
        private string author;
        public void Add(Book book)
        {
            allBooks.Add(book);
        }
        public void Delete(Book book)
        {
            allBooks.Remove(book);
        }
        public void SaveChanges()
        {
            Saver.OpenFile(allBooks);
        }
        public void Edit(int i, Book book)
        {
            if (selectedBooks.Count.Equals(allBooks.Count) || i > allBooks.Count)
            {
                throw new MissingFieldException("Expected that you are Editor but you have functionality of Customer");
            }

            allBooks[i] = book;
        }
        //Customers
        public void ToWrite()
        {
            WriteData.Write(selectedBooks);
        }
        
        
        public List<Book> getAll()
        {
            return allBooks;
        }
        public List<Book> getFiltered()
        {
            return selectedBooks;
        }
        public void FilterByYear(int year)
        {
            this.year = year;
            selectedBooks = SelectXX.SelectYear(allBooks, year);
        }

        public void FilterByAuthor(string author, string name)
        {
            this.author = author;
            this.name = name;
            selectedBooks = SelectXY.Select(allBooks, name, author);
        }


    }
}
