using System;
using System.Collections.Generic;
using System.Text;

namespace AssemblyBrowserLib.Data
{
    public class DataContainer : MemberInformation
    {
        public List<MemberInformation> Members { get; set; }

        public DataContainer(string @namespace, string @class, string signature, List<MemberInformation> members) : base(@namespace, @class)
        {
            Signature = signature;
            Members = members;
        }
        public DataContainer(string @namespace, string @class) : base(@namespace, @class)
        {
            Members = new List<MemberInformation>();
        }
    }
}
