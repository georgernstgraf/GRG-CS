using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/pokemon")]
public class PokemonController : ControllerBase
{
    private readonly PokeApiService _pokeApiService;

    public PokemonController(PokeApiService pokeApiService)
    {
        _pokeApiService = pokeApiService;
    }

    [HttpGet("{name}")]
    public async Task<IActionResult> GetPokemon(string name)
    {
        var pokemon = await _pokeApiService.GetPokemonAsync(name);

        if (pokemon == null)
            return NotFound(new { message = "Pokémon not found!" });

        return Ok(pokemon);
    }
}
