using System.Numerics;

namespace AdventOfCode2020
{
    internal static class Day3
    {
        internal static string Part1()
        {
            // Solve Puzzle
            return "Trees encountered: " + TreeCounter(3, 1);
        }

        internal static string Part2()
        {
            //Solve Puzzle
            var Trees = BigInteger.Multiply(TreeCounter(1, 1), TreeCounter(3, 1));
            Trees = BigInteger.Multiply(Trees, TreeCounter(5, 1));
            Trees = BigInteger.Multiply(Trees, TreeCounter(7, 1));
            Trees = BigInteger.Multiply(Trees, TreeCounter(1, 2));
            return "Trees encountered: " + Trees;
        }

        private static int TreeCounter(int LonStep, int LatStep)
        {
            // Read Inputs
            var TreeLines = Input.Read("Day3");
            var PatternLength = 31;
            var TreeCount = 0;

            // Calculate trees encountered
            for (int i = 0; i * LatStep < TreeLines.Length; i++)
            {
                var Lattitude = i * LatStep;
                var HorizontalDistance = i * LonStep;
                var Longitude = HorizontalDistance % PatternLength; //var Longitude = (int)(HorizontalDistance - (Math.Floor(new decimal(HorizontalDistance / PatternLength)) * PatternLength));

                if (TreeLines[Lattitude][Longitude] == '#')
                {
                    TreeCount++;
                }
            }
            return TreeCount;
        }
    }
}
