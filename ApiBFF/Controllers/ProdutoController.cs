using System.Collections.Generic;
using System.Threading.Tasks;
using ApiBFF.Dto;
using ApiBFF.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiBFF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private MongoService _mongosService;

        public ProdutoController(){
            _mongosService = new MongoService();
        }

        [HttpGet]
        public async Task<IEnumerable<ProdutoDto>> GetProdutoAsync(){
            return await _mongosService.GetProdutoAsync();
        }
    }
}