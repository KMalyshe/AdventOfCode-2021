using System.Globalization;
using System.Diagnostics;

class Day8 {

    public static void solve()
    {
        var watch = new Stopwatch();
        watch.Start();
        var input = new List<String>(File.ReadAllLines(@"C:\AoCFiles\21Day8.txt"));
        var total = 0;
        foreach (string line in input)
        {
            var delimitSplit = line.Split(" | ");
            string left = delimitSplit[0];
            string right = delimitSplit[1];
            var leftNumbers = left.Split(" ").ToList();
            var rightNumbers = right.Split(" ").ToList();
            leftNumbers.Sort((a, b) => a.Length.CompareTo(b.Length)); // make sure 1 is first, 7 is second, etc
            Dictionary<char, char> wirings = new Dictionary<char, char>();

            // Get top segment by XOR-ing one and seven
            var one = getChars(leftNumbers[0]);
            var seven = getChars(leftNumbers[1]);
            wirings.Add('a', seven.Except(one).ToList()[0]);
            // Using this segment assignment: https://en.wikipedia.org/wiki/Seven-segment_display#/media/File:7_Segment_Display_with_Labeled_Segments.svg

            // Get bottom segment by XOR-ing 4 and 9, since we know top segment
            var four = getChars(leftNumbers[2]);
            var fourSet = four.ToHashSet();
            foreach (string number in leftNumbers)
            {
                if (number.Length != 6) continue;
                var nineMaybe = getChars(number).ToHashSet();
                if (nineMaybe.Intersect(fourSet).ToHashSet().SetEquals(fourSet))
                {
                    fourSet.Add(wirings['a']);
                    wirings.Add('d', nineMaybe.Except(fourSet).ToList()[0]);
                }
            }

            // Get bottom left segment by XOR-ing 4+top+bottom and 8
            var eightSet = getChars(leftNumbers.Last()).ToHashSet();
            fourSet = four.ToHashSet();
            fourSet.Add(wirings['a']);
            fourSet.Add(wirings['d']);
            wirings.Add('e', eightSet.Except(fourSet).ToList()[0]);

            // Get middle segment by XOR-ing 7+bottom and 3
            var sevenSet = seven.ToHashSet();
            sevenSet.Add(wirings['d']);
            foreach (string number in leftNumbers)
            {
                if (number.Length != 5) continue;
                var threeMaybe = getChars(number).ToHashSet();
                if (threeMaybe.Intersect(sevenSet).ToHashSet().SetEquals(sevenSet))
                {
                    wirings.Add('g', threeMaybe.Except(sevenSet).ToList()[0]);
                }
            }

            // Get top left segment by XOR-ing 1+middle and 4
            fourSet = four.ToHashSet();
            var oneSet = one.ToHashSet();
            oneSet.Add(wirings['g']);
            wirings.Add('f', fourSet.Except(oneSet).ToList()[0]);

            // Get bottom right segment by checking which element of 1 appears in 2
            var whichNotAdded = 1;
            foreach (string number in leftNumbers)
            {
                if (number.Length != 5) continue;
                var twoMaybe = getChars(number).ToHashSet();
                if (twoMaybe.Contains(wirings['e']) && twoMaybe.Contains(wirings['g'])) // only 2 contains bottom left and middle
                {
                    if (twoMaybe.Contains(one[0]))
                    {
                        wirings.Add('c', one[1]);
                        whichNotAdded = 0;
                    }
                    else 
                    {
                        wirings.Add('c', one[0]);
                    }
                }
            }

            // Get top right segment through process of elimination
            wirings.Add('b', one[whichNotAdded]);

            var concatenation = "";
            foreach (string number in rightNumbers)
            {
                var numChars = getChars(number);
                if (number.Length == 2) concatenation += "1";
                else if (number.Length == 3) concatenation += "7";
                else if (number.Length == 4) concatenation += "4";
                else if (number.Length == 7) concatenation += "8";
                else if (number.Length == 5)
                {
                    if (numChars.Contains(wirings['f'])) concatenation += "5";
                    else if (numChars.Contains(wirings['e'])) concatenation += "2";
                    else concatenation += "3";
                }
                else
                {
                    if (!numChars.Contains(wirings['g'])) concatenation += "0";
                    else if (numChars.Contains(wirings['e'])) concatenation += "6";
                    else concatenation += "9";
                }
            }
            total += Int32.Parse(concatenation);


        }
        
        Console.WriteLine(total);
        watch.Stop();
        Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms"); // about 18ms
        /* Part 1
        var counter = 0;
        foreach (string line in rightSide)
        {
            var numbers = line.Split(" ").ToList();
            foreach (string number in numbers)
            {
                if (((number.Length >= 2) && (number.Length <= 4)) || number.Length == 7) counter++;
            }
        }
        Console.WriteLine(counter);
        */
    }
    public static List<char> getChars(string str)
    {
        List<char> returnList = new List<char>();
        for (int i = 0; i<str.Length; i++)
        {
            returnList.Add(str[i]);
        }
        return returnList;
    }
}