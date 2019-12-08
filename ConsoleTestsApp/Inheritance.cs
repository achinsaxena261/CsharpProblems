using System;

namespace ConsoleTestsApp
{
    public class Inheritance
    {
        public void Test()
        {
            B obj = new B();
            obj.Test3();
        }
    }

    public class A
    {
        public int value1 = 10;
        public static int value2 = 5;
        private string name = "Base";
        protected string share = "Child";

        static A()
        {
            Console.WriteLine("Base static");
        }

        public A()
        {
            Console.WriteLine("{0} normal", name);
        }

        public static void Test1()
        {
            Console.WriteLine("Base Test static");
        }

        public virtual void Test2()
        {
            Console.WriteLine("Base Test");
        }

        public virtual void Test2(int x)
        {
            Console.WriteLine("Base Test {0}", x);
        }

        public void Test3()
        {
            Console.WriteLine("Base Test Protected");
        }
    }

    public class B: A
    {
        static B() {
            Console.WriteLine("Child Static");
        }

        public B()
        {
            Console.WriteLine("{0} normal", share);
        }

        public override void Test2()
        {
            Console.WriteLine("Child Test");
        }

        public void Test3()
        {
            Console.WriteLine("Child Test Hiding Base");
        }
    }
}
