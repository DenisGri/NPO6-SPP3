using System;
using System.Collections;
using System.Collections.Generic;
using Generator.SDK;

namespace Generator.Collection
{
    public class ListGenerator:ICollectionGenerator
    {
        public Type Type => typeof(List<>);

        private readonly Random _random;

        public ListGenerator(Random random)
        {
            _random = random;
        }
        
        public object Generate(Type type, Type argumentType, Func<Type, object> method)
        {
            var result = (IList)Activator.CreateInstance(type);

            var count = _random.Next(4) + 3;
            for (var i = 0; i < count; i++)
            {
                result?.Add(method(argumentType));
            }
        
            return result;
        }
        
    }
}