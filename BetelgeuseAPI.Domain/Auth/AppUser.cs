using BetelgeuseAPI.Domain.Entities;
using BetelgeuseAPI.Domain.Entities.Course;
using BetelgeuseAPI.Domain.Entities.File;
using BetelgeuseAPI.Domain.Entities.Purchase;
using Microsoft.AspNetCore.Identity;
using File = BetelgeuseAPI.Domain.Entities.File.File;

namespace BetelgeuseAPI.Domain.Auth
{
    public class AppUser : IdentityUser<string>
    {
        public UserAccountInformation UserAccountInformation { get; set; }
        public UserAccountAbout UserAccountAbout { get; set; }
        public ICollection<UserSkills> UserSkills { get; set; }

        public ICollection<RefreshToken> RefreshTokens { get; set; }
        public ICollection<UserProfileImage> UserProfileImage { get; set; }
        public ICollection<UserProfileBackgroundImage> UserProfileBackgroundImage { get; set; }
        public ICollection<UserAccountEducation> UserAccountEducations { get; set; }
        public ICollection<UserAccountExperiences> UserAccountExperiences { get; set; }

        public ICollection<InclusiveCourse> InclusiveCourse { get; set; }
        public ICollection<Purchase> Purchases { get; set; }

        //TODO: Kullanıcıların kişisel bilgilerini içeren bir sayfa tasarımını yapıldığında Meta ile bağlantılı olacak şekilde bir MetaData tablosu oluşturulacak.
    }
}
