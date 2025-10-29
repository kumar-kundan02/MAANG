/* 
Given two integer arrays, val and wt, each of size N, which represent the values 
and weights of N items respectively, and an integer W representing the maximum 
capacity of a knapsack, determine the maximum value achievable by selecting a subset 
of the items such that the total weight of the selected items does not exceed 
the knapsack capacity W.

Each item can either be picked in its entirety or not picked at all (0-1 property). 
The goal is to maximize the sum of the values of the selected items while keeping 
the total weight within the knapsack's capacity.

Examples:
Input: val = [60, 100, 120], wt = [10, 20, 30], W = 50
Output: 220

Explanation: Select items with weights 20 and 30 for a total value of 100 + 120 = 220.

Input: val = [10, 40, 30, 50], wt = [5, 4, 6, 3], W = 10
Output: 90

Explanation: Select items with weights 4 and 3 for a total value of 40 + 50 = 90.
*/

class Solution
{
    public int knapsack01(int[] wt, int[] val, int n, int W)
    {
        int[,] dp = new int[n+1, W+1];

        return Solve(wt, val,W, 0, dp);
    }

    private int Solve(int[] wt, int[] val, int cw, int pos, int[,] dp)
    {
        if(cw <= 0 || pos >= wt.Length)
            return 0;

        if(dp[pos,cw] != 0)
            return dp[pos,cw];

        int p1 = 0;
        if(cw >= wt[pos])
        {
            p1 = val[pos] + Solve(wt, val, cw-wt[pos], pos+1, dp);
        }

        int p2 = Solve(wt, val, cw, pos+1, dp);
        dp[pos, cw] = Math.Max(p1, p2); 

        return dp[pos,cw];
        
    }
}