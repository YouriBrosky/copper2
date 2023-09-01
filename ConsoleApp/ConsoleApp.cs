using ManagerOne.Interface;

namespace ConsoleApp;

public class ConsoleApp
{
    private readonly IManagerOne _managerOne;
    public ConsoleApp(IManagerOne managerOne)
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