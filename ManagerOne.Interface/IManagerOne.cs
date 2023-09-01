namespace ManagerOne.Interface;

public interface IManagerOne
{
    Task<IEnumerable<Person>> GetPeople(int amountOfPeople);
}
