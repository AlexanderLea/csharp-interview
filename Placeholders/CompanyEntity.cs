using System;
using System.Collections.Generic;

namespace Example.Interview.Question.Placeholders
{
    public class CompanyEntity
    {
        public string CompanyName { get; internal set; }
        public IEnumerable<string> Synonims { get; internal set; }
        public Guid Id { get; internal set; }
    }
}