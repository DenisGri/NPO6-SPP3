using System;

namespace Faker.Test.TestClasses
{
    public class ExampleClass
    {
        public string String { get; set; }
        public DateTime DateTime { get; set; }
        public char Char { get; set; }
        public decimal Decimal { get; set; }
        
        public int Int { get; }
        public long Long { get; }
        public ulong Ulong { get; }

        public ExampleClass(int i, long l, ulong @ulong)
        {
            Int = i;
            Long = l;
            Ulong = @ulong;
        }
    }
}