using SocialsHub.Core.Repositories;
using SocialsHub.Persistance.Repositories;

namespace SocialsHub.Core
{
    public interface IUnitOfWork
    {
        IProfileRepository Profile { get; }
        IReferenceRepository Reference { get; }
        void Complete();
    }
}
