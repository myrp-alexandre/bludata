using api_bludata.domain.domain.models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_bludata.domain.domain.interfaces.repositories
{
    public interface IFornecedorRepository : IBaseRepository<fornecedor>
    {
        Task<IEnumerable<fornecedor>> listagem();
    }
}
