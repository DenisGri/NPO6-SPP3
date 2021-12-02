using System;
using System.Linq.Expressions;
using System.Reflection;
using Generator.SDK;

namespace SPP2_Faker.Faker
{
    public interface IFakerConfig
    {
        void Add<TClass, TPropertyType, TGenerator>(Expression<Func<TClass, TPropertyType>> expression)
            where TGenerator : IGenerator, new();

        IGenerator GetGenerator(MemberInfo memberInfo);
        IGenerator GetGenerator(ParameterInfo parameterInfo, Type type);
    }
}