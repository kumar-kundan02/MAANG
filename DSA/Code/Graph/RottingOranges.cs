public class Solution {
    public int OrangesRotting(int[][] grid) {
        int rows = grid.Length;
        int cols = grid[0].Length;
        bool[,] visited = new bool[rows, cols];
        Queue<(int, int)> queue = new Queue<(int, int)>();
        int freshCount = 0;
        int minutes = 0;

        for (int r = 0; r < rows; r++) {
            for (int c = 0; c < cols; c++) {
                if (grid[r][c] == 2) {
                    queue.Enqueue((r, c));
                    visited[r, c] = true;
                } else if (grid[r][c] == 1) {
                    freshCount++;
                }
            }
        }

        int[][] directions = new int[][] {
            new int[] {1, 0},
            new int[] {-1, 0},
            new int[] {0, 1},
            new int[] {0, -1}
        };

        while (queue.Count > 0 && freshCount > 0) {
            int size = queue.Count;
            for (int i = 0; i < size; i++) {
                var (r, c) = queue.Dequeue();
                foreach (var dir in directions) {
                    int newRow = r + dir[0];
                    int newCol = c + dir[1];
                    if (newRow >= 0 && newRow < rows && newCol >= 0 && newCol < cols &&
                        grid[newRow][newCol] == 1 && !visited[newRow, newCol]) {
                        visited[newRow, newCol] = true;
                        grid[newRow][newCol] = 2;
                        freshCount--;
                        queue.Enqueue((newRow, newCol));
                    }
                }
            }
            minutes++;
        }

        return freshCount == 0 ? minutes : -1;
    }
}