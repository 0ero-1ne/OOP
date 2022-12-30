using System;

namespace ContrWork2
{
    class Match
    {
        public event Screams Gol;

        public Match() { }

        public void MakePoint()
        {
            Console.WriteLine("И мы забиваем гол!");
            Gol?.Invoke();
        }
    }
}
