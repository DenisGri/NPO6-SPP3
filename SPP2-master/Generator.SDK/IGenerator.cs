using System;

namespace Generator.SDK
{
    public interface IGenerator
    {
        Type Type { get; }
        object Generate();
    }

}