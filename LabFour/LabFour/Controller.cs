/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
*/

namespace LabFour
{
    class Controller
    {
        UI container;

        public UI Container
        {
            get => container;
            set
            {
                if (value == null)
                {
                    throw new NullObject("The object should not store a null value");
                }
                container = value;
            }
        }

        public Controller(UI container)
        {
            Container = container;
        }

        public int GetLength()
        {
            return Container.Length;
        }

        public int GetNumberOfButtons()
        {
            int result = 0;

            for (int i = 0; i < GetLength(); i++)
            {
                if (Container[i] is СontrolElement) result++;
            }

            return result;
        }

        public double GetGeneralArea()
        {
            double area = 0;

            for (int i = 0; i < GetLength(); i++)
            {
                if (Container[i] is GeometricFigure)
                    area += ((GeometricFigure)Container[i]).CalculateSquare();
            }

            return area;
        }
    }
}
