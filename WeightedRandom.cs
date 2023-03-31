using System;
using System.Linq;

namespace WeightedRandoms
{
    public class WeightedRandom
    {
        private Random _random;

        public int Seed
        {
            set => _random = new Random(value);
        }

        public int Next(float[] weights)
        {
            var value = _random.NextDouble() * weights.Sum();
            for (var i = 0; i < weights.Length; i++)
            {
                if (value < weights[i]) return i;
                i++;
                value -= weights[i];
            }

            return -1;
        }
    }
}