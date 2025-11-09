/*
A robber is targeting to rob houses from a street. Each house has security measures that alert the police when two adjacent houses are robbed. The houses are arranged in a circular manner, thus the first and last houses are adjacent to each other.

Given an integer array money, where money[i] represents the amount of money that can be looted from the (i+1)th house. Return the maximum amount of money that the robber can loot without alerting the police.

Examples:
Input: money = [2, 1, 4, 9]

Output: 10

Explanation:

[2, 1, 4, 9] The underlined houses would give the maximum loot.

Note that we cannot loot the 1st and 4th houses together.

Input: money = [1, 5, 2, 1, 6]

Output: 11

Explanation:

[1, 5, 2, 1, 6] The underlined houses would give the maximum loot.
*/

class Solution{
    public int HouseRobber(List<int> money) {

        if(money.Count == 1)
            return money[0];
            
        int n = money.Count;
        int[] dp1 = new int[n];
        Array.Fill(dp1, -1);
        int[] dp2 = new int[n];
        Array.Fill(dp2, -1);

        return Math.Max(Solve(money, n-2, 0, dp1), Solve(money, n-1, 1, dp2));
    }

    private int Solve(List<int> money, int end, int idx, int[] dp)
    {
        if(idx == end) return money[idx];

        if(idx > end) return 0;

        if(dp[idx] != -1) return dp[idx];

        // Not Pick
        int res2 = Solve(money, end, idx+1, dp);

        // pick
        int res1 = money[idx] + Solve(money, end, idx+2, dp);
        
        return dp[idx] = Math.Max(res1, res2);
    }
}