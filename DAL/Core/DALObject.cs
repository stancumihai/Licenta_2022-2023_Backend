namespace DAL.Core
{
    public class DALObject
    {
        protected readonly DatabaseContext _context;

        public DALObject(DatabaseContext context)
        {
            _context = context;
        }
    }
}