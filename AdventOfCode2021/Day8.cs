using System.Globalization;

class Day8 {

    public static void solve()
    {
        var input = new List<String>(File.ReadAllLines(@"C:\AoCFiles\21Day8.txt"));
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

            // Get bottom segment by XOR-ing 4 and 9, since we know top segment
            var four = getChars(leftNumbers[2]);
            foreach (string number in leftNumbers)
            {
                if (number.Length != 6) continue;
                var fourSet = four.ToHashSet();
                var nineMaybe = getChars(number).ToHashSet();
                if (nineMaybe.Intersect(fourSet).ToHashSet().SetEquals(fourSet))
                {
                    fourSet.Add(wirings['a']);
                    wirings.Add('d', nineMaybe.Except(fourSet).ToList()[0]);
                }
            }


        }
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