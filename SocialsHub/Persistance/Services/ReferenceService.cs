using SocialsHub.Core;
using SocialsHub.Core.Models.Domains;
using SocialsHub.Core.Services;

namespace SocialsHub.Persistance.Services
{
    public class ReferenceService : IReferenceService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReferenceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Reference> Get(string userId)
        {
            return _unitOfWork.Reference.Get(userId);
        }

        public Reference Get(string userId, int id)
        {
            return _unitOfWork.Reference.Get(userId, id);
        }

        public void Add(Reference reference)
        {
            _unitOfWork.Reference.Add(reference);
            _unitOfWork.Complete();
        }

        public void Update(Reference reference)
        {
            _unitOfWork.Reference.Update(reference);
            _unitOfWork.Complete();
        }

        public void Delete(int id, string userId)
        {
            _unitOfWork.Reference.Delete(id, userId);
            _unitOfWork.Complete();
        }
    }
}
