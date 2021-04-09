using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TSPP2.model
{
    class WriteData
    {
        const string path = "resultofsearch.txt";

        internal static void Write(List<Book> listOfBooks)
        {

            //List<Book> listOfBooks = new List<Book>();
            try
            {
                StreamWriter streamWriter = new StreamWriter(path);
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("id        name                            author" +
                    "                  year of book     location");
                streamWriter.WriteLine(stringBuilder.ToString());
                int id = stringBuilder.ToString().IndexOf("id");
                int authorLine = stringBuilder.ToString().IndexOf("author");
                int name = stringBuilder.ToString().IndexOf("name");
                int year = stringBuilder.ToString().IndexOf("year of book");
                int location = stringBuilder.ToString().IndexOf("location");
                foreach (Book item in listOfBooks)
                {
                    
                    stringBuilder.Clear();
                    stringBuilder.Append("                                                                                          ");
                    stringBuilder.Insert(id,item.Id.ToString(), 1);
                    stringBuilder.Insert(name, item.Name.ToString(), 1);
                    stringBuilder.Insert(authorLine, item.Author.ToString(),  1);
                    stringBuilder.Insert(year, item.YearOfBook.ToString(), 1);
                    stringBuilder.Insert(location, item.Location.ToString(), 1);
                    streamWriter.WriteLine(stringBuilder.ToString());
                    streamWriter.Flush();
                }
                streamWriter.Close();
            }
#pragma warning disable CS0168 // Переменная "e" объявлена, но ни разу не использована.
            catch (Exception e)
#pragma warning restore CS0168 // Переменная "e" объявлена, но ни разу не использована.
            {
                MessageBox.Show("Exception occured !No such file have found!");
            }
        }
    }
}

