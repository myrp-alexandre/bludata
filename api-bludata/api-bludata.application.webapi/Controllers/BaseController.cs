using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace api_bludata.application.webapi.Controllers
{
    [Route("api/v1/[controller]")]
    public class BaseController : Controller
    {
        protected readonly IMapper mapper;

        public BaseController(IMapper mapper)
        {
            this.mapper = mapper;
        }
        

    }
}