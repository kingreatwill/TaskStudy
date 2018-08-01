using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Task_i_plus
    {
        private static int i = 0;

        private static string
            loc = "0";

        private AtomicInteger ai = new AtomicInteger(0);

        public int Get_i()
        {
            return i;
        }

        public int Get_ai()
        {
            return ai.Value;
        }

        public void Test()
        {
            for (var f = 0; f < 1000000; f++)
            {
                Task.Run(() =>
                {
                    //lock (loc)
                    i++;// i++线程不安全的
                    ai.Add(2);//.Increment();
                });
            }
        }
    }
}