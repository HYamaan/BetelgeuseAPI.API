using BetelgeuseAPI.Application.Repositories;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.File
{
    public class FileReadRepository : ReadRepository<BetelgeuseAPIDbContext,BetelgeuseAPI.Domain.Entities.File>, IFileReadRepository
    {
        public FileReadRepository(BetelgeuseAPIDbContext context) : base(context)
        {
        }
    }
}
