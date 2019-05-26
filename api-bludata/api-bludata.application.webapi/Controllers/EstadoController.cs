using api_bludata.domain.domain.interfaces.repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace api_bludata.application.webapi.Controllers
{
    public class EstadoController : BaseController
    {
        public EstadoController(IMapper mapper) : base (mapper)
        {

        }

        /// <summary>
        /// DLL de estados
        /// </summary>
        /// <param name="value"></param>
        [HttpGet]
        //[SwaggerRequestExample(typeof(RExtraCaixaViewModel), typeof(RExtraCaixaVMEx))]
        public async Task<ActionResult> Get([FromServices] IEstadoRepository estado)
        {
            return Ok(await estado.AllAsync());
        }
        
    }
}