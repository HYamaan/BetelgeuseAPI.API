using BetelgeuseAPI.Domain.Auth;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Domain.Entities
{
    public class File:BaseEntity
    {
        public string AppUserId { get; set; }

        public string FileName { get; set; }
        public string Path { get; set; }
        public string Storage { get; set; }
        public override DateTime UpdatedDate { get => base.UpdatedDate; set => base.UpdatedDate = value; }
        public AppUser? AppUser { get; set; }
    }
}
