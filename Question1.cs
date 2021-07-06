
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
    public class Question1 : BaseService, IPersonService
    {
        private readonly IAuthenticatedUser _authenticatedUser;
        private readonly Lazy<IConfigurationRepository> _configurationRepository;
        private readonly Lazy<IPositionService> _positionService;
        private readonly IUnityContainer _container;

        public Question1(
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
        
        /// <summary>
        /// Load a person that has a name matching given personName
        /// </summary>
        /// <param name="personName">FirstName or LastName of the Person to find</param>
        /// <returns>PersonModel matching the given personName</returns>
        public async Task<PersonModel> GetPerson(string personName)
        {
            var personRepository = _container.Resolve<IPersonRepository>();

            var personEntity = await personRepository.Find(personName);

            var configurationItems = _configurationRepository.Value.GetConfigurationForPerson(personEntity.Id);

            var configuration = configurationItems.First();

            if (!configuration.IsPersonAccessible)
            {
                return null;
            }

            var personModel = new PersonModel
            {
                FirstName = personEntity.FirstName,
                LastName = personEntity.LastName
            };

            return personModel;           
        }
    
        public async Task<PersonModel> GetLastRecordEditor(string personName)
        {
            var personRepository = _container.Resolve<IPersonRepository>();
            
            var editorName =  await personRepository.FindEditorName(personName);

            return GetPerson(editorName);
        }
    }
}
