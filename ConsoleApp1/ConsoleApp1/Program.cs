using System;

namespace ConsoleApp1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var test = new Task_i_plus();
            test.Test();

            Console.WriteLine($"input exit!");
            while (Console.ReadLine() != "exit")
            {
                Console.WriteLine($"{test.Get_i()}    --------------  {test.Get_ai()}");
            }
        }
    }
}