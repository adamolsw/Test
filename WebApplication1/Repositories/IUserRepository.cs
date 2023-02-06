using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public interface IUserRepository : IGenericRepository<Contact>
    {
        Task<Contact> FindByEmailAsync(string email);
    }
}
