using System;

namespace FirstLib
{
    public class Addition
    {
        public String display(int a, int b) {
            System.Console.WriteLine("im in addition");
            // System.Console.WriteLine("Enter a number");
            // int a = Convert.ToInt32(Console.ReadLine());

            // System.Console.WriteLine("Enter another number");
            // int b = Convert.ToInt32(Console.ReadLine());

            int sum = a+b;

            if(sum>10)
                return "greater than 10";

            else 
                return "less than 10";    
        }
    }
}
