using System.Data;

namespace Day05;

public static class Part1
{
    public class Rule
    {
        public int Before { get; set; }
        public int After { get; set; }
    }

    public static bool IsValidUpdate(List<int> update, List<Rule> rules)
    {
        for(int i = 0; i < update.Count; i++)
        {
            int currentUpdateNumber = update[i];
            var foundRules = rules.FindAll(x =>  x.After == currentUpdateNumber);
            if(foundRules.Count > 0)
            {
                foreach(var foundRule in foundRules)
                {
                    int beforeIndex = update.FindIndex(x => foundRule.Before == x);
                    if (beforeIndex > i)
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }

    public static void Part1Main()
    {
        var input = File.ReadAllLines("input.txt");

        var rules = input
            .Where(x => x.Contains('|'))
            .Select(x => new Rule
            {
                Before = int.Parse(x.Split('|')[0]),
                After = int.Parse(x.Split('|')[1])
            })
            .ToList();

        var updates = input
            .Where(x => x.Contains(','))
            .Select(x => x.Split(',').Select(x => int.Parse(x)).ToList());


        int sum = 0;
        foreach(var update in updates)
        {
            if(IsValidUpdate(update, rules))
            {
                var middleIndex = (int)Math.Ceiling((update.Count - 1) / 2.0);
                sum += update[middleIndex];
            }
         }
        Console.WriteLine($"Part 1 result: {sum}");
    }
}
