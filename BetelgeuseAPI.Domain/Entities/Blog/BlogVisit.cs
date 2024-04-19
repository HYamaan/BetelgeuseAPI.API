using System.Reflection.Metadata;

namespace BetelgeuseAPI.Domain.Entities;

public class BlogVisit
{
    public Guid Id { get; set; }
    public Guid BlogId { get; set; } 
    public string IpAddress { get; set; } 
    public DateTime VisitTime { get; set; } 
    public Blogs Blog { get; set; }
}