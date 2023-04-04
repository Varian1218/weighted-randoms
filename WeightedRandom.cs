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

        public int Size
        {
            set => Weights = new float[value];
        }

        public float[] Weights { get; private set; }

        public int Next()
        {
            var value = _random.NextDouble() * Weights.Sum();
            for (var i = 0; i < Weights.Length; i++)
            {
                if (value < Weights[i]) return i;
                i++;
                value -= Weights[i];
            }

            return -1;
        }
    }
}