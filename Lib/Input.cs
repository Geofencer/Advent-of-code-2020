using System;
using System.IO;

namespace AdventOfCode2020
{
    internal static class Input
    {
        internal static string[] Read(string FileName)
        {
            try
            {
                var InputFile = $"{AppDomain.CurrentDomain.BaseDirectory}/../../../input/{FileName}.txt";
                return File.ReadAllLines(InputFile);
            }
            catch (Exception Exception)
            {
                throw new Exception("Failed reading input file: " + FileName, Exception);
            }
        }

        internal static string ReadAsText(string FileName)
        {
            try
            {
                var InputFile = $"{AppDomain.CurrentDomain.BaseDirectory}/../../../input/{FileName}.txt";
                return File.ReadAllText(InputFile);
            }
            catch (Exception Exception)
            {
                throw new Exception("Failed reading input file: " + FileName, Exception);
            }
        }
    }
}
