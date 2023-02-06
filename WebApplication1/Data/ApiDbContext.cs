using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApiDbContext : IdentityDbContext
    {
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<PhoneType> PhoneTypes { get; set; }
        public virtual DbSet<PhoneGroup> PhoneGroups { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options)
        : base(options)
        {
        }
    }
}
