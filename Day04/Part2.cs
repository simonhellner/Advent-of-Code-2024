namespace Day04;

public static class Part2
{
    static int CheckXmas(string[] input, int startRow, int startCol)
    {
        int foundCounter = 0;

        // S M M S
        if (input.GetChar(startRow, startCol) == 'A')
        {
            if (input.GetChar(startRow - 1, startCol + 1) == 'S') // Upp höger steg från start
            {
                if (input.GetChar(startRow + 1, startCol - 1) == 'M') // Ner vänster steg från start
                {
                    if (input.GetChar(startRow - 1, startCol - 1) == 'M')
                    {
                        if (input.GetChar(startRow + 1, startCol + 1) == 'S')
                        {
                            foundCounter++;
                        }
                    }          
                }
            }
        }

        // M S S M
        if (input.GetChar(startRow, startCol) == 'A')
        {
            if (input.GetChar(startRow - 1, startCol + 1) == 'M') // Upp höger steg från start
            {
                if (input.GetChar(startRow + 1, startCol - 1) == 'S') // Ner vänster steg från start
                {
                    if (input.GetChar(startRow - 1, startCol - 1) == 'S')
                    {
                        if (input.GetChar(startRow + 1, startCol + 1) == 'M')
                        {
                            foundCounter++;
                        }
                    }
                }
            }
        }
  
        // M S M S
        if (input.GetChar(startRow, startCol) == 'A')
        {
            if (input.GetChar(startRow - 1, startCol + 1) == 'M') // Upp höger steg från start
            {
                if (input.GetChar(startRow + 1, startCol - 1) == 'S') // Ner vänster steg från start
                {
                    if (input.GetChar(startRow - 1, startCol - 1) == 'M')
                    {
                        if (input.GetChar(startRow + 1, startCol + 1) == 'S')
                        {
                            foundCounter++;
                        }
                    }
                }
            }
        }

        // S M S M
        if (input.GetChar(startRow, startCol) == 'A')
        {
            if (input.GetChar(startRow - 1, startCol + 1) == 'S') // Upp höger steg från start
            {
                if (input.GetChar(startRow + 1, startCol - 1) == 'M') // Ner vänster steg från start
                {
                    if (input.GetChar(startRow - 1, startCol - 1) == 'S')
                    {
                        if (input.GetChar(startRow + 1, startCol + 1) == 'M')
                        {
                            foundCounter++;
                        }
                    }
                }
            }
        }

        return foundCounter;
    }


    public static void Part2Main()
    {
        var input = File.ReadAllLines("input.txt");

        int masCount = 0;
        for (int row = 0; row < input.Length; row++)
        {
            for (int col = 0; col < input[row].Length; col++)
            {
                masCount += CheckXmas(input, row, col);
            }
        }
        Console.WriteLine($"Part 2 result: {masCount}");
    }
}
