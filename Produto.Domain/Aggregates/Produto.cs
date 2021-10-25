using System;
using System.ComponentModel.DataAnnotations;

namespace Produtos.Domain
{
    public class Produto
    {
        [Key]
        public Guid CodigoProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public string TipoProduto { get; set; }
        public DateTime DataLancamento { get; set; }
        public decimal Valor { get; set; }
    }
}
