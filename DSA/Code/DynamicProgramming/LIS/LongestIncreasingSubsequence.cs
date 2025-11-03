/*
Given an integer array nums, return the length of the longest strictly increasing subsequence.

A subsequence is a sequence derived from an array by deleting some or no elements without changing the order of the remaining elements. For example, [3, 6, 2, 7] is a subsequence of [0, 3, 1, 6, 2, 2, 7].

The task is to find the length of the longest subsequence in which every element is greater than the previous one.

Examples:
Input: nums = [10, 9, 2, 5, 3, 7, 101, 18]

Output: 4

Explanation: The longest increasing subsequence is [2, 3, 7, 101], and its length is 4.

Input: nums = [0, 1, 0, 3, 2, 3]

Output: 4

Explanation: The longest increasing subsequence is [0, 1, 2, 3], and its length is 4

*/

// Recursion + Memoization
// TC: O(N^2)
// SC: O(N^2) + O(N)
public class Solution
{
    public int LIS(int[] nums)
    {
        int n = nums.Length;
        int[,] dp = new int[nums.Length, nums.Length];
        return Solve(nums, 0, -1, dp);
    }

    private int Solve(int[] nums, int index, int prev_index, int[,] dp)
    {
        if (index == nums.Length - 1)
        {
            if (prev_index == -1 || nums[index] > nums[prev_index])
                return 1;
            return 0;
        }

        if (dp[index, prev_index + 1] != 0)
            return dp[index, prev_index + 1];

        // Exclude
        int res1 = Solve(nums, index + 1, prev_index, dp);

        // Include
        int res2 = 0;

        if (prev_index == -1 || nums[index] > nums[prev_index])
        {
            res2 = 1 + Solve(nums, index + 1, index, dp);
        }

        return dp[index, prev_index + 1] = Math.Max(res1, res2);
    }
}
