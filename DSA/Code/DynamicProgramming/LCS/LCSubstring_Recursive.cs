/*

Given two strings str1 and str2, find the length of their longest common substring.

A substring is a contiguous sequence of characters within a string.

Examples:
Input: str1 = "abcde", str2 = "abfce"

Output: 2

Explanation: The longest common substring is "ab", which has a length of 2.

Input: str1 = "abcdxyz", str2 = "xyzabcd"

Output: 4

Explanation: The longest common substring is "abcd", which has a length of 4.

*/

class Solution
{
    public int longestCommonSubstr(string str1, string str2)
    {
        int[,,] dp = new int[str1.Length+1, str2.Length+1, Math.Min(str1.Length, str2.Length)+1];

        for(int i=0; i<=str1.Length; i++)
        {
            for(int j=0; j<=str2.Length; j++)
            {
                for(int k=0; k<= Math.Min(str1.Length, str2.Length); k++)
                {
                    dp[i,j,k] = -1;
                }
            }
        }
        return Solve(str1, str2, str1.Length-1, str2.Length-1, 0, dp);
    }

    private int Solve(string s1, string s2, int i, int j, int count, int[,,] dp)
    {
        if(i < 0 || j < 0)
        {
            return count;
        }

        if(dp[i,j,count] != -1) return dp[i,j,count];

        int res1 = 0;
        if(s1[i] == s2[j])
        {
            // Since we need to reset the sum if s[i] != s[j] so,
            // we are passing the count and incrementing in Param as
            // if I would have done it like "res1 = 1 + Solve(s1, s2, i-1, j-1)" then,
            // It will try to find the other solution there onwards with existing length
            // However it would work for Subsequence but not for substring
            // As for Substring we always need to reset the length if chars are not same
            res1 = Solve(s1, s2, i-1, j-1, count+1, dp); 
        }

        int res2 = Math.Max(Solve(s1, s2, i, j-1, 0, dp), Solve(s1, s2, i-1, j, 0, dp));
        return dp[i,j,count] = Math.Max(count, Math.Max(res1, res2));
    }
}