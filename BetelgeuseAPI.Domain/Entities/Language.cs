using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Domain.Entities;

public class Language:BaseEntity
{
    public bool IsPrimary { get; set; }
    public string Name { get; set; }
    public string SeoCode { get; set; }
    public bool Published { get; set; }
}