using AdventOfCode.Library;
using AdventOfCode.Library.Day5;
using NUnit.Framework;

namespace AdventOfCode.Tests
{
    public class Day5Tests
    {
        private ISolution _solution;

        [SetUp]
        public void Setup()
        {
            _solution = new Day5();
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

        [TestCase(44, 5, 357, "FBFBBFFRLR")]
        [TestCase(70, 7, 567, "BFFFBBFRRR")]
        [TestCase(14, 7, 119, "FFFBBBFRRR")]
        [TestCase(102, 4, 820, "BBFFBBFRLL")]
        public void SeatFromBoardingPassTest(int row, int column, int seatId, string boardingCode)
        {
            var expectedSeat = new Seat(row, column);
            var plane = new Plane(128,8);
            var boardingPass = plane.ScanBoardingCodeToBoardingPass(boardingCode);
            Assert.AreEqual(expectedSeat.SeatId, boardingPass.Seat.SeatId);
        }
    }
}