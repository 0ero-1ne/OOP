using System;

namespace LabFour
{
    class Radiobutton : СontrolElement
    {
        public bool Clicked { get; set; }

        public Radiobutton() { }

        public Radiobutton(bool clicked) : base("Radiobutton")
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
            return string.Format("Radiobutton status - {0}", Clicked);
        }
    }
}
