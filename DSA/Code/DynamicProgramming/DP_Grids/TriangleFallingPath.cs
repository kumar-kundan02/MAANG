/*
Given a 2d integer array named triangle with n rows. Its first row has 1 element and each succeeding row has one more element in it than the row above it.

Return the minimum falling path sum from the first row to the last.

Movement is allowed only to the bottom or bottom-right cell from the current cell.


Examples:
Input: triangle = [[1], [1, 2], [1, 2, 4]]

Output: 3

Explanation:

One possible route can be:

Start at 1st row -> bottom -> bottom.

Input: triangle = [[1], [4, 7], [4,10, 50], [-50, 5, 6, -100]]

Output: -42

Explanation:

One possible route can be:

Start at 1st row -> bottom-right -> bottom-right -> bottom-right
*/

class Solution
{
    public int MinTriangleSum(List<List<int>> triangle)
    {
        int m = triangle.Count, n = triangle.Count;

        int[,] dp = new int[m,n];

        for(int i=0; i<m; i++)
        {
            for(int j=0; j<n; j++)
            {
                dp[i,j] = -1;
            }
        }

        return Solve(triangle, 0, 0, dp); 
    }

    private int Solve(List<List<int>> triangle, int i, int j, int[,] dp)
    {
        if(triangle.Count <= i || j > i) return int.MaxValue;

        if(triangle.Count-1 == i) return triangle[i][j];

        if(dp[i,j] != -1) return dp[i,j];

        return dp[i,j] = triangle[i][j] + Math.Min(Solve(triangle, i+1, j, dp), Solve(triangle, i+1, j+1, dp));
    }
}