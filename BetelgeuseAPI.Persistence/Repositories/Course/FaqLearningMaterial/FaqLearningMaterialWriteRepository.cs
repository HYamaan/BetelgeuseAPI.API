using BetelgeuseAPI.Application.Repositories.Course.FaqLearningMaterial;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Course.FaqLearningMaterial;

public class FaqLearningMaterialWriteRepository:WriteRepository<IdentityContext,Domain.Entities.Course.FAQ.FaqLearningMaterial>,IFaqLearningMaterialWriteRepository
{
    public FaqLearningMaterialWriteRepository(IdentityContext context) : base(context)
    {
    }
}