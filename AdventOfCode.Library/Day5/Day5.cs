using System.Collections.Generic;

namespace AdventOfCode.Library.Day5
{
    public class Day5 : BaseSolution
    {
        private IEnumerable<string> _rawData;

        public Day5()
        {
            _rawData = ReadLines(GetType());
        }

        public override string SilverStar()
        {
            var plane = new Plane(128, 8);

            var highestSeatId = 0;

            foreach (var boardingCode in _rawData)
            {
                var boardingPass = plane.ScanBoardingCodeToBoardingPass(boardingCode);
                var boardingPassSeatId = plane.Seats[boardingPass.Seat.Row, boardingPass.Seat.Column].SeatId;
                if (boardingPassSeatId > highestSeatId)
                    highestSeatId = boardingPassSeatId;
            }

            return $"{highestSeatId}";
        }

        public override string GoldStar()
        {
            foreach (var line in _rawData)
            {

            }

            return $"";
        }
    }

    public class Plane
    {
        /// <summary>
        /// 128 x 4 seating in a plane
        /// [X] ->|L|R|    |L|R|
        ///        ^
        ///       [Y]
        /// [LL] = [0,0]
        /// </summary>
        public Seat[,] Seats
        {
            get => new Seat[Rows, Columns];
        }

        public int Rows { get; }
        public int Columns { get; }

        public Plane(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
        }

        public BoardingPass ScanBoardingCodeToBoardingPass(string boardingCode) =>
            new BoardingPass(this, boardingCode);
    }

    public class Seat
    {
        public int Row { get; } // Y
        public int Column { get; } // X

        public Seat(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public int SeatId => Row * 8 + Column;
    }

    public class BoardingPass
    {
        private readonly Plane _plane;

        public Seat Seat { get; }

        public BoardingPass(Plane plane, string boardingCode)
        {
            _plane = plane;
            var row = ParseRows(boardingCode.Substring(0, 7));
            var column = ParseColumns(boardingCode.Substring(7, boardingCode.Length - 7));
            Seat = new Seat(row, column);
        }

        /// <summary>
        /// 0 is the front.
        /// </summary>
        /// <param name="rowCode"></param>
        /// <returns></returns>
        private int ParseRows(string rowCode) // 7 in length
        {
            var upper = _plane.Rows - 1;
            var lower = 0;

            for (var i = 0; i < rowCode.Length; i++)
            {
                var c = rowCode[i];
                int difference = upper - lower;
                switch (c)
                {
                    case 'F': // lower half
                        if (i == rowCode.Length - 1)
                            return lower;
                        upper -= difference / 2;
                        break;
                    case 'B': // upper half
                        if (i == rowCode.Length - 1)
                            return upper;
                        lower += difference / 2;
                        break;
                }
            }

            return 0;
        }

        private int ParseColumns(string columnCode) // 3 in length
        {
            var columns = 0;
            var upper = _plane.Columns - 1;
            var lower = 0;

            for (var i = 0; i < columnCode.Length; i++)
            {
                var c = columnCode[i];
                int difference = upper - lower;
                switch (c)
                {
                    case 'L': // lower half
                        if (i == columnCode.Length - 1)
                            return lower;
                        upper = difference;
                        break;
                    case 'R': // upper half
                        if (i == columnCode.Length - 1)
                            return upper;
                        lower += difference / 2;
                        break;
                }
            }

            return columns;
        }
    }
}