/*
Given an array arr of n integers and an integer target, determine if there is a subset 
of the given array with a sum equal to the given target.

Examples:
Input: arr = [1, 2, 7, 3], target = 6
Output: True

Explanation: There is a subset (1, 2, 3) with sum 6.

Input: arr = [2, 3, 5], target = 6
Output: False

Explanation: There is no subset with sum 6.
*/


// Here even without using the memoization it was able to pass all the Test cases
class Solution
{
    public bool IsSubsetSum(int[] arr, int target)
    {
        return Solve(arr, target, 0);
    }

    private bool Solve(int[] arr, int target, int index)
    {
        if (target == 0) return true;

        if (index >= arr.Length || target < 0)
            return false;

        if (target >= arr[index])
        {
            if (Solve(arr, target - arr[index], index + 1)) return true;
        }

        return Solve(arr, target, index + 1);
    }
}