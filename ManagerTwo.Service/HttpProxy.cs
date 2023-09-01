using ManagerOne.Interface;
using Newtonsoft.Json;

namespace ManagerTwo.Service;

public class HttpProxy : IManagerOne
{
    private readonly HttpClient _httpClient;
    public HttpProxy(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<IEnumerable<Person>> GetPeople(int amount)
    {
        var response = await _httpClient.GetAsync($"http://localhost:5252/Data?amount={amount}");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<IEnumerable<Person>>(content);
        }
        else
        {
            // Handle error
            return null;
        }
    }
}