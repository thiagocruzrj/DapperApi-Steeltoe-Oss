using Dapper.Api.Domain.Entities;
using Dapper.Application.Domain.Commands.ApiRegister;
using Microsoft.AspNetCore.Mvc;

namespace Dapper.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : Controller
    {
        private readonly ApiCallCommand _apicall;

        public RequestController(ApiCallCommand apicall)
        {
            _apicall = apicall;
        }

        // [HttpPost]
        // public string ApiBCallCommand(Request request)
        // {
        //     _apicall.Input(request);

        //     return _apicall.Execute();
        // }
    }
}