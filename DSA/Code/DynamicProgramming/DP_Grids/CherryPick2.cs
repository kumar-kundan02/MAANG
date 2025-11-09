/*
Given a n x m 2d integer array called matrix where matrix[i][j] represents the number of cherries you can pick up from the (i, j) cell.Given two robots that can collect cherries, one is located at the top-leftmost (0, 0) cell and the other at the top-rightmost (0, m-1) cell.

Return the maximum number of cherries that can be picked by the two robots in total, following these rules:

Robots that are standing on (i, j) cell can only move to cell (i + 1, j - 1), (i + 1, j), or (i + 1, j + 1), if it exists in the matrix.

A robot will pick up all the cherries in a given cell when it passes through that cell.

If both robots come to the same cell at the same time, only one robot takes the cherries.

Both robots must reach the bottom row in matrix.

Examples:
Input: matrix = [[2, 1, 3], [4, 2, 5], [1, 6, 2], [7, 2, 8]]

Output: 37

Explanation:

Possible left robot path:-

Start at 0th cell (2) -> down (4) -> down-right (6) ->down-left (7)

Possible right robot path:-

Start at 2nd cell (3) -> down (5) -> down (2) -> down (8)

Input: matrix = [[1, 4, 4, 1], [1, 2, 2, 1], [5, 6, 10, 11], [8, 1, 1, 1]]

Output: 32

Explanation:

Possible left robot path:-

Start at 0th cell (1) -> down-right (2) -> down (6) ->down-left (8)

Possible right robot path:-

Start at 3rd cell (1) -> down-left (2) -> down-right (11) -> down (1)
*/

public class Solution
{
    public int CherryPickup(int[][] matrix)
    {
        int m = matrix.Length, n = matrix[0].Length;

        int[,,] dp = new int[m,n,n];

        for(int i=0; i<m; i++)
        {
            for(int j=0; j<n; j++)
            {
                for(int k=0; k<n; k++)
                {
                    dp[i,j,k] = -1;
                }
            }
        }

        return Solve(matrix, 0, 0, n-1, dp);

    }

    private int Solve(int[][] matrix, int i, int j, int k, int[,,] dp)
    {
        if(matrix[0].Length <= j || j < 0 || k < 0 || matrix[0].Length <= k) return int.MinValue;

        
        if(matrix.Length-1 == i) 
        {
            if(j == k)
                return matrix[i][j];
            else
                return matrix[i][k] + matrix[i][j];
        }

        if(dp[i,j,k] != -1) return dp[i,j,k];

        int maxVal = int.MinValue;
        int ans = 0;

        // Explore all the paths direction => 3 * 3 = 9 directions
        for(int m =- 1; m <= 1; m++)
        {
            for(int n = -1; n <= 1; n++)
            {
                if(j == k)
                {
                    ans = matrix[i][j] + Solve(matrix, i+1, j+m, k+n, dp);
                }
                else
                {
                    ans = matrix[i][j] + matrix[i][k] + Solve(matrix, i+1, j+m, k+n, dp);
                }

                maxVal = Math.Max(ans, maxVal);
            }
        }

        return dp[i,j,k] = maxVal;
        
    }
}