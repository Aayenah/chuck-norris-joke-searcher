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
    public class IndexModel : PageModel
    {
        // Services
        private readonly ILogger<IndexModel> _logger;
        private readonly IJsonFetcher _jsonFetcher;

        [BindProperty(SupportsGet = true)]
        public string SearchValue { get; set; }

        public IEnumerable<Joke> Jokes { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IJsonFetcher jsonFetcher)
        {
            _logger = logger;
            _jsonFetcher = jsonFetcher;
        }

        public async Task OnGet()
        {
            Jokes = await _jsonFetcher.FetchChuckNorrisJokesByKeyword(SearchValue);
        }
    }
}
