using Microsoft.EntityFrameworkCore;

namespace TesteBackendEnContact.Models
{
    public class CompanyContext : DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Company> Companies { get; set; }
    }
}
