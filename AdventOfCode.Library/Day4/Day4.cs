using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Library.Day4
{
    public class Day4 : BaseSolution
    {
        private readonly string _rawData;

        public Day4()
        {
            _rawData = File.ReadAllText(Path.Combine($"{GetType().Name}", "data.txt"));
        }
        
        public override string SilverStar()
        {
            var data = ProcessData(StarType.Silver, _rawData);

            var silverResult = Solve(data);

            return $"{silverResult}";
        }

        public override string GoldStar()
        {
            var data = ProcessData(StarType.Gold, _rawData);

            var goldResult = Solve(data);

            return $"{goldResult}";
        }
        
        #region Methods

        private IEnumerable<Passport> ProcessData(StarType starType, string rawData)
        {
            var passports = new List<Passport>();
            var splitData = rawData.Split($"{Environment.NewLine}{Environment.NewLine}");
            
            foreach (var entity in splitData)
            {
                switch (starType)
                {
                    case StarType.Silver:
                        passports.Add(ParseSilverPassport(entity));
                        break;
                    case StarType.Gold:
                        passports.Add(ParseGoldPassport(entity));
                        break;
                }
            }
            
            return passports;
        }
        
        private static string Solve(IEnumerable<Passport> data) =>
            $"{data.Count(p => p.Validate())}";

        public static Passport ParseSilverPassport(string entity)
        {
            var passport = new Passport();
            var temp = entity.Split(new char[] { ' ', '\n', '\r'}, StringSplitOptions.RemoveEmptyEntries).ToList();

            foreach (var item in temp)
            {
                if (item.Contains("byr:"))
                {
                    var t = short.Parse(item.Split(':')[1]);
                    passport.BirthYear = t;
                }
                else if (item.Contains("iyr:"))
                {
                    var t = short.Parse(item.Split(':')[1]);
                    passport.IssueYear = t;
                }
                else if (item.Contains("eyr:"))
                {
                    var t = short.Parse(item.Split(':')[1]);
                    passport.ExpirationYear = t;
                }
                else if (item.Contains("hgt:"))
                {
                    var t = item.Split(':')[1];
                    passport.Height = t;
                }
                else if (item.Contains("hcl:"))
                {
                    var t = item.Split(':')[1];
                    passport.HairColor = t;
                }
                else if (item.Contains("ecl:"))
                {
                    var t = item.Split(':')[1];
                    passport.EyeColor = t;
                }
                else if (item.Contains("pid:"))
                {
                    var t = item.Split(':')[1];
                    passport.PassportId = t;
                }
                else if (item.Contains("cid:"))
                {
                    var t = short.Parse(item.Split(':')[1]);
                    passport.CountryId = t;
                }
                else
                {
                    throw new InvalidDataException($"Data entry was invalid: {item}");
                }
            }

            return passport;
        }
        
        public static Passport ParseGoldPassport(string entity)
        {
            var passport = new Passport();
            var temp = entity.Split(new char[] { ' ', '\n', '\r'}, StringSplitOptions.RemoveEmptyEntries).ToList();

            foreach (var item in temp)
            {
                if (item.Contains("byr:"))    // Must be at or between 1920-2002
                {
                    var t = short.Parse(item.Split(':')[1]);
                    if (t >= 1920 && t <= 2002)
                        passport.BirthYear = t;
                }
                else if (item.Contains("iyr:"))    // Must be at or between 2010-2020
                {
                    var t = short.Parse(item.Split(':')[1]);
                    if (t >= 2010 && t <= 2020)
                        passport.IssueYear = t;
                }
                else if (item.Contains("eyr:"))    // Must be at or between 2020-2030
                {
                    var t = short.Parse(item.Split(':')[1]);
                    if (t >= 2020 && t <= 2030)
                        passport.ExpirationYear = t;
                }
                else if (item.Contains("hgt:"))    // Must end in cm or in, and be within a se tof ranges
                {
                    var t = item.Split(':')[1];
                    if (t.EndsWith("cm"))
                    {
                        var h = short.Parse(t.Split("cm")[0]);
                        if (h >= 150 && h <= 193)
                            passport.Height = t;
                    }
                    else if (t.EndsWith("in"))
                    {
                        var h = short.Parse(t.Split("in")[0]);
                        if (h >= 59 && h <= 76)
                            passport.Height = t;
                    }
                }
                else if (item.Contains("hcl:"))    // Must be #029abf
                {
                    var t = item.Split(':')[1];
                    if (Regex.Match(t, @"#[0-9a-f]{6}").Value.Equals(t))
                        passport.HairColor = t;
                }
                else if (item.Contains("ecl:"))    // Must be an enum specified
                {
                    var t = item.Split(':')[1];
                    if (Enum.TryParse(typeof(Color), t, out _))
                        passport.EyeColor = t;
                }
                else if (item.Contains("pid:"))    // Must be 9 digits
                {
                    var t = item.Split(':')[1];
                    if (Regex.Match($"{t}", @"\d{9}").Value.Equals(t))
                        passport.PassportId = t;
                }
                else if (item.Contains("cid:"))    // Optional
                {
                    var t = short.Parse(item.Split(':')[1]);
                    passport.CountryId = t;
                }
                else
                {
                    throw new InvalidDataException($"Data entry was invalid: {item}");
                }
            }
            return passport;
        }
        
        #endregion
    }

    #region Classes

    public class Passport
    {
        public short? BirthYear { get; set; }
        public short? IssueYear { get; set; }
        public short? ExpirationYear { get; set; }
        public string? Height { get; set; }
        public string? HairColor { get; set; }
        public string? EyeColor { get; set; }
        public string? PassportId { get; set; }
        public short? CountryId { get; set; }

        public bool Validate() =>
            GetType().GetProperties().All(p =>
            {
                if (p.Name.Contains(nameof(CountryId)))    // Optional, return true regardless
                    return true;
                var propertyValue = p.GetValue(this);
                return propertyValue != null;
            });
    }

    internal enum StarType
    {
        Silver,
        Gold
    }
    
    internal enum Color
    {
        amb,
        blu,
        brn,
        gry,
        grn,
        hzl,
        oth
    }
    
    #endregion
}