using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto03.Entities
{
    public class Produto
    {
        public Guid IdProduto { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
    }
}
