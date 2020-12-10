using System;
using System.Collections.Generic;

namespace AdventOfCode.Library.Day7
{
    public class Day7 : BaseSolution
    {
        private readonly IEnumerable<string> _rawData;

        public Day7()
        {
            _rawData = ReadLines(GetType());
        }

        public override string SilverStar()
        {
            var bagRules = new List<BagRule>();
            foreach (var rule in _rawData)
            {
                bagRules.Add(new BagRule(rule));
            }

            List<Bag> bags = new List<Bag>();
            bags.Add(new Bag("drab tomato", PopulateChildrenBagsFromRules("drab tomato", bagRules)));

            throw new System.NotImplementedException();
        }

        private List<Bag> PopulateChildrenBagsFromRules(string parentDesc, List<BagRule> bagRules)
        {
            var bags = new List<Bag>();
            foreach (BagRule bagRule in bagRules)
            {
                //bags.Add();
                throw new System.NotImplementedException();
            }

            return bags;
        }

        public override string GoldStar()
        {
            throw new System.NotImplementedException();
        }
    }

    public class Bag
    {
        public string Description { get; }
        public List<Bag> Contents { get; } = new List<Bag>();

        public Bag(string description)
        {
            Description = description;
        }

        public Bag(string description, IEnumerable<Bag> bags)
        {
            Description = description;
            Contents.AddRange(bags);
        }
    }

    public class BagRule
    {
        public Bag ParentBag { get; private set; }
        public List<Bag> ChildrenBags { get; } = new List<Bag>();

        public BagRule(string rule)
        {
            var childrenRule = ParseParentBag(rule);
            ParseChildrenBag(childrenRule);
        }

        private void ParseChildrenBag(string rule)
        {
            var children = rule
                .Replace(".","")
                .Replace(" bags", "")
                .Replace(" bag", "")
                .Split(", ");
            // children = [ "2 bright tan", "5 light beige" ]
            foreach (var child in children)
            {
                if (child.Contains("no other")) break;

                var desc = child.Substring(2, child.Length - 2);
                var count = int.Parse(child[0].ToString());

                var childBag = new Bag(desc);

                for (int i = 0; i < count; i++)
                {
                    ChildrenBags.Add(childBag);
                }
            }
        }

        private string ParseParentBag(string rule)
        {
            var selector = " bags contain ";
            var split = rule.Split(selector);
            var parent = split[0];
            // parent = dull crimson

            ParentBag = new Bag(parent);
            return split[1];
        }
    }

}
