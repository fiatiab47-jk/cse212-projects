public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // TODO Problem 1 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        /*
            Step 1: Create a new array of doubles with the size equal to the length.
            This array will store the multiples of the given number.

            Step 2: Use a for loop that starts at index 0 and loops through each index of the array
            
            Step 3: For each index, calculate the multiple of the number.
            The first multiple should be (number * (index + 1)),
            second be (number * (index + 1)) and so forth till 
            it reaches the final index where (i < length)

            Step 4: Store the calculated multiple in the array at the current index.

            Step 5: Return The array stored in the variable (results) when the loop finishes.
        */

        var result = new double[length];

        for(int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        } 

        return result; // replace this return statement with your own
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // TODO Problem 2 Start
        // Remember: Using comments in your program, write down your process for solving this problem
        // step by step before you write the code. The plan should be clear enough that it could
        // be implemented by another person.

        /*
            Step 1: Determine the index where the list should be spilt.
            This can be found by subtracting amount from the total number of items in the data.
            This is done by; (data.Count - amount)

            Step 2: Use GetRange method to get the first part of the List<> from the index 0 to the 
            splitIndex (count); GetRange(index, count).

            Step 3: Use GetRange method to get the second part of the List<> from the splitIndex (index) 
            to the amount (count); GetRange(index, count).
        
            Step 4: Clear the original List<> so we can rebuild it.

            Step 5: Add the second part first; this rotates the second Range to the front of the List<>
            
            Step 6: Add the first part after it to complete the rotation.
        */

        var splitIndex = data.Count - amount;

        var firstPart = data.GetRange(0, splitIndex);

        var secondPart = data.GetRange(splitIndex, amount);

        data.Clear();

        data.AddRange(secondPart);

        data.AddRange(firstPart);

    }
}
