using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Library.Day4
{
    public class Day4 : BaseSolution
    {
        private string _rawData;

        public Day4()
        {
            _rawData = File.ReadAllText(Path.Combine($"{GetType().Name}", "data.txt"));
        }
        
        public override string SilverStar()
        {
            var data = ProcessData(_rawData);

            string silverResult = SolveSilverStar(data);

            return $"{silverResult }";
        }

        public override string GoldStar()
        {
            var data = ProcessData(_rawData);

            string goldResult = SolveGoldStar(data);

            return $"{goldResult}";
        }
        
        #region Methods

        private List<Passport> ProcessData(string rawData)
        {
            var passports = new List<Passport>();
            
            passports.AddRange(ParsePassports(rawData.Split("\n\n")));

            return passports;
        }

        private string SolveSilverStar(object data)
        {
            throw new System.NotImplementedException();
        }
        
        private string SolveGoldStar(object data)
        {
            throw new System.NotImplementedException();
        }

        private IEnumerable<Passport> ParsePassports(string[] split)
        {
            throw new System.NotImplementedException();
        }
        
        #endregion
    }

    #region Classes

    internal class Passport
    {
        public short BirthYear { get; }
        public short IssueYear { get; }
        public short ExpirationYear { get; }
        public string Height { get; }
        public string HairColor { get; }
        public string EyeColor { get; }
        public ulong PassportId { get; }
        public short CountryId { get; }

        public Passport(short byr, short iyr, short eyr, string hgt, string hcl, string ecl, ulong pid, short cid)
        {
            BirthYear = byr;
            IssueYear = iyr;
            ExpirationYear = eyr;
            Height = hgt;
            HairColor = hcl;
            EyeColor = ecl;
            PassportId = pid;
            CountryId = cid;
        }
    }

    #endregion
}