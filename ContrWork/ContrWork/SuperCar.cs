namespace ContrWork
{
    class SuperCar : Car
    {
        public string CarType { get; set; }
        public SuperCar
        (
            int volume,
            string color,
            string model,
            string number
        ) : base(volume, color, model, number)
        {
            CarType = "Super";
        }

        public virtual string Go()
        {
            return "I am a super car, and I have a driver!";
        }
    }
}
