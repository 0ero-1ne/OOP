using System;
using System.Linq;
using System.Text;

namespace LabOne
{
    class Program
    {
        private static void printSteppedArray()
        {
            int[][] steppedArray = new int[3][];
            steppedArray[0] = new int[2] { 1, 2 };
            steppedArray[1] = new int[3] { 3, 4, 5 };
            steppedArray[2] = new int[4] { 6, 7, 8, 9 };

            for (int i = 0; i < 2; i++)
                Console.Write(String.Format("{0}\t", steppedArray[0][i]));
            Console.WriteLine();

            for (int i = 0; i < 3; i++)
                Console.Write(String.Format("{0}\t", steppedArray[1][i]));
            Console.WriteLine();

            for (int i = 0; i < 4; i++)
                Console.Write(String.Format("{0}\t", steppedArray[2][i]));
            Console.WriteLine();

            return;
        }

        private static (int, int, int, string) completeFithTask(int[] arr, string str)
        {
            int maxValueOfArr = arr.Max();
            int minValueOfArr = arr.Min();
            int sumOfArr = arr.Sum();
            string firstLetterOfStr = str.Substring(0, 1);

            return (minValueOfArr, maxValueOfArr, sumOfArr, firstLetterOfStr);
        }
        private static void checkedFunction()
        {
            int maxValue = int.MaxValue;

            try
            {
                checked
                {
                    Console.WriteLine(maxValue + 1);
                }
            }
            catch (OverflowException e)
            {
                Console.WriteLine(e.Message);
            }

            return;
        }
        private static void uncheckedFunction()
        {
            int maxValue = int.MaxValue;

            unchecked
            {
                Console.WriteLine(maxValue + 1);
            }

            return;
        }
        static void Main(string[] args)
        {
            //inicialization
            bool boolType = true;
            sbyte sByteType = 127;
            byte byteType = 255;
            char charType = Convert.ToChar(Console.ReadLine());
            decimal decimalType = 15.55M;
            float floatType = 15.55F;
            double doubleType = 15.55D;
            int intType = Convert.ToInt32(Console.ReadLine());
            uint uIntType = 1234567;
            long longType = Convert.ToInt64(Console.ReadLine());
            ulong uLongType = 12345;
            short shortType = -30000;
            ushort uShortType = 60000;
            string stringType = Console.ReadLine();
            Console.WriteLine("\n<--------->\n\nchar: {0}\nInt type: {1}\nlong: {2}\nstring: {3}", charType, intType, longType, stringType);
            Console.WriteLine(
                "bool: {0}\nsbyte: {1}\nbyte: {2}\ndecimal: {3}\nfloat: {4}\ndouble: {5}\nuint: {6}\nulong: {7}\nshort: {8}\nushort: {9}",
                boolType, sByteType, byteType, decimalType, floatType, doubleType, uIntType, uLongType, shortType, uShortType
            );
            
            //implicit conversions
            byte x = 155;
            int intX = x;
            long longX = x;
            short shortX = x;
            ushort uShortX = x;
            ulong uLongX = x;
            Console.WriteLine("\nImplicit conversion\nbyte: {0}\nint: {1}\nlong: {2}\nshort: {3}\nushort: {4}\nulong: {5}", x, intX, longX, shortX, uShortX, uLongX);
            
            //explicit conversions
            int y = 200;
            byte byteY = (byte)y;
            long longY = (long)y;
            short shortY = (short)y;
            uint uIntY = (uint)y;
            ushort uShortY = (ushort)y;
            Console.WriteLine("\nExplicit conversion\nint: {0}\nbyte: {1}\nlong: {2}\nshort: {3}\nuint: {4}\nushort: {5}", y, byteY, longY, shortY, uIntY, uShortY);

            //packaging and unpackaging
            int packInt = 12345;
            object intObject = packInt;
            int unPackInt = (int)intObject;
            Console.WriteLine("\nPacking and Unpacking\npackInt: {0}\nunPackInt: {1}", packInt, unPackInt);

            //var 1
            var intValue = 567;
            var greetMessage = "Hello, motherfucker!";
            Console.WriteLine("\nVar\nintValue: {0}\ngreetMessage: {1}", intValue, greetMessage);

            //Nullable
            Nullable<int> nullTypeA = null;
            int? nullTypeB = null;
            Console.WriteLine("\nNullable\nnullTypeA: {0}\nnullTypeB: {1}", nullTypeA is null, nullTypeB is null);

            //var 2
            //var intVar = 18;
            //intVar = "Hello";

            //string literals
            string strOne = "Hello";
            string strTwo = "hello";
            Console.WriteLine("\nString literals\nstrOne == strTwo: {0}", strOne == strTwo);

            //String class
            Console.WriteLine("\nString");
            string stringFirst = "Hello world";
            string stringSecond = "You are dumb";
            string stringThird = "I am a student of BSTU";
            string stringFour = "Dumb";
            string bufString = String.Copy(stringFirst);
            string emptyString = "";
            string nullString = null;
            string[] stringWords = stringSecond.Split(' ');
            StringBuilder stringBuilder = new StringBuilder("Hello, World!");
            stringBuilder.Append(" B");
            stringBuilder.Insert(0, "A ");

            Console.WriteLine("Conc: {0}", stringFirst + stringSecond);
            Console.WriteLine("Copy: {0}", bufString);
            bufString = stringSecond.Substring(0, 3);
            Console.WriteLine("Substr: {0}", bufString);
            Console.WriteLine("Split");

            foreach (var word in stringWords)
            {
                Console.WriteLine(word);
            }

            Console.WriteLine("Insert: {0}", stringFirst.Insert(0, stringFour + " "));
            Console.WriteLine("Delete: {0}", stringThird.Replace("BSTU", "BSU"));
            Console.WriteLine("Null string: {0}", String.IsNullOrEmpty(nullString));
            Console.WriteLine("Empty string: {0}", String.IsNullOrEmpty(emptyString));
            Console.WriteLine("String builder: {0}\n", stringBuilder.ToString());

            //arrays
            int[,] matrixOne = new int[2, 5] { { 1, 2, 3, 4, 5 }, { 6, 7, 8, 9, 10 } };
            string[] stringArray = { "AAAA", "BBBB", "CCCC", "DDDD", "EEEE" };
            var stringArrayTwo = new[] { "A", "B", "C", "D", "E" };

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(String.Format("{0}\t", matrixOne[i, j]));
                }
                Console.WriteLine("");
            }

            Console.WriteLine();

            foreach(string str in stringArray)
            {
                Console.Write(String.Format("{0} ", str));
            }

            Console.WriteLine();
            Console.WriteLine("Enter a new value: ");
            bufString = Console.ReadLine();
            Console.WriteLine("Enter a position in array (1-5): ");
            byte chsIndex = Convert.ToByte(Console.ReadLine());
            stringArray[chsIndex - 1] = bufString;

            foreach (string str in stringArray)
            {
                Console.Write(String.Format("{0} ", str));
            }

            Console.WriteLine("\n");

            printSteppedArray();
            
            foreach (string str in stringArrayTwo)
            {
                Console.Write(String.Format("{0} ", str));
            }

            Console.WriteLine("\n");

            //cortege
            (int, string, char, string, ulong) firstCortege = (18, "420", 'D', "715", 99);
            (int, string, char, string, ulong) secondCortege = (25, "67", '3', "44", 57);
            Console.WriteLine(firstCortege.ToString());
            Console.WriteLine(
                "{0} - {1} - {2}",
                firstCortege.Item1, firstCortege.Item3, firstCortege.Item4
            );

            int intItemCortege = firstCortege.Item1;
            string firstStringItemCortege = firstCortege.Item2;
            char charItemCortege = firstCortege.Item3;
            string secondStringItemCortege = firstCortege.Item4;
            ulong uLongItemCortege = firstCortege.Item5;

            Console.WriteLine("Corteges comparing: {0}", firstCortege == secondCortege);

            //local function
            int[] arrayOfNumbers = { 25, 0, -1, 33, 44, 57, 1, 101};
            Console.WriteLine("\n" + completeFithTask(arrayOfNumbers, "Hello, World!").ToString() + "\n");

            //checked and unchecked
            checkedFunction();
            uncheckedFunction();
        }
    }
}
