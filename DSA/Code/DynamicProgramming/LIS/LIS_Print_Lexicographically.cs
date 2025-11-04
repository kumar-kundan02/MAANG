/*
Given an array of n integers arr, return the Longest Increasing Subsequence (LIS) that is Index-wise Lexicographically Smallest.

The Longest Increasing Subsequence (LIS) is the longest subsequence where all elements are in strictly increasing order.

A subsequence A1 is Index-wise Lexicographically Smaller than another subsequence A2 if, at the first position where A1 and A2 differ, the element in A1 appears earlier in the array arr than corresponding element in S2.

Your task is to return the LIS that is Index-wise Lexicographically Smallest from the given array.

Examples:
Input: arr = [10, 22, 9, 33, 21, 50, 41, 60, 80]

Output: [10, 22, 33, 50, 60, 80]

Explanation: The LIS is [10, 22, 33, 50, 60, 80] and it is the lexicographically smallest.

Input: arr = [1, 3, 2, 4, 6, 5]

Output: [1, 3, 4, 6]

Explanation: Possible LIS sequences are [1, 3, 4, 6] and [1, 2, 4, 6]. Since [1, 3, 4, 6] is Index-wise Lexicographically Smaller, it is the result.

*/


class Solution
{
    public List<int> LongestIncreasingSubsequence(int[] arr)
    {
        int[] dp = new int[arr.Length];
        int[] backTrack = new int[arr.Length];

        /* 
        Not required as it can be done in below loop only
        Array.Fill(dp, 1);
        for(int i=0;i<arr.Length; i++)
        {
                backTrack[i] = i;
        }
       */

        int maxIndex = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            // Initializing the dp array and backtrack Array in this loop only 
            dp[i] = 1;
            backTrack[i] = i;

            for (int j = 0; j <= i; j++)
            {
                if (arr[i] > arr[j] && dp[j] + 1 > dp[i])
                {
                    dp[i] = 1 + dp[j];
                    backTrack[i] = j;
                }
            }

            // Updating the index having Max Subsequence Length
            if (dp[i] > dp[maxIndex])
            {
                maxIndex = i;
            }
        }

        /* Not required as already done in the above loop only
            int maxIndex = 0;
            for(int i=1; i<arr.Length; i++)
            {
                if(dp[i] > dp[maxIndex])
                    maxIndex = i;
            }
        */

        // Constructing the subsequence using backtracking
        List<int> subsequence = new List<int>();

        while (maxIndex != backTrack[maxIndex])
        {
            subsequence.Add(arr[maxIndex]);
            maxIndex = backTrack[maxIndex];
        }

        subsequence.Add(arr[maxIndex]);

        subsequence.Reverse();
        return subsequence;
    }
}