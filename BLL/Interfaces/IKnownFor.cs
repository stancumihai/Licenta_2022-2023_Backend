using Library.Models.KnownFor;

namespace BLL.Interfaces
{
    public interface IKnownFor
    {
        KnownForCreate Add(KnownForCreate knownFor);
        List<KnownForRead> GetAll();
        KnownForRead? GetByUid(Guid uid);
    }
}