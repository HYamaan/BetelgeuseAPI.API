using BetelgeuseAPI.Application.Repositories.UserQuizInteraction;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.UserQuizInteraction;

public class UserQuizInteractionReadRepository :
    ReadRepository<IdentityContext, Domain.Entities.User.UserQuizInteraction>, IUserQuizInteractionReadRepository
{
    public UserQuizInteractionReadRepository(IdentityContext context) : base(context)
    {
    }
}