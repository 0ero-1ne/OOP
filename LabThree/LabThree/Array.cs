using System;

namespace LabThree
{
    class Array
    {
        public Production production = new Production("SCANDIWEB");
        public object this[int index]
        {
            get => array[index];
            set => array[index] = value;
        }

        public int Length { get => length; }

        object[] array;
        int length;

        public Array()
        {
            length = 6;
            array = new object[6] { 1, 2, 3, 4, 5, "Array" };
        }

        public Array(int length)
        {
            this.length = length;
            array = new object[length];
        }

        public Array(int length, params object[] values)
        {
            array = new object[length];
            for (int i = 0; i < length; i++)
                array[i] = values[i];

            this.length = length;
        }

        public static Array operator -(Array array, int value)
        {
            for (int i = 0; i < array.Length; i++)
                if (array[i] is int)
                    array[i] = (int)array[i] - value;

            return array;
        }

        public static bool operator >(Array array, object value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Equals(value))
                    return true;
            }

            return false;
        }

        public static bool operator <(Array array, object value)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i].Equals(value))
                    return false;
            }

            return true;
        }

        public static bool operator !=(Array firstArray, Array secondArray)
        {
            if (firstArray.Length != secondArray.Length) return true;

            for (int i = 0; i < firstArray.Length; i++)
                if (!firstArray[i].Equals(secondArray[i]))
                    return true;

            return false;
        }

        public static bool operator ==(Array firstArray, Array secondArray)
        {
            if (firstArray.Length != secondArray.Length) return false;

            for (int i = 0; i < firstArray.Length; i++)
                if (!firstArray[i].Equals(secondArray[i]))
                    return false;

            return true;
        }

        public static Array operator +(Array firstArray, Array secondArray)
        {
            Array array = new Array(firstArray.Length + secondArray.Length);

            for (int i = 0; i < firstArray.Length; i++)
                array[i] = firstArray[i];
            for (int i = 0; i < secondArray.Length; i++)
                array[firstArray.Length + i] = secondArray[i];

            return array;
        }

        public void RemoveElement(int index)
        {
            if (index >= length || index < 0) throw new Exception("Invalid value for index");
            length -= 1;

            object[] newArray = new object[length];

            for (int i = 0; i < index; i++)
                newArray[i] = array[i];

            for (int i = index; i < length; i++)
                newArray[i] = array[i + 1];

            array = newArray;
        }

        public void Pop()
        {
            length -= 1;
            object[] newArray = new object[length];

            for (int i = 0; i < length; i++)
                newArray[i] = array[i];

            array = newArray;
        }

        public void Push(object value)
        {
            length += 1;
            object[] newArray = new object[length];

            newArray[length - 1] = value;

            for (int i = 0; i < length - 1; i++)
                newArray[i] = array[i];

            array = newArray;
        }

        /*public void RemoveFirstFiveElements()
        {
            if (array.Length < 5) return;

            object[] newArray = new object[array.Length - 5];
            for (int i = 5, j = 0; i < array.Length; i++, j++)
                newArray[j] = array[i];

            length -= 5;
            array = newArray;
        }*/

        public void PrintArray()
        {
            for (int i = 0; i < length; i++)
                Console.WriteLine("Element {0} - {1}", i, array[i]);

            Console.WriteLine();
        }

        public class Developer
        {
            int ID;
            public string Name
            {
                get => name;
                set => name = value;
            }
            string name;

            public string Surname
            {
                get => surname;
                set => surname = value;
            }
            string surname;

            public string Office
            {
                get => office;
                set => office = value;
            }
            string office;

            public Developer()
            {
                ID = GetHashCode();
                name = "Dmitry";
                surname = "Volikov";
                office = "PHP";
            }

            public Developer
            (
                string name,
                string surname,
                string office
            )
            {
                ID = GetHashCode();
                Name = name;
                Surname = surname;
                Office = office;
            }

            public void PrintInfo()
            {
                Console.WriteLine("ID - {0}\nName - {1}\nSurname - {2}\nOffice - {3}\n", ID, Name, Surname, Office);
            }
        }
    }
}
