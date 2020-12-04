using AdventOfCode.Library;
using AdventOfCode.Library.Day3;
using AdventOfCode.Library.Day4;
using NUnit.Framework;

namespace AdventOfCode.Tests
{
    public class Day4Tests
    {
        private ISolution _solution;

        [SetUp]
        public void Setup()
        {
            _solution = new Day4();
        }

        [TestCase("202")]
        public void SilverStarTest(string expected)
        {
            Assert.AreEqual(expected, _solution.SilverStar());
        }

        [TestCase("137")]
        public void GoldStarTest(string expected)
        {
            Assert.AreEqual(expected, _solution.GoldStar());
        }
        
        [TestCase(true, "ecl:gry pid:860033327 eyr:2020 hcl:#fffffd\r\nbyr:1937 iyr:2017 cid:147 hgt:183cm")]
        [TestCase(true, "hcl:#ae17e1 iyr:2013\r\neyr:2024\r\necl:brn pid:760753108 byr:1931\r\nhgt:179cm")]
        [TestCase(false, "iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884\r\nhcl:#cfa07d byr:1929")]
        [TestCase(false, "hcl:#cfa07d eyr:2025 pid:166559648\r\niyr:2011 ecl:brn hgt:59in")]
        public void SilverPassportValidateTest(bool expected, string input)
        {
            Assert.AreEqual(expected, Day4.ParseSilverPassport(input).Validate());
        }
        
        [TestCase(true, "hgt:159cm\r\npid:561068005 eyr:2025 iyr:2017 cid:139 ecl:blu hcl:#ceb3a1\r\nbyr:1940")]
        [TestCase(true, "pid:087499704 hgt:74in ecl:grn iyr:2012 eyr:2030 byr:1980\r\nhcl:#623a2f")]
        [TestCase(true, "eyr:2029 ecl:blu cid:129 byr:1989\r\niyr:2014 pid:896056539 hcl:#a97842 hgt:165cm")]
        [TestCase(true, "hcl:#888785\r\nhgt:164cm byr:2001 iyr:2015 cid:88\r\npid:545766238 ecl:hzl\r\neyr:2022")]
        [TestCase(true, "iyr:2010 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719")]
        [TestCase(false, "iyr:2010 hgt:158cm hcl:#b6652aa ecl:blu byr:1944 eyr:2021 pid:093154719")]
        [TestCase(false, "iyr:2010 hgt:158cm hcl:#b6652aa ecl:blu byr:1944 eyr:2021 pid:093154719")]
        [TestCase(false, "iyr:2010 hgt:158cm hcl:b6652a ecl:blu byr:1944 eyr:2021 pid:093154719")]
        [TestCase(false, "iyr:2010 hgt:158cm hcl:b6652a ecl:blu byr:1944 eyr:2021 pid:09315471a")]
        [TestCase(false, "iyr:2010 hgt:158cm hcl:#b6652aa ecl:blu byr:1944 eyr:2021 pid:0931547")]
        [TestCase(false, "iyr:1970 hgt:158cm hcl:#b6652a ecl:blu byr:1944 eyr:2021 pid:093154719")]
        [TestCase(false, "iyr:2014\r\nbyr:1986 pid:960679613 eyr:2025 ecl:hzl")]
        [TestCase(false, "eyr:1972 cid:100\r\nhcl:#18171d ecl:amb hgt:170 pid:186cm iyr:2018 byr:1926")]
        [TestCase(false, "iyr:2019\r\nhcl:#602927 eyr:1967 hgt:170cm\r\necl:grn pid:012533040 byr:1946")]
        [TestCase(false, "hcl:dab227 iyr:2012\r\necl:brn hgt:182cm pid:021572410 eyr:2020 byr:1992 cid:277")]
        [TestCase(false, "hgt:59cm ecl:zzz\r\neyr:2038 hcl:74454a iyr:2023\r\npid:3556412378 byr:2007")]
        [TestCase(false, "pid:08749970444 hgt:74in ecl:grn iyr:2012 eyr:2030 byr:1980\r\nhcl:#623a2f")]
        [TestCase(false, "pid:087499 hgt:74in ecl:grn iyr:2012 eyr:2030 byr:1980\r\nhcl:#623a2f")]
        public void GoldPassportValidateTest(bool expected, string input)
        {
            Assert.AreEqual(expected, Day4.ParseGoldPassport(input).Validate());
        }
    }
}