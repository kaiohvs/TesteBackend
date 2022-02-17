using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteBackendEnContact.Models;
using TesteBackendEnContact.Repositories;

namespace TesteBackendEnContact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase
    {
        private readonly IAgendaRepository _agendaRepository;
        public AgendaController(IAgendaRepository agendaRepository)
        {
            _agendaRepository = agendaRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Agenda>> GetAgendas()
        {
            return await _agendaRepository.Get();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Agenda>> GetAgendas(int id)
        {
            return await _agendaRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Agenda>> PostAgendas([FromBody] Agenda agenda)
        {
            var newAgenda = await _agendaRepository.Create(agenda);
            return CreatedAtAction(nameof(GetAgendas), new { id = newAgenda.Id }, newAgenda);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var agendaToDelete = await _agendaRepository.Get(id);

            if (agendaToDelete == null)
            {
                return NotFound();
            }
            else
            {
                await _agendaRepository.Delete(agendaToDelete.Id);
                return NoContent();
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutAgendas(int id, [FromBody] Agenda agenda)
        {
            if (id != agenda.Id)            
                return BadRequest();           
            
                await _agendaRepository.Update(agenda);

                return NoContent();
            
        }
    }
}
