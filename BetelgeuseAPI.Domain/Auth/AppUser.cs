using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetelgeuseAPI.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BetelgeuseAPI.Domain.Auth
{
    public class AppUser : IdentityUser<string>
    {
        public List<RefreshToken> RefreshTokens { get; set; }
        public UserAccountInformation UserAccountInformation { get; set; }
        public UserAccountAbout UserAccountAbout { get; set; }
        public List<UserAccountEducation> UserAccountEducations { get; set; }
        public List<UserAccountExperiences> UserAccountExperiences { get; set; }
    }
}
