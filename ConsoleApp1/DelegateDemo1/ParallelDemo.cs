using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DelegateDemo1
{
    public class ParallelDemo
    {
        public void RunSimpleParallelTest()
        {
            ParallelLoopResult result = Parallel.For(0, 10, (int val) =>
            {
                Thread.Sleep(300);
                Console.WriteLine(string.Format("Index: {0}, TaskId: {1}, ThreadId: {2}.", val, Task.CurrentId, Thread.CurrentThread.ManagedThreadId));
            });
            Console.WriteLine(result.IsCompleted);
        }
    }
}