using BetelgeuseAPI.Application.Repositories;
using BetelgeuseAPI.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetelgeuseAPI.Persistence.Repositories.File
{
    public class FileWriteRepository : WriteRepository<BetelgeuseAPIDbContext,BetelgeuseAPI.Domain.Entities.File>, IFileWriteRepository
    {
        public FileWriteRepository(BetelgeuseAPIDbContext context) : base(context)
        {
        }
    }
}
