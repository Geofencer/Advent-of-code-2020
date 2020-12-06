using System;
using System.Linq;

namespace AdventOfCode2020
{
    internal static class Day6
    {
        internal static string Part1() //Onliner Roy-T style :p
        {
            var UniqueAnswers = Input.ReadAsText("Day6")
                .Split(new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Replace("\n", "")
                .Replace("\r", "")
                .ToCharArray()
                .Distinct()
                .Count())
                .Sum()
                .ToString();

            return "Unique answers: " + UniqueAnswers.ToString();
        }


        internal static string Part2() //Onliner Jori Huisman style :p
        {
            var AllPositive = (from Questionaire in Input.ReadAsText("Day6").Split(Environment.NewLine + Environment.NewLine)
                               let Respondents = Questionaire.Split(Environment.NewLine).Count()
                               let AllAnswers = Questionaire.Replace(Environment.NewLine, "")
                               let Answers = Questionaire.Replace(Environment.NewLine, "").ToCharArray().Distinct()
                               select (from Answer in Answers
                                       where Respondents == AllAnswers.Where(x => (x == Answer)).Count()
                                       select Answer).Count()).Sum();


            return "Questions everyone answered positive: " + AllPositive;
        }
    }
}
