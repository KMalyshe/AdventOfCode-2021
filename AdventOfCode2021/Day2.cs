class Day2 {

    public static void solve()
    {
        var input = new List<String>(File.ReadAllLines(@"C:\AoCFiles\21Day2.txt"));
        var horizontalPartOne = 0;
        var depthPartOne = 0;
        var horizontalPartTwo = 0;
        var depthPartTwo = 0;
        var aim = 0;
        for (int i = 0; i<input.Count(); i++)
        {
            var currentLine = input[i].Split(" ");
            var parsedValue = Int32.Parse(currentLine[1]);
            if (currentLine[0] == "forward") 
            {
                horizontalPartOne += parsedValue;
                horizontalPartTwo += parsedValue;
                depthPartTwo += aim*parsedValue;
            }
            else if (currentLine[0] == "down")
            {
                depthPartOne += parsedValue;
                aim += parsedValue;
            }
            else if (currentLine[0] == "up") 
            {
                depthPartOne -= parsedValue;
                aim -= parsedValue;
            }
        }
        Console.WriteLine("Part 1: " + horizontalPartOne*depthPartOne);
        Console.WriteLine("Part 2: " + horizontalPartTwo*depthPartTwo);
    }
}