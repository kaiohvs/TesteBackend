using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteBackendEnContact.Models;

namespace TesteBackendEnContact.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        public readonly CompanyContext _context;
        public CompanyRepository(CompanyContext companyContext)
        {
            _context = companyContext;
        }

        public async Task<Company> Creater(Company company)
        {
             _context.Companies.Add(company);
            await _context.SaveChangesAsync();

            return company;
        }

        public async Task Delete(int id)
        {
            var companyToDelete = await _context.Companies.FindAsync(id);
            _context.Companies.Remove(companyToDelete);

             await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Company>> Get()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task<Company> Get(int id)
        {
            return await _context.Companies.FindAsync(id);
        }
        public async Task<Company> GetName(string name)
        {            
            return await _context.Companies.FirstOrDefaultAsync(i => i.Name == name.ToString());
        }

        public async Task Update(Company company)
        {
            _context.Entry(company).State = EntityState.Modified;
             await _context.SaveChangesAsync();
        }
    }
}
