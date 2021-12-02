using System;
using System.Collections.Generic;
using System.Text;

namespace AssemblyBrowserLib.Data
{
    public class MemberInformation
    {
        public string Signature { get; set; }
        public string Class { get; set; }

        public MemberInformation(string signature, string @class)
        {
            Signature = signature;
            Class = @class;
        }
    }
}
