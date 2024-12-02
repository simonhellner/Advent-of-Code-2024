namespace Day02
{
    public static class Part1
    {
        public static void Part1Main()
        {
            var input = File.ReadAllLines("input.txt");

            int safeLevelsCount = 0;
            foreach (var level in input)
            {
                var levelNumbers = level.Split(' ')
                    .Select(int.Parse)
                    .ToList();

                var abc = levelNumbers
                    .Select((number, index) => 
                    {
                        if (index == 0)
                           return new { Curr = -1, Prev = -1 };
                        return new { Curr = number, Prev = levelNumbers[index - 1] };
                    })
                    .Skip(1);

                var all3StepsOrLess = abc.All(x => Math.Abs(x.Prev - x.Curr) <= 3 && x.Prev != x.Curr);
                var allDecreasing = abc.All(x => x.Prev > x.Curr);
                var allIncreasing = abc.All(x => x.Prev < x.Curr);


                if (all3StepsOrLess)
                {
                    if (allDecreasing || allIncreasing)
                    {
                        safeLevelsCount++;
                    }
                }
            }
            Console.WriteLine($"Part 1 result: {safeLevelsCount}");
        }
    }
}
