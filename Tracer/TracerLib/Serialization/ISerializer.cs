using System;
using System.Collections.Generic;
using System.Text;
using TracerLib.Tracer;

namespace TracerLib.Serialization
{
    interface ISerializer
    {
        string Serialize(TraceResult traceResult);
    }
}
