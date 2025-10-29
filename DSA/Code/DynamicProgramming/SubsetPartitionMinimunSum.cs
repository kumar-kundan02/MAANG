/*
Given an array arr of n integers, partition the array into two subsets such that 
the absolute difference between their sums is minimized.

Examples:
Input: arr = [1, 7, 14, 5]
Output: 1

Explanation: The array can be partitioned as [1, 7, 5] and [14], with an absolute difference of 1.

Input: arr = [3, 1, 6, 2, 2]
Output: 0

Explanation: The array can be partitioned as [3, 2, 2] and [6, 1], with an absolute difference of 0.
*/

class Solution
{
    public int minDifference(int[] arr, int n)
    {
        int sum = 0;

        for (int i = 0; i < n; i++)
        {
            sum += arr[i];
        }

        int[,] dp = new int[n, sum + 1];
        return Solve2(arr, n, sum, 0, 0, dp);

    }

    private int Solve2(int[] arr, int n, int totalSum, int s, int index, int[,] dp)
    {
        if (n == index)
        {
            return Math.Abs(totalSum - s - s);
        }

        if (dp[index, s] != 0)
            return dp[index, s];

        // Include
        int sum1 = Solve2(arr, n, totalSum, s + arr[index], index + 1, dp);
        // Exclude
        int sum2 = Solve2(arr, n, totalSum, s, index + 1, dp);

        dp[index, s] = Math.Min(sum1, sum2);

        return dp[index, s];
    }

}
