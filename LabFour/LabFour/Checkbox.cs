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

            Checked = !Checked;
        }

        public override string ToString()
        {
            return string.Format("Checkbox\tstatus - {0}", Checked);
        }
    }
}
