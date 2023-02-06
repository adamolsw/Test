using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IPhoneTypeRepository
    {
        Task<IEnumerable<PhoneType>> GetAllOnViewAsync();
    }
}
