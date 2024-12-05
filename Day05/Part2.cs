using static Day05.Part1;

namespace Day05;

public static class Part2
{
    static void FixUpdate(List<int> update, List<Rule> rules)
    {
        bool restartForLoop = true;
        while (restartForLoop)
        {
            restartForLoop = false;
            for (int i = 0; i < update.Count; i++)
            {
                int currentUpdateNumber = update[i];
                var foundRules = rules.FindAll(x => x.After == currentUpdateNumber);
                if (foundRules.Count > 0)
                {
                    foreach (var foundRule in foundRules)
                    {
                        int beforeIndex = update.FindIndex(x => foundRule.Before == x);
                        if (beforeIndex > i)
                        {
                            // Byt plats
                            var temp = update[i];
                            update[i] = update[beforeIndex];
                            update[beforeIndex] = temp;

                            restartForLoop = true;
                            break;
                        }
                    }
                }
                if (restartForLoop)
                {
                    break;
                }
            }
        }
    }

    public static void Part2Main()
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
            .Select(x => x.Split(',').Select(x => int.Parse(x)).ToList()).ToList();

        int sum = 0;
        foreach (var update in updates)
        {
            if(Part1.IsValidUpdate(update, rules) == false)
            {
                FixUpdate(update, rules);
                var middleIndex = (int)Math.Ceiling((update.Count - 1) / 2.0);
                sum += update[middleIndex];
            }
        }
        Console.WriteLine($"Part 2 result: {sum}");
    }
}
