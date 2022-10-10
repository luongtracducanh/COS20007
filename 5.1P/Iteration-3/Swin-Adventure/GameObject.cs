using System;
using System.Collections.Generic;
using System.Text;

namespace Swin_Adventure
{
    public class GameObject : IdentifiableObject
    {
        string _description, _name;

        public GameObject(string[] ids, string name, string desc) : base(ids)
        {
            _name = name;
            _description = desc;
        }

        public string Name
        {
            get { return _name; }
        }

        public string ShortDescription
        {
            get => "a " + _name + " " + FirstID;
        }

        virtual public string LongDescription
        {
            get => _description;
        }
    }
}
