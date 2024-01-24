using System.Runtime.ExceptionServices;
using System.Transactions;

class Day1 {

    public static void solve()
    {
        var pinput = new List<String>(File.ReadAllLines(@"C:\AoCFiles\21Day1.txt"));
        List<int> input = pinput.ConvertAll(Int32.Parse);
        var p1count = 0;
        var p2count = 0;
        // Part 1
        for (int i = 1; i<input.Count(); i++)
        {
            if (input[i] > input[i-1])
            {
                p1count += 1;
            }
        }

        // Part 2
        var prev = (input[0]) + (input[1]) + (input[2]);
        var current = 0;
        for (int r = 3; r<input.Count(); r++) {
            current = (input[r-2]) + (input[r-1]) + (input[r]);
            if (current > prev) p2count += 1;
            prev = current;
        }
        Console.WriteLine("Part 1:" + p1count);
        Console.WriteLine("Part 2:" + p2count);
    }
}
