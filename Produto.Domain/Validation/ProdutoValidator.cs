using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Produtos.Domain.Validation
{
    public class ProdutoValidator: AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            RuleFor(p => p.DescricaoProduto).NotEmpty().WithMessage("Favor informar a descrição do produto");
            RuleFor(p => p.TipoProduto).NotEmpty().WithMessage("Favor informar o tipo do produto");
            RuleFor(p => p.Valor).NotEmpty().WithMessage("Favor informar o valor do produto");
            RuleFor(p => p.DataLancamento).NotEmpty().WithMessage("Favor informar a data de lançamento");
        }
    }
}
