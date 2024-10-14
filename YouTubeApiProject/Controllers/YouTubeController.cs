using Microsoft.AspNetCore.Mvc;
using YouTubeApiProject.Services;
using YouTubeApiProject.Models;

namespace YouTubeApiProject.Controllers
{
    public class YouTubeController : Controller
    {
        private readonly YouTubeApiService _youtubeService;

        public YouTubeController(YouTubeApiService youtubeService)
        {
            _youtubeService = youtubeService;
        }

        // Display Search Page 
        public IActionResult Index()
        {
            return View(new List<YouTubeVideoModel>());
        }

        // Handle search query using GET and POST methods
        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> Search(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                // If no query, return to the search page with empty results
                return View("Index", new List<YouTubeVideoModel>());
            }

            // Get search results from the YouTubeApiService
            var videos = await _youtubeService.SearchVideosAsync(query);
            return View("Index", videos); // Render the Index view with search results
        }
    }
}
