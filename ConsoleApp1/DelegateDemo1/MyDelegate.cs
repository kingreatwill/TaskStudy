using System;
using System.Collections.Generic;
using System.Text;

namespace DelegateDemo1
{
    public class MyDelegate
    {
        //1. 委托的声明
        public delegate void NoReturnNoPara();

        public delegate int WithReturnNoPara();

        public delegate void NoReturnWithPara(int id, string name);

        public delegate MyDelegate WithReturnWithPara(DateTime time);

        //2. 委托的使用(在show方法中调用)
        public void Show()
        {
            //以“有参无返回值委托”为例,介绍委托的各种用法
            //2.1 用法一
            {
                NoReturnWithPara methord = new NoReturnWithPara(this.Test1);
                methord.Invoke(1, "唐马儒1");
            }
            //2.2 用法二
            {
                NoReturnWithPara methord = this.Test1;
                methord.Invoke(2, "唐马儒2");
            }
            //2.3 用法三 DotNet 2.0 时代
            {
                NoReturnWithPara methord = new NoReturnWithPara
                    (
                    delegate (int id, string name)
                    {
                        Console.WriteLine("{0} {1}", id, name);
                    }
                    );
                methord.Invoke(3, "唐马儒3");
            }
            //2.4 用法四 DotNet 3.0 时代
            {
                NoReturnWithPara methord = new NoReturnWithPara
                    (
                        (int id, string name) =>
                        {
                            Console.WriteLine("{0} {1}", id, name);
                        }
                    );
                methord.Invoke(4, "唐马儒4");
            }
            //2.5 用法五 委托约束
            {
                NoReturnWithPara methord = new NoReturnWithPara
                    (
                        (id, name) =>
                        {
                            Console.WriteLine("{0} {1}", id, name);
                        }
                    );
                methord.Invoke(5, "唐马儒5");
            }
            //2.6 用法六 （如果方法体只有一行，可以去掉大括号和分号）
            {
                NoReturnWithPara methord = new NoReturnWithPara((id, name) => Console.WriteLine("{0} {1}", id, name));
                methord.Invoke(6, "唐马儒6");
            }
            //2.7 用法七
            {
                NoReturnWithPara methord = (id, name) => Console.WriteLine("{0} {1}", id, name);
                methord.Invoke(7, "唐马儒7");
                methord(7, "唐马儒7");
            }
            //2.8 用法八
            {
                //Func<int, bool> methord = (x) =>
                // {
                //     return x > 6;
                // };
                //等价于(原理，当只有一个参数的时候，可以省略参数的小括号，当方法体只有一行的时候，可以省略大括号和分号，即lambda形式)

                Func<int, bool> methord = x => x > 6;
                //等价于 bool methord(int x) => x > 6;
                Console.WriteLine(methord(8));
            }
        }

        private void Test1(int id, string name)
        {
            Console.WriteLine("{0} {1}", id, name);
        }

        private void Test2()
        {
            Console.WriteLine("DoNothing");
        }

        private void Test3()
        {
            Console.WriteLine("DoNothing");
        }
    }
}