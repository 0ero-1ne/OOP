using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace LabFifteen
{
    class Program
    {
        static void Main()
        {
            //1 задание
            var task = new Task(Vector);

            Console.WriteLine($"Номер задачи: {task.Id}\nСтатус: {task.Status}");

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            task.Start();
            Console.WriteLine($"Номер задачи: {task.Id}\nСтатус: {task.Status}");
            task.Wait();
            stopwatch.Stop();
            Console.WriteLine($"Номер задачи: {task.Id}\nСтатус: {task.Status}");
            Console.WriteLine($"Время выполнения задачи в миллисекундах: {stopwatch.ElapsedMilliseconds} ");

            //2 задание
            var cancellationToken = new CancellationTokenSource();

            Task second = Task.Factory.StartNew(VectorWithCancellation, cancellationToken.Token, cancellationToken.Token);
            Console.WriteLine($"Номер задачи: {task.Id}\nСтатус: {task.Status}");
            try
            {
                cancellationToken.Cancel();
                second.Wait();
            }
            catch (AggregateException e)
            {
                Console.WriteLine($"Задача остановлена. Текст ошибки: {e.Message}");
            }

            //3 задание
            var firstSquare = new Task<double>(() => Math.Pow(2, 2));
            var secondSquare = new Task<double>(() => Math.Pow(3, 2));
            var thirdSquare = new Task<double>(() => Math.Pow(4, 2));

            firstSquare.Start();
            secondSquare.Start();
            thirdSquare.Start();
            thirdSquare.Wait();
            firstSquare.Wait();
            secondSquare.Wait();

            var overallSquare = new Task<double>(() => firstSquare.Result + secondSquare.Result + thirdSquare.Result);
            overallSquare.Start();
            Console.WriteLine($"Сумма площадей квадратов: {overallSquare.Result}\n");

            //4 задание
            var firstTask = new Task(() => Console.Write("Выполняется первое задание..."));
            var continueWithTask = firstTask.ContinueWith(s => Console.Write("Теперь второе задание."));
            firstTask.Start();

            var firstTaskForAwaiter = new Task(() => Console.Write("\nВыполняется первое задание с GetAwaiter..."));

            var secondTaskForAwaiter = firstTaskForAwaiter.GetAwaiter();
            secondTaskForAwaiter.OnCompleted(() =>
            {
                secondTaskForAwaiter.GetResult();
                Console.Write("Теперь второе.\n");
            });
            firstTaskForAwaiter.Start();
            firstTaskForAwaiter.Wait();

            //задание 5
            var array1 = new int[10000000];
            var array2 = new int[10000000];
            var array3 = new int[10000000];

            var stopwatchForFifthTask = new Stopwatch();

            stopwatchForFifthTask.Start();
            Parallel.For(0, 10000000, CreatingArrayElements);
            stopwatchForFifthTask.Stop();
            Console.WriteLine($"\n\nВремя выполнения распараллеленного for: {stopwatchForFifthTask.ElapsedMilliseconds} мс");

            stopwatchForFifthTask.Restart();

            for (var i = 0; i < 10000000; i++)
            {
                array1[i] = 1;
                array2[i] = 1;
                array3[i] = 1;
            }

            stopwatchForFifthTask.Stop();
            Console.WriteLine($"Время выполнения обычного for: {stopwatchForFifthTask.ElapsedMilliseconds} мс");


            stopwatchForFifthTask.Restart();
            Parallel.ForEach(array1, SumOfElements);
            stopwatchForFifthTask.Stop();
            Console.WriteLine($"Время выполнения распараллеленного foreach {stopwatchForFifthTask.ElapsedMilliseconds} мс");

            stopwatchForFifthTask.Restart();

            foreach (int item in array1)
            {
            }

            stopwatchForFifthTask.Stop();
            Console.WriteLine($"Время выполнения обычного foreach в миллисекундах: {stopwatchForFifthTask.ElapsedMilliseconds}\n");

            void CreatingArrayElements(int x)
            {
                array1[x] = 2;
                array2[x] = 2;
                array3[x] = 2;
            }

            void SumOfElements(int item)
            {
            }

            //6 задание
            var firstArray = new int[10000000];
            var secondArray = new int[10000000];
            var thirdArray = new int[10000000];


            Parallel.Invoke
            (

                () =>
                {
                    for (var i = 0; i < firstArray.Length; i++)
                    {
                        firstArray[i] = i;
                    }
                    Console.WriteLine("Parallel invoke: array 1");
                },

                () =>
                {
                    for (var i = 0; i < secondArray.Length; i++)
                    {
                        secondArray[i] = i;
                    }
                    Console.WriteLine("Parallel invoke: array 2");
                },

                () =>
                {
                    for (var i = 0; i < thirdArray.Length; i++)
                    {
                        thirdArray[i] = i;
                    }
                    Console.WriteLine("Parallel invoke: array 3");
                }
            );

            //Задание 7
            Console.WriteLine();
            BlockingCollection<string> blockingCollection = new BlockingCollection<string>(5);

            var sellers = new[]
            {

                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(100);
                        blockingCollection.Add("Микроволновка");
                    }
                }),

                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(200);
                        blockingCollection.Add("Миксер");
                    }
                }),

                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(300);
                        blockingCollection.Add("Стиралька");
                    }
                }),

                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(400);
                        blockingCollection.Add("Микроволновка");
                    }
                }),

                new Task(() =>
                {
                    while (true)
                    {
                        Thread.Sleep(500);
                        blockingCollection.Add("Пылесос");
                    }
                })
            };

            foreach (var i in sellers)
            {
                if (i.Status != TaskStatus.Running)
                    i.Start();
            }

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Количество товара на складе: {blockingCollection.Count}");
                Thread.Sleep(600);
                Thread thr = new Thread(Client);
                thr.Start();
            }

            void Client()
            {

                if (blockingCollection.Count == 0)
                {
                    Console.WriteLine("Посетитель ничего не купил");
                    return;
                }

                Console.WriteLine($"Посетитель купил {blockingCollection.Take()}");
            }

            //8 задание
            Thread.Sleep(500);
            Console.WriteLine();

            int Fibonacci(int n)
            {
                if (n == 0 || n == 1)
                {
                    return n;
                }
                return Fibonacci(n - 1) + Fibonacci(n - 2);
            }

            async void FibonacciAsync(int n)
            {
                Console.WriteLine($"Начат подсчет {n}-го числа Фибоначчи");
                var result = Task<int>.Factory.StartNew(() => Fibonacci(n));
                int value = await result;
                Console.WriteLine($"Результат: {value}");
            }

            FibonacciAsync(7);
        }


        //task1
        private static void Vector()
        {
            int[] vector = new int[100000];
            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] = new Random().Next(1000);
            }

            Console.Write("Enter the n: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < vector.Length; i++)
            {
                vector[i] *= n;
            }

            return;
        }

        //task2
        private static void VectorWithCancellation(object obj)
        {
            var token = (CancellationToken)obj;
            int[] vector = new int[100000];
            for (int i = 0; i < vector.Length; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Запрос отмены");
                    token.ThrowIfCancellationRequested();
                    return;
                }
                vector[i] = new Random().Next(1000);
            }

            if (token.IsCancellationRequested)
            {
                Console.WriteLine("Запрос отмены");
                token.ThrowIfCancellationRequested();
                return;
            }

            Console.Write("Enter the n: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < vector.Length; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Запрос отмены");
                    token.ThrowIfCancellationRequested();
                    return;
                }
                vector[i] *= n;
            }

            return;
        }
    }
}
