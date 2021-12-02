using System;
using System.Collections.Generic;
using System.Text.Json;
using CustomGenerator;
using SPP2_Faker.Faker;

namespace Faker.ExampleMain
{
    public static class Program
    {
        static void Main(string[] args)
        {
            var config = new FakerConfig(); 
            
            config.Add<C, string, CompanyGenerator>(c => c.Company);            
            var faker = new Faker(config);
                 
            var example = faker.Create<A>();

            var jsonOptions = new JsonSerializerOptions() { IncludeFields = true, WriteIndented = true };
            var json = JsonSerializer.Serialize(example, jsonOptions);
            Console.WriteLine(json);
        }
    }


    internal class A
    {
        public double DoubleProperty { get; }
        public short ShortField;
        public float FloatField;
        public string CompanyButString;

        public B B;

        public A(B b, double doubleProperty)
        {
            B = b;
            DoubleProperty = doubleProperty;
        }
    }


    internal class C
    {
        public List<DateTime> DatesPropertyTwo { get; set; }
        public string RandomString { get; set; }
        public string Company;
        public A A;

    }

    internal class B
    {
        public char CharProperty { get; set; }
        public int IntField; 
        public List<string> StringPropertyOne { get; set; }

        public C C;

        public B(C c)
        {
            C = c;
        }
    }
    
    
}