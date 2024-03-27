using BetelgeuseAPI.Application.Repositories.Course.FaqRequirements;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Course.FaqRequirements;

public class FaqRequirementsReadRepository:ReadRepository<IdentityContext,Domain.Entities.Course.FAQ.FaqRequirements>, IFaqRequirementsReadRepository
{
    public FaqRequirementsReadRepository(IdentityContext context) : base(context)
    {
    }
}