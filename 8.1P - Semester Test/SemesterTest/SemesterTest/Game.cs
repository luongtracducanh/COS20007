using System;
using System.Collections.Generic;
using System.Text;

namespace SemesterTest
{
    internal class Game : LibraryResource
    {
        string _developer, _contentRating;

        public Game(string name, string developer, string rating) : base(name)
        {
            _developer = developer;
            _contentRating = rating;
        }

        public override string Author
        {
            get { return _developer; }
        }

        public string ContentRating
        {
            get { return _contentRating; }
        }
    }
}
