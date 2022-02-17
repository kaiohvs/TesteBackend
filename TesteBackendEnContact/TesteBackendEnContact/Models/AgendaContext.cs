using Microsoft.EntityFrameworkCore;

namespace TesteBackendEnContact.Models
{
    public class AgendaContext : DbContext
    {
        public AgendaContext( DbContextOptions<AgendaContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Agenda> Agendas { get; set; }
    }
}
