/*

Given a rod of length N inches and an array price[] where price[i] denotes the value of a piece of rod of length i inches (1-based indexing). Determine the maximum value obtainable by cutting up the rod and selling the pieces. Make any number of cuts, or none at all, and sell the resulting pieces.

Examples:
Input: price = [1, 6, 8, 9, 10, 19, 7, 20], N = 8

Output: 25

Explanation: Cut the rod into lengths of 2 and 6 for a total price of 6 + 19= 25.

Input: price = [1, 5, 8, 9], N = 4

Output: 10

Explanation: Cut the rod into lengths of 2 and 2 for a total price of 5 + 5 = 10.

*/

class Solution
{
    public int RodCutting(int[] price, int n)
    {
        // Initialize with "price.Length+1" instead of just "price.Length"
        // As we need to deal with "1" based index for price Array
        int[,] dp = new int[price.Length+1, n+1];

        for(int i=0; i <= price.Length; i++)
        {
            for(int j=0; j<=n; j++)
            {
                dp[i,j] = -1;
            }
        }

        return Solve(price, n, price.Length, dp);
    }

    private int Solve(int[] price, int n, int index, int[,] dp)
    {
        if(n == 0 || index == 0)
            return 0;

        if(dp[index, n] != -1)
            return dp[index, n];

        // Exclude
        int res1 = Solve(price, n, index-1, dp);

        // include

        // Note: Considering the 1 based index for Price Array but in actual it always stars from zero
        // So, To get actual price just use "price[index-1]" instead of price[index]
        // Index will refer "1" based as need to compute with "n" but price will refer "0" based as C# array are Zero based
        int res2 = 0;
        if(index <= n)
        {
            res2 = price[index-1] + Solve(price, n-index, index, dp);
        }

        dp[index, n] = Math.Max(res1, res2);
        return dp[index, n];
    }
}