using DAL.Core;
using DAL.Interfaces;

namespace DAL.Implementation
{
    public class KnownFor : DALObject, IKnownFor
    {
        public KnownFor(DatabaseContext context) : base(context)
        {
        }

        public Models.KnownFor Add(Models.KnownFor knownFor)
        {
            Models.KnownFor addedKnownFor = _context.KnownFor.Add(knownFor).Entity;
            _context.SaveChanges();
            return addedKnownFor;
        }

        public List<Models.KnownFor> GetAll()
        {
            return _context.KnownFor.ToList();
        }

        public Models.KnownFor? GetByUid(Guid uid)
        {
            return _context.KnownFor
                .FirstOrDefault(knownFor => knownFor.KnownForGUID == uid);
        }
    }
}