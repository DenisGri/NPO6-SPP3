using System;
using System.Linq;
using System.Reflection;
using Generator;
using SPP2_Faker.Faker;

namespace Faker
{
    public class Faker
    {
        private readonly CycleDependencyResolver _resolver = new();
        private readonly IFakerConfig _config;

        public Faker()
        {
        }
        
        public Faker(IFakerConfig config)
        {
            _config = config;
        }
        
        public T Create<T>()
        {
            return (T)Create(typeof(T));
        }

        private object Create(Type type)
        {
            var generator = GeneratorsDictionary.GetGenerator(type);
            if (generator != null)
            {
                return generator.Generate();
            }
            
            if (type.IsGenericType)
            {
                var collectionType = type.GetGenericTypeDefinition();
                var argumentType = type.GetGenericArguments().Single();

                if (_resolver.IsCycleDependencyDetected(argumentType))
                {
                    return null;
                }
                
                _resolver.PushSkipType(argumentType);
                
                var collectionGenerator = GeneratorsDictionary.GetCollectionGenerator(collectionType);
                if (collectionGenerator != null)
                {
                    return collectionGenerator.Generate(type, argumentType, Create);
                }
                
                _resolver.PopSkipType();
            }
            else if (type.IsClass)
            {
                if (_resolver.IsCycleDependencyDetected(type))
                {
                    return null;
                }
                
                _resolver.PushType(type);
                
                var constructor = GetConstructorWithMaxParametersCount(type);
                if (constructor == null)
                {
                    throw new ArgumentException("Class: " + type + " has no public constructors");
                }
                
                var result =  CreateUsingConstructor(type, constructor);
                FillPublicFields(result);
                FillPublicProperties(result);
                
                _resolver.PopType();

                return result;
            }
            
            try
            {
                return Activator.CreateInstance(type);
            }
            catch (MissingMethodException)
            {
                return default;
            }
        }

        private object CreateUsingConstructor(Type type, ConstructorInfo constructor)
        {
            try
            {
                return constructor.Invoke((from parameterInfo in constructor.GetParameters()
                    let customGenerator = _config?.GetGenerator(parameterInfo, type)
                    select customGenerator != null
                        ? customGenerator.Generate()
                        : Create(parameterInfo.ParameterType)).ToArray());
            }
            catch (TargetInvocationException e)
            {
                Console.WriteLine(e.StackTrace);
                return null;
            }
        }

        private void FillPublicFields(object instance)
        {
            FieldInfo[] fields = instance.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);
            foreach (FieldInfo field in fields)
            {
                var customGenerator = _config?.GetGenerator(field);
                field.SetValue(instance,
                    customGenerator != null 
                        ? customGenerator.Generate() 
                        : Create(field.FieldType));
            }
        }

        private void FillPublicProperties(object instance)
        {
            PropertyInfo[] properties = instance.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo property in properties)
            {
                if (property.CanWrite)
                {
                    var customGenerator = _config?.GetGenerator(property);
                    property.SetValue(instance,
                        customGenerator != null 
                            ? customGenerator.Generate() 
                            : Create(property.PropertyType));
                }
            }
        }
        
        private static ConstructorInfo GetConstructorWithMaxParametersCount(Type type)
        {
            var constructors = type
                .GetConstructors(BindingFlags.Instance | BindingFlags.Public)
                .ToList();
            
            constructors.Sort((x, y) =>
            {
                var xx = x.GetParameters().Length;
                var yy = y.GetParameters().Length;
                return yy.CompareTo(xx);
            });
            return constructors.FirstOrDefault();
        }

    }
    
}