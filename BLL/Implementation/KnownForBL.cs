using BLL.Converters.KnownFor;
using BLL.Core;
using BLL.Interfaces;
using DAL.Models;
using Library.Models.KnownFor;

namespace BLL.Implementation
{
    public class KnownForBL : BusinessObject, IKnownFor
    {
        public KnownForBL(DAL.Interfaces.IDALContext dalContext) : base(dalContext)
        {
        }

        public KnownForCreate Add(KnownForCreate knownFor)
        {
            KnownFor addedKnownFor = KnownForCreateConverter.ToDALModel(knownFor);
            return KnownForCreateConverter.ToBLLModel(_dalContext.KnownFor.Add(addedKnownFor));
        }

        public List<KnownForRead> GetAll()
        {
            List<KnownFor> knowFors = _dalContext.KnownFor.GetAll();
            List<KnownForRead> knownForReads = new List<KnownForRead>();
            foreach (KnownFor read in knowFors)
            {
                read.Movie = _dalContext.Movies.GetByUid(read.MovieGUID)!;
                read.Person = _dalContext.Persons.GetByUid(read.PersonGUID)!;
                KnownForRead knownFor = KnownForReadConverter.ToBLLModel(read);
                knownForReads.Add(knownFor);
            }
            return knownForReads;
        }

        public KnownForRead? GetByUid(Guid uid)
        {
            return KnownForReadConverter
                .ToBLLModel(_dalContext.KnownFor
                .GetByUid(uid)!);
        }
    }
}