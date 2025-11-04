/*
You are given an array of words where each word consists of lowercase English letters.

wordA is a predecessor of wordB if and only if we can insert exactly one letter anywhere in wordA without changing the order of the other characters to make it equal to wordB.

For example, "abc" is a predecessor of "abac", while "cba" is not a predecessor of "bcad".

A word chain is a sequence of words [word1, word2, ..., wordk] with k >= 1, where word1 is a predecessor of word2, word2 is a predecessor of word3, and so on. A single word is trivially a word chain with k == 1.

Return the length of the longest possible word chain with words chosen from the given list of words.


Examples:
Input: words = ["a", "ab", "abc", "abcd", "abcde"]

Output: 5

Explanation: The longest chain is ["a", "ab", "abc", "abcd", "abcde"].

Each word in the chain is formed by adding exactly one character to the previous word.

Input: words = ["dog", "dogs", "dots", "dot", "d", "do"]

Output: 4

Explanation: The longest chain is ["d", "do", "dot", "dots"].

Each word is formed by inserting one character into the previous word.
*/

public class Solution
{
    public int LongestStringChain(string[] words)
    {
        Array.Sort(words, Compare); // Using custom comparer to sort based on string length

        int[] dp = new int[words.Length];

        int maxLength = 0;

        for(int i=0; i<words.Length; i++)
        {
            dp[i] = 1;
            for(int j=0; j<i; j++)
            {
                if(IsValiPredecessror(words[i], words[j]) && dp[i] < dp[j] + 1)
                {
                    dp[i] = 1 + dp[j];
                }
            }

            if(dp[i] > maxLength)
            {
                maxLength = dp[i];
            }
        }

        return maxLength;
    }

    // Custom comparator function 
    private static int Compare(string s, string t)
    {
        return s.Length.CompareTo(t.Length);
    }

    private bool IsValiPredecessror(string s, string t)
    {
        if(s.Length - t.Length != 1) return false;

        int i=0, j=0;

        while(i < s.Length)
        {
            if(j < t.Length && s[i] == t[j])
            {
                i++;
                j++;
            }
            else
            {
                i++;
            }
        }

        if(i == s.Length && j == t.Length)
            return true;
        return false;
    }
}