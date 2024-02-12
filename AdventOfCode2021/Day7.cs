using System.Collections.Generic;
using System;
using System.ComponentModel.Design;
class Day7 {

    public static void solve()
    {
        var input = new List<String>(File.ReadAllLines(@"C:\AoCFiles\21Day7.txt"));
        List<int> numberListInt = input[0].Split(",").Select(int.Parse).ToList();
        numberListInt.Sort();
        /* Part 1, just grab median lol
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
        */
        Console.WriteLine(solveCenter(numberListInt));
    }

    //Part 1: public static int solveCenter(List<int> numberList, int index), just add the steps converging on index calculated above
    public static int solveCenter(List<int> numberList)
    {
        Dictionary<int, int> stepList = new Dictionary<int, int>();
        stepList.Add(0, 0);
        for (int i = 1; i<numberList.Last() - numberList[0]+1; i++) // weird rounding issues doing it in the loop below, so i just made a bruteforce step list instead
        // i am aware of triangular number = n*(n+1)/2, but code didnt work with that, maybe bug issue, maybe rounding issue, i dont know
        {
            stepList.Add(i, stepList[i-1] + i);
        }
        int leastFuel = Int32.MaxValue;
        var fuelCount = 0;
        for (int i = 0; i<numberList.Last()+1; i++)
        {
            for (int j = 0; j<numberList.Count(); j++)
            {
                fuelCount += stepList[Math.Abs(numberList[j] - i)];
            }
            leastFuel = Math.Min(leastFuel, fuelCount);
            fuelCount = 0;
        }
        return leastFuel;
    }
}