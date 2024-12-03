namespace Day01;

public static class Part1
{
    public static void Part1Main()
    {
        var input = File.ReadAllLines("input.txt");

        var lists = input.Select(x => new 
        {    
            list1 = int.Parse(x.Split(' ')[0].Trim()),
            list2 = int.Parse(x.Split(' ').Last().Trim()) 
        });

        var list1 = lists.Select(x => x.list1).Order().ToList();
        var list2 = lists.Select(x => x.list2).Order().ToList();

        List<int> distances = [];
        for (int i = 0; i < list1.Count; i++)
        {
            var fromList1 = list1[i];
            var fromList2 = list2[i];

            distances.Add(Math.Abs(fromList1 - fromList2));
        }

        var sum = distances.Sum();
        Console.WriteLine($"Part 1 result: {sum}");
    }
}
