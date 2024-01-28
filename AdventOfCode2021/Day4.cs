using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography.X509Certificates;

class Day4 {

    public static void solve()
    {
        var input = new List<String>(File.ReadAllLines(@"C:\AoCFiles\21Day4.txt"));
        var bingoboards = new List<List<List<string>>>();
        var boardnum = -1;
        var boardline = 0;
        for (int i = 2; i<input.Count(); i++)
        {
            if (i % 6 == 1) continue;
            if (i % 6 == 2) 
            {
                boardnum += 1;
                bingoboards.Add(new List<List<string>>());
                boardline = 0;
            }
            bingoboards[boardnum].Add(input[i].Split(" ").ToList());
            bingoboards[boardnum][boardline].RemoveAll(x => (x == " ") || ( x == "") || (x == "  "));
             // Lazy solution to get rid of extra elements after split due to double spaces
            boardline += 1;
        }
        var drawNumber = input[0].Split(",");
        var winnerfound = (0, 0);
        var markCounter = 0;
        var winTracker = new int[boardnum+1];

        for (int i = 0; i<drawNumber.Length; i++) // Iterate through bingo numbers
        {
            for (int board = 0; board<bingoboards.Count(); board++) // For each board
            {
                if (winTracker[board] == 1) continue; // Just a bit faster, dont iterate over dead boards
                for (int linenum = 0; linenum<5; linenum++) // For each row on the board
                {
                    for (int num = 0; num<5; num++) // For each number in the row
                    {
                        if (bingoboards[board][linenum][num] == drawNumber[i]) // If the current number corresponds to the bingo number
                        {
                            bingoboards[board][linenum][num] = "X";
                            for (int j = 0; j<5; j++) 
                            { // Row
                                if (bingoboards[board][linenum][j] == "X") markCounter+= 1;
                            }
                            if (markCounter != 5) markCounter = 0;
                            for (int j = 0; j<5; j++)
                            { // Column
                                if (markCounter == 5) break;
                                if (bingoboards[board][j][num] == "X") markCounter+= 1;
                            }
                            if (markCounter == 5) {
                                /* Part One
                                winnerfound = (board, Convert.ToInt32(drawNumber[i]));
                                goto SearchEnd;
                                */
                                // Part 2 only
                                winTracker[board] = 1;
                            }
                            markCounter = 0; 
                            // Part 2 relevant:
                            var testSet = new HashSet<int>(winTracker);
                            if (testSet.Count == 1 && testSet.Contains(1))
                            {
                                winnerfound = (board, Convert.ToInt32(drawNumber[i]));
                                goto SearchEnd;
                            }
                            // End of Part 2 stuff
                        }
                    }
                }
            }
        }
        SearchEnd:
            var sum = 0;
            for (int i = 0; i<5; i++) 
            {
                for (int j = 0; j<5; j++)
                {   
                    var currentNumber = bingoboards[winnerfound.Item1][i][j];
                    if (currentNumber != "X") sum += Convert.ToInt32(currentNumber);
                }
            }
            Console.WriteLine("Result: " + sum*winnerfound.Item2);
    }
}