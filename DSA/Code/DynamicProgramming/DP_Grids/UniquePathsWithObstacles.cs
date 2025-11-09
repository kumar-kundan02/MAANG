/*
Given an m x n 2d array named matrix, where each cell is either 0 or 1. Return the number of unique ways to go from the top-left cell (matrix[0][0]) to the bottom-right cell (matrix[m-1][n-1]). A cell is blocked if its value is 1, and no path is possible through that cell.



Movement is allowed in only two directions from a cell - right and bottom.


Examples:
Input: matrix = [[0, 0, 0], [0, 1, 0], [0, 0, 0]]

Output: 2

Explanation:

The two possible paths are:

1) down -> down-> right -> right

2) right -> right -> down -> down

Input: matrix = [[0, 0, 0], [0, 0, 1], [0, 1, 0]]

Output: 0

Explanation:

There is no way to reach the bottom-right cell.
*/

public class Solution {
    public int UniquePathsWithObstacles(int[][] matrix) {
        int m = matrix.Length, n = matrix[0].Length;

        // Junt ensure that whether destination cell is rechable or not
        if(matrix[m-1][n-1] == 1) return 0;

        int[,] dp = new int[m,n];

        for(int i=0; i<m; i++)
        {
            for(int j=0; j<n; j++)
            {
                dp[i,j] = -1;
            }
        }

        return Solve(matrix, 0, 0, dp);
    }

    private int Solve(int[][] matrix, int i, int j, int[,] dp)
    {
        if(matrix.Length <= i || matrix[0].Length <= j) return 0;

        if(matrix.Length-1 == i && matrix[0].Length-1 == j) return 1;

        if(matrix[i][j] == 1) return dp[i,j] = 0;

        if(dp[i,j] != -1) return dp[i,j];

        return dp[i,j] = Solve(matrix, i+1, j, dp) + Solve(matrix, i, j+1, dp);
    }
}