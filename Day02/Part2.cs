namespace Day02
{
    public static class Part2
    {
        public static void Part2Main()
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
                        continue;
                    }
                }


                // Lite brute force HEHEHE, ful-lösning jag veeet
                for (int i = 0; i < levelNumbers.Count; i++)
                {
                    var tempLevelNumbers = levelNumbers.ToList();
                    tempLevelNumbers.RemoveAt(i);
                    var abc2 = tempLevelNumbers
                           .Select((number, index) =>
                           {
                               if (index == 0)
                                   return new { Curr = -1, Prev = -1 };
                               return new { Curr = number, Prev = tempLevelNumbers[index - 1] };
                           }).Skip(1);

                    var all3StepsOrLess2 = abc2.All(x => Math.Abs(x.Prev - x.Curr) <= 3 && x.Prev != x.Curr);
                    var allDecreasing2 = abc2.All(x => x.Prev > x.Curr);
                    var allIncreasing2 = abc2.All(x => x.Prev < x.Curr);

                    if (all3StepsOrLess2)
                    {
                        if (allDecreasing2 || allIncreasing2)
                        {
                            safeLevelsCount++;
                            break;
                        }
                    }
                }
            }
            
            Console.WriteLine($"Part 2 result: {safeLevelsCount}");
        }
    }
}
