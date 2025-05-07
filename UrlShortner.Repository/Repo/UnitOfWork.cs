using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortner.Infra;
using UrlShortner.Repository.Interfaces;

namespace UrlShortner.Repository.Repo
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IUrlRepository UrlRepository { get; }

        public UnitOfWork(ApplicationDbContext context, IUrlRepository urlRepository)
        {
            _context = context;
            UrlRepository = urlRepository;
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
