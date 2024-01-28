class Day5 {

    public static void solve()
    {
        var input = new List<String>(File.ReadAllLines(@"C:\AoCFiles\21Day5.txt"));
        List<int> leftSideX = new List<int>();
        List<int> rightSideX = new List<int>();
        List<int> leftSideY = new List<int>();
        List<int> rightSideY = new List<int>();
        HashSet<Tuple<int, int>> intersections = new HashSet<Tuple<int, int>>();
        List<Tuple<int, int>> outerSet = new List<Tuple<int, int>>();
        List<Tuple<int, int>> innerSet = new List<Tuple<int, int>>();
        for (int i = 0; i<input.Count(); i++)
        {
            leftSideX.Add(Int32.Parse(input[i].Split(" -> ")[0].Split(",")[0]));
            leftSideY.Add(Int32.Parse(input[i].Split(" -> ")[0].Split(",")[1]));
            rightSideX.Add(Int32.Parse(input[i].Split(" -> ")[1].Split(",")[0]));
            rightSideY.Add(Int32.Parse(input[i].Split(" -> ")[1].Split(",")[1]));
        }

        for (int i = 0; i<input.Count(); i++)
        {
            if ((leftSideX[i] != rightSideX[i]) && (leftSideY[i] != rightSideY[i])) // Part 1: continue;
            //Part 2:
            {
                var modifier = 0;
                if (leftSideX[i] < rightSideX[i])
                {
                    if (leftSideY[i] < rightSideY[i]) modifier = 1;
                    else modifier = -1;
                    for (int j = leftSideX[i]; j<=rightSideX[i]; j++) outerSet.Add((j, leftSideY[i]+((j-leftSideX[i])*modifier)).ToTuple());
                }
                else
                {
                    if (rightSideY[i] < leftSideY[i]) modifier = 1;
                    else modifier = -1;
                    for (int j = rightSideX[i]; j<=leftSideX[i]; j++) outerSet.Add((j, rightSideY[i]+((j-rightSideX[i])*modifier)).ToTuple());
                }
            }
            else 
            {
            // End part 2 exclusive
                for (int j = Math.Min(leftSideX[i], rightSideX[i]); j<=Math.Max(leftSideX[i], rightSideX[i]); j++)
                {
                    for (int k = Math.Min(leftSideY[i], rightSideY[i]); k<=Math.Max(leftSideY[i], rightSideY[i]); k++)
                    {
                        outerSet.Add((j, k).ToTuple());
                    }
                }
            }
            for (int j = i+1; j<input.Count(); j++)
            {
                if ((leftSideX[j] != rightSideX[j]) && (leftSideY[j] != rightSideY[j])) //Part 1: continue;
                // Part 2:
                {
                    var modifier = 0;
                    if (leftSideX[j] < rightSideX[j])
                    {
                        if (leftSideY[j] < rightSideY[j]) modifier = 1;
                        else modifier = -1;
                        for (int k = leftSideX[j]; k<=rightSideX[j]; k++) innerSet.Add((k, leftSideY[j]+((k-leftSideX[j])*modifier)).ToTuple());
                    }
                    else
                    {
                        if (rightSideY[j] < leftSideY[j]) modifier = 1;
                        else modifier = -1;
                        for (int k = rightSideX[j]; k<=leftSideX[j]; k++) innerSet.Add((k, rightSideY[j]+((k-rightSideX[j])*modifier)).ToTuple());
                    }
                }
                else
                {
                // End part 2 exclusive
                    for (int k = Math.Min(leftSideX[j], rightSideX[j]); k<=Math.Max(leftSideX[j], rightSideX[j]); k++)
                    {
                        for (int l = Math.Min(leftSideY[j], rightSideY[j]); l<=Math.Max(leftSideY[j], rightSideY[j]); l++)
                        {
                            innerSet.Add((k, l).ToTuple());
                        }
                    }
                }
                HashSet<Tuple<int, int>> outInIntersect = outerSet.Intersect(innerSet).ToHashSet();
                intersections.UnionWith(outInIntersect);
                innerSet.Clear();
            }
            outerSet.Clear();
        }
        Console.WriteLine("Part 1: " + intersections.Count());
    }
}