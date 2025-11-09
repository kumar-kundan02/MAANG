/*
A ninja has planned a n-day training schedule. Each day he has to perform one of three activities - running, stealth training, or fighting practice. The same activity cannot be done on two consecutive days and the ninja earns a specific number of merit points, based on the activity and the given day.

Given a n x 3-sized matrix, where matrix[i][0], matrix[i][1], and matrix[i][2], represent the merit points associated with running, stealth and fighting practice, on the (i+1)th day respectively. Return the maximum possible merit points that the ninja can earn.

Examples:
Input: matrix = [[10, 40, 70], [20, 50, 80], [30, 60, 90]]

Output: 210

Explanation:

Day 1: fighting practice = 70

Day 2: stealth training = 50

Day 3: fighting practice = 90

Total = 70 + 50 + 90 = 210

This gives the optimal points.

Input: matrix = [[70, 40, 10], [180, 20, 5], [200, 60, 30]]

Output: 290

Explanation:

Day 1: running = 70

Day 2: stealth training = 20

Day 3: running = 200

Total = 70 + 20 + 200 = 290

This gives the optimal points.

Input: matrix = [[20, 10, 10], [20, 10, 10], [20, 30, 10]]

Output:
60

*/

class Solution
{
    public int NinjaTraining(int[][] matrix)
    {
        int m = matrix.Length, n = matrix[0].Length;
        int res = 0;
        int[,] dp = new int[m+1,n];
        
        // Call for all the combinations
        for(int i=0; i<3; i++)
        {
            ResetDpArray(dp, m+1, n);
            res = Math.Max(res, Solve(matrix, 0, i, dp)); 
        }

        return res;
    }

    private void ResetDpArray(int[,] dp, int m, int n)
    {
        for(int i=0; i<m; i++)
        {
            for(int j=0; j<n; j++)
            {
                dp[i,j] = -1;
            }
        }
    }

    private int Solve(int[][] matrix,  int idx, int j, int[,] dp)
    {
        if(idx == matrix.Length)
        {
            return 0;
        }

        if(dp[idx,j] != -1) return dp[idx,j];

        // explore all the choices
        int p = 0;
        for(int k=0; k<3; k++)
        {
            if(k == j)
                continue;
            p = Math.Max(matrix[idx][j] + Solve(matrix, idx+1, k, dp), p);
        }

        return dp[idx,j] = p;
    }
}