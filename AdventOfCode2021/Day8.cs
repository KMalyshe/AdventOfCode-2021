class Day8 {

    public static void solve()
    {
        var input = new List<String>(File.ReadAllLines(@"C:\AoCFiles\21Day8.txt"));
        var rightside = new List<String>();
        foreach (string line in input)
        {
            rightside.Add(line.Split(" | ")[1]);
        }
        
    }
}