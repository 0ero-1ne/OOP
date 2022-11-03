namespace LabFour
{
    abstract class СontrolElement
    {
        public string Name { get; set; }

        public СontrolElement() { }

        public СontrolElement(string name)
        {
            Name = name;
        }

        public abstract void Click();
    }
}
