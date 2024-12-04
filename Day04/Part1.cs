namespace Day04;

public static class Part1
{
    public static char GetChar(this string[] input, int row, int col)
    {
        if (row < 0 || row >= input.Length)
        {
            return '0';
        }
        if (col < 0 || col >= input[row].Length)
        {
            return '0';
        }

        return input[row][col];
    }

    static int CheckXmasHorizontal(string[] input, int startRow, int startCol)
    {
        int foundCounter = 0;

        if (input.GetChar(startRow, startCol) == 'X')
            if (input.GetChar(startRow, startCol + 1) == 'M')
                if (input.GetChar(startRow, startCol + 2) == 'A')
                    if (input.GetChar(startRow, startCol + 3) == 'S')
                        foundCounter++;

        if (input.GetChar(startRow, startCol) == 'X')
            if (input.GetChar(startRow, startCol - 1) == 'M')
                if (input.GetChar(startRow, startCol - 2) == 'A')
                    if (input.GetChar(startRow, startCol - 3) == 'S')
                        foundCounter++;

        return foundCounter;
    }

    static int CheckXmasVertical(string[] input, int startRow, int startCol)
    {
        int foundCounter = 0;

        if (input.GetChar(startRow, startCol) == 'X')
            if (input.GetChar(startRow + 1, startCol) == 'M')
                if (input.GetChar(startRow + 2, startCol) == 'A')
                    if (input.GetChar(startRow + 3, startCol) == 'S')
                        foundCounter++;

        if (input.GetChar(startRow, startCol) == 'X')
            if (input.GetChar(startRow - 1, startCol) == 'M')
                if (input.GetChar(startRow - 2, startCol) == 'A')
                    if (input.GetChar(startRow - 3, startCol) == 'S')
                        foundCounter++;

        return foundCounter;
    }

    static int CheckXmasDiagonal(string[] input, int startRow, int startCol)
    {
        int foundCounter = 0;

        if (input.GetChar(startRow, startCol) == 'X')
            if (input.GetChar(startRow + 1, startCol+1) == 'M')
                if (input.GetChar(startRow + 2, startCol+2) == 'A')
                    if (input.GetChar(startRow + 3, startCol+3) == 'S')
                        foundCounter++;

        if (input.GetChar(startRow, startCol) == 'X')
            if (input.GetChar(startRow - 1, startCol-1) == 'M')
                if (input.GetChar(startRow - 2, startCol-2) == 'A')
                    if (input.GetChar(startRow - 3, startCol-3) == 'S')
                        foundCounter++;

        if (input.GetChar(startRow, startCol) == 'X')
            if (input.GetChar(startRow - 1, startCol + 1) == 'M')
                if (input.GetChar(startRow - 2, startCol + 2) == 'A')
                    if (input.GetChar(startRow - 3, startCol + 3) == 'S')
                        foundCounter++;

        if (input.GetChar(startRow, startCol) == 'X')
            if (input.GetChar(startRow + 1, startCol - 1) == 'M')
                if (input.GetChar(startRow + 2, startCol - 2) == 'A')
                    if (input.GetChar(startRow + 3, startCol - 3) == 'S')
                        foundCounter++;

        return foundCounter;
    }

    public static void Part1Main()
    {
        var input = File.ReadAllLines("input.txt");

        int xmasCount = 0;
        for(int row = 0; row<input.Length; row++)
        {
            for(int col = 0; col< input[row].Length; col++)
            {
                xmasCount += CheckXmasVertical(input, row, col);
                xmasCount += CheckXmasHorizontal(input, row, col);
                xmasCount += CheckXmasDiagonal(input, row, col);
            }
        }
        Console.WriteLine($"Part 1 result: {xmasCount}");
    }
}