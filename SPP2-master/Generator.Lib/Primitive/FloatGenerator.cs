using System;
using Generator.SDK;

namespace Generator.Primitive
{
    public class FloatGenerator:IGenerator
    {
        public Type Type => typeof(float);
        
        private readonly Random _random;
        
        public FloatGenerator(Random random)
        {
            _random = random;
        }
        
        public object Generate()
        {
            var mantissa = (_random.NextDouble() * 2.0) - 1.0;
            var exponent = Math.Pow(2.0, _random.Next(-126, 128));
            
            return (float)(mantissa * exponent);
        }
        
    }
}