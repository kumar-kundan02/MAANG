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
        int[,] dp = new int[m+1, n+1];

        // Initialize Base case
        // if "t" is empty then there will be only one subsequence length i.e empty
        // if "s" is empty it means there is zero subsequence possible
        // i.e if len(s) == 0 then dp[0,j] = 0
        // if len(t) == 0 then dp[i,0] = 1. considering empty case

        for(int i=0; i<=m; i++)
        {
            dp[i,0] = 1;
        }

        // No need of this initialization as by default its zero only
        // Need to start with 1 as if both are of zero length then empty should be common to both so, it won't be zero  but one
        for(int j=1; j<=n; j++)
        {
            dp[0,j] = 0;
        }

        for(int i=1; i<=m; i++)
        {
            for(int j=1; j<=n; j++)
            {
                if(s[i-1] == t[j-1])
                {
                    dp[i,j] = (dp[i-1, j-1] % MOD + dp[i-1, j] % MOD) % MOD;
                }
                else
                {
                    dp[i,j] = dp[i-1, j] % MOD;
                }
            }
        } 

        return dp[m,n];
    }
}