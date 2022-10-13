using System;

namespace LabThree
{
    static class StatisticOperation
    {
        public static int Sum(Array array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += (int)array[i];
            }

            return sum;
        }

        public static int Length(Array array)
        {
            return array.Length;
        }

        public static int MaxMinusMin(Array array)
        {
            int max = (int)array[0];
            int min = (int)array[0];

            for (int i = 0; i < array.Length; i++)
            {
                if ((int)array[i] > max) max = (int)array[i];
                if ((int)array[i] < min) min = (int)array[i];
            }

            return max - min;
        }

        public static string RemoveVowelChars(this string str)
        {
            string result = "";
            const string VowelLetters = "aeouiAEOUI";

            for (int i = 0; i < str.Length; i++)
                if (VowelLetters.IndexOf(str[i]) == -1)
                    result += str[i];

            return result;
        }

        public static Array RemoveFirstFiveElements(this Array array)
        {
            if (array.Length < 5) throw new Exception("Invalid length for this method");

            Array newArray = new Array(array.Length - 5);
            for (int i = 5, j = 0; i < array.Length; i++, j++)
                newArray[j] = array[i];

            return newArray;
        }
    }
}
