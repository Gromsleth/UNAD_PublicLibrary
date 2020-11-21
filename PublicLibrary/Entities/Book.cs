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

    }
}
