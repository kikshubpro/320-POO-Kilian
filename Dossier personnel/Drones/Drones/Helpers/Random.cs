using System;

namespace Drones
{
    /// <summary>
    /// Summary description for Class1
    /// </summary>
    public static class RandomHelper
    {
        private Random _randomValue = new Random();

        public Random RandomValue { get => _randomValue; private set; }
    }
}

