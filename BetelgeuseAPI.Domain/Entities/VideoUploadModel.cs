using BetelgeuseAPI.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace BetelgeuseAPI.Domain.Entities;

public class VideoUploadModel : BaseEntity
{
    public required string  FileName { get; set; }
    public required string Path { get; set; }
    public required string Storage { get; set; }
    public override DateTime UpdatedDate { get => base.UpdatedDate; set => base.UpdatedDate = value; }
}