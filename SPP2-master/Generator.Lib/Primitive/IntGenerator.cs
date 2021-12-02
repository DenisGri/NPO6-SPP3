using System;
using Generator.SDK;

namespace Generator.Primitive
{
    public class IntGenerator:IGenerator
    {
        public Type Type => typeof(int);
        
        private readonly Random _random;
        
        public IntGenerator(Random random)
        {
            _random = random;
        }
        
        public object Generate()
        {
            return _random.Next(int.MinValue, int.MaxValue);
        }
        
    }
}