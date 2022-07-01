using System;
using System.Collections.Generic;
using System.Text;

namespace SemesterTest
{
    internal class Library
    {
        List<LibraryResource> _resources;

        public Library(string name)
        {
            _resources = new List<LibraryResource>();
        }

        public void AddResource(LibraryResource resource)
        {
            _resources.Add(resource);
        }

        public bool HasResource(string name)
        {
            foreach (LibraryResource resource in _resources)
            {
                if (resource.Name == name && resource.OnLoan == false)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
