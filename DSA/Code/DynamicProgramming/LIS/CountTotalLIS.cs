/* 
Given an integer array nums, find the number of Longest Increasing Subsequences (LIS) in the array.

Examples:
Input: nums = [1, 3, 5, 4, 7]

Output: 2

Explanation: There are two LIS of length 4:

[1, 3, 4, 7]

[1, 3, 5, 7].

Input: nums = [2, 2, 2, 2, 2]

Output: 5

Explanation: All elements are the same, so every single element can form an LIS of length 1. There are 5 such subsequences.

*/

public class Solution
{
    public int NumberOfLIS(int[] nums)
    {
        int[] dp = new int[nums.Length];

        // Need one count array to store the possible ways to create the same subsequences Length
        int[] count = new int[nums.Length];

        int maxLength = 0;

        for(int i=0; i<nums.Length; i++)
        {
            dp[i] = 1;
            count[i] = 1;

            for(int j=0; j<i; j++)
            {
                // if nums[i] > nums[j] then we Need to consider the scenarios 
                // when current subsequnce length is equal or less than previous
                
                if(nums[i] > nums[j])
                {
                    if(dp[i] < 1 + dp[j])
                    {
                        dp[i] = 1 + dp[j];
                        // Count will be just updated if it reaches for the first time with prev Index count
                        count[i] = count[j];
                    }
                    else if(dp[i] == 1 + dp[j])
                    {
                        // Going further we need to add the count for previous index 
                        count[i] += count[j];
                    }
                }
                
            }

            if(dp[i] > maxLength)
                maxLength = dp[i];
        }

        int subsetCount = 0;

        for(int i=0; i<dp.Length; i++)
        {
            if(dp[i] == maxLength)
            {
                subsetCount += count[i];
            }
        }

        return subsetCount;
    }
}