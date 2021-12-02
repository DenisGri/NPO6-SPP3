using System;
using System.Collections.Generic;
using System.Text;

namespace TestableLib
{
    class TestClass2
    {
            public string Name { get; set; }
            public override string ToString()
            {
                if (String.IsNullOrEmpty(Name))
                    return base.ToString();
                return Name;
            }
    }
}
