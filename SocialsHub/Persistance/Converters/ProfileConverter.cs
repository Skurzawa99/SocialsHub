using Microsoft.AspNetCore.Identity;
using SocialsHub.Core.Models.Domains;
using SocialsHub.Core.Models.Dtos;
using System.ComponentModel.DataAnnotations;

namespace SocialsHub.Persistance.Converters
{
    public static class ProfileConverter
    {
        public static ProfileDto ToDto(this ApplicationUser model)
        {
            return new ProfileDto
            {
                Id = model.Id,
                Name = model.UserName,
                Description = model.Description,
                Email = model.Email,
                Image = model.Image,
                Facebook = model.Facebook,
                Instagram = model.Instagram,
                Twitter = model.Twitter,
                YouTube = model.YouTube,
                GitHub = model.GitHub,
                Linkedin  = model.Linkedin
            };
        }
        public static IQueryable<ProfileDto> ToDtos(this IQueryable<ApplicationUser> model)
        {
            if (model == null)
                return null;

            return model.Select(x => x.ToDto());
        }

        public static ApplicationUser ToDao(this ProfileDto model)
        {
            return new ApplicationUser
            {
                Id = model.Id,
                UserName = model.Name,
                Description = model.Description,
                Email = model.Email,
                Image = model.Image,
                Facebook = model.Facebook,
                Instagram = model.Instagram,
                Twitter = model.Twitter,
                YouTube = model.YouTube,
                GitHub = model.GitHub,
                Linkedin = model.Linkedin
            };
        }
    }
}
