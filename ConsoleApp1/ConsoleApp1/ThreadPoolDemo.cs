using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{
    public class ThreadPoolDemo
    {
        public void Test()
        {
            ThreadPool.QueueUserWorkItem((t) =>
            {
                Console.WriteLine($"-----------{t}-----{Thread.CurrentThread.ManagedThreadId}-------");
            });
        }
    }
}