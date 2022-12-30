using System;
/*using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
*/

namespace ContrWork
{
    class FirstTask
    {
        int[,] array;
        public int Rows { get; set; }
        public int Columns { get; set; }

        public FirstTask(int rows, int columns)
        {
            array = new int[rows, columns];
            Rows = rows;
            Columns = columns;
        }

        public void FillArray()
        {
            Random random = new Random();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    array[i, j] = random.Next() % 255;
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public int CalculateElements()
        {
            return Rows * Columns;
        }
    }
}
