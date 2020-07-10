using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using RazorPagesUI.Models;
using RazorPagesUI.Services;

namespace RazorPagesUI.Pages
{
    public class RandomModel : PageModel
    {
        public Joke RandomJoke { get; set; }

        private readonly IJsonFetcher _jsonFetcher;

        public RandomModel(IJsonFetcher jsonFetcher)
        {
            _jsonFetcher = jsonFetcher;
        }

        public async Task OnGet()
        {
            RandomJoke = await _jsonFetcher.FetchRandomChuckNorrisJoke();
        }
    }
}