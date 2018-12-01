using Solutions;
using System;

namespace AdventConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Day1 day1 = new Day1();
            Console.WriteLine($"Day 1, part 1:\t{day1.Part1()}");
            Console.WriteLine($"Day 1, part 2:\t{day1.Part2()}");

            Console.ReadLine();
        }
    }
}
