/*

Given two integer arrays, val and wt, each of size N, representing the values and weights of N items respectively, and an integer W, representing the maximum capacity of a knapsack, determine the maximum value achievable by selecting a subset of the items such that the total weight of the selected items does not exceed the knapsack capacity W. The goal is to maximize the sum of the values of the selected items while keeping the total weight within the knapsack's capacity.

An infinite supply of each item can be assumed.

Examples:
Input: val = [5, 11, 13], wt = [2, 4, 6], W = 10

Output: 27

Explanation: Select 2 items with weights 4 and 1 item with weight 2 for a total value of 11+11+5 = 27.

Input: val = [10, 40, 50, 70], wt = [1, 3, 4, 5], W = 8

Output: 110

Explanation: Select items with weights 3 and 5 for a total value of 40 + 70 = 110.

*/

class Solution {
    public int UnboundedKnapsack(int[] wt, int[] val, int n, int W) {
        int[,] dp = new int[n, W+1];

        for(int i=0; i<n; i++)
        {
            for(int j=0; j<=W; j++)
            {
                dp[i,j] = -1;
            }
        }
            
        return Solve(wt, val, n-1, W, dp);
    }

    private int Solve(int[] wt, int[] val, int index, int W, int[,] dp)
    {
        if(W == 0 || index == -1)
            return 0;

        if(dp[index, W] != -1)
        {
            return dp[index, W];
        }

        // Exclude
        int res1 = Solve(wt, val, index-1, W, dp);

        // Include
        int res2 = 0;
        if(wt[index] <= W)
        {
            res2 = val[index] + Solve(wt, val, index, W - wt[index], dp);
        }
        
        dp[index, W] = Math.Max(res1, res2);
        return dp[index, W];
    }
}
