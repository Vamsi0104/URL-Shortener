using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrlShortner.Repository.Interfaces
{
    public interface IUnitOfWork
    {
        IUrlRepository UrlRepository { get; }
        public Task CommitAsync();
    }
}
