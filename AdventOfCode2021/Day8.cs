class Day8 {

    public static void solve()
    {
        var input = new List<String>(File.ReadAllLines(@"C:\AoCFiles\21Day8.txt"));
        var rightside = new List<String>();
        var counter = 0;
        foreach (string line in input)
        {
            rightside.Add(line.Split(" | ")[1]);
        }
        foreach (string line in rightside)
        {
            var numbers = line.Split(" ").ToList();
            foreach (string number in numbers)
            {
                if (((number.Length >= 2) && (number.Length <= 4)) || number.Length == 7) counter++;
            }
        }
        Console.WriteLine(counter);
    }
}