using RazorPagesUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RazorPagesUI.Services
{
    public interface IJsonFetcher
    {
        Task<Joke> FetchRandomChuckNorrisJoke();
        Task<IEnumerable<Joke>> FetchChuckNorrisJokesByKeyword(string keyword);
    }
}
