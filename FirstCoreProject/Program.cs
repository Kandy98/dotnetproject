using System;
using FirstLib;
using Humanizer;

namespace FirstCoreProject
{
    class Program
    {
        static void Main(string[] args)
        {

            System.Console.WriteLine("Enter 2 numbers:");
            int a = Convert.ToInt32(Console.ReadLine());
            int b = Convert.ToInt32(Console.ReadLine());
            int c = a+b;

            System.Console.WriteLine("Sum of {0} and {1} ins {2}", a,b,c);

            System.Console.WriteLine("Enter some amount:");
            int d = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine(d.ToWords());

            Console.WriteLine("Hello World!");
            System.Console.WriteLine("in am in .net project");

            var ob = new Addition();
            System.Console.WriteLine(ob.display(2,3));

        }
    }
}
