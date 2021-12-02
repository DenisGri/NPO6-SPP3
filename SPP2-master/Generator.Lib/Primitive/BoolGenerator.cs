using System;
using Generator.SDK;

namespace Generator.Primitive
{
    public class BoolGenerator:IGenerator
    {
        public Type Type => typeof(bool);
        
        private readonly Random _random;
        
        public BoolGenerator(Random random)
        {
            _random = random;
        }
        
        public object Generate()
        {
            return Convert.ToBoolean(_random.Next(2));
        }
        
    }
}