using System;

namespace Example.Interview.Question.Placeholders
{
    internal interface IPersonRepository
    {
        PersonEntity Get(Guid id);
    }
}