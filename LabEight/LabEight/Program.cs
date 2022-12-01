using System;

namespace LabEight
{
    public delegate void CompressHandler();
    public delegate void MoveHandler(string destination);

    class Program
    {
        static void Main(string[] args)
        {
            User user1 = new User("Dmitry", "Volikov", "Belarus", 18);

            CompressHandler ch = new CompressHandler(Meth);

            user1.Moved += (string destination) => Console.WriteLine("Moved to " + destination.ToString());
            user1.Compressed += () => Console.WriteLine("Compressed");

            Action<string, string, string> action = User.ReplaceString;
            action += User.DeleteString;

            Predicate<string> predicate = User.IsPalyndrom;

            action.Invoke("Test string", "str", "ptr");
            Console.WriteLine(predicate.Invoke("abbab"));

            user1.MoveObject("Russia");
            Console.WriteLine(user1.Country);
        }

        public static void Meth()
        {
            Console.WriteLine("Hello");
        }
    }
}
