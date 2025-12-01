/*

Given a string text and a string pattern, implement the Rabin-Karp algorithm to find the starting index of all occurrences of pattern in text. If pattern is not found, return an empty list.

Examples:
Input: text = "ababcabcababc", pattern = "abc"


Output: [2, 5, 10]

Expalanation : The pattern "abc" is found at indices 2, 5, and 10 in the text.

Input: text = "hello", pattern = "ll"

Output: [2]

Explanation: The pattern "ll" is found at index 2 in the text.

*/

class Solution
{
    public List<int> search(string pat, string txt)
    {
        List<int> res = new List<int>();

        if(pat.Length > txt.Length) return res;

        for(int i=0; i<txt.Length; i++)
        {
            if(txt[i] == pat[0])
            {
                int k =0;
                while(k < pat.Length && i+k < txt.Length && txt[i+k] == pat[k])
                {
                    k++;
                }
                if(k == pat.Length) res.Add(i);
            }
        }

        return res;
    }
}