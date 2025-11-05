/*
Given two strings s and t, return the number of distinct subsequences of s that equal t.

A subsequence of a string is a new string generated from the original string with some characters (can be none) deleted without changing the relative order of the remaining characters. For example, "ace" is a subsequence of "abcde" while "aec" is not.

The task is to count how many different ways we can form t from s by deleting some (or no) characters from s. Return the result modulo 109+7.

Examples:
Input: s = "axbxax", t = "axa"

Output: 2

Explanation: In the string "axbxax", there are two distinct subsequences "axa":

(a)(x)bx(a)x

(a)xb(x)(a)x

Input: s = "babgbag", t = "bag"

Output: 5

Explanation: In the string "babgbag", there are five distinct subsequences "bag":

(ba)(b)(ga)(g)

(ba)(bg)(ag)

(bab)(ga)(g)

(bab)(g)(ag)

(babg)(a)(g)
*/

public class Solution
{
    private const int MOD = 1000000007;
    public int DistinctSubsequences(string s, string t)
    {
      int m = s.Length, n = t.Length;
        int[,] dp = new int[m, n];

        for(int i=0; i<m; i++)
        {
          for(int j=0; j<n; j++)
          {
            dp[i,j] = -1;
          }
        }
        return Solve(s, t, 0, 0, dp);
    }

    private int Solve(string s, string t, int i, int j, int[,] dp)
    {
       if(t.Length == j)
       {
          return 1;
       }

       if(s.Length == i)
       {
          return 0;
       }

       if(dp[i,j] != -1) return dp[i,j];

        if(s[i] == t[j])
        {
          // Need to add both the condition pick and not pick as we need to find all the subsequences
          return dp[i,j] = (Solve(s, t, i+1, j+1, dp) % MOD + Solve(s, t, i+1, j, dp) % MOD) % MOD;
        }
        else
        {
          return dp[i,j] = Solve(s, t, i+1, j, dp) % MOD;
        }
    }
}