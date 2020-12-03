using System.Linq;

namespace AdventOfCode2020
{
    internal static class Day1
    {
        internal static string Part1()
        {
            // Read Inputs
            var RawInput = Input.Read("Day1");
            var Numbers = RawInput.Select(int.Parse).ToList();

            //Solve Puzzle
            foreach (int Entry1 in Numbers)
            {
                foreach (int Entry2 in Numbers)
                {
                    if (Entry1 + Entry2 == 2020)
                    {
                        return
                            @"Entry1: " + Entry1 + "\n" +
                            "Entry2: " + Entry2 + "\n" +
                            "Multiplied: " + Entry1 * Entry2;
                    }
                }
            }
            return "No solution";
        }

        public static string Part2()
        {
            // Read Inputs
            var RawInput = Input.Read("Day1");
            var Numbers = RawInput.Select(int.Parse).ToList();

            //Solve Puzzle
            foreach (int Entry1 in Numbers)
            {
                foreach (int Entry2 in Numbers)
                {
                    foreach (int Entry3 in Numbers)
                    {
                        if (Entry1 + Entry2 + Entry3 == 2020)
                        {
                            return
                            @"Entry1: " + Entry1 + "\n" +
                            "Entry2: " + Entry2 + "\n" +
                            "Entry3: " + Entry3 + "\n" +
                            "Multiplied: " + Entry1 * Entry2 * Entry3;
                        }
                    }
                }
            }
            return "No solution";
        }
    }
}
