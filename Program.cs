using System;

namespace AdventOfCode2020
{
    class Coder
    {
        private static readonly int Day = 6;

        static void Main()
        {
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
                case 4:
                    Console.WriteLine("Day 4: part 1");
                    Console.WriteLine(Day4.Part1());
                    Console.WriteLine("Day 4: part 2");
                    Console.WriteLine(Day4.Part2()); ;
                    break;
                case 5:
                    Console.WriteLine("Day 5: part 1");
                    Console.WriteLine(Day5.Part1());
                    Console.WriteLine("Day 5: part 2");
                    Console.WriteLine(Day5.Part2()); ;
                    break;
                case 6:
                    Console.WriteLine("Day 6: part 1");
                    Console.WriteLine(Day6.Part1());
                    Console.WriteLine("Day 6: part 2");
                    Console.WriteLine(Day6.Part2()); ;
                    break;
            }
        }
    }
}
