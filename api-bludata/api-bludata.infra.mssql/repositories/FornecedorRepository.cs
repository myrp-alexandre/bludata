using System.Collections.Generic;
using System.Threading.Tasks;
using api_bludata.domain.domain.interfaces.repositories;
using api_bludata.domain.domain.models;
using api_bludata.infra.mssql.context;
using Microsoft.EntityFrameworkCore;

namespace api_bludata.infra.mssql.repositories
{
    public class FornecedorRepository : BaseRepository<fornecedor>, IFornecedorRepository
    {
        private readonly Context context;

        public FornecedorRepository(Context context) : base (context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<fornecedor>> listagem()
        {
            return context.Fornecedor
                .Include(x => x.empresa)
                .Include(x => x.telefones);
        }
    }
}
