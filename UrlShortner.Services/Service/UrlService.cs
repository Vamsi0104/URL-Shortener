using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortner.Entities;
using UrlShortner.Repository.Interfaces;
using UrlShortner.Services.Interface;

namespace UrlShortner.Services.Service
{
    public class UrlService : IUrlService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UrlService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<string> CreateShortUrlAsync(string longUrl, DateTime? expiryDate = null)
        {
            // Generate a simple short code (could use a more robust hash/algorithm)
            var shortUrl = Guid.NewGuid().ToString("N").Substring(0, 8);

            var urlEntity = new UrlEntity
            {
                LongUrl = longUrl,
                ShortUrl = shortUrl,
                VisitCount = 0,
                CreatedAt = DateTime.UtcNow,
                ExpiryDate = expiryDate
            };

            await _unitOfWork.UrlRepository.AddUrlAsync(urlEntity);
            await _unitOfWork.CommitAsync();

            return shortUrl;
        }

        public async Task<UrlEntity?> GetUrlForRedirectAsync(string shortUrl)
        {
            var urlEntity = await _unitOfWork.UrlRepository.GetUrlByShortUrlAsync(shortUrl);

            if (urlEntity == null || (urlEntity.ExpiryDate.HasValue && urlEntity.ExpiryDate.Value < DateTime.UtcNow))
            {
                return null;
            }

            urlEntity.VisitCount++;
            await _unitOfWork.CommitAsync();

            return urlEntity;
        }
    }
}
