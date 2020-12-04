using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Library.Day2
{
    public class Day2 : BaseSolution
    {
        private readonly IEnumerable<string> _rawData;

        public Day2()
        {
            _rawData = File.ReadLines(Path.Combine($"{GetType().Name}", "data.txt"));
        }
        
        public override string SilverStar()
        {
            var data = ProcessSilverStarData(_rawData);

            var silverResult = Solve(data);

            return $"{silverResult}";
        }

        public override string GoldStar()
        {
            var data = ProcessGoldStarData(_rawData);

            var goldResult = Solve(data);

            return $"{goldResult}";
        }

        private static List<IUserInput> ProcessSilverStarData(IEnumerable<string> rawData) =>
            (from line
                    in rawData
                select line
                    .Split(": ")
                into tempLine
                let policy = GeneratePolicy(tempLine[0])
                let password = tempLine[1]
                select new UserUserInputSilver(policy, password))
                .Cast<IUserInput>()
                .ToList();

        private static List<IUserInput> ProcessGoldStarData(IEnumerable<string> rawData) =>
            (from line
                    in rawData
                select line
                    .Split(": ")
                into tempLine
                let policy = GeneratePolicy(tempLine[0])
                let password = tempLine[1]
                select new UserUserInputGold(policy, password))
            .Cast<IUserInput>()
            .ToList();

        private static string Solve(List<IUserInput> inputs)
        {
            return $"{inputs.Count(i => i.IsValid)}";
        }

        private static PasswordPolicy GeneratePolicy(string s)
        {
            var temp = s.Split('-');
            var max = int.Parse(temp[1].Split(' ')[0]);
            var min = int.Parse(temp[0]);
            var c = char.Parse(s.Split(' ')[1]);

            return new PasswordPolicy(max, min, c);
        }
    }

    #region Classes

    internal class UserUserInputSilver : IUserInput
    {
        private PasswordPolicy _passwordPolicy { get; }
        private string _password { get; }

        public bool IsValid
        {
            get
            {
                var count = _password.Count(c => c == _passwordPolicy.PolicyCharacter);

                return count >= _passwordPolicy.Minimum &&
                       count <= _passwordPolicy.Maximum;
            }
        }

        internal UserUserInputSilver(PasswordPolicy policy, string password)
        {
            _passwordPolicy = policy;
            _password = password;
        }
    }

    internal class UserUserInputGold : IUserInput
    {
        private PasswordPolicy _passwordPolicy { get; }
        private string _password { get; }

        public bool IsValid
        {
            get
            {
                var occurrences = 0;

                if (_password[_passwordPolicy.Minimum - 1] == _passwordPolicy.PolicyCharacter)
                    occurrences++;

                if (_password[_passwordPolicy.Maximum - 1] == _passwordPolicy.PolicyCharacter)
                    occurrences++;

                return occurrences == 1;
            }
        }

        internal UserUserInputGold(PasswordPolicy policy, string password)
        {
            _passwordPolicy = policy;
            _password = password;
        }
    }      

    internal class PasswordPolicy
    {
        internal int Maximum { get; }
        internal int Minimum { get; }
        internal char PolicyCharacter { get; }

        internal PasswordPolicy(int maximum, int minimum, char policyCharacter)
        {
            Maximum = maximum;
            Minimum = minimum;
            PolicyCharacter = policyCharacter;
        }
    }

    internal interface IUserInput
    {
        bool IsValid { get; }
    }

    #endregion
}
