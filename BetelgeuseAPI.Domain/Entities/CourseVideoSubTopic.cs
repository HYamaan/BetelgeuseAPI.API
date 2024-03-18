using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetelgeuseAPI.Domain.Common;

namespace BetelgeuseAPI.Domain.Entities
{
    public class CourseVideoSubTopic:BaseEntity
    {
        public required string VideoName { get; set; }
        public required string Path { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        [DefaultValue(true)]
        public bool Publish { get; set; }
        public required CourseChildSubTopic CourseSubTopic { get; set; }
        public override DateTime UpdatedDate { get => base.UpdatedDate; set => base.UpdatedDate = value; }
    }
}
