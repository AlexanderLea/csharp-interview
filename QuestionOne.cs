
using System;
using System.Linq;
using System.Threading.Tasks;
using Example.Interview.Question.Placeholders;
using Unity;

namespace Example.Interview.Question
{
    /// <summary>
    ///     Person service
    /// </summary>
    public class QuestionOne : BaseService, IPersonService
    {
        private readonly IAuthenticatedUser _authenticatedUser;
        private readonly Lazy<IConfigurationRepository> _configurationRepository;
        private readonly Lazy<IPositionService> _positionService;
        private readonly IUnityContainer _container;

        public QuestionOne(
            IAuthenticatedUser authenticatedUser,
            Lazy<IConfigurationRepository> configurationRepository,
            Lazy<IPositionService> positionService,
            IUnityContainer container
        )
        {
            _authenticatedUser = authenticatedUser;
            _configurationRepository = configurationRepository;
            _positionService = positionService;
            _container = container;
        }

        public async Task<PersonModel> GetPerson(Guid id)
        {
            var personRepository = _container.Resolve<IPersonRepository>();

            var configurationItems = _configurationRepository.Value.GetConfigurationForPerson(id);

            var configuration = configurationItems.First();

            if (!configuration.IsPersonAccessible)
            {
                return null;
            }

            var personEntity = personRepository.Get(id);

            var personModel = new PersonModel
            {
                FirstName = personEntity.FirstName,
                LastName = personEntity.LastName,
                LastEditedBy = GetPerson(personEntity.LastEditorId)
            };

            return personModel;
        }
        
        public async Task<PersonModel> GetLastRecordEditor(Guid id)
        {
            var personRepository = _container.Resolve<IPersonRepository>();
            
            var editorId = personRepository.GetRecordEditorId(id);

            return GetPerson(editorId);
        }
        
    }
}
