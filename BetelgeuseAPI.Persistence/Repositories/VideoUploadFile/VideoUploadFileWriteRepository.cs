using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetelgeuseAPI.Application.Repositories.VideoUploadFile;
using BetelgeuseAPI.Domain.Entities;
using BetelgeuseAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BetelgeuseAPI.Persistence.Repositories.VideoUploadFile
{
    public class VideoUploadFileWriteRepository:WriteRepository<BetelgeuseAPIDbContext,VideoUploadModel>,IVideoUploadFileWriteRepository
    {
        public VideoUploadFileWriteRepository(BetelgeuseAPIDbContext context) : base(context)
        {
        }
    };

}