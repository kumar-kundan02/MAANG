/*
Given a string s, find the minimum number of insertions needed to make it a palindrome. A palindrome is a sequence that reads the same backward as forward. You can insert characters at any position in the string.

Examples:
Input: s = "abcaa"

Output: 2

Explanation: Insert 2 characters "c", and "b" to make "abcacba", which is a palindrome.

Input: s = "ba"

Output: 1

Explanation: Insert "a" at the beginning to make "aba", which is a palindrome.

*/

class Solution
{

    // If we Subtract the length of longest common subsequence from 
    // Actual string length then we will get the minimum count of insertions
    // Intution : Keep the Exixting palindromic Sequence intact and then for existing which are not part of 
    // Palindromic subsequence then these needs to be added at other places to make the complete string Palindrome

    public int minInsertion(string s)
    {
        char[] rev_arr = s.ToCharArray();
        Array.Reverse(rev_arr);
        string s_rev = new string(rev_arr);

        return s.Length - LCS(s, s_rev);
    }

    private int LCS(string s1, string s2)
    {
        int m = s1.Length;

        int[,] dp = new int[m+1, m+1];

        for(int i=1; i<=m; i++)
        {
            for(int j=1; j<=m; j++)
            {
                if(s1[i-1] == s2[j-1])
                {
                    dp[i,j] = 1 + dp[i-1, j-1];
                }
                else
                {
                    dp[i,j] = Math.Max(dp[i-1, j], dp[i, j-1]);
                }
            }
        }

        return dp[m,m];
    }
}
