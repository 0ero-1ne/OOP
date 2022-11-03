using System;

namespace LabFour
{
    class Radiobutton : СontrolElement, IClickable
    {
        public bool Clicked { get; set; }

        public Radiobutton() { }

        public Radiobutton(bool clicked) : base("Radiobutton")
        {
            Clicked = clicked;
        }

        public override void Click()
        {
            Console.WriteLine("Clicked class");

            if (Clicked) Clicked = false;
            else Clicked = true;
        }

        void IClickable.Click() => Console.WriteLine("Clicked interface");

        public override string ToString()
        {
            return string.Format("Radiobutton status - {0}", Clicked);
        }
    }
}
