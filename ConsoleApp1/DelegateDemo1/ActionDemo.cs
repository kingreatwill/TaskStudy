using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace DelegateDemo1
{
    public class ActionDemo
    {
        public void Test()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            Console.WriteLine("----------------- button1_Click 开始 主线程id为：{0}  --------------------------", Thread.CurrentThread.ManagedThreadId);

            Action<string> myFunc = this.TestThread;
            IAsyncResult asyncResult = null;
            //参数说明：前面几个参数都是方法的参数值，倒数第二个为异步调用的回调函数，倒数第一个为传给回调函数的参数
            for (int i = 0; i < 1; i++)
            {
                string name = string.Format("button1_Click{0}", i);
                asyncResult = myFunc.BeginInvoke(name, t =>
                {
                    Console.WriteLine("我是线程{0}的回调", Thread.CurrentThread.ManagedThreadId);
                    //用 t.AsyncState 来获取回调传进来的参数
                    Console.WriteLine("传进来的参数为：{0}", t.AsyncState);

                    //测试一下异步返回值的结果
                    Console.WriteLine("异步返回值的结果：{0}", t.Equals(asyncResult));
                }, "maru");
            }

            watch.Stop();
            Console.WriteLine("----------------- button1_Click 结束 主线程id为：{0}  总耗时：{1}--------------------------", Thread.CurrentThread.ManagedThreadId, watch.ElapsedMilliseconds);
        }

        private void TestThread(string a)
        {
            Console.WriteLine($"-----------{a}------------");
        }
    }
}