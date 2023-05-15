using Newtonsoft.Json;
using Projeto03.Contracts;
using Projeto03.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Projeto03.Repositories
{
    public class FornecedorRepositoryJSON : IfornecedorRepository
    {
        public void Exportar(Fornecedor fornecedor)
        {
            var filename = $"fornecedor_{DateTime.Now.ToString("yyyyMMddHHmmss")}.json";

            using (var streamWriter = new StreamWriter("c:\\temp\\" + filename, true))
            {
                var json = JsonConvert.SerializeObject(fornecedor, Formatting.Indented);
                streamWriter.WriteLine(json);
            }
        }
    }
}
