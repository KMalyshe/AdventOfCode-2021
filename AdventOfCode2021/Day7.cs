using System.Collections.Generic;
using System;
using System.ComponentModel.Design;
class Day7 {

    public static void solve()
    {
        var input = new List<String>(File.ReadAllLines(@"C:\AoCFiles\21Day7.txt"));
        List<int> numberListInt = input[0].Split(",").Select(int.Parse).ToList();
        numberListInt.Sort();
        if (numberListInt.Count() % 2 == 1) 
        {
            int center = (int) numberListInt.Count() / 2;
            Console.WriteLine("Part 1: " + solveCenter(numberListInt, center));
        }
        else
        {
            int leftcenter = numberListInt.Count() / 2 - 1;
            int rightcenter = numberListInt.Count() / 2;
            Console.WriteLine("Part 1: " + Math.Min(solveCenter(numberListInt, leftcenter), solveCenter(numberListInt, rightcenter)));
        }
    }

    public static int solveCenter(List<int> numberList, int index)
    {
        int fuelCount = 0;
        for (int i = 0; i<numberList.Count(); i++)
        {
            if (i == index) continue;
            fuelCount += Math.Abs(numberList[i] - numberList[index]);
        }
        return fuelCount;
    }
}