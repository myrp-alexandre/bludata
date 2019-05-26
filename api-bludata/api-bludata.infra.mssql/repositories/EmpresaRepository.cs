using api_bludata.domain.domain.interfaces.repositories;
using api_bludata.domain.domain.models;
using api_bludata.infra.mssql.context;

namespace api_bludata.infra.mssql.repositories
{
    public class EmpresaRepository : BaseRepository<empresa>, IEmpresaRepository
    {
        public EmpresaRepository(Context context) : base (context)
        {

        }

    }
}
