using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TSPP2.model;

namespace TSPPLIB.model
{
    public class SelectXY
    {
        public static List<Book> Select(List<Book> books, string name, string author)
        {
            return books.FindAll(e => (name == e.Name && author == e.Author));
        }
    }
}
