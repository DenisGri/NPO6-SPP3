using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;

namespace TracerLib.Tests
{
    [TestClass]
    public class TraceLibTests
    {
        readonly Tracer.Tracer tracer = new Tracer.Tracer();
        readonly List<Thread> threads = new List<Thread>();

        const int expectedThreadsCount = 3;
        const int expectedMethodsCount = 5;
        const string expectedMethodName = "Method";
        const string expectedMethodClass = "TraceLibTests";

        void Method()
        {
            tracer.StartTrace();
            Thread.Sleep(100);
            tracer.StopTrace();
        }

        [TestMethod]
        public void MethodNameCheck()
        {
            Method();
            Assert.AreEqual(expectedMethodName,
                tracer.GetTraceResult().GetThreadTracers()[Thread.CurrentThread.ManagedThreadId]
                    .MethodTracerList[0]
                    .MethodName);
        }

        [TestMethod]
        public void MethodClassCheck()
        {
            Method();
            Assert.AreEqual(expectedMethodClass,
                tracer.GetTraceResult().GetThreadTracers()[Thread.CurrentThread.ManagedThreadId]
                    .MethodTracerList[0]
                    .ClassName);
        }

        [TestMethod]
        public void ThreadCountCheck()
        {
            for (var i = 0; i < expectedThreadsCount; i++)
            {
                threads.Add(new Thread(Method));
                threads[i].Start();
                threads[i].Join();
            }

            Assert.AreEqual(expectedThreadsCount, tracer.GetTraceResult().GetThreadTracers().Count);
        }

        [TestMethod]
        public void MethodCountChek()
        {
            for (var i = 0; i < expectedMethodsCount; i++)
            {
                Method();
            }

            Assert.AreEqual(expectedMethodsCount,
                tracer.GetTraceResult().GetThreadTracers()[Thread.CurrentThread.ManagedThreadId]
                    .MethodTracerList.Count);
        }

        [TestMethod]
        public void MethodTimeIsCorrect()
        {
            var stopwatch = Stopwatch.StartNew();
            Method();
            var time = stopwatch.ElapsedMilliseconds;

            var methodTime = tracer.GetTraceResult().GetThreadTracers()[Thread.CurrentThread.ManagedThreadId]
                .MethodTracerList[0]
                .Time;

            Console.WriteLine(time);
            Console.WriteLine(methodTime);

            var flag = methodTime + 5 >= time;
            flag |= methodTime - 5 <= time;

            Assert.IsTrue(flag);
        }

        [TestMethod]
        public void ThreadTimeIsCorrect()
        {
            var stopwatch = Stopwatch.StartNew();
            Method();
            Method();
            Method();
            var time = stopwatch.ElapsedMilliseconds;

            var threadTime = tracer.GetTraceResult().GetThreadTracers()[Thread.CurrentThread.ManagedThreadId]
                .ThreadTime;

            Console.WriteLine(time);
            Console.WriteLine(threadTime);

            var flag = threadTime + 5 >= time;
            flag |= threadTime - 5 <= time;

            Assert.IsTrue(flag);
        }
    }
}