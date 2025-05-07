namespace UrlShortner.DTO
{
    public class ShortenUrlRequest
    {
        public string LongUrl { get; set; } = string.Empty;
        public DateTime? ExpiryDate { get; set; }
        public string? CustomAlias { get; set; }
    }
}
