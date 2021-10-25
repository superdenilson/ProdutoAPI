using Produto.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProdutoDomain = Produtos.Domain.Produto;

namespace Produto.Infrastructure.Repository
{
    public class ProdutoRepository : IProdutoRepository<ProdutoDomain>
    {
        ApplicationDbContext _dbContext;

        public ProdutoRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Produtos.Domain.Produto> Create(Produtos.Domain.Produto _object)
        {
            var obj = await _dbContext.Produtos.AddAsync(_object);
            _dbContext.SaveChanges();
            return obj.Entity;
        }

        public void Delete(Produtos.Domain.Produto _object)
        {
            _dbContext.Remove(_object);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Produtos.Domain.Produto> GetAll()
        {
            return _dbContext.Produtos.ToList();
        }

        public Produtos.Domain.Produto GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(Produtos.Domain.Produto _object)
        {
            _dbContext.Produtos.Update(_object);
            _dbContext.SaveChanges();
        }
    }
}
