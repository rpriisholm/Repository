using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortLib
{
    public class InsertionSort : ISort
    {
        public T[] Sort<T>(T[] array) where T : IComparable, IComparable<T>
        {
            List<T> result = new List<T>();
            if (array.Count() > 0) {
                result.Add(array[0]);

                #region Iterates through each value in the array and puts the values ordered in the result list.
                for (int i = 1; i < array.Count(); i++)
                {
                    T current = array[i];
                    int lastIndex = result.Count() - 1;

                    #region Find location in result (lowest value first)
                    bool found = false;
                    for (int j = 0;  j < result.Count() && !found; j++)
                    {
                        if (result[j].CompareTo(current) > 0) {
                            result.Insert(j, current);
                            found = !found;
                        }
                        else
                        {
                            if (lastIndex == j)
                            {
                                result.Add(current);
                                found = !found;
                            }
                        }
                    }
                    #endregion
                }
                #endregion
            }

            return result.ToArray();
        }
    }
}
