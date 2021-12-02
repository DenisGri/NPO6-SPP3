using System;
using System.Collections.Generic;
using Generator.SDK;

namespace CustomGenerator
{
    public class CompanyGenerator:IGenerator
    {
        public Type Type => typeof(string);
        
        private readonly Random _random = new();
        private readonly List<string> _companies;

        public CompanyGenerator()
        {
            _companies = new List<string>(){ "Apple Inc", "TOYOTA", "Microsoft", "Amazon", "Facebook", "Tesla", "Nokia", "MasterCard", "Alibaba Group", "Magnit",
            "MTBank", "Visa", "Sony", "EPAM", "Ozon", "NIKE" };
        }
        
        public object Generate()
        {
            return _companies[_random.Next(_companies.Count)];
        }
    }
}