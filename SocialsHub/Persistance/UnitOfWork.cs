using SocialsHub.Core;
using SocialsHub.Core.Repositories;
using SocialsHub.Persistance.Repositories;

namespace SocialsHub.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IApplicationDbContext _context;

        public UnitOfWork(IApplicationDbContext context)
        {
            _context = context;
            Profile = new ProfileRepository(context);
            Reference = new ReferenceRepository(context);
        }

        public IProfileRepository Profile { get; set; }
        public IReferenceRepository Reference { get; set; }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
