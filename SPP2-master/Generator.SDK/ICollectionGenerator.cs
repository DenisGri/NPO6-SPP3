using System;

namespace Generator.SDK
{
    public interface ICollectionGenerator
    {
        Type Type { get; }
        object Generate(Type type, Type argumentType, Func<Type, object> method);
    }
}