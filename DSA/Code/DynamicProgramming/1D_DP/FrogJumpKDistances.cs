/*
A frog wants to climb a staircase with n steps. Given an integer array heights, where heights[i] contains the height of the ith step, and an integer k.

To jump from the ith step to the jth step, the frog requires abs(heights[i] - heights[j]) energy, where abs() denotes the absolute difference. The frog can jump from the ith step to any step in the range [i + 1, i + k], provided it exists.

Return the minimum amount of energy required by the frog to go from the 0th step to the (n-1)th step.

Examples:
Input: heights = [10, 5, 20, 0, 15], k = 2

Output: 15

Explanation:

0th step -> 2nd step, cost = abs(10 - 20) = 10

2nd step -> 4th step, cost = abs(20 - 15) = 5

Total cost = 10 + 5 = 15.

Input: heights = [15, 4, 1, 14, 15], k = 3

Output: 2

Explanation:

0th step -> 3rd step, cost = abs(15 - 14) = 1

3rd step -> 4th step, cost = abs(14 - 15) = 1

Total cost = 1 + 1 = 2.
*/

public class Solution {
    public int frogJump(int[] heights, int k) {
        int n = heights.Length;
        int[] dp = new int[n];
        Array.Fill(dp, -1);

        return Solve(heights, k, n-1, dp);
    }

    private int Solve(int[] heights, int k, int i, int[] dp)
    {
        if(i == 0) return 0;

        if(dp[i] != -1) return dp[i];

        int res = int.MaxValue;
        for(int m=k; m>0; m--)
        {
            if(i-m >= 0 )
            {
                res = Math.Min(res, Math.Abs(heights[i-m] - heights[i]) + Solve(heights, k, i-m, dp));
            }
        }

        return dp[i] = res;
    }
}