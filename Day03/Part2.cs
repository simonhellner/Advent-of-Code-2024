using System.Text.RegularExpressions;

namespace Day03;

public static class Part2
{
    public static void Part2Main()
    {
        var input = File.ReadAllText("input.txt");

        var regex = new Regex(@"mul\([0-9]{1,3},[0-9]{1,3}\)");

        int sum = 0;
        foreach (var doInstruction in input.Split("do()"))
        {
            var instrcutions = doInstruction.Split("don't()")[0];
            var matches = regex.Matches(instrcutions);
            foreach (Match match in matches)
            {
                var value = match.Value;
                var numb1Str = value.Split(',')[0].Split('(')[1];
                var numb2Str = value.Split(',')[1].Split(')')[0];

                var numb1 = int.Parse(numb1Str);
                var numb2 = int.Parse(numb2Str);
                sum += numb1 * numb2;
            }
        }
        
        Console.WriteLine($"Part 2 result: {sum}");
    }
}