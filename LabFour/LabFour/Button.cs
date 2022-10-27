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
            return string.Format("Button status - {0}", Clicked);
        }
    }
}
