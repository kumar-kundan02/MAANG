### Dynamic Programming

* Dynamic Programming (DP) is a method for solving complex problems by breaking them down into simpler subproblems.
* It is applicable when the subproblems overlap and optimal substructure is present.
* DP can be implemented using two main approaches: Top-Down (Memoization) and Bottom-Up (Tabulation).
* **Top-Down (Memoization):** This approach involves solving the problem recursively and storing the results of subproblems in a cache to avoid redundant calculations.
* **Bottom-Up (Tabulation):** This approach involves solving the problem iteratively by building a table from the smallest subproblems up to the original problem.
* Common examples of DP problems include the Fibonacci sequence, Knapsack problem, Longest Common Subsequence, and Coin Change problem.

* **Applications:** DP is widely used in various fields such as operations research, economics, bioinformatics, and computer science for optimization problems, resource allocation, and decision-making processes.

#### Knapsack(0/1)
* Problem Statement: Given a set of items, each with a weight and a value, determine the maximum value that can be obtained by selecting items such that their total weight does not exceed a given limit.
* Approach: Use a 2D DP table where `dp[i][w]` represents the maximum value that can be obtained with the first `i` items and a weight limit of `w`. The recurrence relation is:
  * If the weight of the current item is less than or equal to the current weight limit, we have two choices: include the item or exclude it.
  * If we include the item, we add its value to the maximum value obtained with the remaining weight.
  * If we exclude the item, we simply take the maximum value without including it.
  * The final answer will be found in `dp[n][W]`, where `n` is the number of items and `W` is the weight limit.

* Time Complexity: O(n*W), where n is the number of items and W is the weight limit.
* Space Complexity: O(n*W) for the DP table, which can be optimized to O(W) using a 1D array.

>- **Problems based on 0/1 Knapsack:**
>     * Subset Sum Problem
>     * Equal Sum Partition
>     * Partition Equal Subset Sum
>     * Count of Subsets with a given sum
>     * Minimum Subset Sum Difference
>     * Target Sum

#### Unbpunded Knapsack
* Problem Statement: Similar to the 0/1 Knapsack problem, but each item can be chosen multiple times.
* Approach: Use a 1D DP array where `dp[w]` represents the maximum value that can be obtained with a weight limit of `w`. The recurrence relation is:
  * For each item, iterate through all possible weights from the item's weight to the weight limit.
  * Update the DP array by considering the inclusion of the current item multiple times.
  * The final answer will be found in `dp[W]`, where `W` is the weight limit.
* Time Complexity: O(n*W), where n is the number of items and W is the weight limit.
* Space Complexity: O(W) for the DP array.
>- **Problems based on Unbounded Knapsack:**
>     * Rod Cutting Problem
>     * Coin Change Problem (Number of ways and Minimum coins)

#### Longest Common Subsequence (LCS)
* Problem Statement: Given two sequences, find the length of the longest subsequence present in both sequences.
* Approach: Use a 2D DP table where `dp[i][j]` represents the length of the LCS of the first `i` characters of sequence A and the first `j` characters of sequence B. The recurrence relation is:
  * If the characters match, increment the count from the previous indices.
  * If they don't match, take the maximum value from either excluding the current character from sequence A or sequence B.
  * The final answer will be found in `dp[m][n]`, where `m` and `n` are the lengths of sequences A and B respectively.
* Time Complexity: O(m*n), where m and n are the lengths of the two sequences.
* Space Complexity: O(m*n) for the DP table, which can be optimized to O(min(m, n)) using a 1D array.
>- **Problems based on LCS:**
>     * Longest Common Substring
>     * Print Longest Common Subsequence
>     * Shortest Common Supersequence
>     * Minimun number of deletions and insertions to convert one string to another
>     * Delete Operation for Two Strings
>     * print Shortest Common Supersequence
>     * Longest Palindromic Subsequence
>     * Minimum deletions to make a string palindrome
>     * Longest Repeating Subsequence
>     * Sequence Pattern Matching

#### Matrix Chain Multiplication
* Problem Statement: Given a sequence of matrices, find the most efficient way to multiply them together.
* Approach: Use a 2D DP table where `dp[i][j]` represents the minimum number of scalar multiplications needed to multiply matrices from index `i` to `j`. The recurrence relation is:
  * For each possible split point `k`, calculate the cost of multiplying the two resulting subchains and add the cost of multiplying the resulting matrices.
  * The final answer will be found in `dp[1][n-1]`, where `n` is the number of matrices.
* Time Complexity: O(n^3), where n is the number of matrices.
* Space Complexity: O(n^2) for the DP table.    
>- **Problems based on Matrix Chain Multiplication:**
>     * Palindrome Partitioning(Recursive && Memoization)
>     * Evaluate Expression to True Boolean Parent
>     * Scramble String(Recursive && Memoization)
>     * Egg Dropping Puzzle(Recursive && Memoization)

#### DP on Trees
* Problem Statement: Solve optimization problems on tree data structures using dynamic programming techniques.  
* Approach: Use a DFS traversal to compute DP values for each node based on its children. Store results in a DP table or array to avoid redundant calculations.
* Common problems include finding the maximum sum of non-adjacent nodes, counting the number of ways to color a tree, and finding the longest path in a tree.
* Time Complexity: O(n), where n is the number of nodes in the tree.
* Space Complexity: O(h), where h is the height of the tree due to the recursion stack.
>- **Problems based on DP on Trees:**
>     * Count Number of ways to color a tree
>     * Maximum sum of non-adjacent nodes in a tree
>     * Diameter of a tree
>     * Longest path sum from any node
>     * Longest path sum from leaf to leaf
