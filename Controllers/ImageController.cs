using Microsoft.AspNetCore.Mvc;

namespace vuedemobackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImageController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ImageController> _logger;

        public ImageController(ILogger<ImageController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetImage")]  /// Get[NameofController]
        public IEnumerable<ImageData> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new ImageData
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}