using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Domain.Entities.Category
{
    public class Category : BaseEntity
    {

        public string Name { get; set; }
        public bool Published { get; set; }

        public Guid? ParentCategoryID { get; set; }
        public Category ParentCategory { get; set; }

        public ICollection<Category> ChildCategories { get; set; }
    }
}
