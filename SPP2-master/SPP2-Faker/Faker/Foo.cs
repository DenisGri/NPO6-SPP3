using System;

namespace SPP2_Faker.Faker
{
    public class Foo
    {
        private readonly int _int1;
        private readonly int _int2;
        private readonly float _float1;
        public float _float2;
        private readonly DateTime _date1;
        
        private DateTime Date2 { get; set; }

        private Foo(int int1, int int2)
        {
            _int1 = int1;
        }
        
        private Foo(int int1, int int2, float float1, DateTime date1)
        {
            _int1 = int1;
            _int2 = int2;
            _float1 = float1;
            _date1 = date1;
        }
        
        private Foo(int int1, int int2, float float1)
        {
            _int1 = int1;
            _int2 = int2;
            _float1 = float1;
        }
        
        public void SetFloat2(float value)
        {
            _float2 = value;
        }

        public override string ToString()
        {
            return "int1: " + _int1 + "\n" +
                   "int2: " + _int2 + "\n" +
                   "float1: " + _float1 + "\n" +
                   "float2: " + _float2 + "\n" +
                   "date1: " + _date1 + "\n" +
                   "date2: " + Date2 + "\n";
        }
    }
}