using System;
using System.Collections.Generic;
using System.Text;

namespace LabsHelper
{
    public static class Helper
    {
        public static double ProdTree(int l, int r)
        {
            if (l > r)
                return 1;
            if (l == r)
                return l;
            if (r - l == 1)
                return (double)l * r;
            int m = (l + r) / 2;
            return ProdTree(l, m) * ProdTree(m + 1, r);
        }

        public static double FactTree(int n)
        {
            if (n < 0)
                return 0;
            if (n == 0)
                return 1;
            if (n == 1 || n == 2)
                return n;
            return ProdTree(2, n);
        }
    }
}