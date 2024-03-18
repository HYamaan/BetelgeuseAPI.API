using BetelgeuseAPI.Application.Repositories.FileContent.File;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.FileContent.File
{
    public class FileReadRepository : ReadRepository<BetelgeuseAPIDbContext, Domain.Entities.File.File>, IFileReadRepository
    {
        public FileReadRepository(BetelgeuseAPIDbContext context) : base(context)
        {
        }
    }
}
