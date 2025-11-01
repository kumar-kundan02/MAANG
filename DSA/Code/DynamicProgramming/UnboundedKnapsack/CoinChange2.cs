/* 
Give an array coins of n integers representing coin denominations. Your task is to find the number of distinct combinations that sum up to a specified amount of money. If it's impossible to achieve the exact amount with any combination of coins, return 0.

Single coin can be used any number of times.

Return your answer with modulo 109+7.

Examples:
Input: coins = [2, 4,10], amount = 10
Output: 4

Explanation: The four combinations are:
10 = 10
10 = 4 + 4 + 2
10 = 4 + 2 + 2 + 2
10 = 2 + 2 + 2 + 2 + 2

Input: coins = [5], amount = 5
Output: 1
Explanation: There is one combination: 5 = 5.

*/

class Solution
{
    private static int MOD = (int)1e9 + 7;

    public int count(int[] coins, int N, int amount)
    {

      int[,] dp = new int[N, amount + 1];

      for(int i=0; i<N; i++)
      {
        for(int j=0; j <= amount; j++)
        {
            dp[i,j] = -1;
        }
      }

      return Solve(coins, amount, N-1, dp);
    }

    private int Solve(int[] coins, int amount, int index, int[,] dp)
    {
        if(amount == 0)
        {
            return 1;
        }

        if(index == -1)
        {
            return 0;
        }

        if(dp[index, amount] != -1)
        {
            return dp[index, amount];
        }

        // Exclude
        int res1 = Solve(coins, amount, index-1, dp);

        // Include
        int res2 = 0;
        if(coins[index] <= amount)
        {
            res2 = Solve(coins, amount - coins[index], index, dp);
        } 

        dp[index, amount] = (res1 % MOD + res2 % MOD) % MOD;
        return dp[index, amount];
    }
}