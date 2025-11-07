/*
Given an array arr of n integers, where arr[i] represents price of the stock on the ith day. Determine the maximum profit achievable by buying and selling the stock at most once. 



The stock should be purchased before selling it, and both actions cannot occur on the same day.


Examples:
Input: arr = [10, 7, 5, 8, 11, 9]

Output: 6

Explanation: Buy on day 3 (price = 5) and sell on day 5 (price = 11), profit = 11 - 5 = 6.

Input: arr = [5, 4, 3, 2, 1]

Output: 0

Explanation: In this case, no transactions are made. Therefore, the maximum profit remains 0.
*/

class Solution
{
    public int stockBuySell(int[] arr, int n)
    {
        if(arr.Length == 1)
            return 0;
       int buy = arr[0], sell = arr[1], profit = Math.Max(0, sell-buy);

       for(int i=1; i<n; i++)
       {
            if(arr[i] < buy)
            {
                buy = arr[i];
                sell = buy;
            }
            else if(arr[i] > sell)
            {
                sell = arr[i];
            }

            profit = Math.Max(profit, sell - buy);
       }

       return profit;
    }
}