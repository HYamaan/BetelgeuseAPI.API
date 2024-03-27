using BetelgeuseAPI.Application.Repositories.FileContent.FaqUploadLogo;
using BetelgeuseAPI.Domain.Entities.Course.FAQ;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.FileContent.FaqUploadLogo;

public class FaqUploadLogoReadRepository : ReadRepository<IdentityContext, Domain.Entities.Course.FAQ.FaqUploadLogo>, IFaqUploadLogoReadRepository
{
    public FaqUploadLogoReadRepository(IdentityContext context) : base(context)
    {
    }
}