using System;

namespace LabEight
{
    class User
    {
        public event CompressHandler Compressed;
        public event MoveHandler Moved;

        public int CompressFactor { get; set; }

        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Country { get; set; }
        public int Age { get; set; }

        public User
        (
            string firstName,
            string secondName,
            string country,
            int age
        )
        {
            FirstName = firstName;
            SecondName = secondName;
            Country = country;
            Age = age;
        }

        public static void ReplaceString(string str, string oldChar, string newChar) => Console.WriteLine(str.Replace(oldChar, newChar));

        public static void DeleteString(string str, string delStr1, string delStr2)
        {
            if (str.Contains(delStr1))
            {
                Console.WriteLine(str.Replace(delStr1, ""));
            }
            else if (str.Contains(delStr2))
            {
                Console.WriteLine(str.Replace(delStr2, ""));
            }
            else
            {
                Console.WriteLine(str);
            }
        }

        public static bool IsLenghtGreaterThanFive(string str) => str.Length > 5;

        public static bool StringContainsA(string str) => str.Contains("A");

        public static bool IsPalyndrom(string str)
        {
            for (int first = 0, last = str.Length - 1; first < last; ++first, --last)
            {
                if (str[first] != str[last])
                {
                    return false;
                }
            }

            return true;
        }

        public void CompressObject()
        {
            if (Compressed != null)
            {
                CompressFactor = new Random().Next(100);
                Compressed.Invoke();
            }
        }

        public void MoveObject(string destination)
        {
            if (Moved != null)
            {
                Country = destination;
                Moved.Invoke(destination);
            }
        }
    }
}
