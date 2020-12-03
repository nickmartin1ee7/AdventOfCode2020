/*
 * Advent of Code 2020
 * Author: Nick Martin
 * GitHub Repo: https://github.com/nickmartin1ee7/AdventOfCode2020
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using AdventOfCode.Library;
using static System.Console;

namespace AdventOfCode.Console
{
    public static class Program
    {
        public static void Main()
        {
            WriteLine(PrintAllSolutions());
            ReadKey();
        }

        private static string PrintAllSolutions()
        {
            var sb = new StringBuilder();

            foreach (var r in RunAllSolutions())
            {
                sb.Append(r);
            }

            return sb.ToString();
        }

        private static IEnumerable<string> RunAllSolutions() =>
            SolutionReflector.ReflectEverySolutionType().Select(type => Activator.CreateInstance(type)?.ToString());
    }
}
