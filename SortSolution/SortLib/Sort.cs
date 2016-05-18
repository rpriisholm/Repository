using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SortLib
{
    public class Sort
    {
        MergeSort _MergeSort;
        MergeSort GetMergeSort()
        {
            if (_MergeSort != null)
            {
                // do nothing
            }
            else
            {
                _MergeSort = new MergeSort();
            }

            return _MergeSort;
        }


        public T[] MergeSort<T>(T[] array) where T : IComparable, IComparable<T>
        {
            return GetMergeSort().Sort<T>(array);
        }

        public T[] MergeSort<T>(T[] array_A, T[] array_B) where T : IComparable, IComparable<T>
        {
            return GetMergeSort().Merge<T>(array_A, array_B);
        }
    }

    public interface ISort
    {
        T[] Sort<T>(T[] array) where T : IComparable, IComparable<T>;
    }

    public interface IMerge
    {
        T[] Merge<T>(T[] array_A, T[] array_B) where T : IComparable, IComparable<T>;
    }

    public abstract class AMerge : IMerge
    {
        /**
            summary: Merges two sorted lists.
            precondition: Both lists must be sorted.
        */
        public T[] Merge<T>(T[] array_A, T[] array_B) where T : IComparable, IComparable<T>
        {
            // Convert the input arrays to lists, which gives more flexibility 
            // and the option to resize the arrays dynamically.
            List<T> leftList = array_A.OfType<T>().ToList();
            List<T> rightList = array_B.OfType<T>().ToList();
            List<T> resultList = new List<T>();

            // While the sublist are not empty merge them repeatedly to produce new sublists 
            // until there is only 1 sublist remaining. This will be the sorted list.
            while (leftList.Count > 0 || rightList.Count > 0)
            {
                if (leftList.Count > 0 && rightList.Count > 0)
                {
                    // Compare the 2 lists, append the smaller element to the result list
                    // and remove it from the original list.
                    if (leftList[0].CompareTo(rightList[0]) <= 0)
                    {
                        resultList.Add(leftList[0]);
                        leftList.RemoveAt(0);
                    }

                    else
                    {
                        resultList.Add(rightList[0]);
                        rightList.RemoveAt(0);
                    }
                }

                else if (leftList.Count > 0)
                {
                    resultList.Add(leftList[0]);
                    leftList.RemoveAt(0);
                }

                else if (rightList.Count > 0)
                {
                    resultList.Add(rightList[0]);
                    rightList.RemoveAt(0);
                }
            }

            // Convert the resulting list back to a static array
            return resultList.ToArray();
        }
    }

}
