using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SortLib
{
    public class Sort
    {
        MergeSort _MergeSort = new MergeSort();

        InsertionSort _InsertionSort = new InsertionSort();

        /* O(n) = n * log_2(n) 
        * n is cause number of values that should be compared, log_2(n) is cause all values are splited 
        * into a single value and then compared and putted togheter again one and one, two and two, four and four ...
        */
        public T[] MergeSort<T>(T[] array) where T : IComparable, IComparable<T>
        {
            return _MergeSort.Sort<T>(array);
        }

        /* O(n) = n^2 */
        public T[] InsertionSort<T>(T[] array) where T : IComparable, IComparable<T>
        {
            return _InsertionSort.Sort<T>(array);
        }
    }

    public interface ISort
    {
        /**
            summary: can sort an unsorted array.
        */
        T[] Sort<T>(T[] array) where T : IComparable, IComparable<T>;
    }

    public interface IMerge
    {
        T[] Merge<T>(T[] array_A, T[] array_B) where T : IComparable, IComparable<T>;
    }

    public abstract class AMerge : IMerge
    {
        /**
            summary: Merges two sorted arrays.
            precondition: Both arrays must be sorted (smallest value first). 
        */
        public T[] Merge<T>(T[] arrayA, T[] arrayB) where T : IComparable, IComparable<T>
        {
            int indexA = 0;
            int indexB = 0;
            int indexRes = 0;

            int resultSize = arrayA.Count() + arrayB.Count();
            T[] arrayRes = new T[resultSize];

            while (arrayA.Count() > indexA || arrayB.Count() > indexB)
            {
                if (arrayA.Count() > indexA && arrayB.Count() > indexB)
                {
                    // Compare the 2 arrays, append the smaller element to the result list
                    if (arrayA[indexA].CompareTo(arrayB[indexB]) <= 0)
                    {
                        arrayRes[indexRes] = arrayA[indexA];
                        indexA++;
                        indexRes++;
                    }

                    else
                    {
                        arrayRes[indexRes] = arrayB[indexB];
                        indexB++;
                        indexRes++;
                    }
                }
                else {
                    if (arrayA.Count() > indexA)
                    {
                        arrayRes[indexRes] = arrayA[indexA];
                        indexA++;
                        indexRes++;
                    }
                    else {
                        if (arrayB.Count() > indexB)
                        {
                            arrayRes[indexRes] = arrayB[indexB];
                            indexB++;
                            indexRes++;
                        }
                    }
                }
            }

            // Convert the resulting list back to a static array
            return arrayRes;
        }
    }

}
