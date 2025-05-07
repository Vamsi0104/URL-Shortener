using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortner.DTO
{
    public class ShortenUrlResponse
    {
        public string ShortUrl { get; set; } = string.Empty;
        public string LongUrl { get; set; } = string.Empty;
        public int VisitCount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}
