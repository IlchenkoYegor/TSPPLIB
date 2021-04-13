using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TSPP2.model
{
    public class Book
    {

        private int id;
        private string author;
        private int yearOfBook;
        private string name;
        private int location;

        public Book(int id, string author, int yearOfBook, string name, int location)
        {
            this.id = id;
            this.Author = author ?? throw new ArgumentNullException(nameof(author));
            this.YearOfBook = yearOfBook;
            this.Name = name ?? throw new ArgumentNullException(nameof(name));
            this.Location = location;
        }

        public int Id { get => id; set => id = value; }
        public string Author { get => author; set => author = value; }
        public int YearOfBook { get => yearOfBook; set => yearOfBook = value; }
        public int Location { get => location; set => location = value; }
        public string Name { get => name; set => name = value; }

        public override bool Equals(object obj)
        {
            return obj is Book book &&
                   id == book.id &&
                   author == book.author &&
                   yearOfBook == book.yearOfBook &&
                   name == book.name &&
                   location == book.location;
        }
    }
}
