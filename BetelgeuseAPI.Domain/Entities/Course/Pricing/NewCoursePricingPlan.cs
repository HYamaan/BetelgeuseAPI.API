﻿using BetelgeuseAPI.Domain.Common;
using BetelgeuseAPI.Domain.Enum;

namespace BetelgeuseAPI.Domain.Entities.Course.Pricing;

public class NewCoursePricingPlan : BaseEntity
{
    public Languages Language { get; set; }
    public string Title { get; set; }
    public int Discount { get; set; }
    public int Capacity { get; set; }
    public int Price { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public Guid CoursePricingId { get; set; }

    public CoursePricing CoursePricing { get; set; }

}