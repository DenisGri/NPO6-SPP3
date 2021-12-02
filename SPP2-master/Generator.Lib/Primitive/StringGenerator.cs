using System;
using Generator.SDK;

namespace Generator.Primitive
{
    public class StringGenerator:IGenerator
    {
       
        public Type Type => typeof(string);

        private readonly Random _random;

        public StringGenerator(Random random)
        {
            _random = random;
        }

        public object Generate()
        {
            var bytes = new byte[_random.Next(16, 32)];
            _random.NextBytes(bytes);
            return Convert.ToBase64String(bytes);
        }
    }
}