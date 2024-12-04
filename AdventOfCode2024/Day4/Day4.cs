public static class Day4
{
    public static void Part1()
    {
        StreamReader sr = new("C:\\Code\\AdventOfCode2024\\AdventOfCode2024\\Day4\\input.txt");
        List<string> reports = [];
        string? line;
        char[,] carray = new char[140, 140];

        int row = 0;

        while (!sr.EndOfStream)
        {
            line = sr.ReadLine();
            for (int i = 0; i < line?.Length; ++i)
            {
                carray[row, i] = line[i];
            }
            row++;
        }
        int a = 0;

        for (int i = 0; i < 140; ++i)
        {
            for (int j = 0; j < 140; ++j)
            {
                if (carray[i, j].Equals('X'))
                {
                    a += Search(carray, i, j);
                }
            }
        }
        Console.WriteLine(a);
    }

    public static void Part2()
    {
        StreamReader sr = new("C:\\Code\\AdventOfCode2024\\AdventOfCode2024\\Day4\\input.txt");
        List<string> reports = [];
        string? line;
        char[,] carray = new char[140, 140];

        int row = 0;

        while (!sr.EndOfStream)
        {
            line = sr.ReadLine();
            for (int i = 0; i < line?.Length; ++i)
            {
                carray[row, i] = line[i];
            }
            row++;
        }
        int a = 0;

        for (int i = 0; i < 140; ++i)
        {
            for (int j = 0; j < 140; ++j)
            {
                if (carray[i, j].Equals('A'))
                {
                    a += Search2(carray, i, j);
                }
            }
        }
        Console.WriteLine(a);
    }

    public static int Search(char[,] arr, int startRow, int startCol)
    {
        int sum = 0;
        if (Up(arr, startRow, startCol))
        {
            sum++;
        }
        if (Down(arr, startRow, startCol))
        {
            sum++;
        }
        if (Left(arr, startRow, startCol))
        {
            sum++;
        }
        if (Right(arr, startRow, startCol))
        {
            sum++;
        }
        if (UpLeft(arr, startRow, startCol))
        {
            sum++;
        }
        if (UpRight(arr, startRow, startCol))
        {
            sum++;
        }
        if (DownLeft(arr, startRow, startCol))
        {
            sum++;
        }
        if (DownRight(arr, startRow, startCol))
        {
            sum++;
        }
        return sum;
    }
    public static bool Up(char[,] arr, int startRow, int startCol)
    {
        if (startRow < 3)
        {
            return false;
        }

        if (arr[startRow - 1, startCol].Equals('M')
            && arr[startRow - 2, startCol].Equals('A')
            && arr[startRow - 3, startCol].Equals('S'))
        {
            return true;
        }
        return false;
    }
    public static bool Down(char[,] arr, int startRow, int startCol)
    {
        if (startRow > 136)
        {
            return false;
        }

        if (arr[startRow + 1, startCol].Equals('M')
            && arr[startRow + 2, startCol].Equals('A')
            && arr[startRow + 3, startCol].Equals('S'))
        {
            return true;
        }
        return false;
    }
    public static bool Left(char[,] arr, int startRow, int startCol)
    {
        if (startCol < 3)
        {
            return false;
        }

        if (arr[startRow, startCol - 1].Equals('M')
            && arr[startRow, startCol - 2].Equals('A')
            && arr[startRow, startCol - 3].Equals('S'))
        {
            return true;
        }

        return false;
    }
    public static bool Right(char[,] arr, int startRow, int startCol)
    {
        if (startCol > 136)
        {
            return false;
        }

        if (arr[startRow, startCol + 1].Equals('M')
            && arr[startRow, startCol + 2].Equals('A')
            && arr[startRow, startCol + 3].Equals('S'))
        {
            return true;
        }

        return false;
    }
    public static bool UpLeft(char[,] arr, int startRow, int startCol)
    {
        if (startRow < 3 || startCol < 3)
        {
            return false;
        }

        if (arr[startRow - 1, startCol - 1].Equals('M')
            && arr[startRow - 2, startCol - 2].Equals('A')
            && arr[startRow - 3, startCol - 3].Equals('S'))
        {
            return true;
        }
        return false;
    }
    public static bool UpRight(char[,] arr, int startRow, int startCol)
    {
        if (startRow < 3 || startCol > 136)
        {
            return false;
        }

        if (arr[startRow - 1, startCol + 1].Equals('M')
            && arr[startRow - 2, startCol + 2].Equals('A')
            && arr[startRow - 3, startCol + 3].Equals('S'))
        {
            return true;
        }
        return false;
    }
    public static bool DownLeft(char[,] arr, int startRow, int startCol)
    {
        if (startRow > 136 || startCol < 3)
        {
            return false;
        }

        if (arr[startRow + 1, startCol - 1].Equals('M')
            && arr[startRow + 2, startCol - 2].Equals('A')
            && arr[startRow + 3, startCol - 3].Equals('S'))
        {
            return true;
        }
        return false;
    }
    public static bool DownRight(char[,] arr, int startRow, int startCol)
    {
        if (startRow > 136 || startCol > 136)
        {
            return false;
        }

        if (arr[startRow + 1, startCol + 1].Equals('M')
            && arr[startRow + 2, startCol + 2].Equals('A')
            && arr[startRow + 3, startCol + 3].Equals('S'))
        {
            return true;
        }
        return false;
    }
    public static int Search2(char[,] arr, int startRow, int startCol)
    {
        if (startRow == 0 || startRow == 139 || startCol == 0 || startCol == 139)
        {
            return 0;
        }
        int count = 0;

        for (int i = -1; i < 2; ++i)
        {
            for (int j = -1; j < 2; ++j)
            {
                if (i == 0 || j == 0)
                {
                    continue;
                }
                if (arr[startRow + i, startCol + j].Equals('M'))
                {
                    if (arr[startRow + (-i), startCol + (-j)].Equals('S'))
                    {
                        count++;
                    }
                }
            }
        }

        if (count == 2)
        {
            return 1;
        }
        return 0;
    }
}
