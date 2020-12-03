using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode.Console
{
    public class Day2 : BaseSolution
    {
        public override string SilverStar()
        {
            var rawData = File.ReadLines($"{GetType().Name}\\data.txt");

            var data = ProcessSilverStarData(rawData);

            var silverResult = Solve(data);

            return $"{silverResult}";
        }

        public override string GoldStar()
        {
            var rawData = File.ReadLines($"{GetType().Name}\\data.txt");

            var data = ProcessGoldStarData(rawData);

            var goldResult = Solve(data);

            return $"{goldResult}";
        }

        private static List<IInput> ProcessSilverStarData(IEnumerable<string> rawData)
        {
            var inputs = new List<IInput>();

            foreach (var line in rawData)
            {
                var tempLine = line.Split(": ");
                var policy = GeneratePolicy(tempLine[0]);
                var password = tempLine[1];
                inputs.Add(new InputPt1(policy, password));
            }

            return inputs;
        }

        private static List<IInput> ProcessGoldStarData(IEnumerable<string> rawData)
        {
            var inputs = new List<IInput>();

            foreach (var line in rawData)
            {
                var tempLine = line.Split(": ");
                var policy = GeneratePolicy(tempLine[0]);
                var password = tempLine[1];
                inputs.Add(new InputPt2(policy, password));
            }

            return inputs;
        }

        private static string Solve(List<IInput> inputs)
        {
            return $"{inputs.Count(i => i.IsValid)}";
        }

        private static PasswordPolicy GeneratePolicy(string s)
        {
            int max;
            int min;
            char c;

            var temp = s.Split('-');
            max = int.Parse(temp[1].Split(' ')[0]);
            min = int.Parse(temp[0]);
            c = char.Parse(s.Split(' ')[1]);

            return new PasswordPolicy(max, min, c);
        }
    }

    internal class InputPt1 : IInput
    {
        internal PasswordPolicy PasswordPolicy { get; }
        internal string Password { get; }

        public bool IsValid
        {
            get
            {
                int count = Password.Count(c => c == PasswordPolicy.PolicyCharacter);

                if (count >= PasswordPolicy.Miniumum &&
                    count <= PasswordPolicy.Maxiumum)
                    return true;

                return false;
            }
        }

        internal InputPt1(PasswordPolicy policy, string password)
        {
            PasswordPolicy = policy;
            Password = password;
        }
    }

    internal class InputPt2 : IInput
    {
        internal PasswordPolicy PasswordPolicy { get; }
        internal string Password { get; }

        public bool IsValid
        {
            get
            {
                int occurances = 0;

                if (Password[PasswordPolicy.Miniumum - 1] == PasswordPolicy.PolicyCharacter)
                    occurances++;

                if (Password[PasswordPolicy.Maxiumum - 1] == PasswordPolicy.PolicyCharacter)
                    occurances++;

                return occurances == 1;
            }
        }

        internal InputPt2(PasswordPolicy policy, string password)
        {
            PasswordPolicy = policy;
            Password = password;
        }
    }      

    internal class PasswordPolicy
    {
        internal int Maxiumum { get; }
        internal int Miniumum { get; }
        internal char PolicyCharacter { get; }

        internal PasswordPolicy(int maxiumum, int miniumum, char policyCharacter)
        {
            Maxiumum = maxiumum;
            Miniumum = miniumum;
            PolicyCharacter = policyCharacter;
        }
    }

    internal interface IInput
    {
        public bool IsValid { get; }
    }
}
