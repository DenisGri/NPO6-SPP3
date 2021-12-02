using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace TracerLib.Tracer
{
    public class Tracer : ITracer
    {
        private readonly TraceResult _traceResult;
        private readonly MD5CryptoServiceProvider _md5;

        public Tracer()
        {
            _traceResult = new TraceResult(new ConcurrentDictionary<int, ThreadTracer>());
            _md5 = new MD5CryptoServiceProvider();
        }

        public TraceResult GetTraceResult()
        {
            return _traceResult;
        }

        public void StartTrace()
        {
            var threadTracer = _traceResult.GetThreadTracer(Thread.CurrentThread.ManagedThreadId);

            var stackTrace = new StackTrace();

            var path = stackTrace.ToString().Split(new string[] { "\r\n" }, StringSplitOptions.None);
            path[0] = "";

            var bytesPath = Encoding.ASCII.GetBytes(string.Join("", path));
            var hash = _md5.ComputeHash(bytesPath);

            var methodName = stackTrace.GetFrames()?[1].GetMethod().Name;
            var className = stackTrace.GetFrames()?[1].GetMethod().ReflectedType?.Name;

            threadTracer.PushMethod(methodName, className, hash);
        }

        public void StopTrace()
        {
            var threadTracer = _traceResult.GetThreadTracer(Thread.CurrentThread.ManagedThreadId);

            var path = new StackTrace().ToString().Split(new string[] { "\r\n" }, StringSplitOptions.None);
            path[0] = "";

            var bytesPath = Encoding.ASCII.GetBytes(string.Join("", path));
            var hash = _md5.ComputeHash(bytesPath);

            threadTracer.PopMethod(hash);
        }
    }
}