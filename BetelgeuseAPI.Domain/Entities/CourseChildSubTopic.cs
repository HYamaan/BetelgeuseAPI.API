using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Domain.Entities
{
    public class CourseChildSubTopic:BaseEntity
    {
        public required string SubTitle { get; set; }
        public ICollection<CourseVideoSubTopic>? CourseVideoSubTopic { get; set; }
        public required CourseParentSubTopic CourseParentSubTopic { get; set; }
    }
}
