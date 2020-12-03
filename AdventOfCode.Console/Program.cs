/*
 * Advent of Code 2020
 * Author: Nick Martin
 * GitHub Repo: https://github.com/nickmartin1ee7/advent-of-code
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
