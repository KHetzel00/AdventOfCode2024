public static class Day2
{
    public static void Part1()
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

        List<int> levels;
        string[] split;
        int safe = 0;

        for (int i = 0; i < reports.Count; ++i)
        {
            levels = [];
            split = reports[i].Split(' ');
            for (int j = 0; j < split.Length; ++j)
            {
                levels.Add(int.Parse(split[j]));
            }
            if (!CheckIncrease(levels) && !CheckDecrease(levels) || !CheckDiff(levels))
            {
                continue;
            }
            safe++;
        }

        Console.WriteLine(safe);
        sr.Dispose();
    }

    public static void Part2()
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

        List<int> levels;
        string[] split;
        int safe = 0;
        List<int> diff;

        for (int i = 0; i < reports.Count; ++i)
        {
            levels = [];
            split = reports[i].Split(' ');
            for (int j = 0; j < split.Length; ++j)
            {
                levels.Add(int.Parse(split[j]));
            }
            if (!CheckIncrease(levels) && !CheckDecrease(levels) || !CheckDiff(levels))
            {
                for (int j = 0; j < levels.Count; ++j)
                {
                    diff = [.. levels];
                    diff.RemoveAt(j);
                    if (!CheckIncrease(diff) && !CheckDecrease(diff) || !CheckDiff(diff))
                    {
                        continue;
                    }
                    safe++;
                    break;
                }
                continue;
            }
            safe++;
        }

        Console.WriteLine(safe);
        sr.Dispose();
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
