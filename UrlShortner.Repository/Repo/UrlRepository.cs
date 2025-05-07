using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortner.Entities;
using UrlShortner.Infra;
using UrlShortner.Repository.Interfaces;

namespace UrlShortner.Repository.Repo
{
    public class UrlRepository : IUrlRepository
    {
        private readonly ApplicationDbContext _context;

        public UrlRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UrlEntity> GetUrlByShortUrlAsync(string shortUrl)
        {
            return await _context.Urls.FirstOrDefaultAsync(u => u.ShortUrl == shortUrl);
        }

        public async Task AddUrlAsync(UrlEntity url)
        {
            await _context.Urls.AddAsync(url);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
