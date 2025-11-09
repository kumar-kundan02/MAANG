/*
Given an integer array nums of size n. Return the maximum sum possible using the elements of nums such that no two elements taken are adjacent in nums.

Examples:
Input: nums = [1, 2, 4]

Output: 5

Explanation:

[1, 2, 4], the underlined elements are taken to get the maximum sum.

Input: nums = [2, 1, 4, 9]

Output: 11

Explanation:

[2, 1, 4, 9], the underlined elements are taken to get the maximum sum.
*/

class Solution
{
    public int NonAdjacent(int[] nums)
    {
        int[] dp = new int[nums.Length];
        Array.Fill(dp, -1);

        return Solve(nums, 0, dp);
    }

    private int Solve(int[] nums, int idx, int[] dp)
    {
        if(idx >= nums.Length) return 0;

        if(dp[idx] != -1) return dp[idx];
        // Pick 
        int res1 = nums[idx] + Solve(nums, idx+2, dp);

        // not pick
        int res2 = Solve(nums, idx+1, dp);

        return dp[idx] = Math.Max(res1, res2);
    }
}
