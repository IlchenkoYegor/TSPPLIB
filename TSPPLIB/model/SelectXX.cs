using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSPP2.model;

namespace TSPPLIB.model
{
    class SelectXX
    {
        public static List<Book> SelectYear(List<Book> books ,int year)
        {
            return books.FindAll(e => (year == e.YearOfBook));
        }
    }
}
