using System.Globalization;
using System.Runtime.ExceptionServices;

class Day3 {

    public static void solve()
    {
        var input = new List<String>(File.ReadAllLines(@"C:\AoCFiles\21Day3.txt"));
        int[] occurenceWeighting = new int[input[0].Length]; 
        for (int i = 0; i<input.Count(); i++)
        {
            for (int j = 0; j<input[i].Length; j++) 
            {
                if (input[i][j] == '0') occurenceWeighting[j] -= 1;
                else occurenceWeighting[j] += 1;
            }
        }
        // occurenceWeighting:
        // If positive: More 1s, If 0: Equal, If <0: More 0s
        string binaryNumber1 = "";
        string binaryNumber2 = "";
        for (int i = 0; i<occurenceWeighting.Length; i++)
        {
            if (occurenceWeighting[i] < 0) 
            {
                binaryNumber1 += "1"; binaryNumber2 += "0";

            }
            else
            {
                binaryNumber1 += "0"; binaryNumber2 += "1";
            }
        }
        List<string> oxygenInputCopy = new List<string>(input);
        var oxygenOccurenceWeighting = 0;
        var co2OcurrenceWeighting = 0;
        // Oxygen Calculation
        for (int i = 0; i<occurenceWeighting.Length; i++) 
        // I don't see a way to do this shorter since the two lists have different sizes, unless calculation and filtering can be combined..
        {   
            for (int j = 0; j<oxygenInputCopy.Count(); j++) //Oxygen Calculation
            {
                if (oxygenInputCopy.Count() == 1) break;
                if (oxygenInputCopy[j][i] == '1') oxygenOccurenceWeighting+=1;
                else oxygenOccurenceWeighting -= 1;
            }
            for (int j = 0; j<input.Count(); j++) // CO2 Calculation
            {
                if (input.Count() == 1) break;
                if (input[j][i] == '1') co2OcurrenceWeighting+=1;
                else co2OcurrenceWeighting -= 1;
            }
            for (int j = 0; j<oxygenInputCopy.Count(); j++) // Oxygen Filtering
            {
                if (oxygenInputCopy.Count() == 1) break;
                if (oxygenOccurenceWeighting >= 0)
                {
                    if (oxygenInputCopy[j][i] == '0') oxygenInputCopy[j] = "x";
                }
                else
                {
                    if (oxygenInputCopy[j][i] == '1') oxygenInputCopy[j] = "x";
                }
            }
            for (int j = 0; j<input.Count(); j++) // CO2 Filtering
            {
                if (input.Count() == 1) break;
                if (co2OcurrenceWeighting >= 0)
                {
                    if (input[j][i] == '1') input[j] = "x";
                }
                else
                {
                    if (input[j][i] == '0') input[j] = "x";
                }
            }
            oxygenOccurenceWeighting = 0;
            co2OcurrenceWeighting = 0;
            oxygenInputCopy.RemoveAll(x => x == "x");
            input.RemoveAll(x => x == "x");
        }
        Console.WriteLine("Part 1: " + Convert.ToInt32(binaryNumber1, 2)*Convert.ToInt32(binaryNumber2, 2));
        Console.WriteLine("Part 2: " + Convert.ToInt32(input[0], 2)*Convert.ToInt32(oxygenInputCopy[0], 2));

    }
}