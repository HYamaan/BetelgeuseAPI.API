using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetelgeuseAPI.Application.Repositories
{
    public interface IUnitOfWork
    {
        Task CommitIdentityAsync();
        void CommitIdentity();
    }
}
