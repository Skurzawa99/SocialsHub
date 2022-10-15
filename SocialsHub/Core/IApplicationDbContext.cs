using Microsoft.EntityFrameworkCore;
using SocialsHub.Core.Models.Domains;

namespace SocialsHub.Core
{
    public interface IApplicationDbContext
    {
        DbSet<Reference> References { get; set; }
        DbSet<ApplicationUser> ApplicationUsers { get; set; }
        int SaveChanges();
    }
}
