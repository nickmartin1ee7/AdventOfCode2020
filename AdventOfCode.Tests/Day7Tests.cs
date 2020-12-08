using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode.Library;
using AdventOfCode.Library.Day7;
using NUnit.Framework;

namespace AdventOfCode.Tests
{
    public class Day7Tests
    {
        private ISolution _solution;

        [SetUp]
        public void Setup()
        {
            _solution = new Day7();
        }

        [TestCase("")]
        public void SilverStarTest(string expected)
        {
            Assert.AreEqual(expected, _solution.SilverStar());
        }

        [TestCase("")]
        public void GoldStarTest(string expected)
        {
            Assert.AreEqual(expected, _solution.GoldStar());
        }
    }
}
