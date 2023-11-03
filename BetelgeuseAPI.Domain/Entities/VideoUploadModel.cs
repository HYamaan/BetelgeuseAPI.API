using BetelgeuseAPI.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace BetelgeuseAPI.Domain.Entities;

public class VideoUploadModel : BaseEntity
{
    public string FileName { get; set; }
    public string Path { get; set; }
    public string Storage { get; set; }
    public override DateTime UpdatedDate { get => base.UpdatedDate; set => base.UpdatedDate = value; }
}