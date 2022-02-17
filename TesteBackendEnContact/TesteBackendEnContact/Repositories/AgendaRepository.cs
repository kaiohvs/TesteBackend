using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteBackendEnContact.Models;

namespace TesteBackendEnContact.Repositories
{
    public class AgendaRepository : IAgendaRepository
    {
        //reandonly ele apenas faz uma leitura não podemos implementar encima dela
        public readonly AgendaContext _context;
        public AgendaRepository(AgendaContext context)
        {
            _context = context;
        }
        public async Task<Agenda> Create(Agenda agenda)
        {
            _context.Agendas.Add(agenda);
           await _context.SaveChangesAsync();

            return agenda;
        }

        public async Task Delete(int id)
        {
            var agendaToDelete = await _context.Agendas.FindAsync(id);
            _context.Agendas.Remove(agendaToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Agenda>> Get()
        {
            return await _context.Agendas.ToListAsync();
        }

        public async Task<Agenda> Get(int id)
        {
            return await _context.Agendas.FindAsync(id);
        }

        public async Task Update(Agenda agenda)
        {
            _context.Entry(agenda).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
