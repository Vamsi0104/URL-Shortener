using Microsoft.AspNetCore.Mvc;
using UrlShortner.DTO;
using UrlShortner.Services.Interface;

namespace UrlShortner.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UrlShortenerController : ControllerBase
    {
        private readonly IUrlService _urlService;

        public UrlShortenerController(IUrlService urlService)
        {
            _urlService = urlService;
        }

        [HttpPost("shorten")]
        public async Task<IActionResult> ShortenUrl([FromBody] ShortenUrlRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.LongUrl))
                return BadRequest("Long URL is required.");

            var shortUrl = await _urlService.CreateShortUrlAsync(request.LongUrl, request.ExpiryDate);

            var response = new ShortenUrlResponse
            {
                ShortUrl = shortUrl,
                LongUrl = request.LongUrl,
                VisitCount = 0,
                CreatedAt = DateTime.UtcNow,
                ExpiryDate = request.ExpiryDate
            };

            return Ok(response);
        }

        [HttpGet("{shortUrl}")]
        public async Task<IActionResult> RedirectToLongUrl(string shortUrl)
        {
            var urlEntity = await _urlService.GetUrlForRedirectAsync(shortUrl);

            if (urlEntity == null)
                return NotFound("Short URL not found or has expired.");

            return Redirect(urlEntity.LongUrl);
        }
    }
}
