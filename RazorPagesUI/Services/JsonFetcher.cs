using RazorPagesUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace RazorPagesUI.Services
{
    public class JsonFetcher : IJsonFetcher
    {
        private readonly HttpClient _client;

        public JsonFetcher(HttpClient client)
        {
            _client = client;
        }

        public async Task<Joke> FetchRandomChuckNorrisJoke()
        {
            _client.BaseAddress = new Uri("https://api.chucknorris.io/jokes/");
            var response = await _client.GetStringAsync("random");
            Joke joke = JsonSerializer.Deserialize<Joke>(response);
            return joke;
        }

        public async Task<IEnumerable<Joke>> FetchChuckNorrisJokesByKeyword(string keyword)
        {
            if (string.IsNullOrEmpty(keyword)) return new List<Joke>();

            _client.BaseAddress = new Uri("https://api.chucknorris.io/jokes/");
            HttpResponseMessage message = await _client.GetAsync("search?query=" + keyword);
            
            if(message.IsSuccessStatusCode == false) return new List<Joke>();

            var response = await message.Content.ReadAsStringAsync();
            RootJsonObject rootJson = JsonSerializer.Deserialize<RootJsonObject>(response);
            return rootJson.Results;
        }
    }
}
