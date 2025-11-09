/*
Given an array nums of n integers and an integer target, build an expression using the integers from nums where each integer can be prefixed with either a '+' or '-' sign.

The goal is to achieve the target sum by evaluating all possible combinations of these signs.

Determine the number of ways to achieve the target sum and return your answer with modulo 10^9+7.

Examples:
Input: nums = [1, 2, 7, 1, 5], target = 4

Output: 2

Explanation: There are 2 ways to assign symbols to make the sum of nums be target 4.

+1 + 2 + 7 - 1 - 5 = 4

-1 + 2 + 7 + 1 - 5 = 4

Input: nums = [1], target = 1

Output: 1

Explanation: There is only one way to assign symbols to make the sum of nums be target 1.
*/

class Solution
{
    public int targetSum(int n, int target, int[] nums)
    {
        Dictionary<(int,int), int> dp = new Dictionary<(int,int), int>();
        return Solve(nums, target, n, 0, dp);
    }

    private int Solve(int[] nums, int target, int n, int index, Dictionary<(int,int), int> dp)
    {
        if(index == n)
        {
            if(target == 0)
            {
                return 1;
            }
            return 0;
        }

        if(dp.ContainsKey((index, target)))
            return dp[(index, target)];

        int res = Solve(nums, target - nums[index], n , index+1, dp) % 1000000007+ Solve(nums, target+nums[index], n, index+1, dp) % 1000000007;

        dp.Add((index, target), res % 1000000007);
        return dp[(index, target)];
    }
}
