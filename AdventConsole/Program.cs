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
            
            Day2 day2 = new Day2();
            Console.WriteLine($"Day 2, part 1:\t{day2.Part1()}");
            Console.WriteLine($"Day 2, part 2:\t{day2.Part2()}");

            Day3 day3 = new Day3();
            Console.WriteLine($"Day 3, part 1:\t{day3.Part1()}");
            Console.WriteLine($"Day 3, part 1:\t{day3.Part2()}");

            Console.ReadLine();
        }
    }
}
