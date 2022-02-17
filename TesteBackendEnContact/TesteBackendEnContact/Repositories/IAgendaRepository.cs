using System.Collections.Generic;
using System.Threading.Tasks;
using TesteBackendEnContact.Models;

namespace TesteBackendEnContact.Repositories
{
    public interface IAgendaRepository
    {
        Task<IEnumerable<Agenda>> Get();
        Task<Agenda> Get(int Id);
        Task<Agenda> Create(Agenda agenda);

        Task Update(Agenda agenda);
        Task Delete(int Id);
       
    }
}
