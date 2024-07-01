using Newtonsoft.Json;
using TestAPI_Demo_P3.MVVM.Models;

namespace TestAPI_Demo_P3.Services;

public class APIService
{
    private readonly HttpClient _httpClient;
    
    public APIService()
    {
        _httpClient = new HttpClient();
    }
    
    public async Task<SWCharacters> GetSWCharactersAsync(int id)
    {
        var response = await _httpClient.GetStringAsync($"https://www.swapi.tech/api/people/{id}");
        var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(response);
        return apiResponse?.Result;
    }
    
    private class ApiResponse
    {
        [JsonProperty("result")]
        public SWCharacters Result { get; set; }
    }
}