/*
 * Advent of Code 2020
 * Author: Nick Martin
 * GitHub Repo: https://github.com/nickmartin1ee7/AdventOfCode2020
 */

using System.Text;
using static System.Console;

namespace AdventOfCode.Console
{
    public static class Program
    {
        public static void Main()
        {
            WriteLine(RunAllSolutions());
            ReadKey();
        }

        private static string RunAllSolutions()
        {
            var sb = new StringBuilder();

            sb.Append(new Day1());
            sb.Append(new Day2());
            sb.Append(new Day3());

            return sb.ToString();
        }
    }
}
