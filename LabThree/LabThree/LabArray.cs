using System;

namespace LabThree
{
    class Array
    {
        object[] array;
        private int length;

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



        public void PrintArray()
        {
            for (int i = 0; i < length; i++)
                Console.WriteLine("Element {0} - {1}", i, array[i]);

            return;
        }
    }
}
