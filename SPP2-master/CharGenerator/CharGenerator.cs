using System;
using Generator.SDK;

namespace Plugin.CharGenerator
{
    public class CharGenerator:IGenerator
    {
        public Type Type => typeof(char);

        private readonly Random _random;

        public CharGenerator(Random random)
        {
            _random = random;
        }

        public object Generate()
        {
            return (char)_random.Next('A', 'z');
        }

    }
}