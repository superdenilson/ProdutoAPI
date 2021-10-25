using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProdutoAPI.Application;
using ProdutoDomain = Produtos.Domain.Produto;
using Produto.Infrastructure.Repository;
using Newtonsoft.Json;

namespace ProdutoAPI.Controllers
{
    [ApiController]
    [Route("api/produtocommand")]
    public class ProdutoCommandController : Controller
    {
        private readonly ProdutoService _produtoService;

        private readonly IProdutoRepository<ProdutoDomain> _produtoRepository;

        public ProdutoCommandController(IProdutoRepository<ProdutoDomain> produtoRepository, ProdutoService produtoService)
        {
            _produtoService = produtoService;
            _produtoRepository = produtoRepository;

        }

        //Adiciona um  Produto
        [HttpPost("AddProduto")]
        public async Task<bool> AddProduto([FromBody] ProdutoDomain produto)
        {
            try
            {
                await _produtoService.AddProduto(produto);
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        //Deleta um produto
        [HttpDelete("DeleteProduto/{id}")]
        public bool DeleteProduto([FromRoute] Guid id)
        {
            try
            {
                _produtoService.DeleteProduto(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Atualiza um produto
        [HttpPut("UpdateProduto")]
        public bool UpdateProduto(ProdutoDomain produto)
        {
            try
            {
                _produtoService.UpdateProduto(produto);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //GET All
        [HttpGet("GetAll")]
        public Object GetAll()
        {
            var data = _produtoService.GetTodosProdutos();
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

        //GET BY ID
        [HttpGet("GetById/{id}")]
        public Object GetById([FromRoute] Guid id)
        {
            var data = _produtoService.GetProdutoPorId(id);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }
    }
}
