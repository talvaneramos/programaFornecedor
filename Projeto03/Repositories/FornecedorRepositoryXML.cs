using Newtonsoft.Json;
using Projeto03.Contracts;
using Projeto03.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Projeto03.Repositories
{
    public class FornecedorRepositoryXML : IfornecedorRepository
    {
        public void Exportar(Fornecedor fornecedor)
        {
            var filename = $"fornecedor_{DateTime.Now.ToString("yyyyMMddHHmmss")}.xml";

            using (var streamWriter = new StreamWriter("c:\\temp\\" + filename, true))
            {
                var xml = new XmlSerializer(fornecedor.GetType());
                xml.Serialize(streamWriter, fornecedor);
            }
        }
    }
}
