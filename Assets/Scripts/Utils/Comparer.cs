using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;

namespace Utils
{
    public class PriorityCompare<T1, T2> : IComparer<Tuple<float, T1, T2>>
    {
        public int Compare(Tuple<float, T1, T2> x, Tuple<float, T1, T2> y)
        {
            return x.Item1.CompareTo(y.Item1);
        }
    }
}