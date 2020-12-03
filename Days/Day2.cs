using System.Linq;

namespace AdventOfCode2020
{
    internal static class Day2
    {
        internal static string Part1()
        {
            // Read Inputs
            var RawInput = Input.Read("Day2");

            //Solve Puzzle
            var CountValid = 0;
            foreach (string item in RawInput)
            {
                var X = item.Split("-");
                var Y = X[1].Split(" ");
                var MinOccurence = int.Parse(X[0]);
                var MaxOccurence = int.Parse(Y[0]);
                var TargetCharacater = Y[1].Replace(":", "").First();
                var Password = Y[2];
                var Occurences = Password.Count(f => f == TargetCharacater);

                if (MinOccurence <= Occurences & MaxOccurence >= Occurences)
                {
                    CountValid++;
                }
            }
            return "Valid occurences: " + CountValid.ToString();
        }


        internal static string Part2()
        {
            // Read Inputs
            var RawInput = Input.Read("Day2");

            //Solve Puzzle
            var CountValid = 0;
            foreach (string item in RawInput)
            {

                var X = item.Split("-");
                var Y = X[1].Split(" ");
                var FirstPosition = int.Parse(X[0]) - 1;
                var SecondPosition = int.Parse(Y[0]) - 1;
                var TargetCharacater = Y[1].Replace(":", "").First();
                var Password = Y[2];

                var z = 0;
                if (Password[FirstPosition] == TargetCharacater)
                {
                    z++;
                }
                if (Password[SecondPosition] == TargetCharacater)
                {
                    z++;
                }
                if (z == 1)
                {
                    CountValid++;
                }
            }
            return "Valid occurences: " + CountValid.ToString();
        }
    }
}
