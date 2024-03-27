using BetelgeuseAPI.Application.Repositories.Course.Faq;
using BetelgeuseAPI.Domain.Entities.Course.FAQ;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Course.FaqOptions;

public class FaqOptionWriteRepository:WriteRepository<IdentityContext, FaqOption>, IFaqOptionWriteRepository
{
    public FaqOptionWriteRepository(IdentityContext context) : base(context)
    {
    }
}