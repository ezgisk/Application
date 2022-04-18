using Application.Entitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.GenericRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<User> UserRepository { get; }
        IGenericRepository<Book> BookRepository { get; }
        Task Commit();
    }
}
