/*
Given an array arr of n integers, the task is to find the length of the longest bitonic sequence. A sequence is considered bitonic if it first increases, then decreases. The sequence does not have to be contiguous.

Examples:
Input: arr = [5, 1, 4, 2, 3, 6, 8, 7]

Output: 6

Explanation: The longest bitonic sequence is [1, 2, 3, 6, 8, 7] with length 6.

Input: arr = [10, 20, 30, 40, 50, 40, 30, 20]

Output: 8

Explanation: The entire array is bitonic, increasing up to 50 and then decreasing.

*/

public class Solution {
    public int LongestBitonicSequence(List<int> arr) {
        int maxLength = 0;

        int[] dp1 = GetLIS(arr); // LIS: Left - > Right
        int[] dp2 = GetLDS(arr); // LDS: Right -> Left

        // At the same index If we take sum of both the longest Seqence
        // one with LIS Left->right, and other with LDS Right->Left
        // It will consider current element as peak element where direction of sequence is getting reversed
        // Since in both sequence this element considered twice so, will subtract 1 from sum
        for (int i = 0; i < dp1.Length; i++)
        {
            maxLength = Math.Max(maxLength, dp1[i] + dp2[i] - 1);
        }

        return maxLength;
    }

    private int[] GetLIS(List<int> arr)
    {
        int[] dp = new int[arr.Count];

        for(int i=0; i<arr.Count; i++)
        {
            dp[i] = 1;
            for(int j=0; j<i; j++)
            {
                if(arr[i] > arr[j] && dp[i] < 1+dp[j])
                {
                    dp[i] = 1 + dp[j];
                }
            }
        }

        return dp;
    }
    
    private int[] GetLDS(List<int> arr)
    {
        int n = arr.Count;
        int[] dp = new int[n];

        for(int i=n-1; i >= 0 ; i--)
        {
            dp[i] = 1;
            for(int j=n-1; j>i; j--)
            {
                if(arr[i] > arr[j] && dp[i] < 1+dp[j])
                {
                    dp[i] = 1 + dp[j];
                }
            }
        }

        return dp;
    }
}