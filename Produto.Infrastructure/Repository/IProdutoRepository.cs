using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Produto.Infrastructure.Repository
{
    public interface IProdutoRepository<T>
    {
        public Task<Produtos.Domain.Produto> Create(Produtos.Domain.Produto _object);

        public void Update(Produtos.Domain.Produto _object);

        public IEnumerable<Produtos.Domain.Produto> GetAll();

        public Produtos.Domain.Produto GetById(int Id);

        public void Delete(Produtos.Domain.Produto _object);
    }
}
