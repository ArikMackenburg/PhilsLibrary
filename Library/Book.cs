using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Library
{
    public class Book
    {
        public Book()
        {
            CheckedOut = false;
        }
        public string Title { get; set; }
        public Author Author { get; set; }
        public Genre Genre { get; set; }
        public virtual bool CheckedOut { get; set; }

        public int iD { get; set; }

    }
}
