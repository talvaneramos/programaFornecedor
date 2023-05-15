using Projeto03.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto03.Contracts
{
    public interface IfornecedorRepository
    {
        void Exportar(Fornecedor fornecedor);
    }
}
