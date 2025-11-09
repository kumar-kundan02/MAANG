/*

Given two integers m and n, representing the number of rows and columns of a 2d array named matrix. Return the number of unique ways to go from the top-left cell (matrix[0][0]) to the bottom-right cell (matrix[m-1][n-1]).

Movement is allowed only in two directions from a cell: right and bottom.

Examples:
Input: m = 3, n = 2

Output: 3

Explanation:

There are 3 unique ways to go from the top left to the bottom right cell.

1) right -> down -> down

2) down -> right -> down

3) down -> down -> right

Input: m = 2, n = 4

Output: 4

Explanation:

There are 4 unique ways to go from the top left to the bottom right cell.

1) down -> right -> right -> right

2) right -> down -> right -> right

3) right -> right -> down -> right

4) right -> right -> right -> down

*/

public class Solution {
    public int uniquePaths(int m, int n) {
        int[,] dp = new int[m,n];
        for(int i=0; i<m; i++)
        {
            for(int j=0; j<n; j++)
            {
                dp[i,j] = -1;
            }
        }
        return Solve(m, n, 0, 0, dp);
    }

    private int Solve(int m, int n, int i, int j, int[,] dp)
    {
        if(i >= m || j >= n) return 0;

        if(i == m-1 && j == n-1) return 1;

        if(dp[i,j] != -1) return dp[i,j];

        return dp[i,j] = Solve(m, n, i+1, j, dp) + Solve(m, n, i, j+1, dp);
    }
}