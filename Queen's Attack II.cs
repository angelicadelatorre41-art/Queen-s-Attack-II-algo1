using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'queensAttack' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER k
     *  3. INTEGER r_q
     *  4. INTEGER c_q
     *  5. 2D_INTEGER_ARRAY obstacles
     */

    public static int queensAttack(int n, int k, int r_q, int c_q, List<List<int>> obstacles)
    {
    int left = c_q - 1;
    int right = n - c_q;
    int up = n - r_q;
    int down = r_q - 1;
    int upLeft = Math.Min(up, left);
    int upRight = Math.Min(up, right);
    int downLeft = Math.Min(down, left);
    int downRight = Math.Min(down, right);

    HashSet<(int, int)> obsSet = new HashSet<(int, int)>();
    foreach (var ob in obstacles)
    {
        obsSet.Add((ob[0], ob[1]));
    }

    for (int i = 1; i <= n; i++)
    {
        if (obsSet.Contains((r_q + i, c_q))) { up = i - 1; break; }
    }
    for (int i = 1; i <= n; i++)
    {
        if (obsSet.Contains((r_q - i, c_q))) { down = i - 1; break; }
    }
    for (int i = 1; i <= n; i++)
    {
        if (obsSet.Contains((r_q, c_q + i))) { right = i - 1; break; }
    }
    for (int i = 1; i <= n; i++)
    {
        if (obsSet.Contains((r_q, c_q - i))) { left = i - 1; break; }
    }
    for (int i = 1; i <= n; i++)
    {
        if (obsSet.Contains((r_q + i, c_q + i))) { upRight = i - 1; break; }
    }
    for (int i = 1; i <= n; i++)
    {
        if (obsSet.Contains((r_q + i, c_q - i))) { upLeft = i - 1; break; }
    }
    for (int i = 1; i <= n; i++)
    {
        if (obsSet.Contains((r_q - i, c_q + i))) { downRight = i - 1; break; }
    }
    for (int i = 1; i <= n; i++)
    {
        if (obsSet.Contains((r_q - i, c_q - i))) { downLeft = i - 1; break; }
    }

    return up + down + left + right + upLeft + upRight + downLeft + downRight;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int k = Convert.ToInt32(firstMultipleInput[1]);

        string[] secondMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int r_q = Convert.ToInt32(secondMultipleInput[0]);

        int c_q = Convert.ToInt32(secondMultipleInput[1]);

        List<List<int>> obstacles = new List<List<int>>();

        for (int i = 0; i < k; i++)
        {
            obstacles.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(obstaclesTemp => Convert.ToInt32(obstaclesTemp)).ToList());
        }

        int result = Result.queensAttack(n, k, r_q, c_q, obstacles);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
