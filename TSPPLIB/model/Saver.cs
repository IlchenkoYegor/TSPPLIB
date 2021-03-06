using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TSPP2.model;

namespace TSPPLIB.model
{
    public class Saver
    {
            const string path = "listofbooks.txt";

            internal static void OpenFile(List<Book> listOfBooks)
            {
                try
                {
                    StreamWriter streamWriter = new StreamWriter(path);
                    foreach (Book item in listOfBooks)
                    {
                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder.Append(item.Id+",");
                        stringBuilder.Append(item.Name+",");
                        stringBuilder.Append(item.Author+",");
                        stringBuilder.Append(item.YearOfBook+",");
                        stringBuilder.Append(item.Location+",");
                        String result = stringBuilder.ToString();
                        streamWriter.WriteLine(result);
                        streamWriter.Flush();
                    }
                streamWriter.Close();
                return;
                }
                catch (Exception e)
                {
                    MessageBox.Show("Exception occured !No such file have found! " +e.StackTrace);
                }
                return;
            }
        }
    }
