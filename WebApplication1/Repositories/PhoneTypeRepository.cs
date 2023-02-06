using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class PhoneTypeRepository : IPhoneTypeRepository
    {
        private readonly ApiDbContext _context;
        public PhoneTypeRepository(ApiDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PhoneType>> GetAllOnViewAsync()
        {
            return await _context.PhoneTypes.Where(p => p.OnView == true).ToListAsync();
        }
    }
}
