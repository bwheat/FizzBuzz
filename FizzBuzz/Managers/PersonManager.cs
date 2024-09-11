using FizzBuzz.Model;
using FizzBuzz.Repositories;

namespace FizzBuzz.Managers 
{
    public interface IPersonManager
    {
        public List<Person> Results();
        public Person? Update(Person person);
    }

    public class PersonManager : IPersonManager
    {
        IPersonRepository _personRepository;
        public PersonManager(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public List<Person> Results()
        {
            return _personRepository.Results();
        }

        public Person? Update(Person person)
        {
            return _personRepository.Update(person);
        }
    }
}