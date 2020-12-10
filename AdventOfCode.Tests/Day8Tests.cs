using System;
using AdventOfCode.Library;
using AdventOfCode.Library.Day8;
using NUnit.Framework;

namespace AdventOfCode.Tests
{
    public class Day8Tests
    {
        private ISolution _solution;

        [SetUp]
        public void Setup()
        {
            _solution = new Day8();
        }

        [TestCase("1317")]
        public void SilverStarTest(string expected)
        {
            Assert.AreEqual(expected, _solution.SilverStar());
        }

        [TestCase("")]
        public void GoldStarTest(string expected)
        {
            Assert.AreEqual(expected, _solution.GoldStar());
        }

        [TestCase(5, false, "nop +0\r\nacc +1\r\njmp +4\r\nacc +3\r\njmp -3\r\nacc -99\r\nacc +1\r\njmp -4\r\nacc +6")]
        [TestCase(8, true, "nop +0\r\nacc +1\r\njmp +4\r\nacc +3\r\njmp -3\r\nacc -99\r\nacc +1\r\njmp -4\r\nacc +6")]
        public void ComputerTest(int expected, bool fixRecursion, string programData)
        {
            var lmc = new Computer(fixRecursion);
            lmc.RunProgram(programData.Split(Environment.NewLine));
            Assert.AreEqual(expected, lmc.Accumulator);
        }
    }
}
