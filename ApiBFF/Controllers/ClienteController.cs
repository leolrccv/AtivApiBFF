using System.Collections.Generic;
using System.Threading.Tasks;
using ApiBFF.Dto;
using ApiBFF.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiBFF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private MongoService _mongosService;

        public ClienteController(){
            _mongosService = new MongoService();
        }

        [HttpGet]
        public async Task<IEnumerable<ClienteDto>> GetClienteAsync(){
            return await _mongosService.GetClienteAsync();
        }
    
    }
}