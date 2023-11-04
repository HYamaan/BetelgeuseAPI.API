using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetelgeuseAPI.Domain.Entities
{
    public class UserProfileImage:File
    {
        public  User? User { get; set; }
    }
}
