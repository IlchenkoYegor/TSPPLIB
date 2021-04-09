﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TSPP2.model;

namespace TSPPLIB.model
{
    class Saver
    {
            const string path = "listofbooks.txt";

            internal static List<Book> OpenFile(List<Book> listOfBooks)
            {

                //List<Book> listOfBooks = new List<Book>();
                try
                {
                    StreamWriter streamReader = new StreamWriter(path);
                    foreach (Book item in listOfBooks)
                    {
                        StringBuilder stringBuilder = new StringBuilder();
                        stringBuilder.Append(item.Id+",");
                        stringBuilder.Append(item.Name+",");
                        stringBuilder.Append(item.Author+",");
                        stringBuilder.Append(item.YearOfBook+",");
                        stringBuilder.Append(item.Location+",");
                        String result = stringBuilder.ToString();
                    }
                    return listOfBooks;
                    streamReader.Close();
#pragma warning disable CS0168 // Переменная "e" объявлена, но ни разу не использована.
                }
                catch (Exception e)
#pragma warning restore CS0168 // Переменная "e" объявлена, но ни разу не использована.
                {
                    MessageBox.Show("Exception occured !No such file have found!");
                }
                return null;
            }
        }
    }