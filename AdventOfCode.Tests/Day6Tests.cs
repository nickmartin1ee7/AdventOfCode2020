using System;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode.Library;
using AdventOfCode.Library.Day6;
using NUnit.Framework;
using Group = AdventOfCode.Library.Day6.Group;

namespace AdventOfCode.Tests
{
    public class Day6Tests
    {
        private ISolution _solution;

        [SetUp]
        public void Setup()
        {
            _solution = new Day6();
        }

        [TestCase("6530")]
        public void SilverStarTest(string expected)
        {
            Assert.AreEqual(expected, _solution.SilverStar());
        }

        [TestCase("3323")]
        public void GoldStarTest(string expected)
        {
            Assert.AreEqual(expected, _solution.GoldStar());
        }

        [TestCase("11", "abc\r\n\r\na\r\nb\r\nc\r\n\r\nab\r\nac\r\n\r\na\r\na\r\na\r\na\r\n\r\nb")]
        public void GroupAnyAnswersTest(string expected, string data)
        {
            var groupsData = data.Split(Environment.NewLine + Environment.NewLine);
            int total = 0;
            foreach (var groupData in groupsData)
            {
                total += new Group(groupData.Trim().Split(Environment.NewLine)).Answers.Keys.Count;
            }
            Assert.AreEqual(expected, $"{total}");
        }

        [TestCase("6", "abc\r\n\r\na\r\nb\r\nc\r\n\r\nab\r\nac\r\n\r\na\r\na\r\na\r\na\r\n\r\nb")]
        public void GroupInAgreementQuestionsTest(string expected, string data)
        {
            var groupsData = data.Split(Environment.NewLine + Environment.NewLine);
            int total = 0;
            foreach (var groupData in groupsData)
            {
                var group = new Group(groupData.Trim().Split(Environment.NewLine));
                total += group.InAgreementQuestions;
            }

            Assert.AreEqual(expected, $"{total}");
        }
    }
}