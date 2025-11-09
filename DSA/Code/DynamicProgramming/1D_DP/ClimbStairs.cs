/*
Given an integer n, there is a staircase with n steps, starting from the 0th step.



Determine the number of unique ways to reach the nth step, given that each move can be either 1 or 2 steps at a time.


Examples:
Input: n = 2

Output: 2

Explanation:

There are 2 unique ways to climb to the 2nd step:

1) 1 step + 1 step

2) 2 steps

Input: n = 3

Output: 3

Explanation:

There are 3 unique ways to climb to the 3rd step:

1) 1 step + 1 step + 1 step

2) 2 steps + 1 step

3) 1 step + 2 steps

*/

public class Solution {
    public int climbStairs(int n) {
        int[] dp = new int[n+1];
        Array.Fill(dp, -1);
        return dp[n] = Solve(n, dp);
    }

    private int Solve(int n, int[] dp)
    {
        if(n == 0) return 1;

        if(n < 0) return 0;

        if(dp[n] != -1) return dp[n];
        return dp[n] = Solve(n-1, dp) + Solve(n-2, dp);
    }
}
