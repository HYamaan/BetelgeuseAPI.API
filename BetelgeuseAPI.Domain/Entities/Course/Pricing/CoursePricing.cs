﻿using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Domain.Entities.Course.Pricing;

public class CoursePricing : BaseEntity
{
    public int Price { get; set; }
    public bool IsFree { get; set; }

    public ICollection<NewCoursePricingPlan>? NewCoursePricingPlan { get; set; }
}