using System.Collections.Generic;
using ApiProduto.Models;
using ApiProduto.Services;
using Microsoft.AspNetCore.Mvc;


namespace ApiProduto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoService _produtoService;

        public ProdutoController(ProdutoService produtoService)
        {
            _produtoService = produtoService;
        }

        [HttpGet]
        public ActionResult<List<Produto>> Get() =>
            _produtoService.Get();

        
        [HttpGet("{id:length(24)}", Name = "GetProduto")]
        public ActionResult<Produto> Get(string id)
        {
            var produto = _produtoService.Get(id);

            if (produto == null)
            {
                return NotFound();
            }

            return produto;
        }

        [HttpPost]
        public ActionResult<Produto> Create(Produto produto)
        {
            _produtoService.Create(produto);

            return CreatedAtRoute("GetProduto", new { id = produto.Id.ToString() }, produto);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Produto produtoIn)
        {
            var produto = _produtoService.Get(id);

            if (produto == null)
            {
                return NotFound();
            }

            _produtoService.Update(id, produtoIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var produto = _produtoService.Get(id);

            if (produto == null)
            {
                return NotFound();
            }

            _produtoService.Remove(produto.Id);

            return NoContent();
        }
    }
}