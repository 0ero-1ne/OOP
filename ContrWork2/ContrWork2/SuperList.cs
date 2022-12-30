using System;
using System.Collections.Generic;

namespace ContrWork2
{
    class SuperList<T>
    {
        List<T> _elements = new List<T>();

        public SuperList(params T[] array)
        {
            foreach (var item in array)
            {
                _elements.Add(item);
            }
        }

        public void Add(T obj)
        {
            _elements.Add(obj);
        }

        public void FindElement(T obj)
        {
            if (_elements.Contains(obj))
                Console.WriteLine("Element exists");
            else
                throw new Exception("No such element!");
        }
    }
}
