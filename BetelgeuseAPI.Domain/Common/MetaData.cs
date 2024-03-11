
using System.ComponentModel.DataAnnotations;

namespace BetelgeuseAPI.Domain.Common
{
    public class MetaData:BaseEntity
    {
        public string? ShortDescription { get; set; }
        public string? MetaTitle { get; set; }
        public string? MetaDescription { get; set; }
        public string? MetaKeywords { get; set; }
        public string? Url { get; set; }

    }
}
