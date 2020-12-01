using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PublicLibrary.Entities
{
    public class Book
    {
        public int ReferenceId { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public int Quantity { get; set; }

        public string ForData()
        {
            return String.Format("{0}|{1}|{2}|{3}", ReferenceId, Quantity, Title, Author);
        }

        public string ForList()
        {
            return String.Format(" | {0} | {1} | {2} | {3} |\n", ReferenceId.ToString().PadLeft(10, ' '), Quantity.ToString().PadLeft(10, ' '), Title.PadLeft(50, ' '), Author.PadLeft(50, ' '));
        }
    }
}
