using Produto.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProdutoDomain = Produtos.Domain.Produto;

namespace ProdutoAPI.Application
{
    public class ProdutoService
    {
        private IProdutoRepository<ProdutoDomain> _produtoRepository;

        public ProdutoService(IProdutoRepository<ProdutoDomain> produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        //Retorna produto pelo ID
        public IEnumerable<ProdutoDomain> GetProdutoPorId(Guid produtoId)
        {
            return _produtoRepository.GetAll().Where(x => x.CodigoProduto == produtoId).ToList();
        }

        //Retorna todos os produtos
        public IEnumerable<ProdutoDomain> GetTodosProdutos()
        {
            try
            {
                return _produtoRepository.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //Retorna produto pela descrição
        public ProdutoDomain GetProdutoPorDescricao(string descricaoProduto)
        {
            return _produtoRepository.GetAll().Where(x => x.DescricaoProduto == descricaoProduto).FirstOrDefault();
        }
        
        //Grava um produto
        public async Task<ProdutoDomain> AddProduto(ProdutoDomain produto)
        {
            return await _produtoRepository.Create(produto);
        }

        //Exclui um produto
        public bool DeleteProduto(Guid codigoProduto)
        {

            try
            {
                var DataList = _produtoRepository.GetAll().Where(x => x.CodigoProduto == codigoProduto).ToList();
                foreach (var item in DataList)
                {
                    _produtoRepository.Delete(item);
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }

        }
        //Atualiza o produto
        public bool UpdateProduto(ProdutoDomain produto)
        {
            try
            {
                var prd = _produtoRepository.GetAll().Where(x => x.CodigoProduto == produto.CodigoProduto).FirstOrDefault();

                if (prd != null)
                {
                    prd.DescricaoProduto = produto.DescricaoProduto;
                    prd.Valor = produto.Valor;
                    prd.DataLancamento = produto.DataLancamento;
                    prd.TipoProduto = produto.TipoProduto;

                    _produtoRepository.Update(prd);
                }
                
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }

    }
}
