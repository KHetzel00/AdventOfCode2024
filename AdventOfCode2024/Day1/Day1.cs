public static class Day1
{
    public static void Test()
    {
        StreamReader sr = new("C:\\Code\\AdventOfCode2024\\AdventOfCode2024\\Day1\\input.txt");
        List<int> left = [];
        List<int> right = [];
        string? line;

        while (!sr.EndOfStream)
        {
            line = sr.ReadLine();
            if (String.IsNullOrEmpty(line))
            {
                break;
            }
            left.Add(int.Parse(line[..6]));
            right.Add(int.Parse(line[8..]));
        }

        int l, r, sum;
        sum = 0;
        while (left.Count != 0 && right.Count != 0) {
            l = left.Min();
            r = right.Min();
            sum += Math.Abs(l - r);
            left.Remove(l);
            right.Remove(r);
        }

        Console.WriteLine(sum);
    }
}

