using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteBackendEnContact.Models;
using TesteBackendEnContact.Repositories;

namespace TesteBackendEnContact.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {

        private readonly ICompanyRepository _companyRepository;
        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Company>> GetCompany()
        {
            return await _companyRepository.Get();
        }

        [HttpGet("BuscarId/{id}")]
        public async Task<ActionResult<Company>> GetCompanyId(int id)
        {
            return await _companyRepository.Get(id);
        }

        [HttpGet("BuscarNome/{name}")]
        public async Task<ActionResult<Company>> GetCompanyName(string name)
        {
            return await _companyRepository.GetName(name);
        }

        [HttpPost]
        public async Task<ActionResult<Company>> PostCompany([FromBody] Company company)
        {
            var newCompany = await _companyRepository.Creater(company);
            return CreatedAtAction(nameof(GetCompany), new { id = newCompany.Id }, newCompany);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCompany(int id)
        {
            var companyToDelete = await _companyRepository.Get(id);

            if(companyToDelete == null)
            {
                return NotFound();
            }
            else
            {
                await _companyRepository.Delete(companyToDelete.Id);
                return NoContent();
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutCompany(int id, [FromBody] Company company)
        {
            if(id != company.Id)
            {
                return BadRequest();
            }
            else
            {
                await _companyRepository.Update(company);
                return NoContent();
            }

        }


    }
}
