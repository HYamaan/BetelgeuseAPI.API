using BetelgeuseAPI.Domain.Auth;
using BetelgeuseAPI.Domain.Common;
using BetelgeuseAPI.Domain.Enum;

namespace BetelgeuseAPI.Domain.Entities;

public class Blogs : BaseEntity
{

    public required string Title { get; set; }

    public required Guid BlogCategoriesID { get; set; }
    public required string Description { get; set; }
    public required string Content { get; set; }
    public required string Status { get; set; }

    public Guid BlogImageID { get; set; }
    public BlogImage BlogImage { get; set; }
    public BlogCategories BlogCategories { get; set; }
    public MetaData MetaData { get; set; }


}