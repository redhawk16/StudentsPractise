using StudentsPract.Classes;
using System;
using System.Collections.Generic;
using System.Windows;

namespace StudentsPract.Classes
{
    public class Parent : DependencyObject, IParent<object>
    {
        public string Name { get; set; }
        public List<Child> Members { get; set; }

        IEnumerable<object> IParent<object>.GetChildren()
        {
            return Members;
        }
    }

    public class Child : DependencyObject
    {
        public string Name { get; set; }
    }

    interface IParent<T>
    {
        IEnumerable<T> GetChildren();
    }
}