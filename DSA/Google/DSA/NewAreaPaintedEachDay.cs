/*
There is a long, narrow strip that can be visualized as a number line. Given a 0-indexed 2D integer array paint of size n, 
where paint[i] = [starti, endi], it signifies that on the i-th day, you need to paint the segment covering all integer 
points in [starti, endi), i.e. starting at start_i inclusive and ending at end_i exclusive.

To ensure an even coat, any section should only be painted once.

Return an integer array worklog of size n, where worklog[i] represents the newly painted length on the i-th day.

Examples:
Input: paint = [[5,8],[1,5],[7,10]]

Output: [3,4,2]

Explanation:

On day 0, the segment between 5 and 8 is painted, covering 8 - 5 = 3 units.

On day 1, the section from 1 to 5 is painted, contributing 5 - 1 = 4 new units.

On day 2, the segment 7 to 10 is painted, but 7 to 8 was already painted on day 0, so only 10 - 8 = 2 new unit is added.

Input: paint = [[1,7],[4,6]]

Output: [6,0]

Explanation:

Day 0: Paint from 1 to 7, covering 6 units.

Day 1: Paint from 4 to 6, but this section was already painted on day 0, so 0 new units are added.

Input: paint = [[2,6],[3,7],[5,8]]

Output:
[4, 1, 1]
Constraints:
1 <= paint.length <= 105
paint[i].length == 2
0 <= starti < endi <= 5 * 104
*/

// Approach: Using HashSet to keep track of painted area
// TC: O(n * m) where n is number of days and m is the average length of paint area
// SC: O(k) where k is the total painted area stored in HashSet
public class Solution
{
    public int[] AmountPainted(int[][] paint)
    {
        List<int> res = new List<int>();
        HashSet<int> painted = new HashSet<int>();
        for (int i = 0; i < paint.Length; i++)
        {
            int left = paint[i][0], right = paint[i][1];
            int count = 0;
            for (int j = left; j < right; j++)
            {
                if (!painted.Contains(j))
                {
                    painted.Add(j);
                    count++;
                }
            }
            res.Add(count);
        }

        return res.ToArray();
    }
}

// Approach: Using Union Find and path compression
// TC: O(n * log m) where n is number of days and m is the average length of paint area
// SC: O(k) where k is the total painted area stored in parent array

public class Solution
{
    public int[] AmountPainted(int[][] paint)
    {
        // Initialize the result Array
        int[] res = new int[paint.Length];

        // Getting max index for Paint 
        int maxPaintIndex = 0;
        for(int i=0; i<paint.Length; i++)
        {
            maxPaintIndex = Math.Max(maxPaintIndex, paint[i][1]);
        }

        // Creating an Array to track the next Paint Pointer
        int[] next = new int[maxPaintIndex+1];
        for(int i=0; i<=maxPaintIndex; i++)
        {
            next[i] = i;
        }

        // Now will try to iterate the painted Array

        for(int i=0; i<paint.Length; i++)
        {
            int left = paint[i][0];
            int right = paint[i][1];

            int count = 0;
            while(left < right)
            {
                left = Find(next, left);
                if(left < right)
                {
                    count++;
                    next[left] = left+1;
                }
            }
            res[i] = count;
        }

        return res;
    }

    private int Find(int[] next, int idx)
    {
        if(next[idx] == idx) return idx;
        return next[idx] = Find(next, next[idx]);
    }
}