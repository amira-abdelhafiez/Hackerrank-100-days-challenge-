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
     * Complete the 'nonDivisibleSubset' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER k
     *  2. INTEGER_ARRAY s
     */

    public static int nonDivisibleSubset(int k, List<int> s)
    {
        int maxSubsetLength = 0;
        int[] remaindersCnt = new int[k];
        foreach(int num in s){
            remaindersCnt[num%k]++;
        }
        for(int i = 0; i <= (k/2) ; i++){
            if(i == 0){
                maxSubsetLength += Math.Min(remaindersCnt[0], 1);
            }else if(k%2 == 0 && i == k/2){
                maxSubsetLength += Math.Min(remaindersCnt[i], 1);
            }else{
                maxSubsetLength += Math.Max(remaindersCnt[i], remaindersCnt[k-i]);
            }
        }
        
        return maxSubsetLength;
    }

}

class Solution
{
    public static void Main(string[] args)
    {

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int k = Convert.ToInt32(firstMultipleInput[1]);

        List<int> s = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList();

        int result = Result.nonDivisibleSubset(k, s);

        Console.WriteLine(result);

    }
}
