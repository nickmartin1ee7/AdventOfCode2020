using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace AdventOfCode.Library.Day6
{
    public class Day6 : BaseSolution
    {
        private string _rawData;

        public Day6()
        {
            _rawData = ReadAllText(GetType());
        }

        public override string SilverStar()
        {
            var groupsData = _rawData.Split(Environment.NewLine + Environment.NewLine);
            int total = 0;
            foreach (var groupData in groupsData)
            {
                total += new Group(groupData.Trim().Split(Environment.NewLine)).Answers.Keys.Count;
            }

            return $"{total}";
        }

        public override string GoldStar()
        {
            var groupsData = _rawData.Split(Environment.NewLine + Environment.NewLine);
            int total = 0;
            foreach (var groupData in groupsData)
            {
                var group = new Group(groupData.Trim().Split(Environment.NewLine));
                total += group.InAgreementQuestions;
            }

            return $"{total}";
        }
    }

    public class Group
    {
        private readonly int _groupMembers;

        public Dictionary<char, List<bool>> Answers { get; } = new Dictionary<char, List<bool>>();
        
        public int InAgreementQuestions
        {
            get => Answers.Values.Count(answers => answers.Count(a => a) == _groupMembers);
        }

        public Group(IReadOnlyCollection<string> data)
        {
            _groupMembers = data.Count;

            foreach (var person in data)
            {
                foreach (var question in person)
                {
                    if (Answers.TryGetValue(question, out List<bool> answers))
                    {
                        answers.Add(true);
                        Answers.TryAdd(question, answers);
                    }
                    else
                    {
                        Answers.TryAdd(question, new List<bool> { true });
                    }
                }
            }
        }
    }   
}
