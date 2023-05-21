using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Pokedex.Models;

namespace Pokedex.Controllers
{
    [ApiController]
    [Route("pokedex/controller")]
    public class PokedexController :ControllerBase
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string pokeApiUrl = "https://pokeapi.co/api/v2/pokemon/";

        private static List<PokemonModel> pokemons = new List<PokemonModel>();

        [HttpGet]
        public ActionResult<IEnumerable<PokemonModel>> Get()
        {
            return pokemons;
        }

        // Método GET que retorna o pokemon capturado com o ID especificado
        [HttpGet("{id}")]
        public ActionResult<PokemonModel> Get(int id)
        {
            // Busca o pokemon capturado com o ID especificado na lista de pokemons capturados
            var pokemon = pokemons.FirstOrDefault(p => p.Id == id);

            // Se o pokemon não for encontrado, retorna um erro 404 (Not Found)
            if (pokemon == null)
                if (pokemon == null)
            {
                return NotFound();
            }
            return pokemon;
        }

        // Método POST que adiciona um novo pokemon capturado na lista
        [HttpPost]
        public async Task<ActionResult<PokemonModel>> Post(PokemonModel pokemon)
        {

            // Buscar dados do pokemon na PokeAPI
            var response = await client.GetAsync(pokeApiUrl + pokemon.Number);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.ToString());
                var responseString = await response.Content.ReadAsStringAsync();
                var pokemonData = JsonConvert.DeserializeObject<JObject>(responseString);
                
                if (pokemonData != null)
                {
                    // preencher dados do pokemon capturado com os dados da PokeAPI
                    pokemon.Name = pokemonData["name"].ToString();
                    pokemon.Type = pokemonData["types"].Select(t => t["type"]["name"].ToString()).ToArray();
                    await pokemon.ObtainType();
                    await pokemon.ObtainWeakness();

                    pokemon.Id = pokemons.Count + 1;
                    pokemons.Add(pokemon);
                    // Retorna um código 201 (Created) com o novo pokemon capturado no corpo da resposta
                    return CreatedAtAction(nameof(Get), new { id = pokemon.Id }, pokemon);
                }
                else
                {
                    return NotFound($"Pokemon '{pokemon.Name}' not found.");
                }
                
            }
            else
            {
                return BadRequest($"Could not find pokemon with number {pokemon.Number}.");
            }

            
        }

        // Método PUT que atualiza os dados de um pokemon capturado com o ID especificado
        [HttpPut("{id}")]
        public ActionResult<PokemonModel> Put(int id, PokemonModel pokemon)
        {
            // Busca o pokemon capturado com o ID especificado na lista de pokemons capturados
            var pokemonIndex = pokemons.FindIndex(p => p.Id == id);

            // Se o pokemon não for encontrado, retorna uma exception
            if (pokemonIndex == -1)
            {
                    throw new Exception($"Pokemon with ID {id} not found.");
            }
            else
            {
                // Atualiza os dados do pokemon capturado com os dados enviados na requisição
                return pokemons[pokemonIndex] = pokemon;

            }
        }

        // Método DELETE que remove o pokemon capturado com o ID especificado da lista
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            // Busca o pokemon capturado com o ID especificado na lista de pokemons capturados
            var pokemonIndex = pokemons.FindIndex(p => p.Id == id);

            if (pokemonIndex == -1)
            {
                return NotFound();
            }
            pokemons.RemoveAt(pokemonIndex);
                return NoContent();
            }
    }
}
