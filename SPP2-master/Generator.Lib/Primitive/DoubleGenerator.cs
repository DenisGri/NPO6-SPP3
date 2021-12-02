using System;
using Generator.SDK;

namespace Generator.Primitive
{
    public class DoubleGenerator:IGenerator
    {
        public Type Type => typeof(double);
        
        private readonly Random _random;
        
        public DoubleGenerator(Random random)
        {
            _random = random;
        }

        public object Generate()
        {
            var mantissa = (_random.NextDouble() * 2.0) - 1.0;
            var exponent = Math.Pow(2.0, _random.Next(-1073, 1023));
            
            return mantissa * exponent;
        }
        
    }
}