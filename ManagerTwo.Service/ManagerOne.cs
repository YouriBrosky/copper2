using ManagerOne.Interface;

namespace ManagerTwo.Service;

public class ManagerOne
{
    private readonly IManagerOne _managerOne;
    public ManagerOne(IManagerOne managerOne)
    {
        _managerOne = managerOne;
    }

    public async Task GetSomePeople(int amountOfPeople)
    {
        var data = await _managerOne.GetPeople(amountOfPeople);
        foreach (var person in data)
        {
            Console.WriteLine($"{person.Name} - {person.Age} - {person.Email} - {person.DateOfBirth}");
        }
    }
}