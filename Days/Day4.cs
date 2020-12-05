using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020
{
    internal static class Day4
    {
        // Read Inputs
        private static string PassportFile = Input.ReadAsText("Day4");

        internal static string Part1()
        {
            // Solve Puzzle
            var PassportLists = PassportFile
                .Split(new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Split(new string[] { " ", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries));

            var PassportDicts = from x in PassportLists
                                select (from y in x
                                        select new
                                        {
                                            Key = y.Split(':')[0],
                                            Value = y.Split(':')[1]
                                        });

            var ValidPasports = from x in PassportDicts
                                where (x.Count() == 7 && x.Where(y => y.Key == "cid").Any() == false) ^ x.Count() == 8
                                select x;

            return "Valid Passwords: " + ValidPasports.Count();
        }

        internal static string Part2()
        {
            // Solve Puzzle
            var PassportLists = PassportFile
                .Split(new string[] { Environment.NewLine + Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Split(new string[] { " ", Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries));

            var PassportDicts = from x in PassportLists
                                select (from y in x
                                        select new
                                        {
                                            Key = y.Split(':')[0],
                                            Value = y.Split(':')[1],
                                            Validity = CheckValidity(y.Split(':')[0], y.Split(':')[1])
                                        });

            var ValidPasports = from x in PassportDicts
                                where ((x.Count() == 7 && x.Where(y => y.Key == "cid").Any() == false) ^ x.Count() == 8) && x.Where(y => !y.Validity).Any() == false
                                select x;

            var ValidPasports2 = from x in PassportDicts
                                 where x.Count() == 7 && !(from xx in x where xx.Key == "cid" select xx).Any() | x.Count() == 8 && (from xx in x where !xx.Validity select xx).Any()
                                 select x;

            return "Valid Passwords: " + ValidPasports.Count();
        }

        private static bool CheckValidity(string Key, string Value)
        {
            var Valid = true;
            switch (Key)
            {
                case "byr":
                    if (int.Parse(Value) < 1920 | int.Parse(Value) > 2002)
                    {
                        Valid = false;
                    }
                    break;
                case "iyr":
                    if (int.Parse(Value) < 2010 | int.Parse(Value) > 2020)
                    {
                        Valid = false;
                    }
                    break;
                case "eyr":
                    if (int.Parse(Value) < 2020 | int.Parse(Value) > 2030)
                    {
                        Valid = false;
                    }
                    break;
                case "hgt": //ok
                    var HGTPattern = new Regex(@"^([0-9]{1,3})([a-z]{2})$");
                    var HGTMatch = HGTPattern.Match(Value);

                    if (!HGTMatch.Success)
                    {
                        Valid = false;
                    }

                    if (RemoveDigits(Value).Contains("cm"))
                    {
                        if (int.Parse(RemoveNonDigits(Value)) < 150 | int.Parse(RemoveNonDigits(Value)) > 193)
                        {
                            Valid = false;
                        }
                    }

                    if (RemoveDigits(Value).Contains("in"))
                    {
                        if (int.Parse(RemoveNonDigits(Value)) < 59 | int.Parse(RemoveNonDigits(Value)) > 76)
                        {
                            Valid = false;
                        }
                    }
                    break;
                case "hcl":
                    var HCLPattern = new Regex(@"^#[a-f0-9]{6}$");
                    var HCLMatch = HCLPattern.Match(Value);

                    if (!HCLMatch.Success)
                    {
                        Valid = false;
                    }
                    break;

                case "ecl":
                    var Eyecolors = new List<string>() { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };

                    if (!Eyecolors.Contains(Value))
                    {
                        Valid = false;
                    }
                    break;
                case "pid":
                    var PIDPattern = new Regex(@"^[0-9]{9}$");
                    var PIDMatch = PIDPattern.Match(Value);

                    if (!PIDMatch.Success)
                    {
                        Valid = false;
                    }
                    break;
            }
            return Valid;
        }

        private static string RemoveNonDigits(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;
            string cleaned = new string(s.Where(char.IsDigit).ToArray());
            return cleaned;
        }

        private static string RemoveDigits(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;
            string cleaned = new string(s.Where(char.IsLetter).ToArray());
            return cleaned;
        }
    }
}
