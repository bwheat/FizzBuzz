using FizzBuzz.Model;

namespace FizzBuzz.Repositories
{
    public interface IPersonRepository
    {
        public List<Person> Results();
        public Person? Update(Person person);
    }

    public class PersonRepository : IPersonRepository
    {
        CapServicesDbContext _context;
        public PersonRepository(CapServicesDbContext context)
        {
            _context = context;
        }

        public List<Person> Results()
        {
            return _context.Persons.ToList();
        }
        public Person? Update(Person person)
        {
            using (var db = _context)
            {
                var result = db.Persons.SingleOrDefault(x => x.Id == person.Id);
                if (result != null)
                {
                    result.LastName = person.LastName;
                    result.FirstName = person.FirstName;
                    result.Age = person.Age;
                    db.SaveChanges();
                    return person;
                }
            }
            return null;
        }
    }
}