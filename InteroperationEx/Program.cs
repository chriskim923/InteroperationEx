using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteroperationEx
{
    class Program
    {
        static void Main(string[] args)
        {
            int noElements = 1000;
            int[] myArray = new int[noElements];

            for (int i = 0; i < noElements; i++)
                myArray[i] = i * 10;

            // sum array in c++ using a vector.
            unsafe
            {
                fixed(int* pmyArray = &myArray[0])
                {
                    CppWrapper.CppWrapperClass controlCpp = new CppWrapper.CppWrapperClass(pmyArray, noElements);
                    controlCpp.getSum();
                    int sumOfArray = controlCpp.sum;
                }
            }
        }
    }
}
