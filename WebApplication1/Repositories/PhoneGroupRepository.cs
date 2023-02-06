using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class PhoneGroupRepository : IPhoneGroup
    {

        private readonly ApiDbContext _context;
        public PhoneGroupRepository(ApiDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<PhoneGroup>> GetAllAsync()
        {
            return await _context.PhoneGroups.ToListAsync();
        }
    }
}
