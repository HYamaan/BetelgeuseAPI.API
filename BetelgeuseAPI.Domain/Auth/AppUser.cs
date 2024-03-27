using BetelgeuseAPI.Domain.Entities;
using BetelgeuseAPI.Domain.Entities.Course;
using BetelgeuseAPI.Domain.Entities.File;
using BetelgeuseAPI.Domain.Entities.Purchase;
using Microsoft.AspNetCore.Identity;

namespace BetelgeuseAPI.Domain.Auth
{
    public class AppUser : IdentityUser<string>
    {
        public UserAccountInformation UserAccountInformation { get; set; }
        public UserAccountAbout UserAccountAbout { get; set; }
        public ICollection<UserSkills> UserSkills { get; set; }

        public List<RefreshToken> RefreshTokens { get; set; }
        public List<UserProfileImage> UserProfileImage { get; set; }
        public List<UserProfileBackgroundImage> UserProfileBackgroundImage { get; set; }
        public List<UserAccountEducation> UserAccountEducations { get; set; }
        public List<UserAccountExperiences> UserAccountExperiences { get; set; }

        public List<InclusiveCourse> InclusiveCourse { get; set; }
        public ICollection<Purchase> Purchases { get; set; }

        //TODO: Kullanıcıların kişisel bilgilerini içeren bir sayfa tasarımını yapıldığında Meta ile bağlantılı olacak şekilde bir MetaData tablosu oluşturulacak.
    }
}
