using System;
using Generator.SDK;

namespace Generator.System
{
    public class DateTimeGenerator:IGenerator
    {
        public Type Type => typeof(DateTime);
        
        private readonly Random _random;
        
        public DateTimeGenerator(Random random)
        {
            _random = random;
        }
        
        public object Generate()
        {
            int year = _random.Next(1970, DateTime.Now.Year);
            int month = _random.Next(1, 12);
            int day = _random.Next(1, DateTime.DaysInMonth(year, month));
            int hours = _random.Next(24);
            int minutes = _random.Next(60);
            int seconds = _random.Next(60);
            
            return new DateTime(year, month, day, hours, minutes, seconds);
        }
        
    }
}