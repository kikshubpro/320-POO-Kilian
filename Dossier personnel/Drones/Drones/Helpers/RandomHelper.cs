using System;

namespace Drones.Helpers
{
    internal class RandomHelper
    {
        private static Random alea = new Random();
        public static int Next(int min = 0, int max = 1) => alea.Next(min, max);
    }
}

