public class Solution {
	
    public int NumIslands(char[][] grid) {
		int islandCount =0;
		bool[,] visitorMatirx = new bool[grid.Length, grid[0].Length];
		
		for(int row=0; row < grid.Length; row++)
		{
			for(int col=0; col < grid[0].Length; col++)
			{
				visitorMatirx[row,col] = false;
			}
		}
		
        for(int row=0; row < grid.Length; row++)
		{
			for(int col=0; col < grid[0].Length; col++)
			{
				if(grid[row][col] == '1' && visitorMatirx[row,col] == false)
				{
					DFS(grid,row,col,visitorMatirx);
					islandCount++;
				}					
			}
		}
		
		return islandCount;
    }
	
	private void DFS(char[][] grid, int i, int j, bool[,] visitorMatirx)
	{
        
		if(i < grid.Length && j < grid[0].Length && i >= 0 && j >= 0 && grid[i][j] != '0' && !visitorMatirx[i,j])	
		{
			visitorMatirx[i,j] = true;
			DFS(grid, i+1,j, visitorMatirx);
            DFS(grid, i-1,j, visitorMatirx);
			DFS(grid, i,j+1, visitorMatirx);
			DFS(grid, i,j-1, visitorMatirx);
		}
	}
}