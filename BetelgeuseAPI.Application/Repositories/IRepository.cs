using BetelgeuseAPI.Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace BetelgeuseAPI.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
