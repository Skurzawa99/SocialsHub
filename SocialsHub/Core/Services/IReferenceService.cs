using SocialsHub.Core.Models.Domains;

namespace SocialsHub.Core.Services
{
    public interface IReferenceService
    {
        IEnumerable<Reference> Get(string userId);
        Reference Get(string userId, int id);
        void Add(Reference reference);
        void Update(Reference reference);
        void Delete(int id, string userId);
    }
}
