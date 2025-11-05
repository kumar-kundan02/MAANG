/*

Given a string, Find the longest palindromic subsequence length in given string.

A palindrome is a sequence that reads the same backwards as forward.

A subsequence is a sequence that can be derived from another sequence by deleting some or no elements without changing the order of the remaining elements.


Examples:
Input: s = "eeeme"

Output: 4

Explanation: The longest palindromic subsequence is "eeee", which has a length of 4.

Input: s = "annb"

Output: 2

Explanation: The longest palindromic subsequence is "nn", which has a length of 2.

*/

class Solution {
    public int LongestPalinSubseq(string s) {
      
      // We just need to reverse the string and then apply LCS 
      // It will give longest Palindrome as after reversal it should be same only
      
      char[] rev_arr = s.ToCharArray();
      Array.Reverse(rev_arr);
      string rev_s = new string(rev_arr);

      return LCS(s, rev_s);
    }

    private int LCS(string s1, string s2)
    {
        int m = s1.Length, n = s2.Length;
        int[,] dp = new int[m+1, n+1];

        int maxLength = 0;

        for(int i=1; i<=m; i++)
        {
            for(int j=1; j<=n; j++)
            {
                if(s1[i-1] == s2[j-1])
                {
                    dp[i,j] = 1 + dp[i-1, j-1];
                }
                else
                {
                    dp[i,j] = Math.Max(dp[i, j-1], dp[i-1, j]);
                }

                maxLength = Math.Max(dp[i,j], maxLength);
            }
        }
        return maxLength;
    }
}
