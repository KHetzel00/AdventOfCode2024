
using System.Diagnostics;

public static class Day2
{
    public static void Test()
    {
        StreamReader sr = new("C:\\Code\\AdventOfCode2024\\AdventOfCode2024\\Day2\\input.txt");
        List<string> reports = [];
        string? line;

        while (!sr.EndOfStream)
        {
            line = sr.ReadLine();
            if (String.IsNullOrEmpty(line))
            {
                break;
            }
            reports.Add(line);
        }

        List<int> levels = [];
        string[] split = [];
        int safe = 0;

        for (int i = 0; i < reports.Count; ++i)
        {
            levels = [];
            split = reports[i].Split(' ');
            for (int j = 0; j < split.Length; ++j)
            {
                levels.Add(int.Parse(split[j]));
            }
            if (!CheckIncrease(levels) && !CheckDecrease(levels))
            {
                continue;
            }
            if (CheckDiff(levels))
            {
                safe++;
            }
        }

        Console.WriteLine(safe);
    }

    public static bool CheckIncrease(List<int> levels)
    {
        for (int i = 0; i < levels.Count - 1; ++i)
        {
            if (levels[i] > levels[i + 1])
            {
                return false;
            }
        }
        return true;
    }

    public static bool CheckDecrease(List<int> levels)
    {
        for (int i = 0; i < levels.Count - 1; ++i)
        {
            if (levels[i] < levels[i + 1])
            {
                return false;
            }
        }
        return true;
    }

    public static bool CheckDiff(List<int> levels)
    {
        for (int i = 0; i < levels.Count - 1; ++i)
        {
            if (Math.Abs(levels[i] - levels[i + 1]) > 3 || levels[i] - levels[i + 1] == 0)
            {
                return false;
            }
        }

        return true;
    }
}
