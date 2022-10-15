using SocialsHub.Core.Models.Domains;

namespace SocialsHub.Core.Repositories
{
    public interface IProfileRepository
    {
        IQueryable<ApplicationUser> GetAll(string searchString);
        ApplicationUser Get(string id);
        void UpdateDesc(ApplicationUser profileDao, string userId);
        void UpdateIcon(ApplicationUser iconDao, string userId);
        void UpdateImage(string image, string userId);
    }
}
