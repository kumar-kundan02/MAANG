### Recursion

Recursion is a programming technique where a function calls itself to solve smaller instances of the same problem until it reaches a base case. It is commonly used for problems that can be broken down into smaller, similar subproblems.
* **Base Case:** The condition under which the recursion stops. It prevents infinite recursion and eventual stack overflow.
* **Recursive Case:** The part of the function where it calls itself with a modified argument, moving towards the base case.
* **Types of Recursion:**
  * **Direct Recursion:** A function calls itself directly.
  * **Indirect Recursion:** A function calls another function, which in turn calls the first function.
* **Advantages of Recursion:**
  * Simplifies code and makes it easier to read and maintain.
    * Useful for problems that have a natural recursive structure, such as tree traversals and combinatorial problems.
* **Disadvantages of Recursion:**
  * Can lead to high memory usage due to function call stack.
    * May result in stack overflow if the recursion depth is too high.
* **Examples of Recursive Problems:**
  * Factorial calculation
    * Fibonacci sequence
    * Tree traversals (preorder, inorder, postorder)
    
Note: While recursion is a powerful tool, it is essential to consider its limitations and choose the appropriate approach based on the problem at hand. In some cases, iterative solutions may be more efficient in terms of memory and performance.    

#### Points to Remember:
* Recursion contains below three main parts:
  * Induction: What to do for a single input
    * Like Main Logic: f(n) = f(n-1) + something => Here Something is Induction
  * Base Case:
    * Smallest valid input for which we know the answer
    * e.g. for factorial, base case is f(0) = 1
  * Hypothesis:
    * Fucntion Definition i.e. Recursion Function Signature
    * Identify parameters required to solve the problem (input and return type)

#### Recursion Varriations:
* **Simple IBH Recursion:**
  * Function calls itself with smaller input until base case is reached.
  * Example: Calculating factorial of a number. f(n) = f(n-1) * [Stuff to do with n]
* **Input/Output Based Recursion:**
  * Function takes input and produces output based on recursive calls.
  * Initialize output and break it into two parts:
    * Output1: Part1 solved by recursion => Choice1
    * Output2: Part2 solved by induction => Choice2
  * Combine Output1 and Output2 to get final result.
  * Here we are populationig output based on choices.
     * For +ve choice output1 and 
     * For -ve choice output2
  * Hence Recursion tree id formed based on choices. **(Choice Diagram)**
  * Example: Generating all subsets of a set.
* **Backtracking Recursion:**
  * Function explores all possible solutions and backtracks when a solution path is not valid.
    * Used for constraint satisfaction problems.
    * Example: N-Queens problem, Sudoku solver.
* **Tree Recursion:**
  * Function makes multiple recursive calls for each input, leading to a tree-like structure of calls.
    * Example: Fibonacci sequence calculation.
* **Tail Recursion:**
  * A special case of recursion where the recursive call is the last operation in the function.
    * Can be optimized by the compiler to avoid increasing the call stack.
    * Example: Tail-recursive factorial calculation.
* **Mutual Recursion:**
  * Two or more functions call each other recursively.
    * Example: Even and odd number checking functions.
* **Nested Recursion:**
  * A function calls itself with the result of another recursive call.
    * Example: Hofstadter's Q-sequence.
* **Head Recursion:**
  * The recursive call is made before any other operations in the function.
    * Example: Printing numbers in reverse order.
#### Example: Factorial Calculation using Simple IBH Recursion in C#
```csharp
public class RecursionExamples
{
    // Simple IBH Recursion to calculate factorial
    public static int Factorial(int n)
    {
        // Base Case
        if (n == 0)
        {
            return 1; // Factorial of 0 is 1
        }
        // Recursive Case
        return n * Factorial(n - 1); // f(n) = n * f(n-1)
    }

    public static void Main(string[] args)
    {
        int number = 5;
        int result = Factorial(number);
        Console.WriteLine($"Factorial of {number} is {result}");
    }
}
```
#### Example: Generating All Subsets of a Set using Input/Output Based Recursion in C#
>- Recursive backtracking:
At each step, you decide:
    - Include the current element in the subset.
    - Exclude the current element and move on.

```csharp
using System;
using System.Collections.Generic;
public class RecursionExamples
{
    // Input/Output Based Recursion to generate all subsets of a set
    public static void GenerateSubsets(List<int> set, List<int> currentSubset, int index, List<List<int>> allSubsets)
    {
        // Base Case: If index reaches the end of the set
        if (index == set.Count)
        {
            allSubsets.Add(new List<int>(currentSubset)); // Add current subset to all subsets
            return;
        }

        // Choice 1: Include the current element
        currentSubset.Add(set[index]);
        GenerateSubsets(set, currentSubset, index + 1, allSubsets);

        // Choice 2: Exclude the current element
        currentSubset.RemoveAt(currentSubset.Count - 1);
        GenerateSubsets(set, currentSubset, index + 1, allSubsets);
    }

    public static void Main(string[] args)
    {
        List<int> set = new List<int> { 1, 2, 3 };
        List<List<int>> allSubsets = new List<List<int>>();
        GenerateSubsets(set, new List<int>(), 0, allSubsets);

        Console.WriteLine("All Subsets:");
        foreach (var subset in allSubsets)
        {
            Console.WriteLine("{" + string.Join(", ", subset) + "}");
        }
    }
}
```