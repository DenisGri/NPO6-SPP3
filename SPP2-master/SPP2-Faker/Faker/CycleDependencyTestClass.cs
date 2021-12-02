using System;
using System.Collections.Generic;
using CustomGenerator;

namespace SPP2_Faker.Faker
{
    public class CycleDependencyTestClass
    {
        public A Property { get; set; }
        
        public int Int1 { get; set; }
        public int Int2 { get; set; }

        public class A
        {
            public B B { get; set; }
            
            public float Float1 { get; set; }
            public int Int2 { get; set; }
            
        }

        public class B
        {
            public C C { get; set; }
            
            public long Long1 { get; set; }
            public bool Bool1 { get; set; }
            
        }

        public class C
        {
            public D D { get; set; } 
            
            public DateTime Date1 { get; set; }
            public DateTime Date2 { get; set; }
            
        }
        
        public class D
        {
            public List<long> Longs;
            
            private List<A> _a;
            
            public short Short1 { get; set; }
            public string City1 { get; set; }
            
            public string City2 { get; }

            public string City3;
            
            public D(List<A> a, string city2)
            {
                City2 = city2;
                _a = a;
            }
        }
    }
}