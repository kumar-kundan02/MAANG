/*
Given an array arr of n integers, return true if the array can be partitioned into 
two subsets such that the sum of elements in both subsets is equal else return false.

Examples:
Input: arr = [1, 10, 21, 10]
Output: True

Explanation: The array can be partitioned as [1, 10, 10] and [21].

Input: arr = [1, 2, 3, 5]
Output: False

Explanation: The array cannot be partitioned into equal sum subsets.
*/

class Solution {

    public bool EqualPartition(int n, int[] arr) {
        int sum = 0;

        for(int i=0; i<arr.Length; i++)
        {
            sum += arr[i];
        }

        if(sum % 2 != 0)
            return false;
        
        int target = sum / 2;
        int[,] dp = new int[n, target+1];
        return Solve(arr, target, 0, dp);
    }

    private bool Solve(int[] arr, int target, int index, int[,] dp)
    {
        if( index >= arr.Length || target < 0)
        {
            return false;
        }

        if(target == 0)
        {
            return true;
        }

        if(dp[index, target] != 0)
            return dp[index, target] == 1;

        dp[index, target] = Solve(arr, target - arr[index], index+1, dp);
        if(dp[index, target] == 1)
        {
            return true;
        }
        else
        {
            dp[index, target] = -1;
        }
        
        return Solve(arr, target, index+1, dp);
    }
}
