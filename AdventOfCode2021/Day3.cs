using System.Globalization;
using System.Runtime.ExceptionServices;

class Day3 {

    public static void solve()
    {
        var input = new List<String>(File.ReadAllLines(@"C:\AoCFiles\21Day3.txt"));
        int[] tracker = new int[input[0].Length];
        for (int i = 0; i<input.Count(); i++)
        {
            for (int j = 0; j<input[i].Length; j++)
            {
                if (input[i][j] == '0') tracker[j] -= 1;
                else tracker[j] += 1;
            }
        }
        string str1 = "";
        string str2 = "";
        for (int i = 0; i<tracker.Length; i++)
        {
            if (tracker[i] < 0) 
            {
                str1 += "1"; str2 += "0";

            }
            else
            {
                str1 += "0"; str2 += "1";
            }
        }
        List<string> input2 = new List<string>(input);
        var balance2 = 0;
        var balance = 0;
        // Oxygen Calculation
        for (int i = 0; i<tracker.Length; i++) 
        // I don't see a way to do this shorter since the two lists have different sizes, unless calculation and filtering can be combined..
        {   
            for (int j = 0; j<input2.Count(); j++) //Oxygen Calculation
            {
                if (input2.Count() == 1) break;
                if (input2[j][i] == '1') balance2+=1;
                else balance2 -= 1;
            }
            for (int j = 0; j<input.Count(); j++) // CO2 Calculation
            {
                if (input.Count() == 1) break;
                if (input[j][i] == '1') balance+=1;
                else balance -= 1;
            }
            for (int j = 0; j<input2.Count(); j++) // Oxygen Filtering
            {
                if (input2.Count() == 1) break;
                if (balance2 >= 0)
                {
                    if (input2[j][i] == '0') input2[j] = "x";
                }
                else
                {
                    if (input2[j][i] == '1') input2[j] = "x";
                }
            }
            for (int j = 0; j<input.Count(); j++) // CO2 Filtering
            {
                if (input.Count() == 1) break;
                if (balance >= 0)
                {
                    if (input[j][i] == '1') input[j] = "x";
                }
                else
                {
                    if (input[j][i] == '0') input[j] = "x";
                }
            }
            balance2 = 0;
            balance = 0;
            input2.RemoveAll(x => x == "x");
            input.RemoveAll(x => x == "x");
        }
        Console.WriteLine("Part 1: " + Convert.ToInt32(str1, 2)*Convert.ToInt32(str2, 2));
        Console.WriteLine("Part 2: " + Convert.ToInt32(input[0], 2)*Convert.ToInt32(input2[0], 2));

    }
}