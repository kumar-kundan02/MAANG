/*
Given an array, arr, of n integers, where arr[i] represents the price of the stock on an ith day, determine the maximum profit achievable by completing at most two transactions in total.



Holding at most one share of the stock at any time is allowed, meaning buying and selling the stock twice is permitted, but the stock must be sold before buying it again. Buying and selling the stock on the same day is allowed.


Examples:
Input: arr = [4, 2, 7, 1, 11, 5]

Output: 15

Explanation: Buy on day 2 (price = 2) and sell on day 3 (price = 7), profit = 7 - 2 = 5. Then buy on day 4 (price = 1) and sell on day 5 (price = 11), profit = 11 - 1 = 10. Total profit is 5 + 10 = 15.

Input: arr = [1, 3, 2, 8, 4, 9]

Output: 12

Explanation: Buy on day 1 (price = 1) and sell on day 4 (price = 8), profit = 8 - 1 = 7. Then buy on day 5 (price = 4) and sell on day 6 (price = 9), profit = 9 - 4 = 5. Total profit is 7 + 5 = 12.

Input: arr = [5, 7, 2, 10, 6, 9]

Output:
11
*/

class Solution {
    public int StockBuySell(int[] arr, int n)
    {
        int[,] dp = new int[n+1, 5];

        for(int i=0; i<n+1; i++)
        {
            for(int j=0; j<5; j++)
            {
                dp[i,j] = -1;
            }
        }
        return Solve(arr, 0, 0, dp);
    }

    private int Solve(int[] arr, int j, int c, int[,] dp)
    {
        if(c == 4 || j == arr.Length)
        {
          return 0;
        }

        if(dp[j,c] != -1) return dp[j,c];

        if(c % 2 == 0) // Buy
        {
            return dp[j,c] = Math.Max(-arr[j] + Solve(arr, j+1, c+1, dp), Solve(arr, j+1, c, dp));
        }
        else // Sell
        {
            return dp[j,c] = Math.Max(arr[j] + Solve(arr, j, c+1, dp), Solve(arr, j+1, c, dp));
        }
        
    }
}
