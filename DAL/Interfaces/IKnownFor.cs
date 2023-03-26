
using DAL.Models;

namespace DAL.Interfaces
{
    public interface IKnownFor
    {
        KnownFor Add(KnownFor knownFor);
        List<KnownFor> GetAll();
        KnownFor? GetByUid(Guid uid);
    }
}