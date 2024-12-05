public static class Day5
{
    public static void Part1()
    {
        StreamReader sr = new("C:\\Code\\AdventOfCode2024\\AdventOfCode2024\\Day5\\input.txt");
        List<string> answers = [];
        string? line;
        List<string> lines = [];
        Dictionary<string, string> rules= new Dictionary<string, string>();

        int row = 0;

        while (!sr.EndOfStream)
        {
            if (row < 1176)
            {
                line = sr.ReadLine();
                lines.Add(line);
                row++;
            }
            else 
            {
                line = sr.ReadLine();
                answers.Add(line);
            }  
        }
        answers.RemoveAt(0);
        Console.WriteLine(answers[0]);
        Console.WriteLine(lines[lines.Count-1]);
        List<string[]> split = [];

        foreach (var lin in lines)
        {
            rules.Add(lin[3..], lin[..2]);
        }

        foreach (var ans in answers)
        {
            split.Add(ans.Split(','));
        }

        Console.WriteLine(split[0][0]);
        string a;
        for (int i = 0; i < split.Count; ++i)
        {
            for (int j = 0; j < split[i].Length; ++j)
            {
                if (rules.TryGetValue(split[i][j],out a))
                {
                    Console.WriteLine(a);
                }
            }
        }

    }

    public static void Part2()
    {
        
    }


}
