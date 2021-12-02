using System;
using System.Collections.Generic;

namespace Faker
{
    public class CycleDependencyResolver
    {
        private const string Message = "== Cycle dependency was found! ==";
        
        private readonly Stack<Type> _stackTypeTrace = new();
        private readonly Stack<Type> _stackSkipTrace = new();

        private bool _printed;

        public bool IsCycleDependencyDetected(Type type)
        {
            if (_stackSkipTrace.TryPeek(out var result))
            {
                if (result == type)
                {
                    return false;
                }
            }

            if (_stackTypeTrace.Contains(type))
            {
                PrintMessage();
                return true;
            }

            return false;
        }

        private void PrintMessage()
        {
            if (!_printed)
            {
                Console.WriteLine(Message);
                _printed = true;
            }
        }

        public void PushType(Type type)
        {
            _stackTypeTrace.Push(type);
        }

        public void PopType()
        {
            if (_stackTypeTrace.Count != 0)
            {
                _stackTypeTrace.Pop();
            }
        }
        
        public void PushSkipType(Type type)
        {
            _stackSkipTrace.Push(type);
        }
        
        public void PopSkipType()
        {
            if (_stackSkipTrace.Count != 0)
            {
                _stackSkipTrace.Pop();
            }
        }
        
    }
}