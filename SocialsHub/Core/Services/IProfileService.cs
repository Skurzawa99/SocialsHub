using SocialsHub.Core.Models;
using SocialsHub.Core.Models.Domains;

namespace SocialsHub.Core.Services
{
    public interface IProfileService
    {
        IQueryable<ApplicationUser> GetAll(string searchString);

        ApplicationUser Get(string id);
        void UpdateDesc(ApplicationUser profileDao, string userId);
        void UpdateIcon(ApplicationUser iconDao, string userId);
        string UploadFile(IFormFile image);
        void UpdateImage(string image, string userId);
    }
}
