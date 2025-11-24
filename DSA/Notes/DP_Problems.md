
### DP Problems

#### Matrix Chain Multiplication

```CSharp
/*

Given a chain of matrices A1, A2, A3,.....An, you have to figure out the most efficient way to multiply these matrices. In other words, determine where to place parentheses to minimize the number of multiplications.

Given an array nums of size n. Dimension of matrix Ai ( 0 < i < n ) is nums[i - 1] x nums[i].Find a minimum number of multiplications needed to multiply the chain.

Examples:
Input : nums = [10, 15, 20, 25]

Output : 8000

Explanation : There are two ways to multiply the chain - A1*(A2*A3) or (A1*A2)*A3.

If we multiply in order- A1*(A2*A3), then number of multiplications required are 11250.

If we multiply in order- (A1*A2)*A3, then number of multiplications required are 8000.

Thus minimum number of multiplications required is 8000.

Input : nums = [4, 2, 3]

Output : 24

Explanation : There is only one way to multiply the chain - A1*A2.

Thus minimum number of multiplications required is 24.

*/


class Solution
{
    public int MatrixMultiplication(int[] nums)
    {
        //your code goes here
        int n = nums.Length;
        int[,] dp = new int[n, n];

        for(int i=0; i<n; i++)
        {
            for(int j=0; j<n; j++)
            {
                dp[i,j] = -1;
            }
        }

        return MCM(nums, 1, n-1, dp);
    }

    private int MCM(int[] nums, int i, int j, int[,] dp)
    {
        if(i == j)
        {
            return 0;
        }        

        if(dp[i,j] != -1)
            return dp[i,j];

        int min = int.MaxValue;

        for(int k=i; k<j; k++)
        {
            // consider the case for partition from i to k then k+1 to j-1. Where j = nums.Length-1
            int ans = nums[i-1] * nums[k] * nums[j] + MCM(nums, i, k, dp) + MCM(nums, k+1, j, dp);
            min = Math.Min(min, ans);
        }

        return dp[i,j] = min;
    }
}
```