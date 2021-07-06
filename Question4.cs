using csharp_interview.Placeholders;
using Example.Interview.Question.Placeholders;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace csharp_interview
{
    internal class Question4
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IRecordManagementService _recordManagementService;

        public Question4(ICompanyRepository companyRepository, IRecordManagementService recordManagementService)
        {
            _companyRepository = companyRepository;
            _recordManagementService = recordManagementService;
        }

        public void SaveCompany(String companyName, IEnumerable<string> synonims)
        {
            var companyId = _companyRepository.Save(new CompanyEntity { CompanyName = companyName, Synonims = synonims });
            
            var changeTracker = new ChangeTracker(_companyRepository);
            
            changeTracker.CompanyRemoved += OnCompanyRemoved;
            changeTracker.TrackChanges(companyId);
        }

        private void OnCompanyRemoved(object sender, Guid e)
        {
            _recordManagementService.SendEmailToAdministrator("Company removed", $"Someone has removed the company {e}");
        }

        internal class ChangeTracker
        {
            public event EventHandler<Guid> CompanyRemoved;
            private readonly ICompanyRepository _companyRepository;

            public ChangeTracker(ICompanyRepository companyRepository)
            {
                _companyRepository = companyRepository;
            }
            
            /// <summary>
            /// Track changes. (For now, only detect if the company has been removed)
            /// </summary>
            /// <param name="id">Company id</param>
            public void TrackChanges(Guid id)
            {
                var company = _companyRepository.Find(id);
                if (company == null)
                {
                    CompanyRemoved?.Invoke(this, id);
                    return;
                }
                
                Thread.Sleep(5000); 

                TrackChanges(id);
            }
        }
    }
}
