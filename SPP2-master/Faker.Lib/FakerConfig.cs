using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Generator.SDK;

namespace SPP2_Faker.Faker
{
    public class FakerConfig : IFakerConfig
    {
        private readonly Dictionary<MemberInfo, IGenerator> _generators = new();
        
        public void Add<TClass, TPropertyType, TGenerator>(Expression<Func<TClass, TPropertyType>> expression)
            where TGenerator : IGenerator, new()
        {
            var generator = (IGenerator)Activator.CreateInstance<TGenerator>();

            var body = (MemberExpression)expression.Body;
            var memberInfo = body.Member;
            _generators.Add(memberInfo, generator);
        }

        public IGenerator GetGenerator(MemberInfo memberInfo)
        {
            _generators.TryGetValue(memberInfo, out var result);
            return result;
        }

        public IGenerator GetGenerator(ParameterInfo parameterInfo, Type type)
        {
            foreach (var member in _generators.Keys)
            {
                if (member.Name.Equals(parameterInfo.Name, StringComparison.OrdinalIgnoreCase) && member.DeclaringType == type)
                {
                    _generators.TryGetValue(member, out var generator);
                    return generator;
                }
            }

            return null;
        }
        
    }
}