using Core.DataAccess.Abstract;
using Entities.Concrete.TableModels;

namespace DataAccess.Abstract
{
    public interface IGurdianNumberDal : IBaseRepository<GurdianNumber> 
    {
        List<GurdianNumber> GetNumberWithAppointments();
    }

}
