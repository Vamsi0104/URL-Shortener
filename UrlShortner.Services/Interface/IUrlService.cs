using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortner.Entities;

namespace UrlShortner.Services.Interface
{
    public interface IUrlService
    {
        Task<string> CreateShortUrlAsync(string longUrl, DateTime? expiryDate = null);
        Task<UrlEntity?> GetUrlForRedirectAsync(string shortUrl);
    }
}
