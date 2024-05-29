using BetelgeuseAPI.Application.Repositories.UserQuizInteraction;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.UserQuizInteraction;

public class UserQuizInteractionWriteRepository :
    WriteRepository<IdentityContext, Domain.Entities.User.UserQuizInteraction>, IUserQuizInteractionWriteRepository
{
    public UserQuizInteractionWriteRepository(IdentityContext context) : base(context)
    {
    }
}