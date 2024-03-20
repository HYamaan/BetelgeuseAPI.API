using BetelgeuseAPI.Domain.Common;
using BetelgeuseAPI.Domain.Entities.Category;
using BetelgeuseAPI.Domain.Entities.File;


namespace BetelgeuseAPI.Domain.Entities;

public class Blogs : BaseEntity
{
    public Guid BlogCategoryId { get; set; }
    public Guid BlogImageID { get; set; }

    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string Content { get; set; }
    public required string Status { get; set; }

    public int ViewCount { get; set; }
    public BlogImage BlogImage { get; set; }
    public BlogCategory BlogCategory { get; set; }
    public MetaData MetaData { get; set; }


}