using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace LabFourteen
{
    class Program
    {
        static void Main()
        {
            //first task
            var allProcesses = Process.GetProcesses();
            foreach (var process in allProcesses)
            {
                try
                {
                    Console.WriteLine(
                        $"Process ID: {process.Id}, Process name: {process.ProcessName}, Process prior: " +
                        $"{process.BasePriority}, Start time: {process.StartTime}, " +
                        $"Volume of virtual memory (bytes): {process.VirtualMemorySize64}, Process time: {process.TotalProcessorTime}.");

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            //second task
            var domain = AppDomain.CurrentDomain;
            Console.WriteLine($"\nDomain name: {domain.FriendlyName}\nConfiguration details: {domain.SetupInformation}\n");
            var currentBuilds = AppDomain.CurrentDomain.GetAssemblies();
            Console.WriteLine("All build in application:");
            foreach (var build in currentBuilds)
            {
                Console.WriteLine(build.GetName().Name);
            }

            try
            {
                AppDomain newDomain = AppDomain.CreateDomain("New domain");
                newDomain.Load(@"D:\OOP\OOP\LabFourteen\LabFourteen\Task3.txt");
                AppDomain.Unload(newDomain);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //task 3
            var newThread = new Thread(ThreadInfo);
            newThread.Start(Thread.CurrentThread);
            Thread.Sleep(2000);
            Console.Write("Enter n: ");
            var userInput = int.Parse(Console.ReadLine());
            Console.WriteLine($"\nSimple numbers from 1 to {userInput}:");
            using (var newStream = new StreamWriter(@"D:\OOP\OOP\LabFourteen\LabFourteen\Task3.txt", false))
            {
                for (int i = 2; i < userInput; i++)
                {
                    if (IsPrime(i))
                    {
                        Console.Write($"{i} ");
                        newStream.Write($"{i} ");
                    }
                }
            }

            //task4
            Console.WriteLine("\nFirst even, than odd:");
            Task4.FirstEvenThanOdd(userInput);
            Console.WriteLine("\nEven-odd-even-odd:");
            Task4.EvenOddChangingEveryTime(userInput);
            Console.WriteLine();
            //task5
            int num = 5;
            TimerCallback tm = new TimerCallback(Multiplier);
            Timer timer = new Timer(tm, num, 200, 1000);
            Thread.Sleep(5000);
        }

        private static bool IsPrime(int number)
        {
            for (var i = 2; i < number; i++)
            {
                if (number % i == 0)
                    return false;
            }
            return true;
        }

        private static void ThreadInfo(object thread)
        {
            var currentThread = thread as Thread;
            Console.WriteLine($"\nThread name: {currentThread?.Name}");
            Console.WriteLine($"Thread status: {currentThread.ThreadState}");
            Console.WriteLine($"Thread prior: {currentThread.Priority}");
            Console.WriteLine($"Thread ID: {currentThread.ManagedThreadId}");
        }

        private static void Multiplier(object obj)
        {
            Console.WriteLine("Iteration");
        }
    }
}
