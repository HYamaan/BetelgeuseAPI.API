using BetelgeuseAPI.Application.Repositories;
using BetelgeuseAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BetelgeuseAPI.Persistence.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly DbContext _context;
        public UnitOfWork(IdentityContext identityContext)
        {
            _context = identityContext;
        }

        public async Task CommitIdentityAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void CommitIdentity()
        {
            _context.SaveChangesAsync();
        }
    }
}
