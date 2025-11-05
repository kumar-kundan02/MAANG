/*
Given a string str and a pattern pat, implement a pattern matching function that supports the following special characters:

'?' Matches any single character.

'*' Matches any sequence of characters (including the empty sequence).

The pattern must match the entire string.

Examples:
Input: str = "xaylmz", pat = "x?y*z"

Output: true

Explanation: 

The pattern "x?y*z" matches the string "xaylmz":

- '?' matches 'a'

- '*' matches "lm"

- 'z' matches 'z'

Input: str = "xyza", pat = "x*z"

Output: false

Explanation: 

The pattern "x*z" does not match the string "xyza" because there is an extra 'a' at the end of the string that is not matched by the pattern.
*/

class Solution
{
    public bool WildCard(string str, string pat)
    {
        int m = str.Length, n = pat.Length;
        int[,] dp = new int[m,n];

        for(int i=0; i<m; i++)
        {
            for(int j=0; j<n; j++)
            {
                dp[i,j] = -1;
            }
        }
        return Solve(str, pat, 0, 0, dp);
    }

    private bool Solve(string s, string p, int i, int j, int[,] dp)
    {
        // if both pattern and string reached till end or exhausted
        if(s.Length == i && p.Length == j)
        {
            return true;
        }

        // if pattern exhausted but not the string
        if(p.Length == j)
        {
            return false;
        }

        // if string exhausted but not the pattern
        if(s.Length == i)
        {
            // just validate if in pattern there is * in remianing pattern
            for(int k=j; k<p.Length; k++)
            {
                if(p[k] != '*')
                    return false;
            }

            return true;
        }

        if(dp[i,j] != -1) return dp[i,j] == 1;

        bool res = false;

        // If there is a match of chars
        if(s[i] == p[j] || p[j] == '?')
        {
            dp[i,j] = Solve(s, p, i+1, j+1, dp) ? 1 : 0;
        }

        else if(p[j] == '*')
        {
            // considering that in pattern there is * but it could be skipped 
            // as in string it might not be required to match with any char
            dp[i,j] = (Solve(s, p, i+1, j, dp) || Solve(s, p, i, j+1, dp)) ? 1 : 0;
        }

        return dp[i,j] == 1;
    }
}
