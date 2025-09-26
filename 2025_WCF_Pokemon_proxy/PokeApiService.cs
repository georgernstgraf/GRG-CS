using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

public class PokeApiService
{
    private readonly HttpClient _httpClient;

    public PokeApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<PokemonData?> GetPokemonAsync(string name)
    {
        var response = await _httpClient.GetAsync($"https://pokeapi.co/api/v2/pokemon/{name.ToLower()}");

        if (!response.IsSuccessStatusCode)
            return null;

        var json = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<PokemonData>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }
}

public class PokemonData
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int BaseExperience { get; set; }
    public int Height { get; set; }
    public int Weight { get; set; }
}
