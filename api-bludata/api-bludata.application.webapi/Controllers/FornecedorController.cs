using System.Collections.Generic;
using System.Threading.Tasks;
using api_bludata.application.webapi.Models;
using api_bludata.application.webapi.SwaggerDocs.Examples;
using api_bludata.domain.domain.interfaces.repositories;
using api_bludata.domain.domain.models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Examples;

namespace api_bludata.application.webapi.Controllers
{
    public class FornecedorController : BaseController
    {
        private readonly IFornecedorRepository ifornecedor;

        public FornecedorController(IMapper mapper, IFornecedorRepository ifornecedor) : base (mapper)
        {
            this.ifornecedor = ifornecedor;
        }

        /// <summary>
        /// Lista todos os fornecedores
        /// </summary>
        /// <param name="value"></param>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var fornecedores = await ifornecedor.listagem();
            return Ok(mapper.Map<IEnumerable<FornecedorViewModel>>(fornecedores));
        }

        /// <summary>
        /// Cadastro de fornecedor
        /// </summary>
        /// <param name="value"></param>
        [HttpPost]
        [SwaggerRequestExample(typeof(fornecedor), typeof(FornecedorEx))]
        public async Task<ActionResult> Post([FromBody] fornecedor model)
        {
            await ifornecedor.SaveAsync(model);
            return Ok();
        }

        /// <summary>
        /// Atualizar fornecedor
        /// </summary>
        /// <param name="value"></param>
        [HttpPut]
        [SwaggerRequestExample(typeof(fornecedor), typeof(FornecedorUpdateEx))]
        public async Task<ActionResult> Put([FromBody] fornecedor model)
        {
            await ifornecedor.UpdateAsync(model);
            return Ok();
        }

        /// <summary>
        /// Deletar fornecedor
        /// </summary>
        /// <param name="value"></param>
        [HttpDelete]
        [SwaggerRequestExample(typeof(fornecedor), typeof(FornecedorDeleteEx))]
        public async Task<ActionResult> Delete([FromBody] fornecedor model)
        {
            await ifornecedor.DeleteAsync(model);
            return Ok();
        }
    }
}