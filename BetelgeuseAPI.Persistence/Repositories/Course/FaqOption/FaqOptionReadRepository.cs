using BetelgeuseAPI.Application.Repositories.Course.Faq;
using BetelgeuseAPI.Domain.Entities.Course.FAQ;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Course.FaqOptions;

public class FaqOptionReadRepository:ReadRepository<IdentityContext,FaqOption>,IFaqOptionReadRepository
{
    public FaqOptionReadRepository(IdentityContext context) : base(context)
    {
    }
}