/*

Given an input string, containing upper-case and lower-case letters, digits, and spaces( ' ' ). A word is defined as a sequence of non-space characters. The words in s are separated by at least one space.

Return a string with the words in reverse order, concatenated by a single space.

Examples:
Input: s = "welcome to the jungle"

Output: "jungle the to welcome"

Explanation: The words in the input string are "welcome", "to", "the", and "jungle". Reversing the order of these words gives "jungle", "the", "to", and "welcome". The output string should have exactly one space between each word.

Input: s = " amazing coding skills "

Output: "skills coding amazing"

Explanation: The input string has leading and trailing spaces, as well as multiple spaces between the words "amazing", "coding", and "skills". After trimming the leading and trailing spaces and reducing the multiple spaces between words to a single space, the words are "amazing", "coding", and "skills". Reversing the order of these words gives "skills", "coding", and "amazing". The output string should not have any leading or trailing spaces and should have exactly one space between each word.
*/

using System.Text;

public class Solution
{
    public string ReverseWords(string s)
    {
        Stack<string> stk = new Stack<string>();
        StringBuilder sb = new StringBuilder();

        bool shouldPush = false;

        for (int i = 0; i < s.Length; i++)
        {
            if (s[i] != ' ')
            {
                if (shouldPush)
                {
                    stk.Push(sb.ToString());
                    sb = new StringBuilder();
                    shouldPush = false;
                }
                sb.Append(s[i]);

            }
            else if (s[i] == ' ')
            {
                shouldPush = true;
            }
        }

        stk.Push(sb.ToString());
        sb = new StringBuilder();

        while (stk.Count > 0)
        {
            sb.Append(stk.Pop());
            sb.Append(" ");
        }

        return sb.ToString();
    }
}

// In-Place reversal without using much extra Space

public class Solution {
    public string ReverseWords(string s) {
        Stack<char> stk = new Stack<char>();
        StringBuilder sb = new StringBuilder();

        int n = s.Length-1;
        while(n >= 0)
        {
            if(s[n] != ' ')
            {
                stk.Push(s[n]);
            }
            else if(s[n] == ' ' && stk.Count > 0)
            {
                while(stk.Count > 0)
                {
                    sb.Append(stk.Pop());
                }
                sb.Append(" ");
            }
            n--;
        }

        while(stk.Count > 0)
        {
            sb.Append(stk.Pop());
        }

        return sb.ToString();
    }
}