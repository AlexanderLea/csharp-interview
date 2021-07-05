using Example.Interview.Question.Placeholders;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace csharp_interview
{
    internal class Question3
    {
        private readonly ICompanyRepository _companyRepository;
        
        public Question3(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public IEnumerable<PersonEntity> FindEmployees(string companySynonim)
        {
            var result = new List<PersonEntity>();
            var companies = _companyRepository.FindCompaniesWithMatchingSynonims(companySynonim);
       
            Parallel.ForEach(companies, company =>
            {
                var employees = _companyRepository.FindEmployeesOfCompany(company.Id);
                result.AddRange(employees);
            });

            return result;
        }
    }
}
