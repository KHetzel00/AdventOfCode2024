using System.Net.WebSockets;
using System.Text.RegularExpressions;

public static class Day3
{
    public static void Part1()
    {
        StreamReader sr = new("C:\\Code\\AdventOfCode2024\\AdventOfCode2024\\Day3\\input.txt");
        List<string> reports = [];
        string? line;
        Regex regex = new("mul\\([0-9]*,[0-9]*\\)");

        while (!sr.EndOfStream)
        {
            line = sr.ReadLine();
            if (String.IsNullOrEmpty(line))
            {
                break;
            }
            reports.Add(line);
        }

        int sum = 0;
        string[] split;
        List<int> value = [0, 0];

        for (int i = 0; i < reports.Count; ++i)
        {
            var a = regex.Matches(reports[i]);
            foreach (Match m in a)
            {
                split = m.ToString().Split(',');
                value[0] = int.Parse(split[0][4..]);
                value[1] = int.Parse(split[1][..(split[1].Length - 1)]);
                sum += value[0] * value[1];
            }
        }

        Console.WriteLine(sum);
        sr.Dispose();
    }

    public static void Part2()
    {
        StreamReader sr = new("C:\\Code\\AdventOfCode2024\\AdventOfCode2024\\Day3\\input.txt");
        List<string> reports = [];
        string? line;
        Regex regex = new("mul\\([0-9]*,[0-9]*\\)|do\\(\\)|don't\\(\\)");

        while (!sr.EndOfStream)
        {
            line = sr.ReadLine();
            if (String.IsNullOrEmpty(line))
            {
                break;
            }
            reports.Add(line);
        }

        int sum = 0;
        string[] split;
        List<int> value = [0, 0];
        bool DoMul = true;

        for (int i = 0; i < reports.Count; ++i)
        {
            var a = regex.Matches(reports[i]);
            foreach (Match m in a)
            {
                if (m.ToString().Equals("do()"))
                {
                    DoMul = true;
                    continue;
                }
                else if (m.ToString().Equals("don't()"))
                {
                    DoMul = false;
                    continue;
                }
                if (DoMul)
                {
                    split = m.ToString().Split(',');
                    value[0] = int.Parse(split[0][4..]);
                    value[1] = int.Parse(split[1][..(split[1].Length - 1)]);
                    sum += value[0] * value[1];
                }
            }
        }

        Console.WriteLine(sum);
        sr.Dispose();
    }
}

