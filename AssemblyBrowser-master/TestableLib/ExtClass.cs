using System;
using System.Collections.Generic;
using System.Text;

namespace TestableLib
{
    public static class ExtClass
    {
        public static int CharCount(this string str, char c)
        {
            int counter = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == c)
                    counter++;
            }
            return counter;
        }

    }
}
