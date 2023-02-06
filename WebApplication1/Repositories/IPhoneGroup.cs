using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IPhoneGroup
    {
        Task<IEnumerable<PhoneGroup>> GetAllAsync();
    }
}
