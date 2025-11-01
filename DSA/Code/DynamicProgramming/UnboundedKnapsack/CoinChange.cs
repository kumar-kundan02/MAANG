/*
Given an integer array of coins representing coins of different denominations and an integer amount representing a total amount of money. Return the fewest number of coins that are needed to make up that amount. If that amount of money cannot be made up by any combination of the coins, return -1. There are infinite numbers of coins of each type

Examples:
Input: coins = [1, 2, 5], amount = 11

Output: 3

Explanation: 11 = 5 + 5 + 1. We need 3 coins to make up the amount 11.

Input: coins = [2, 5], amount = 3

Output: -1

Explanation: It's not possible to make amount 3 with coins 2 and 5. Since we can't combine the coin 2 and 5 to make the amount 3, the output is -1.

*/

class Solution
{
    public int MinimumCoins(int[] coins, int amount)
    {
        int[,] dp = new int[coins.Length, amount + 1];
        int res = Solve(coins, amount, coins.Length-1, dp);
        if(res < 0 || res == int.MaxValue)
        {
            return -1;
        }

        return res;
    }

    public int Solve(int[] coins, int amount, int index, int[,] dp)
    {
        if(index == 0)
        {
            if(amount % coins[index] == 0)
                return amount/coins[index];
            else
                return int.MaxValue;
        }

        if(amount == 0)
            return 0;
        
        if(dp[index, amount] != 0)
            return dp[index, amount];

        // exclude corrent coin
        int res1 = Solve(coins, amount, index-1, dp);

        int res2 = int.MaxValue;
        
        // include current Coin
        // Including the coin one by one and not by formula 
        // amount/coins[index] : it becomes Greedy and doesn't give the optimal solution
        // So, better try all the possible combinations to get optimized output
        if(coins[index] <= amount)
        {
            res2 = Solve(coins, amount - coins[index], index, dp);
            if(res2 != int.MaxValue)
            {
                res2 += 1;
            }
        }

        dp[index, amount] = Math.Min(res1, res2);
        return dp[index, amount];
    }
}