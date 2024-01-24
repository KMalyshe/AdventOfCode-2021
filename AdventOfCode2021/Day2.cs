class Day2 {

    public static void solve()
    {
        var input = new List<String>(File.ReadAllLines(@"C:\AoCFiles\21Day2.txt"));
        var hor1 = 0;
        var dep1 = 0;
        var hor2 = 0;
        var dep2 = 0;
        var aim = 0;
        for (int i = 0; i<input.Count(); i++)
        {
            var split = input[i].Split(" ");
            var val = Int32.Parse(split[1]);
            if (split[0] == "forward") 
            {
                hor1 += val;
                hor2 += val;
                dep2 += aim*val;
            }
            else if (split[0] == "down")
            {
                dep1 += val;
                aim += val;
            }
            else if (split[0] == "up") 
            {
                dep1 -= val;
                aim -= val;
            }
        }
        Console.WriteLine("Part 1: " + hor1*dep1);
        Console.WriteLine("Part 2: " + hor2*dep2);
    }
}