using System;
using System.Collections.Generic;
using System.Text;

namespace SemesterTest
{
    internal class Book : LibraryResource
    {
        string _author, _isbn;

        public Book(string name, string author, string isbn) : base(name)
        {
            _author = author;
            _isbn = isbn;
        }

        public override string Author
        {
            get { return _author; }
        }

        public string ISBN
        {
            get { return _isbn; }
        }
    }
}
