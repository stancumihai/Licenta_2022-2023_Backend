using DAL.Interfaces;

namespace BLL.Core
{
    public class BusinessObject
    {
        protected readonly IDALContext _dalContext;
        
        public BusinessObject(IDALContext dalContext)
        {
            _dalContext = dalContext;
        }
    }
}