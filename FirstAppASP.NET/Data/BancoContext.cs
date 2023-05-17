using FirstAppASP.NET.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAppASP.NET.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext>options) : base(options)
        {
        }

        public DbSet<ContactModel> Contacts { get; set; }
    }
}
