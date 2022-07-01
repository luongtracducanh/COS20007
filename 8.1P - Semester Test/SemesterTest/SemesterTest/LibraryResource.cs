using System;
using System.Collections.Generic;
using System.Text;

namespace SemesterTest
{
    abstract class LibraryResource
    {
        string _name;
        bool _onLoan;

        public LibraryResource(string name)
        {
            _name = name;
        }

        public string Name
        {
            get { return _name; }
        }

        abstract public string Author
        {
            get;
        }

        public bool OnLoan
        {
            get { return _onLoan; }
            set { _onLoan = value; }
        }
    }
}
