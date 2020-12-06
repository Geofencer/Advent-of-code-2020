using System;
using System.Linq;

namespace AdventOfCode2020
{
    internal static class Day6
    {
        internal static string Part1()
        {
            // Read Inputs
            var Questions = Input.ReadAsText("Day6");

            //Solve Puzzle
            var UniqueAnswers = Questions
                .Split(new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Replace("\n", "").Replace("\r", "").ToCharArray().Distinct().Count()).Sum();

            return "Unique answers: " + UniqueAnswers.ToString();
        }


        internal static string Part2()
        {
            // Read Inputs
            var Questionaires = Input.ReadAsText("Day6");

            //Solve Puzzle
            var AllPositive = from Questionaire in Questionaires.Split(Environment.NewLine + Environment.NewLine)
                              let Respondents = Questionaire.Split(Environment.NewLine).Count()
                              let AllAnswers = Questionaire.Replace(Environment.NewLine, "")
                              let Answers = Questionaire.Replace(Environment.NewLine, "").ToCharArray().Distinct()
                              select (from Answer in Answers
                                      where Respondents == AllAnswers.Where(x => (x == Answer)).Count()
                                      select Answer).Count();

            var AllPositiveSum = AllPositive.Sum();

            return "Questions everyone answered positive: " + AllPositiveSum;
        }
    }
}
