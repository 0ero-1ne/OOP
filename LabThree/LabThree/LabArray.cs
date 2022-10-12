using System;

namespace LabThree
{
    class Array
    {
        public object this[int index]
        {
            get => array[index];
            set => array[index] = value;
        }

        object[] array;
        int length;

        public Array()
        {
            length = 6;
            array = new object[6] { 1, 2, 3, 4, 5, "Array" };
        }

        public Array(int length, params object[] values)
        {
            array = new object[length];
            for (int i = 0; i < length; i++)
                array[i] = values[i];

            this.length = length;
        }

        public void Push(object value)
        {
            length += 1;
            object[] newArray = new object[length];

            newArray[length - 1] = value;

            for (int i = 0; i < length - 1; i++)
                newArray[i] = array[i];

            array = newArray;

            return;
        }

        public void Pop()
        {
            length -= 1;
            object[] newArray = new object[length];

            for (int i = 0; i < length; i++)
                newArray[i] = array[i];

            array = newArray;

            return;
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

        public void PrintArray()
        {
            for (int i = 0; i < length; i++)
                Console.WriteLine("Element {0} - {1}", i, array[i]);
            Console.WriteLine("\n");
            return;
        }
    }
}
