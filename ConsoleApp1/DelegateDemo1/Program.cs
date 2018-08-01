using System;
using System.Threading;

namespace DelegateDemo1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine($"-----Main-----------{Thread.CurrentThread.ManagedThreadId}-------");

            for (var i = 0; i < 10; i++)
                new TaskDemo().Test();

            for (var i = 0; i < 10; i++)
                new TaskDemo().TestStartNew1();
            for (var i = 0; i < 10; i++)
                new TaskDemo().TestStartNew2();
            for (var i = 0; i < 10; i++)
                new TaskDemo().TestRun();

            for (var i = 0; i < 10; i++)
                new TaskDemo().TestThread();

            for (var i = 0; i < 10; i++)
                new TaskDemo().TestThreadPool();

            Console.WriteLine($"------Main----------{Thread.CurrentThread.ManagedThreadId}-------");
            Console.ReadLine();
        }
    }
}