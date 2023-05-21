using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using RestSharp;
using System.Reflection.Metadata;

namespace Pokedex.Models
{
    public class PokemonModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }
        public string[] Type { get; set; }
        public string Gender { get; set; }

        public List<string> Weakness { get; set; }


        public async Task ObtainType()
        {
            var client = new RestClient($"https://pokeapi.co/api/v2/type/{Type[0].ToLower()}");
            Console.WriteLine(client.ToString());
            var request = new RestRequest(Method.Get.ToString());
            RestResponse response = await client.ExecuteAsync(request);
        }

        public async Task ObtainWeakness()
        {
            var client = new RestClient($"https://pokeapi.co/api/v2/type/{Type[0].ToLower()}");
            if (Type[0] == "normal")
            {
                client = new RestClient($"https://pokeapi.co/api/v2/type/1");
            }
            else if (Type[0] == "fighting")
            {
                client = new RestClient($"https://pokeapi.co/api/v2/type/2");
            }
            else if (Type[0] == "flying")
            {
                client = new RestClient($"https://pokeapi.co/api/v2/type/3");
            }
            else if (Type[0] == "poison")
            {
                client = new RestClient($"https://pokeapi.co/api/v2/type/4");
            }
            else if (Type[0] == "ground")
            {
                client = new RestClient($"https://pokeapi.co/api/v2/type/5");
            }
            else if (Type[0] == "rock")
            {
                client = new RestClient($"https://pokeapi.co/api/v2/type/6");
            }
            else if (Type[0] == "bug")
            {
                client = new RestClient($"https://pokeapi.co/api/v2/type/7");
            }
            else if (Type[0] == "ghost")
            {
                client = new RestClient($"https://pokeapi.co/api/v2/type/8");
            }
            else if (Type[0] == "steel")
            {
                client = new RestClient($"https://pokeapi.co/api/v2/type/9");
            }
            else if (Type[0] == "fire")
            {
                client = new RestClient($"https://pokeapi.co/api/v2/type/10");
            }
            else if (Type[0] == "water")
            {
                client = new RestClient($"https://pokeapi.co/api/v2/type/11");
            }
            else if (Type[0] == "grass")
            {
                client = new RestClient($"https://pokeapi.co/api/v2/type/12");
            }
            else if (Type[0] == "electric")
            {
                client = new RestClient($"https://pokeapi.co/api/v2/type/13");
            }
            else if (Type[0] == "psychic")
            {
                client = new RestClient($"https://pokeapi.co/api/v2/type/14");
            }
            else if (Type[0] == "ice")
            {
                client = new RestClient($"https://pokeapi.co/api/v2/type/15");
            }
            else if (Type[0] == "dragon")
            {
                client = new RestClient($"https://pokeapi.co/api/v2/type/16");
            }
            else if (Type[0] == "dark")
            {
                client = new RestClient($"https://pokeapi.co/api/v2/type/17");
            }
            else if (Type[0] == "fairy")
            {
                client = new RestClient($"https://pokeapi.co/api/v2/type/18");
            }
            else if (Type[0] == "unknown")
            {
                client = new RestClient($"https://pokeapi.co/api/v2/type/10001");
            }
            else if (Type[0] == "shadow")
            {
                client = new RestClient($"https://pokeapi.co/api/v2/type/10002");
            }
            
            if (Type[1] != null)
            {
                if (Type[0] == "normal")
                {
                    client = new RestClient($"https://pokeapi.co/api/v2/type/1");
                }
                else if (Type[0] == "fighting")
                {
                    client = new RestClient($"https://pokeapi.co/api/v2/type/2");
                }
                else if (Type[0] == "flying")
                {
                    client = new RestClient($"https://pokeapi.co/api/v2/type/3");
                }
                else if (Type[0] == "poison")
                {
                    client = new RestClient($"https://pokeapi.co/api/v2/type/4");
                }
                else if (Type[0] == "ground")
                {
                    client = new RestClient($"https://pokeapi.co/api/v2/type/5");
                }
                else if (Type[0] == "rock")
                {
                    client = new RestClient($"https://pokeapi.co/api/v2/type/6");
                }
                else if (Type[0] == "bug")
                {
                    client = new RestClient($"https://pokeapi.co/api/v2/type/7");
                }
                else if (Type[0] == "ghost")
                {
                    client = new RestClient($"https://pokeapi.co/api/v2/type/8");
                }
                else if (Type[0] == "steel")
                {
                    client = new RestClient($"https://pokeapi.co/api/v2/type/9");
                }
                else if (Type[0] == "fire")
                {
                    client = new RestClient($"https://pokeapi.co/api/v2/type/10");
                }
                else if (Type[0] == "water")
                {
                    client = new RestClient($"https://pokeapi.co/api/v2/type/11");
                }
                else if (Type[0] == "grass")
                {
                    client = new RestClient($"https://pokeapi.co/api/v2/type/12");
                }
                else if (Type[0] == "electric")
                {
                    client = new RestClient($"https://pokeapi.co/api/v2/type/13");
                }
                else if (Type[0] == "psychic")
                {
                    client = new RestClient($"https://pokeapi.co/api/v2/type/14");
                }
                else if (Type[0] == "ice")
                {
                    client = new RestClient($"https://pokeapi.co/api/v2/type/15");
                }
                else if (Type[0] == "dragon")
                {
                    client = new RestClient($"https://pokeapi.co/api/v2/type/16");
                }
                else if (Type[0] == "dark")
                {
                    client = new RestClient($"https://pokeapi.co/api/v2/type/17");
                }
                else if (Type[0] == "fairy")
                {
                    client = new RestClient($"https://pokeapi.co/api/v2/type/18");
                }
                else if (Type[0] == "unknown")
                {
                    client = new RestClient($"https://pokeapi.co/api/v2/type/10001");
                }
                else if (Type[0] == "shadow")
                {
                    client = new RestClient($"https://pokeapi.co/api/v2/type/10002");
                }
            }

            var request = new RestRequest(Method.Get.ToString());
            RestResponse response = await client.ExecuteAsync(request);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var type = JsonConvert.DeserializeObject<PokeApiType>(response.Content);

                Weakness = type.damage_relations.double_damage_from
                    .Select(t => t.name)
                    .ToList();
            }
        }

        public class PokeApiType
        {
            public PokeApiTypeDamageRelations damage_relations { get; set; }
        }

        public class PokeApiTypeDamageRelations
        {
            public List<PokeApiTypeDamage> double_damage_from { get; set; }
        }

        public class PokeApiTypeDamage
        {
            public string name { get; set; }
            public string url { get; set; }
        }

    }
}
