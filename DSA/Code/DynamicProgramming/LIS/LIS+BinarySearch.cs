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

Input: nums = [7, 7, 7, 7, 7, 7, 7]

Output:
1
*/

public class Solution
{
    public int LIS(int[] nums)
    {
        // This list gets updated whenever subsequence count gets updated
        List<int> tails = new List<int>();
        tails.Add(nums[0]);

        for(int i=1; i<nums.Length; i++)
        {
            if(nums[i] > tails.Last())
            {
                tails.Add(nums[i]);
            }
            else
            {
                int idx = tails.BinarySearch(nums[i]);
                if(idx < 0)
                {
                    tails[~idx] = nums[i]; // It gives immediate next greater number
                }
            }
        }

        return tails.Count;
    }
}
