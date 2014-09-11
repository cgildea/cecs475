using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _475_2
{
    delegate bool CompareEmployeeSSNDes(Object o1, Object o2);

    class BubbleSort
    {
        public static void SortSSN(IPayable[] a, CompareEmployeeSSNDes e)
        {
            int i;
            int j;
            object temp;
            for (i = a.Length - 1; i >= 0; i--)
            {
                for (j = 1; j <= i; j++)
                {
                    if (e(a[j - 1].getSSN(), a[j].getSSN()))
                    {
                        temp = a[j - 1];
                        a[j - 1] = a[j];
                        a[j] = (IPayable)temp;
                    }
                }
            }
        }
        public static bool SSNAscending(object f, object s)
        {
            return (int)f > (int)s;
        }
    }
}
