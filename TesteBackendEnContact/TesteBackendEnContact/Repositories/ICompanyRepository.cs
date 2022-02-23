using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteBackendEnContact.Models;

namespace TesteBackendEnContact.Repositories
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> Get();
        Task<Company> Get(int id);
        Task<Company> GetName(string name);
        Task<Company> Creater(Company company);
        Task Update(Company company);
        Task Delete(int id);

    }
}
