using System;

namespace LabFour
{
    class Button : СontrolElement
    {
        public bool Clicked { get; set; }

        public Button() { }

        public Button(bool clicked) : base("Button")
        {
            Clicked = clicked;
        }

        public override void Click()
        {
            Console.WriteLine("Clicked");

            if (Clicked) Clicked = false;
            else Clicked = true;
        }

        public override string ToString()
        {
            return string.Format("Button\tstatus - {0}", Clicked);
        }

        struct ButtonStruct
        {
            public string ShapeOfButton;
            string ColorOfButton;

            string GetColor()
            {
                return ColorOfButton;
            }

            public string GetShape()
            {
                return ShapeOfButton;
            }
        }

        public enum Colors
        {
            Green = 1,
            Purple,
            Red,
            Black = 5,
            White = 0,
            Gray = 10
        }
    }
}
