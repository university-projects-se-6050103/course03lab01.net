using System;

namespace lab_01
{
    public class Task1
    {
        public static void Run()
        {
            Console.WriteLine("Please enter your first, last and middle name"
                              + " (separated by space) and press dot at the end.");

            var input = Console.ReadLine();

            Console.WriteLine($"Hello \n {input.Replace(".", "")}");
        }
    }
}