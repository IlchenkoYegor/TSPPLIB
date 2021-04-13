using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace TSPP2.model
{
    public class FileReader
    {
        const string path = "listofbooks.txt";
        
        internal static List<Book> OpenFile()
        {
            
            List<Book> listOfBooks = new List<Book>();
            try
            {
                StreamReader streamReader = new StreamReader(path);
                while (!streamReader.EndOfStream)
                {
                    String result = streamReader.ReadLine();
                    result.Trim();
                    string[] toRead = result.Split(',');
                    int id = Convert.ToInt32(toRead[0]);
                    string name = toRead[1];
                    string author = toRead[2];
                    int yearOfBook = Convert.ToInt32(toRead[3]);
                    int location = Convert.ToInt32(toRead[4]);
                    listOfBooks.Add(new Book(id, author, yearOfBook, name, location));
                }
                streamReader.Close();
                return listOfBooks;
                
#pragma warning disable CS0168 // Переменная "e" объявлена, но ни разу не использована.
            } catch(Exception e)
#pragma warning restore CS0168 // Переменная "e" объявлена, но ни разу не использована.
            {
                MessageBox.Show("Exception occured !No such file have found!");                
            }
            Environment.Exit(0);
            return null;
        }
    }
}
