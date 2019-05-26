using api_bludata.domain.domain.interfaces.repositories;
using api_bludata.infra.mssql.context;
using api_bludata.infra.mssql.repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace api_bludata.cross_cutting.ioc
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services, IConfiguration configuration)
        {

            #region injeção de dep dos repositorios
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IFornecedorRepository, FornecedorRepository>();
            services.AddScoped<IEstadoRepository, EstadoRepository>();
            #endregion

            services.AddDbContext<Context>(o => o.UseSqlServer("Server=sql-server;Database=bludata_db;User Id=sa;Password=sa@123456;"));
        }
    }
}
