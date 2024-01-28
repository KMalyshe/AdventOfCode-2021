class Day6 {

    public static void solve()
    {
        var inputLine = new List<String>(File.ReadAllLines(@"C:\AoCFiles\21Day6.txt"));
        long[] lanternFish = new long[9]; // Chose to use array instead of list as it's already initialized to 0
        foreach (string s in inputLine[0].Split(","))
        {
            lanternFish[Int32.Parse(s)] += 1;
        }
        for (int i = 0; i<256; i++) // Part 1: i<80, Part 2: i<256
        {
            List<long> fishCheckpoint = new List<long>(lanternFish);
            for (int j = 8; j>0; j--)
            {
                lanternFish[j-1] = fishCheckpoint[j];
            }
            lanternFish[8] = fishCheckpoint[0];
            lanternFish[6] += fishCheckpoint[0];
        }
        
        Console.WriteLine(lanternFish.Sum());
    }
}