using System.Reflection.Emit;
using System.Reflection.Metadata;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client.Payloads;

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

        // array to hold multiples, with length set from param
        double[] multiples = new double[length];
        // start with 'number'
        double n = number;
        // run number of times to match the length, adding next number to increasing index
        for (int i = 0; i < length; i++)
        {
            // add number to array, starting with 'number'
            multiples[i] = n;
            // increase number by number to get next multiple
            n += number;
        }

        return multiples; // return multiples array after building multiples
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

        // create new List with the size of the param List to hold shifted list
        List<int> newData = new List<int>(data.Count);

        // find shift amount within scope of size of array, in case it is larger than the array count
        int realAmount = amount;
        if (amount > data.Count)
        {
            realAmount = amount % data.Count;
        }

        // add items that overflow/shift past the end of the array to the beginning
        int realEnd = data.Count - realAmount;
        for (int i = realEnd; i < data.Count; i++)
        {
            newData.Add(data[i]);
        }

        // add items before the shift to the end
        for (int i = 0; i < realEnd; i++)
        {
            newData.Add(data[i]);
        }

        // copy the rotated list back into the original list
        for (int i = 0; i < data.Count; i++)
        {
            data[i] = newData[i];
        }


    }
}
