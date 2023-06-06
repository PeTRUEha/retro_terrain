using System;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;

namespace Utils
{
    public class Math
    {
        public static Vector3 Median(List<Vector3> values)
        {
            var length = values.Count;
            var x = new float[length];
            var y = new float[length];
            var z = new float[length];
            
            for (var i = 0; i < length; i++)
            {
                var vector = values[i];
                x[i] = vector.x;
                y[i] = vector.y;
                z[i] = vector.z;
            }
            Array.Sort(x);
            Array.Sort(y);
            Array.Sort(z);
            
            var middleIndex = length / 2;
            var middleVector = new Vector3(x[middleIndex], y[middleIndex], z[middleIndex]);
            
            if (length % 2 == 1)
            {
                return middleVector;
            }
            else
            {
                return (middleVector + new Vector3(x[middleIndex - 1], y[middleIndex - 1], z[middleIndex - 1])) / 2f;
            }
            
        }

        public static Vector3 DropY(Vector3 input)
        {
            return new Vector3(input.x, 0f, input.z);
        }

        public static float Mod360(float input)
        {
            return (input + 360f) % 360f;
        }
    }
}