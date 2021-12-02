using System;
using Generator.SDK;

namespace Generator.Primitive
{
    public class ByteGenerator:IGenerator
    {
        public Type Type => typeof(int);
        
        private readonly Random _random;
        
        public ByteGenerator(Random random)
        {
            _random = random;
        }
        
        public object Generate()
        {
            return (byte)_random.Next(byte.MinValue, byte.MaxValue);
        }
        
    }
}