using System;

namespace LabFour
{
    class Checkbox : СontrolElement
    {
        public bool Checked { get; set; }

        public Checkbox() { }

        public Checkbox(bool clicked) : base("Checkbox")
        {
            Checked = clicked;
        }

        public override void Click()
        {
            Console.WriteLine("Checked");

            if (Checked) Checked = false;
            else Checked = true;
        }

        public override string ToString()
        {
            return string.Format("Checkbox status - {0}", Checked);
        }
    }
}
