using System;
using System.Collections.Generic;

namespace Example.Interview.Question.Placeholders
{
    public interface IConfigurationRepository
    {
        public List<ConfigurationEntity> GetConfigurationForPerson(Guid id);
    }
}