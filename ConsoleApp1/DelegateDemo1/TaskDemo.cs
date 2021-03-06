﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DelegateDemo1
{
    public class TaskDemo
    {
        //①：ContinueWhenAny：等价于Task的WhenAny+ContinueWith

        //②：ContinueWhenAll：等价于Task的WhenAll+ContinueWith

        //Task.Factory.StartNew比Task.run好
        // https://blogs.msdn.microsoft.com/pfxteam/2011/10/24/task-run-vs-task-factory-startnew/

        //Task实例化的方式，然后调用同步方法RunSynchronously ，进行线程启动。(PS: 类似委托开启线程，BeginInvoke是异步，而Invoke是同步)
        public void Test()
        {
            //TaskFactory
            Task t = new Task(() =>
            {
                Console.WriteLine($"------new Task----{Task.CurrentId}------{Thread.CurrentThread.ManagedThreadId}-------");
            });
            t.RunSynchronously();
        }

        public void TestStartNew1()
        {
            //TaskFactory
            new TaskFactory().StartNew(() =>
            {
                Console.WriteLine($"------new TaskFactory().StartNew----{Task.CurrentId}------{Thread.CurrentThread.ManagedThreadId}-------");
            });
        }

        public void TestStartNew2()
        {
            //TaskFactory
            Task.Factory.StartNew(() =>
            {
                Console.WriteLine($"------Task.Factory.StartNew---{Task.CurrentId}-------{Thread.CurrentThread.ManagedThreadId}-------");
            });
        }

        public void TestRun()
        {
            //TaskFactory
            Task.Run(() =>
            {
                Console.WriteLine($"------Task.Run-----{Task.CurrentId}-----{Thread.CurrentThread.ManagedThreadId}-------");
            });
        }

        public void TestThread()
        {
            //TaskFactory
            Thread SecondThread = new Thread(new ThreadStart(Print));

            SecondThread.Start();
        }

        public void TestThreadPool()
        {
            ThreadPool.QueueUserWorkItem((t) =>
            {
                Console.WriteLine($"-----------ThreadPool----------{Task.CurrentId}---{Thread.CurrentThread.ManagedThreadId}-------");
            });
        }

        private void Print()
        {
            Console.WriteLine($"------Thread---{Task.CurrentId}-------{Thread.CurrentThread.ManagedThreadId}-------");
        }
    }
}