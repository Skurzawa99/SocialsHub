using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SocialsHub.Core;
using SocialsHub.Core.Models.Domains;
using SocialsHub.Core.Repositories;

namespace SocialsHub.Persistance.Repositories
{
    public class ProfileRepository : IProfileRepository
    {
        private IApplicationDbContext _context;

        public ProfileRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<ApplicationUser> GetAll(string searchString)
        {
            var profiles = _context.ApplicationUsers.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchString))
                profiles = profiles.Where(x => x.UserName.Contains(searchString));

            return profiles;
        }

        public ApplicationUser Get(string id)
        {
            return _context.ApplicationUsers.Where(x => x.Id == id).Single();
        }

        public void UpdateDesc(ApplicationUser profileDao, string userId)
        {
            var profileToUpdate = _context.ApplicationUsers.Where(x => x.Id == userId).Single();

            profileToUpdate.Description = profileDao.Description;
        }
        public void UpdateImage(string image, string userId)
        {
            var profileToUpdate = _context.ApplicationUsers.Where(x => x.Id == userId).FirstOrDefault();

            profileToUpdate.Image = image;
        }

        public void UpdateIcon(ApplicationUser iconDao, string userId)
        {
            var iconToUpdate = _context.ApplicationUsers.Where(x => x.Id == userId).Single();

            iconToUpdate.Facebook = iconDao.Facebook;
            iconToUpdate.Twitter = iconDao.Twitter;
            iconToUpdate.Instagram = iconDao.Instagram;
            iconToUpdate.YouTube = iconDao.YouTube;
            iconToUpdate.GitHub = iconDao.GitHub;
            iconToUpdate.Linkedin = iconDao.Linkedin;
        }
    }
}
