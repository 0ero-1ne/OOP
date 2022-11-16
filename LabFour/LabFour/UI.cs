using System;
using System.Collections.Generic;
/*using System.Linq;
using System.Text;
using System.Threading.Tasks;
*/

namespace LabFour
{
    class UI
    {
        public dynamic this[int index]
        {
            get => elements[index];
            set
            {
                if (value == null)
                {
                    throw new NullObject("The object should not store a null value");
                }
                else
                {
                    elements[index] = value;
                }
            }
        }

        List<dynamic> elements = new List<dynamic>();

        public int Length => elements.Count;

        public void AddElement(dynamic item)
        {
            if (item == null)
            {
                throw new NullObject("The object should not store a null value");
            }
            elements.Add(item);
        }

        public void RemoveElement(int item)
        {
            elements.RemoveAt(item - 1);
        }

        public void PrintElements()
        {
            string result = "";

            for (int i = 0; i < elements.Count; i++)
            {
                result += (i + ": ").ToString() + elements[i].ToString() + "\n";
            }

            Console.WriteLine(result);
        }
    }
}
