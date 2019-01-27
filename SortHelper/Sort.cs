using System;

namespace SortHelper
{
    /// <summary>
    /// Class containing various sorting algorithms with various efficiencies to sort elements
    /// </summary>
    /// <typeparam name="T">The <see cref="Type"/> of the elements to sort</typeparam>
    public class Sort<T>
    {
        /// <summary>
        /// Delegate to determine which element takes priority when sorting
        /// </summary>
        /// <param name="a">The first element of the comparison</param>
        /// <param name="b">The second element of the comparison</param>
        /// <returns>Whether element a should take priority over element b</returns>
        public delegate bool Comparator(T a, T b);

        /// <summary>
        /// Subprogram to sort an array using Bubble Sort - O(n^2)
        /// </summary>
        /// <param name="array">The array to be sorted</param>
        /// <param name="comparator">The comparator to determine which elements take priority</param>
        /// <returns>The sorted array</returns>
        public T[] BubbleSort(T[] array, Comparator comparator)
        {
            // Iterating through all elements
            for (int i = 0; i < array.Length; ++i)
            {
                for (int j = 0; j < array.Length - i - 1; ++j)
                {
                    // If elements are out of place, swap them
                    if (!comparator(array[j], array[j + 1]))
                    {
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }

            // Returning the sorted array
            return array;
        }

        /// <summary>
        /// Subprogram to swap to elements by reference
        /// </summary>
        /// <param name="a">The first element to be swapped</param>
        /// <param name="b">The second element to be swapped</param>
        private void Swap(ref T a, ref T b)
        {
            // Swapping the elements
            T swapHolder;
            swapHolder = a;
            a = b;
            b = swapHolder;
        }


        public T[] InsertionSort()
        {
            throw new NotImplementedException();
        }

        public T[] QuickSort()
        {
            throw new NotImplementedException();
        }

        public T[] HeapSort()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Subprogram to sort an array using Merge Sort - O(n log n)
        /// </summary>
        /// <param name="array">The array to be sorted</param>
        /// <param name="comparator">The comparator to determine which elements take priority</param>
        /// <returns>The sorted array</returns>
        public T[] MergeSort(T[] array, Comparator comparator)
        {
            // The first and second array in the merge sort
            T[] firstArray;
            T[] secondArray;

            // Returning array in the the size of the array is 0 or 1
            if (array.Length == 0 || array.Length == 1)
            {
                return array;
            }

            // Initializing the two arrays with the appropriate size
            firstArray = new T[(array.Length + 1) / 2];
            secondArray = new T[array.Length / 2];

            // Setting up first array
            for (int i = 0; i < firstArray.Length; ++i)
            {
                firstArray[i] = array[i];
            }

            // Setting up second array
            for (int i = 0; i < secondArray.Length; ++i)
            {
                secondArray[i] = array[i + firstArray.Length];
            }

            // Returning recursive case of merge sort
            return Merge(firstArray, secondArray, comparator);
        }

        /// <summary>
        /// Subprogram to merge two arrays in a merge sort
        /// </summary>
        /// <param name="firstArray">The first array to be merged</param>
        /// <param name="secondArray">The second array to be merged</param>
        /// <param name="comparator">The comparator to determine which elements take priority</param>
        /// <returns>The merged array</returns>
        private T[] Merge(T[] firstArray, T[] secondArray, Comparator comparator)
        {
            // Initializing merged array and indexers
            T[] mergedArray = new T[firstArray.Length + secondArray.Length];
            int firstIndex = 0;
            int secondIndex = 0;

            // Looping through the array and adding the appropriate elements to the array
            for (int i = 0; i < mergedArray.Length; ++i)
            {
                // Adding from appropriate array as required
                if (firstIndex == firstArray.Length)
                {
                    mergedArray[i] = secondArray[secondIndex++];
                }
                else if (secondIndex == secondArray.Length)
                {
                    mergedArray[i] = firstArray[firstIndex++];
                }
                else
                {
                    mergedArray[i] = comparator(firstArray[firstIndex], secondArray[secondIndex]) 
                        ? firstArray[firstIndex++] : secondArray[secondIndex++];
                }
            }

            // Returning the merged array
            return mergedArray;
        }
    }
}
