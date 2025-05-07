using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UrlShortner.Entities;

namespace UrlShortner.Repository.Interfaces
{
    public interface IUrlRepository
    {
        Task<UrlEntity> GetUrlByShortUrlAsync(string shortUrl);
        Task AddUrlAsync(UrlEntity url);
        Task SaveChangesAsync();
    }
}
