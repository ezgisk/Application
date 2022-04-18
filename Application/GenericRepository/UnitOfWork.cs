using Application.Entitities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.GenericRepository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly SampleDbContext _context;
        private IGenericRepository<User> _userRepository;
        private IGenericRepository<Book> _booksRepository;
      
        public UnitOfWork(SampleDbContext context)
        {
            _context = context;
        }
        public IGenericRepository<User> UserRepository
        {
            get { return _userRepository ?? (_userRepository = new GenericRepository<User>(_context)); }
        }

        public IGenericRepository<Book> BookRepository
        {
            get { return _booksRepository ?? (_booksRepository = new GenericRepository<Book>(_context)); }
        }

        // I manage all my database commit and rollback transactions from only one point:
        public async Task Commit()
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    await _context.SaveChangesAsync();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    _context.Dispose();
                    transaction.Rollback();
                }

            }

        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            System.GC.SuppressFinalize(this);
        }
    }
}
