using System;

namespace TestableLib
{
    public class TestClass1
    {
        private int foo;
        public string str;
        protected bool flag;

        public TestClass1(int foo, string str, bool flag)
        {
            this.foo = foo;
            this.str = str;
            this.flag = flag;
        }

        public int Foo
        {
            get => foo;
            set => foo = value;
        }

        private int GetStrLength()
        {
            return str.Length;
        }
    }
}
