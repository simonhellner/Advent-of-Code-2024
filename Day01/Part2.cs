namespace Day01;

public static class Part2
{
    public static void Part2Main()
    {
        var input = File.ReadAllLines("input.txt");

        var lists = input.Select(x => new { list1 = int.Parse(x.Split(' ')[0].Trim()), list2 = int.Parse(x.Split(' ').Last().Trim()) });

        var list1 = lists.Select(x => x.list1).Order();
        var list2 = lists.Select(x => x.list2).Order();

        List<int> distances = [];
        foreach (var list1Number in list1)
        {
            var multiplier = list2.Count(list2Number => list2Number == list1Number);
            distances.Add(list1Number * multiplier);
        }

        var sum = distances.Sum();
        Console.WriteLine($"Part 2 result: {sum}");
    }
}
