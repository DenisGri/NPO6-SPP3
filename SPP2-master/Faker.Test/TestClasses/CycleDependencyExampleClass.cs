using System.Collections.Generic;

namespace Faker.Test.TestClasses
{
    public class CycleDependencyExampleClass
    {
        public One One { get; set; }
    }

    public class One
    {
        public List<Two> List { get; set; }
    }

    public class Two
    {
        public OneTwo OneTwo { get; set; }
    }

    public class OneTwo 
    {
        public One One { get; set; }
    }
    
}