using System; 
using System.Collections.Generic;
using System.Linq;

namespace CadastroProdutos
{
    class Program
    {
        static List<Produto> produtos = new List<Produto>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nEscolha uma opção:");
                Console.WriteLine("1 - Cadastrar novo produto");
                Console.WriteLine("2 - Listar produtos");
                Console.WriteLine("3 - Sair");

                int opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        CadastrarProduto();
                        break;
                    case 2:
                        ListarProdutos();
                        break;
                    case 3:
                        Console.WriteLine("Saindo...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        static void CadastrarProduto()
        {
            Console.WriteLine("\nCadastro de Novo Produto");
            Console.Write("Nome do produto: ");
            string nome = Console.ReadLine();
            Console.Write("Descrição do produto: ");
            string descricao = Console.ReadLine();
            Console.Write("Valor do produto: ");
            decimal valor = decimal.Parse(Console.ReadLine());
            Console.Write("Disponível para venda (s/n): ");
            bool disponivel = Console.ReadLine().ToLower() == "s";

            Produto novoProduto = new Produto(nome, descricao, valor, disponivel);
            produtos.Add(novoProduto);

            Console.WriteLine("Produto cadastrado com sucesso!");
        }

        static void ListarProdutos()
        {
            if (produtos.Count == 0)
            {
                Console.WriteLine("Nenhum produto cadastrado.");
                return;
            }

            Console.WriteLine("\nLista de Produtos");
            Console.WriteLine("{0,-20} {1,-20} {2,-10}", "Nome", "Valor", "Disponível");

            foreach (Produto produto in produtos.OrderBy(p => p.Valor))
            {   //Essa parte estou usando para fazer a formatação da exibição na tela
                Console.WriteLine("{0,-20} {1,-20} {2,-10}", produto.Nome, produto.Valor.ToString("C"), produto.Disponivel ? "Sim" : "Não");
            }
        }
    }

    class Produto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public bool Disponivel { get; set; }

        public Produto(string nome, string descricao, decimal valor, bool disponivel)
        {
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
            Disponivel = disponivel;
        }
    }
}
