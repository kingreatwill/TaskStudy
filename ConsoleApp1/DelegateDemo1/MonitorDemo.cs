using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace DelegateDemo1
{
    public class MonitorDemo
    {
        public void Test()
        {
            string obj = "1";
            bool lockTaken = false;
            Monitor.TryEnter(obj, 500, ref lockTaken);
            if (lockTaken)
            {
                try
                {
                    // acquired the lock
                    // synchronized region for obj
                }
                finally
                {
                    Monitor.Exit(obj);
                }
            }
            else
            {
                // didn't get the lock, do something else
            }
        }
    }
}