/* 

Given an array arr of n integers and an integer K, count the number of subsets of the given array that have a sum equal to K. Return the result modulo (109 + 7).


Examples:
Input: arr = [2, 3, 5, 16, 8, 10], K = 10

Output: 3

Explanation: The subsets are [2, 8], [10], and [2, 3, 5].

Input: arr = [1, 2, 3, 4, 5], K = 5

Output: 3

Explanation: The subsets are [5], [2, 3], and [1, 4].

*/

class Solution
{
    public int perfectSum(int[] arr, int K)
    {
        int[,] dp = new int[arr.Length, K+1];
        return Solve(arr, K, arr.Length-1, dp);
    }

    private int Solve(int[] arr, int K, int index, int[,] dp)
    {
        if(K == 0)
        {
            return 1;
        }

        if(index < 0)
        {
            return 0;
        }

        if(dp[index, K] != 0)
            return dp[index, K];

        // Exclude
        int res1 = Solve(arr, K, index-1, dp);

        // Include
        int res2 = 0;

        if(arr[index] <= K)
        {
            res2 = Solve(arr, K - arr[index], index-1, dp);
        }

        dp[index, K] = (res1 % 1000000007 + res2 % 1000000007) % 1000000007;

        return dp[index, K];
    }
}
