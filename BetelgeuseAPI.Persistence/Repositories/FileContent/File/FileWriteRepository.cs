using BetelgeuseAPI.Application.Repositories.FileContent.File;
using BetelgeuseAPI.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetelgeuseAPI.Persistence.Repositories.FileContent.File
{
    public class FileWriteRepository : WriteRepository<BetelgeuseAPIDbContext, Domain.Entities.File.File>, IFileWriteRepository
    {
        public FileWriteRepository(BetelgeuseAPIDbContext context) : base(context)
        {
        }
    }
}
