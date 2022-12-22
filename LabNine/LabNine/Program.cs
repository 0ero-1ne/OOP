using System;
using System.Collections.Generic;

namespace LabNine
{
    public delegate void CollectionChange();

    class Program
    {
        static void Main()
        {
            Book<int, string> books = new Book<int, string>();
            books.Add(1, "The police");
            books.Add(2, "Great Math of music");
            books.Add(new KeyValuePair<int, string>(3, "C# from 0 to Infinity"));

            Console.WriteLine(books.GetAllBooks());

            books.Remove(1);
            string value;

            bool hasElement = books.TryGetValue(2, out value);
            Console.WriteLine(hasElement ? "There is such element" : "There is no such element");
            Console.WriteLine(books.GetAllBooks() != "" ? books.GetAllBooks() : "No elements...");
            Console.WriteLine("Number of books: " + books.Amount);

            object[] range =
            {
                1,
                2,
                "Dmitry"
            };

            List<object> rangeList = new List<object>(range);

            List<object> objList = new List<object>();
            objList.Add(1);
            objList.Add("F");
            objList.Add(4.5);
            objList.AddRange(rangeList);

            Console.WriteLine("List<object>:");

            foreach (var obj in objList)
            {
                Console.WriteLine(obj.ToString());
            }

            Queue<object> queue = new Queue<object>();
            foreach (var obj in objList)
            {
                queue.Enqueue(obj);
            }
            Console.WriteLine(queue.Contains(1));

            var observableCollection = new ObservableCollection<Book<int, string>>();
            CollectionChange collectionChange = new CollectionChange(Changed);
            observableCollection.CollectionChanged += collectionChange;

            observableCollection.Add(books);
        }

        public static void Changed()
        {
            Console.WriteLine("Коллекция изменилась");
        }
    }
}
