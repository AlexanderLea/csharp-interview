using System;

namespace Example.Interview.Question.Placeholders
{
    public class PersonEntity
    {
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        public Guid Id { get; internal set; }
    }
}