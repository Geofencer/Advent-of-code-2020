using System;

namespace AdventOfCode2020
{
    class Coder
    {
        private static readonly int Day = 3;

        static void Main()
        {
            Console.WriteLine("Welcome to advent of code 2020");
            Console.WriteLine("Today is day: " + Day.ToString());

            switch (Day)
            {
                case 1:
                    Console.WriteLine("Day 1: part 1");
                    Console.WriteLine(Day1.Part1());
                    Console.WriteLine("Day 1: part 2");
                    Console.WriteLine(Day1.Part2());
                    break;
                case 2:
                    Console.WriteLine("Day 2: part 1");
                    Console.WriteLine(Day2.Part1());
                    Console.WriteLine("Day 2: part 2");
                    Console.WriteLine(Day2.Part2()); ;
                    break;
                case 3:
                    Console.WriteLine("Day 3: part 1");
                    Console.WriteLine(Day3.Part1());
                    Console.WriteLine("Day 3: part 2");
                    Console.WriteLine(Day3.Part2()); ;
                    break;
            }
        }
    }
}
