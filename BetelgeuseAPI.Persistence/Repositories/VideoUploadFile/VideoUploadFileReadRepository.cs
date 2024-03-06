using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetelgeuseAPI.Application.Repositories.VideoUploadFile;
using BetelgeuseAPI.Domain.Entities;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.VideoUploadFile
{
    public class VideoUploadFileReadRepository:ReadRepository<BetelgeuseAPIDbContext,VideoUploadModel>,IVideoUploadFileReadRepository
    {
        public VideoUploadFileReadRepository(BetelgeuseAPIDbContext context) : base(context)
        {
        }
    }
}
