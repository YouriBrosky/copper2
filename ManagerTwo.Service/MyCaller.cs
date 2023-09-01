using ManagerOne.Interface;

namespace ManagerTwo.Service;

public class MyCaller
{
    private readonly IManagerOne _managerOne;
    public MyCaller(IManagerOne managerOne)
    {
        _managerOne = managerOne;
    }

    public async Task Call(int amount)
    {
        var data = await _managerOne.GetPeople(amount);
        foreach (var person in data)
        {
            Console.WriteLine($"{person.Name} - {person.Age} - {person.Email} - {person.DateOfBirth}");
        }
    }
}