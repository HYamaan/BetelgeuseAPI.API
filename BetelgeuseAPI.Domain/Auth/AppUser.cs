using BetelgeuseAPI.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BetelgeuseAPI.Domain.Auth
{
    public class AppUser : IdentityUser<string>
    {
        public UserAccountInformation UserAccountInformation { get; set; }
        public UserAccountAbout UserAccountAbout { get; set; }
        public ICollection<UserSkills> UserSkills { get; set; }
        public ICollection<Blogs> Blogs { get; set; }

        public List<RefreshToken> RefreshTokens { get; set; }
        public List<UserProfileImage> UserProfileImage { get; set; }
        public List<UserProfileBackgroundImage> UserProfileBackgroundImage { get; set; }
        public List<UserAccountEducation> UserAccountEducations { get; set; }
        public List<UserAccountExperiences> UserAccountExperiences { get; set; }
    }
}
