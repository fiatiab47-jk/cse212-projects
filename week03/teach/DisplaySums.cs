public static class DisplaySums {
    public static void Run() {
        DisplaySumPairs([1, 2, 3, 4, 5, 6, 7, 8, 9, 10]);
        // Should show something like (order does not matter):
        // 6 4
        // 7 3
        // 8 2
        // 9 1 

        Console.WriteLine("------------");
        DisplaySumPairs([-20, -15, -10, -5, 0, 5, 10, 15, 20]);
        // Should show something like (order does not matter):
        // 10 0
        // 15 -5
        // 20 -10

        Console.WriteLine("------------");
        DisplaySumPairs([5, 11, 2, -4, 6, 8, -1]);
        // Should show something like (order does not matter):
        // 8 2
        // -1 11
    }

    /// <summary>
    /// Display pairs of numbers (no duplicates should be displayed) that sum to
    /// 10 using a set in O(n) time.  We are assuming that there are no duplicates
    /// in the list.
    /// </summary>
    /// <param name="numbers">array of integers</param>
    private static void DisplaySumPairs(int[] numbers) {
        // TODO Problem 2 - This should print pairs of numbers in the given array
        var valuesSeen = new HashSet<int>();
        foreach(var n in numbers)
        {
            // Compliment is the number that adds to another number in the array to sum up to 10
            int complement = 10 - n;
            // Checks if set already contains a compliment
            // Print the two numbers to sum up 10 if compliment is found 
            if (valuesSeen.Contains(complement))
            {
                Console.WriteLine($"{n} {complement}");
            }
            // Adds number set if not found in the set (valueSeen)
            valuesSeen.Add(n);
        }
    }
}