using ManagerOne.Interface;

namespace ManagerOne.Service;

public class ManagerOne : IManagerOne
{
    static readonly Random Random = new Random();
    
    public Task<IEnumerable<Person>> GetPeople(int amount)
    {
        List<Person> people = new List<Person>();
        for (int i = 0; i < amount; i++)
        {
            people.Add(GenerateRandomPerson());
        }
        
        return Task.FromResult<IEnumerable<Person>>(people);
    }

    private Person GenerateRandomPerson()
    {
        string[] names = { "Alice", "Bob", "Charlie", "David", "Eva" };
        string[] domains = { "gmail.com", "yahoo.com", "outlook.com" };

        return new Person
        {
            Name = names[Random.Next(names.Length)],
            Age = Random.Next(18, 65),
            Email = $"{names[Random.Next(names.Length)]}@{domains[Random.Next(domains.Length)]}",
            DateOfBirth = DateTime.Now.AddYears(-Random.Next(18, 65))
        };
    }
}