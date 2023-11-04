using BetelgeuseAPI.Application.Repositories.User;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.User;

public class UserReadRepository : ReadRepository<Domain.Entities.User>, IUserReadRepository
{
    public UserReadRepository(BetelgeuseAPIDbContext context) : base(context)
    {
    }
}