using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMY.WEB.Comm.Algorithm
{
    public class BubbleSort
    {
        public void DoBubbleSort1()
        {
            int[] arr = new int[] { 12, 3, 32, 44, 342, 43 };

            int count = arr.Length - 1, lastChange, i = 0;

            while (i < count)
            {
                lastChange = 0;

                for (i = 0; i < count; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        arr[i] = arr[i] + arr[i + 1];
                        arr[i + 1] = arr[i] - arr[i + 1];
                        lastChange = i;
                    }
                }

                i = 0;
                count = lastChange;
            }
        }
    }
}
