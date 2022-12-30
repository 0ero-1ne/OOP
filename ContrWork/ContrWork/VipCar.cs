namespace ContrWork
{
    class VipCar : SuperCar
    {
        public VipCar
        (
            int volume,
            string color,
            string model,
            string number
        ) : base(volume, color, model, number)
        {
            CarType = "Super";
        }

        public override string Go()
        {
            return "Ha! My driver is a president of Belarus!";
        }
    }
}
