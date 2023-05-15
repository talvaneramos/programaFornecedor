using Projeto03.Contracts;
using Projeto03.Entities;
using Projeto03.Repositories;
using System;
using System.Collections.Generic;

namespace Projeto03
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nCONTROLE DE FORNECEDORES E PRODUTOS\n");
            try
            {
                var fornecedor = new Fornecedor();
                fornecedor.IdFornecedor = Guid.NewGuid();

                fornecedor.Produtos = new List<Produto>();

                Console.Write("Nome do Fornecedor.................: ");
                fornecedor.Nome = Console.ReadLine();

                Console.Write("CNPJ do Fornecedor.................: ");
                fornecedor.Cnpj = Console.ReadLine();

                Console.Write("Quantidade.........................: ");
                var quantidade = int.Parse(Console.ReadLine());

                for (int i = 0; i < quantidade; i++)
                {
                    var produto = new Produto();
                    produto.IdProduto = Guid.NewGuid();

                    Console.WriteLine($"\nInforme o {i+1}º Produto:\n");

                    Console.Write("Nome do produto................: ");
                    produto.Nome = Console.ReadLine();
                    
                    Console.Write("Preço do produto................: ");
                    produto.Preco = decimal.Parse(Console.ReadLine());                    
                   
                    Console.Write("Quantidade do produto...........: ");
                    produto.Quantidade = int.Parse(Console.ReadLine());
                    
                    fornecedor.Produtos.Add(produto);
                }

                IfornecedorRepository fornecedorRepository = null;


                Console.Write("\nInforme (1)JSON ou (2)XML: ");
                var opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        fornecedorRepository = new FornecedorRepositoryJSON();
                        break;
                    case 2:
                        fornecedorRepository = new FornecedorRepositoryXML();
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida!\n");
                        break;
                }

                if (fornecedorRepository != null)
                {
                    fornecedorRepository.Exportar(fornecedor);
                    Console.WriteLine("\nArquivo gerado com sucesso!");

                    if (fornecedorRepository is FornecedorRepositoryJSON)
                    {
                        Console.WriteLine("\nArquivo JSON gerado com sucesso!");

                    }else if (fornecedorRepository is FornecedorRepositoryXML)
                    {
                        Console.WriteLine("\nArquivo XML gerado com sucesso!");
                    }

                }

                Console.WriteLine("\nDADOS DO FORNECEDOR\n");
                Console.WriteLine("\tId do Fornecedor...............: " + fornecedor.IdFornecedor);
                Console.WriteLine("\tNome do Fornecedor.............: " + fornecedor.Nome);
                Console.WriteLine("\tCNPJ...........................: " + fornecedor.Cnpj);

                foreach (var item in fornecedor.Produtos)
                {
                    Console.WriteLine("\tId do Produto...............: " + item.IdProduto);
                    Console.WriteLine("\tNome do Produto.............: " + item.Nome);
                    Console.WriteLine("\tPreço.......................: " + item.Preco);
                    Console.WriteLine("\tQuantidade..................: " + item.Quantidade);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("\nOcorreu um erro: " + ex);
            }
            Console.ReadKey();
        }
    }
}
