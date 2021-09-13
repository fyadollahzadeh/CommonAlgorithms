using System;
using System.Collections.Generic;
using System.Linq;

namespace DynamicProgramming.LCS
{
    class Program
    {
        static void Main(string[] args)
        {
            var res = FindLCS("stone".ToCharArray(), "longest".ToCharArray());
            Console.WriteLine("longest common subsequence is : {0}", string.Join(',',res.lcs));
        }

        public static (int lcsLength,List<char> lcs) FindLCS(char[] first,char[] second)
        {
            (int lcsLength, List<char> lcs) result = new (0, "".ToList());            
            var shorterArray = first.Length > second.Length ? second : first;
            var longerArray = first.Length < second.Length ? second : first;
            int[,] LCS = new int[longerArray.Length+1, shorterArray.Length+1];
            for (int i = 1; i <= longerArray.Length; i++)
            {
                for (int j = 1; j <= shorterArray.Length; j++)
                {
                    if (longerArray[i-1]== shorterArray[j-1])
                    {
                        LCS[i,j] = 1 + LCS[i - 1,j - 1];
                    }
                    else
                    {
                        LCS[i,j] = Math.Max(LCS[i - 1,j], LCS[i,j - 1]);
                    }
                }
            }


            result.lcsLength = LCS.Cast<int>().Max();
            for (int i = longerArray.Length; i >= 1; i--)
            {
                for (int j = shorterArray.Length; j >= 1; j--)
                {
                    if (Math.Max(LCS[i - 1, j], LCS[i, j - 1]) < LCS[i,j])
                    {
                        result.lcs.Add(shorterArray[j-1]);
                    }
                    else
                    {
                        LCS[i, j] = Math.Max(LCS[i - 1, j], LCS[i, j - 1]);
                    }
                }
            }
            result.lcs.Reverse();
            return result;
        }
    }
}
