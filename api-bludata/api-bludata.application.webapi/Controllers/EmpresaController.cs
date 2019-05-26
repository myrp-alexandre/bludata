using System.Threading.Tasks;
using api_bludata.application.webapi.SwaggerDocs.Examples;
using api_bludata.domain.domain.interfaces.repositories;
using api_bludata.domain.domain.models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Examples;

namespace api_bludata.application.webapi.Controllers
{
    public class EmpresaController : BaseController
    {
        public EmpresaController(IMapper mapper) : base(mapper)
        {
        }

        /// <summary>
        /// GETALL de Empresa
        /// </summary>
        /// <param name="value"></param>
        [HttpGet]
        public async Task<ActionResult> Get([FromServices] IEmpresaRepository empresa)
        {
            return Ok(await empresa.AllAsync());
        }

        /// <summary>
        /// Cadastro de empresa
        /// </summary>
        /// <param name="value"></param>
        [SwaggerRequestExample(typeof(empresa), typeof(EmpresaEx))]
        [HttpPost]
        public async Task<ActionResult> Post([FromServices] IEmpresaRepository empresa, [FromBody] empresa model)
        {
            await empresa.SaveAsync(model);
            return Ok();
        }

    }
}