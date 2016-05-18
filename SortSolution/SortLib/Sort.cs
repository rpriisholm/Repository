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
            if(_MergeSort != null){
                // do nothing
            }
            else
            {
                _MergeSort = new MergeSort();
            }

            return _MergeSort;
        }

        public Sort()
        {

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

    public interface ISort{
        T[] Sort<T>(T[] array) where T : IComparable, IComparable<T>;

        T[] Merge<T>(T[] array_A, T[] array_B) where T : IComparable, IComparable<T>;

    }
}
