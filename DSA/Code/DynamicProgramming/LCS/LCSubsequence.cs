/*
Given two strings str1 and str2, find the length of their longest common subsequence.

A subsequence is a sequence that appears in the same relative order but not necessarily contiguous and a common subsequence of two strings is a subsequence that is common to both strings.

Examples:
Input: str1 = "bdefg", str2 = "bfg"

Output: 3

Explanation: The longest common subsequence is "bfg", which has a length of 3.

Input: str1 = "mnop", str2 = "mnq"

Output: 2

Explanation: The longest common subsequence is "mn", which has a length of 2.

*/

class Solution {
    public int Lcs(string str1, string str2)
    {
        int[,] dp = new int[str1.Length, str2.Length];
        for(int i=0; i<str1.Length; i++)
        {
            for(int j=0; j<str2.Length; j++)
            {
                dp[i,j] = -1;
            }
        }
        return LCS(str1, str2, 0, 0, dp);
    }

    private int LCS(string s1, string s2, int i, int j, int[,] dp)
    {
        if(s1.Length == i || s2.Length == j)
        {
            return 0;
        }

        if(dp[i,j] != -1)
            return dp[i,j];

        int res1 = 0, res2 = 0;
        if(s1[i] == s2[j])
        {
            res1 = 1 + LCS(s1, s2, i+1, j+1, dp);
        }
        else
        {
            res2 = Math.Max(LCS(s1, s2, i+1, j, dp), LCS(s1, s2, i, j+1, dp));
        }

        return dp[i,j] = Math.Max(res1, res2);
    }
}
