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
            if (result.Count() > 0) {
                result.Add(array[0]);

                #region Iterates through each value in the array and puts the values ordered in the result list.
                for (int i = 0; i < array.Count(); i++)
                {
                    T current = array[i];
                    int lastIndex = result.Count() - 1;

                    #region Find location in result (lowest value first)
                    bool found = false;
                    for (int j = 0; result.Count() < j && !found; j++)
                    {
                        if (result[j].CompareTo(current) < 0) {
                            result.Insert(j, current);
                        }
                        else
                        {
                            if (lastIndex == j)
                            {
                                result.Add(current);
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
