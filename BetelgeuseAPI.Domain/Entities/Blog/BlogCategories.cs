using System.ComponentModel.DataAnnotations.Schema;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Domain.Entities;

public class BlogCategories:BaseEntity
{
    public required string Title { get; set; }
    public required string SubTitle { get; set; }


}