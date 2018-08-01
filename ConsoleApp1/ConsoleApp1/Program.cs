using System;

namespace ConsoleApp1
{
    internal class Program
    {
        //http://www.cnblogs.com/yaopengfei/p/8178039.html
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