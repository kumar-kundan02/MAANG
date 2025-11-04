/*
Given an array nums of positive integers, the task is to find the largest subset such that every pair (a, b) of elements in the subset satisfies a % b == 0 or b % a == 0.

Return the subset in any order. If there are multiple solutions, return any one of them.

Note: As there can be multiple correct answers, the compiler returns 1 if the answer is valid, else 0.

Examples:
Input: nums = [3, 5, 10, 20]

Output: [5, 10, 20]

Explanation:

The subset [5, 10, 20] satisfies the divisibility condition: 10 % 5 == 0 and 20 % 10 == 0.

Input: nums = [16, 8, 2, 4, 32]

Output: [2, 4, 8, 16, 32]

Explanation:

The entire array forms a divisible subset since 32 % 16 == 0, 16 % 8 == 0, and so on.
*/


// After Sorting the Array this problem has been converted into kind of problem where
// we need to find the longest chain which the divisible by previous element
public class Solution
{
    public List<int> LargestDivisibleSubset(int[] nums)
    {
        // Need to Sort Array as we need to make use of logic that
        // if element which can divide the current element should also be divisibe by
        // the elements which devides the current element which is dividing

        Array.Sort(nums);
        int[] dp = new int[nums.Length];
        int[] backtrack = new int[nums.Length];

        int maxIndex = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            dp[i] = 1;
            backtrack[i] = i;

            for (int j = 0; j < i; j++)
            {
                // Adjusted the logic here to check if % operation is giving "Zero"
                if (nums[i] % nums[j] == 0 && dp[i] < dp[j] + 1)
                {
                    dp[i] = 1 + dp[j];
                    backtrack[i] = j;
                }
            }

            if (dp[i] > dp[maxIndex])
                maxIndex = i;
        }

        List<int> res = new List<int>();

        while (backtrack[maxIndex] != maxIndex)
        {
            res.Add(nums[maxIndex]);
            maxIndex = backtrack[maxIndex];
        }

        res.Add(nums[maxIndex]);

        return res;
    }
}