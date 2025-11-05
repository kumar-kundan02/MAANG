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

Input: str1 = "abcdef", str2 = "ghijkl"

Output:
0
*/

class Solution
{
    public int longestCommonSubstr(string str1, string str2)
    {
        int m = str1.Length;
        int n = str2.Length;

        int[,] dp = new int [m+1,n+1];
        int maxLength = 0;

        // Here in indexes we are considering the length of substring 
        // That's why we are taking the startin index for i and j as "1"
        // But while comparing the string taking "i-1 and j-1" as in string it will work on Array based index
        for(int i=1; i<=m; i++)
        {
            for(int j=1; j<=n; j++)
            {
                if(str1[i-1] == str2[j-1])
                {
                    dp[i,j] = 1 + dp[i-1,j-1];
                }
                else
                {
                    dp[i,j] = 0;
                }

                maxLength = Math.Max(maxLength, dp[i,j]);
            }
        }

        return maxLength;
    }
}
