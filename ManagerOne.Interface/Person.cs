using Newtonsoft.Json;

namespace ManagerOne.Interface;

public class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public DateTime DateOfBirth { get; set; }
}