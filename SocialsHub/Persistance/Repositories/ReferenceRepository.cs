using SocialsHub.Core;
using SocialsHub.Core.Models.Domains;
using SocialsHub.Core.Repositories;

namespace SocialsHub.Persistance.Repositories
{
    public class ReferenceRepository : IReferenceRepository
    {
        private IApplicationDbContext _context;

        public ReferenceRepository(IApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Reference> Get(string userId)
        {
            return _context.References.Where(x => x.UserId == userId).OrderBy(x => x.CreatedDate).ToList();
        }

        public Reference Get(string userId, int id)
        {
            return _context.References.Where(x => x.UserId == userId && x.Id == id).Single();
        }

        public void Add(Reference reference)
        {
            _context.References.Add(reference);
        }
        public void Update(Reference reference)
        {
            var referenceToUpdate = _context.References.Where(x => x.Id == reference.Id).Single();

            referenceToUpdate.Name = reference.Name;
            referenceToUpdate.Description = reference.Description;
            referenceToUpdate.Link = reference.Link;
            referenceToUpdate.Enable = reference.Enable;
        }
        public void Delete(int id, string userId)
        {
            var referenceToDelete = _context.References.Where(x => x.Id == id && x.UserId == userId).Single();

            _context.References.Remove(referenceToDelete);
        }
    }
}
