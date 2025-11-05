/*
Given two strings str1 and str2, find the minimum number of insertions and deletions in string str1 required to transform str1 into str2.

Insertion and deletion of characters can take place at any position in the string.

Examples:
Input: str1 = "kitten", str2 = "sitting"

Output: 5

Explanation: To transform "kitten" to "sitting", delete "k" and insert "s" to get "sitten", then insert "i" to get "sittin", and insert "g" at the end to get "sitting".

Input: str1 = "flaw", str2 = "lawn"

Output: 2

Explanation: To transform "flaw" to "lawn", delete "f" and insert "n" at the end. Hence minimum number of operations required is 2".
*/

class Solution
{
    public int minOperations(string str1, string str2)
    {
        int lcs = LCS(str1, str2);

        // if we take the difference of lcs with str1.Length and str2.Length and Add them
        // It will give total insert/delete count as these are extra elements other than LCS
        // So, To convert we need to do all these insert and delete operations
        return str1.Length - lcs + str2.Length - lcs;
    }

    private int LCS(string str1, string str2)
    {
        int m = str1.Length, n = str2.Length;
        int[,] dp = new int[m+1, n+1];

        for(int i=1; i<=m; i++)
        {
            for(int j=1; j<=n; j++)
            {
                if(str1[i-1] == str2[j-1])
                {
                    dp[i,j] = 1 + dp[i-1, j-1];
                }
                else
                {
                    dp[i,j] = Math.Max(dp[i,j-1], dp[i-1, j]);
                }
            }
        }

        return dp[m,n];
    }
}