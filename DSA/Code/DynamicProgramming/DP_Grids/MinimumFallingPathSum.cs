/*
Given a 2d array called matrix consisting of integer values. Return the minimum path sum that can be obtained by starting at any cell in the first row and ending at any cell in the last row.



Movement is allowed only to the bottom, bottom-right, or bottom-left cell of the current cell.


Examples:
Input: matrix = [[1, 2, 10, 4], [100, 3, 2, 1], [1, 1, 20, 2], [1, 2, 2, 1]]

Output: 6

Explanation:

One optimal route can be:-

Start at 1st cell of 1st row -> bottom-right -> bottom -> bottom-left.

Input: matrix = [[1, 4, 3, 1], [2, 3, -1, -1], [1, 1, -1, 8]]

Output: -1

Explanation:

One optimal route can be:-

Start at 4th cell of 1st row -> bottom-left -> bottom.
*/

public class Solution {
    public int MinFallingPathSum(int[][] matrix) {
        int m = matrix.Length, n = matrix[0].Length;

        int[,] dp = new int[m,n];

        int res = int.MaxValue;

        // There is no need of doing Reset DP at each step. As it's not gonna disturb other solutions
        ResetDP(dp, m, n);

        for(int j=0; j<n; j++)
        {         
            res = Math.Min(res, Solve(matrix, 0, j, dp));
        }

        return res;
    }

    private int Solve(int[][] matrix, int i, int j, int[,] dp)
    {
        // Here return int.MaxValue it's output should be discarded. 
        // Since we are looking for minimum so, we will assign max value to discard it
        if(i >= matrix.Length || j >= matrix[0].Length || j < 0) return int.MaxValue;

        if(matrix.Length-1 == i) return matrix[i][j];

        if(dp[i,j] != -1) return dp[i,j];

        return dp[i,j] = matrix[i][j] + Math.Min(Solve(matrix, i+1,j, dp), Math.Min(Solve(matrix, i+1, j+1, dp), Solve(matrix, i+1, j-1, dp)));
    }

    private void ResetDP(int[,] dp, int m, int n)
    {
        for(int i=0; i<m; i++)
        {
            for(int j=0; j<n; j++)
            {
                dp[i,j] = -1;
            }
        }
    }
}