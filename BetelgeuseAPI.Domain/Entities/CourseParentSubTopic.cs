using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Domain.Entities
{
    public class CourseParentSubTopic:BaseEntity
    {
        public required string ParentTopic { get; set; }
        public ICollection<CourseChildSubTopic>? CourseSubTopics { get; set; }
    }
}
