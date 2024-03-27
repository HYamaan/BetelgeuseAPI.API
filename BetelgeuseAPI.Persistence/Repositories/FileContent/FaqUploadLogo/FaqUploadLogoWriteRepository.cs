using BetelgeuseAPI.Application.Repositories.FileContent.FaqUploadLogo;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.FileContent.FaqUploadLogo;

public class FaqUploadLogoWriteRepository:WriteRepository<IdentityContext,Domain.Entities.Course.FAQ.FaqUploadLogo>, IFaqUploadLogoWriteRepository
{
    public FaqUploadLogoWriteRepository(IdentityContext context) : base(context)
    {
    }
}