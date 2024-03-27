using BetelgeuseAPI.Application.Repositories.Course.FaqRequirements;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Course.FaqRequirements;

public class FaqRequirementsWriteRepository:WriteRepository<IdentityContext,Domain.Entities.Course.FAQ.FaqRequirements>, IFaqRequirementsWriteRepository
{
    public FaqRequirementsWriteRepository(IdentityContext context) : base(context)
    {
    }
}