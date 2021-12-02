using System;
using Generator.SDK;

namespace Generator.Primitive
{
    public class ShortGenerator:IGenerator
    {
        public Type Type => typeof(short);
        
        private readonly Random _random;
        
        public ShortGenerator(Random random)
        {
            _random = random;
        }
        
        public object Generate()
        {
            return (short)_random.Next(short.MinValue, short.MaxValue);
        }
        
    }
}