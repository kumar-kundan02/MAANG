/*

Given two strings start and target, you need to determine the minimum number of operations required to convert the string start into the string target. The operations you can use are:

Insert a character: Add any single character at any position in the string.

Delete a character: Remove any single character from the string.

Replace a character: Change any single character in the string to another character.

The goal is to transform start into target using the fewest number of these operations.

Examples:
Input: start = "planet", target = "plan"

Output: 2

Explanation: 

To transform "planet" into "plan", the following operations are required:

1. Delete the character 'e': "planet" -> "plan"

2. Delete the character 't': "plan" -> "plan"

Thus, a total of 2 operations are needed.

Input: start = "abcdefg", target = "azced"

Output: 4

Explanation: 

To transform "abcdefg" into "azced", the following operations are required:

1. Replace 'b' with 'z': "abcdefg" -> "azcdefg"

2. Delete 'd': "azcdefg" -> "azcefg"

3. Delete 'f': "azcefg" -> "azceg"

4. Replace 'g' with 'd': "azceg" -> "azced"

Thus, a total of 4 operations are needed.
*/

class Solution
{
    public int editDistance(string start, string target)
    {
        // Wrong Approach: Find LCS count
        // Now apply formula : ans = (start.Length - lcs) - (target.Length - lcs) XXXXX (Noooo, it won't work)

        // Correct Approach
        // Consider all the operations and then take minimum
        // No need to do the actual changes like insert/update/delete
        // But just simulate the scenarios and update the index values

        int m = start.Length, n = target.Length;
        int[,] dp = new int[m+1, n+1];

        // Initialize as if target.Length == 0 then need to remove all chars in start. hence dp[i,0] = i
        for(int i=0; i<=m; i++) {
            dp[i,0] = i;
        }

        // Initialize as if start.Length == 0 then need to remove all chars in target. hence dp[0,i] = i
        for(int i=1; i<=n; i++) {
            dp[0,i] = i;
        }

        for(int i=1; i<=m; i++)
        {
            for(int j=1; j<=n; j++)
            {
                if(start[i-1] == target[j-1])
                {
                    dp[i,j] = dp[i-1, j-1];
                }
                else
                {
                    dp[i,j] = 1 + Math.Min(dp[i,j-1], Math.Min(dp[i-1, j], dp[i-1, j-1]));
                } 
            }
        }

        return dp[m,n];
    }
}