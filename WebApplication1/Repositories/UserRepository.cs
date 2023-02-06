using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly ApiDbContext _context;
        public UserRepository(ApiDbContext context)
        {
            _context = context;
        }
        public async Task<Contact> GetByIdAsync(int id)
        {
            return await _context.Contacts.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task AddAsync(Contact entity)
        {
            await _context.Contacts.AddAsync(entity);
        }

        public Task UpdateAsync(Contact existEntity, Contact  entity)
        {
            existEntity.Birthday = entity.Birthday;
            existEntity.Email = entity.Email;
            existEntity.FirstName = entity.FirstName;
            existEntity.LastName = entity.LastName;
            existEntity.PhoneNumber = entity.PhoneNumber;
            existEntity.Password = entity.Password;
            existEntity.PhoneType = entity.PhoneType;
            existEntity.PhoneTypeId = entity.PhoneTypeId;
            existEntity.Id = entity.Id;
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Contact entity)
        {
            _context.Contacts.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync(); 
        }

        public async Task<Contact> FindByEmailAsync(string email)
        {
            return await _context.Contacts.FirstOrDefaultAsync(c => c.Email.ToLower().Equals(email.ToLower()));
        }
    }
}
