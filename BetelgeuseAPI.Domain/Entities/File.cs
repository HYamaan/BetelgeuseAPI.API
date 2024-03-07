using BetelgeuseAPI.Domain.Auth;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Domain.Entities
{
    public class File:BaseEntity
    {
        public string AppUserId { get; set; }
        public required string FileName { get; set; }
        public required string Path { get; set; }
        public required string Storage { get; set; }

        public  AppUser? AppUser { get; set; }
        public override DateTime UpdatedDate { get => base.UpdatedDate; set => base.UpdatedDate = value; }
    }
}
