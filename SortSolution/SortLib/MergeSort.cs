using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortLib
{
    public class MergeSort : ISort
    {

        public T[] Sort<T>(T[] array) where T : IComparable, IComparable<T>
        {
            T[] result;

            // If list size is 0 (empty) or 1, consider it sorted and return it
            // (using less than or equal prevents infinite recursion for a zero length array).
            if (array.Length <= 1)
            {
                result = array;
            }
            else
            {
                // Else list size is > 1, so split the list into two sublists.
                int middleIndex = (array.Length) / 2;
                T[] left = new T[middleIndex];
                T[] right = new T[array.Length - middleIndex];

                Array.Copy(array, left, middleIndex);
                Array.Copy(array, middleIndex, right, 0, right.Length);

                // Recursively call MergeSort() to further split each sublist
                // until sublist size is 1.
                left = Sort(left);
                right = Sort(right);

                // Merge the sublists returned from prior calls to MergeSort()
                // and return the resulting merged sublist.
                result = Merge(left, right);
            }
            return result;
        }

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
