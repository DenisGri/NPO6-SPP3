using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using CustomGenerator;

namespace SPP2_Faker.Faker
{
    class Program
    { 
        static void Main(string[] args)
        {
            
            var config = new FakerConfig(); 
            
            config.Add<CycleDependencyTestClass.D, string, CityGenerator>(d => d.City1);
            config.Add<CycleDependencyTestClass.D, string, CityGenerator>(d => d.City2);
            config.Add<CycleDependencyTestClass.D, string, CityGenerator>(d => d.City3);
            
            // config.Add<Bar, string, CityGenerator>(bar => bar.City1);
            // config.Add<Bar, string, CityGenerator>(bar => bar.City2);
            // config.Add<Bar, string, CityGenerator>(bar => bar.City3);

            var faker = new Faker(config);
            
            var testObj = faker.Create<CycleDependencyTestClass>();
            
            var jsonOptions = new JsonSerializerOptions() { IgnoreNullValues = true, IncludeFields = true, WriteIndented = true };
            var json = JsonSerializer.Serialize(testObj, jsonOptions);
            Console.WriteLine(json);
            
        }
    }
}