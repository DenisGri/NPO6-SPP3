using System;
using Generator.SDK;

namespace LongGenerator
{
    public class LongGenerator:IGenerator
    {
        public Type Type => typeof(long);
        
        private readonly Random _random;

        public LongGenerator(Random random)
        {
            _random = random;
        }
        
        public object Generate()
        {
            long result = _random.Next(int.MinValue, int.MaxValue);
            result = (result << 32);
            result = result | (uint)_random.Next(int.MinValue, int.MaxValue);
            return result;
        }
    }
}