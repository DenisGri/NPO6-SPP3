using System;
using System.Collections.Generic;
using System.Text;

namespace AssemblyBrowserLib.Data
{
    public class NamespaceInfo
    {
        public string Signature { get; private set; }
        public List<DataContainer> MemberInfo { get; private set; }

        public NamespaceInfo(string signature, List<DataContainer> info)
        {
            this.Signature = signature;
            this.MemberInfo = info;
        }
    }
}
