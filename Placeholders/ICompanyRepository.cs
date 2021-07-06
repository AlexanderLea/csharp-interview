using System;
using System.Collections.Generic;

namespace Example.Interview.Question.Placeholders
{
    internal interface ICompanyRepository
    {
        public IEnumerable<CompanyEntity> FindCompaniesWithMatchingSynonims(string synonim);
        public IEnumerable<PersonEntity> FindEmployeesOfCompany(Guid companyId);
        public CompanyEntity Find(Guid id);
        public Guid Save(CompanyEntity company);
    }
}