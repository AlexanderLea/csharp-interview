using System;
using System.Threading.Tasks;

namespace Example.Interview.Question.Placeholders
{
    internal interface IPersonRepository
    {
        PersonEntity Get(Guid id);
        Task<PersonEntity> Find(string personName);
    }
}