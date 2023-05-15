using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto03.Entities
{
    public class Fornecedor
    {
        public Guid IdFornecedor { get; set; }
        public string Nome { get; set; }
        public string Cnpj { get; set; }

        public List<Produto> Produtos { get; set; }
    }
}
