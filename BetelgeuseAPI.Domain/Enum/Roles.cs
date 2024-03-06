using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetelgeuseAPI.Domain.Enum
{
    public enum Roles
    {
        Admin,
        Moderator,
        Student
    }
    public static class Constants
    {
        public static readonly string Admin = Guid.NewGuid().ToString();
        public static readonly string Moderator = Guid.NewGuid().ToString();
        public static readonly string Student = Guid.NewGuid().ToString();
    }
}
