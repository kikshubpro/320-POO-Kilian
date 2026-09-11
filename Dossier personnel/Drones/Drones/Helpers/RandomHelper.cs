using System;

namespace Drones
{
    /// <summary>
    /// Summary description for Class1
    /// </summary>
    internal class RandomHelper
    {
        private static Random alea = new Random();
        public static int Next(int  min = 0, int max = 1) => alea.Next(min, max);
    }
}

