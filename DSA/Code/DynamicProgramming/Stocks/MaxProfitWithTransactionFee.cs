/*
Given an array arr where arr[i] represents the price of a given stock on the ith day. Additionally, you are given an integer fee representing a transaction fee for each trade. The task is to determine the maximum profit you can achieve such that you need to pay a transaction fee for each buy and sell transaction. The Transaction Fee is applied when you sell a stock.

You may complete as many transactions. You may not engage in multiple transactions simultaneously (i.e., you must sell the stock before buying again).


Examples:
Input: arr = [1, 3, 4, 0, 2], fee = 1

Output: 3

Explanation: Buy at day 1, sell at day 3, then, buy at day 4, sell at day 5.

Profit calculation: ((4 - 1) - 1) + ((2 - 0) - 1) = 2 + 1 = 3.

Input: arr = [1, 3, 2, 8, 4, 9], fee = 2

Output: 8

Explanation: Buy at day 1 (price = 1), sell at day 4 (price = 8), then Buy at day 5 (price = 4), sell at day 6 (price = 9),

Profit calculation: ((9 - 4) - 2) + ((8 - 1) - 2)= 8.
*/

public class Solution
{
    public int stockBuySell(int[] arr, int n, int fee)
    {
        // Your code goes here
        int[,] dp = new int[n, 2];

        for(int i=0; i<n; i++)
        {
            dp[i,0] = -1;
            dp[i,1] = -1;
        }
        return Solve(arr, fee, 0, 0, dp);
    }

    private int Solve(int[] arr, int fee, int buy, int i, int[,] dp)
    {
        if(i == arr.Length)
        {
            return 0;
        }

        if(dp[i,buy] != -1) return dp[i,buy];

        if(buy  == 0)
        {
            return dp[i, buy] = Math.Max(-arr[i] + Solve(arr, fee, 1, i+1, dp), Solve(arr, fee, 0, i+1, dp));
        }
        else
        {
            return dp[i,buy] = Math.Max(arr[i]-fee + Solve(arr, fee, 0, i, dp), Solve(arr, fee, 1, i+1, dp));
        }
    }
}