using BetelgeuseAPI.Application.Repositories.Course.FaqLearningMaterial;
using BetelgeuseAPI.Persistence.Context;

namespace BetelgeuseAPI.Persistence.Repositories.Course.FaqLearningMaterial;

public class FaqLearningMaterialReadRepository:ReadRepository<IdentityContext,Domain.Entities.Course.FAQ.FaqLearningMaterial>,IFaqLearningMaterialReadRepository
{
    public FaqLearningMaterialReadRepository(IdentityContext context) : base(context)
    {
    }
}