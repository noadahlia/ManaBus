using System;

namespace dotNet5781_00_7799_9212
{
    partial class Program
    {
        static void Main(string[] args)
        {
            Welcome9212();
            Welcome7799();
            Console.ReadKey();
        }
        static partial void Welcome7799();
        private static void Welcome9212()
        {
            Console.WriteLine("Enter your name: ");
            string userName = Console.ReadLine();
            Console.WriteLine("{0}, welcome to my first console application", userName);
        }
    }
}
