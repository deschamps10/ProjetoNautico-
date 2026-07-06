using System;
using System.Collections.Generic;

namespace ProjetoNautico_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Listas paralelas: o mesmo índice = o mesmo equipamento
            List<int> codigos = new List<int>();
            List<string> nomes = new List<string>();
            List<double> custos = new List<double>();
            List<int> quantidades = new List<int>();

            // Estoque inicial da estação (dados de exemplo já cadastrados).
            // Assim quem for usar o sistema já sabe quais equipamentos existem,
            // em vez de começar com o inventário totalmente vazio.
            codigos.Add(101); nomes.Add("Tanque de Oxigenio Comprimido"); custos.Add(150.00); quantidades.Add(25);
            codigos.Add(102); nomes.Add("Traje de Mergulho Padrao"); custos.Add(300.00); quantidades.Add(15);
            codigos.Add(103); nomes.Add("Robo Autonomo de Coleta"); custos.Add(450.00); quantidades.Add(5);
            codigos.Add(104); nomes.Add("Lanterna Subaquatica LED"); custos.Add(40.00); quantidades.Add(30);
            codigos.Add(105); nomes.Add("Kit de Amostragem Biologica"); custos.Add(80.00); quantidades.Add(0);
            codigos.Add(106); nomes.Add("Sonda de Pressao Abissal"); custos.Add(220.00); quantidades.Add(8);

            bool sair = false;
            do
            {
                Console.Clear();
                ExibirCabecalho();

                Console.WriteLine("  1. Novo Equipamento (Reabastecimento)");
                Console.WriteLine("  2. Listar Equipamentos em Estoque");
                Console.WriteLine("  3. Consultar Item por Código");
                Console.WriteLine("  0. Sair");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("  Escolha uma opção: ");
                Console.ResetColor();

                int menu;
                bool valido = int.TryParse(Console.ReadLine(), out menu);

                if (!valido)
                {
                    EscreverErro("\n  Opção inválida. Digite apenas números.");
                    Console.ReadKey();
                    continue; // volta pro início do loop sem crashar
                }

                switch (menu)
                {
                    case 1:
                        NovoEquipamento(codigos, nomes, custos, quantidades);
                        break;
                    case 2:
                        ListarEquipamentos(codigos, nomes, custos, quantidades);
                        break;
                    case 3:
                        ConsultarItemPorCodigo(codigos, nomes, custos, quantidades);
                        break;
                    case 0:
                        sair = true;
                        break;
                    default:
                        EscreverErro("  Opção inválida.");
                        break;
                }

                if (!sair)
                {
                    Console.WriteLine("\n  Pressione uma tecla para continuar...");
                    Console.ReadKey();
                }

            } while (!sair);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n  Encerrando conexão com a Estação Nautilus. Até a próxima missão!\n");
            Console.ResetColor();
        }

        // ---------- Métodos de apoio visual (estilização do terminal) ----------

        static void ExibirCabecalho()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔══════════════════════════════════════════════════════════╗");
            Console.WriteLine("║        ESTAÇÃO NAUTILUS - CONTROLE DE EQUIPAMENTOS       ║");
            Console.WriteLine("╚══════════════════════════════════════════════════════════╝");
            Console.ResetColor();
            Console.WriteLine();
        }

        static void EscreverErro(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(mensagem);
            Console.ResetColor();
        }

        static void EscreverSucesso(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(mensagem);
            Console.ResetColor();
        }

        static void EscreverAviso(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(mensagem);
            Console.ResetColor();
        }

        // ---------- Métodos do módulo de inventário ----------

        static void NovoEquipamento(List<int> codigos, List<string> nomes, List<double> custos, List<int> quantidades)
        {
            Console.WriteLine("\n--- REABASTECIMENTO DE SUPERFÍCIE (Novo Item) ---\n");

            int codigo;
            Console.Write("Digite o Código do Equipamento: ");
            while (!int.TryParse(Console.ReadLine(), out codigo))
            {
                EscreverErro("Código inválido. Digite apenas números:");
                Console.Write("Digite o Código do Equipamento: ");
            }

            Console.Write("Digite o Nome do Equipamento/Consumível: ");
            string nome = Console.ReadLine();

            double custo;
            Console.Write("Digite o Custo de Suporte (em Litros de O2): ");
            while (!double.TryParse(Console.ReadLine(), out custo))
            {
                EscreverErro("Valor inválido. Digite apenas números:");
                Console.Write("Digite o Custo de Suporte (em Litros de O2): ");
            }

            int quantidade;
            Console.Write("Digite a Quantidade disponível no porão: ");
            while (!int.TryParse(Console.ReadLine(), out quantidade))
            {
                EscreverErro("Quantidade inválida. Digite apenas números:");
                Console.Write("Digite a Quantidade disponível no porão: ");
            }

            // Adiciona nas 4 listas, na mesma posição (mesmo índice)
            codigos.Add(codigo);
            nomes.Add(nome);
            custos.Add(custo);
            quantidades.Add(quantidade);

            EscreverSucesso("\nEquipamento cadastrado com sucesso!");
        }

        static void ConsultarItemPorCodigo(List<int> codigos, List<string> nomes, List<double> custos, List<int> quantidades)
        {
            Console.WriteLine("\n--- CONSULTAR ITEM POR CÓDIGO ---\n");

            int codigoBuscado;
            Console.Write("Digite o Código do Equipamento: ");
            while (!int.TryParse(Console.ReadLine(), out codigoBuscado))
            {
                EscreverErro("Código inválido. Digite apenas números:");
                Console.Write("Digite o Código do Equipamento: ");
            }

            // Percorre as listas procurando o código. Como são paralelas,
            // o índice "i" onde achar o código é o mesmo índice dos outros dados.
            bool encontrado = false;

            for (int i = 0; i < codigos.Count; i++)
            {
                if (codigos[i] == codigoBuscado)
                {
                    encontrado = true;

                    Console.WriteLine("\n--- Item Encontrado ---");
                    Console.WriteLine($"Código: {codigos[i]}");
                    Console.WriteLine($"Nome: {nomes[i]}");
                    Console.WriteLine($"Custo de Suporte: {custos[i]:F2} L de O2");
                    Console.WriteLine($"Quantidade no porão: {quantidades[i]}");

                    if (quantidades[i] == 0)
                    {
                        EscreverAviso("\n⚠ AVISO: Item indisponível nos hangares (stock zerado).");
                    }

                    break; // já achou, não precisa continuar procurando
                }
            }

            if (!encontrado)
            {
                EscreverErro("\nNenhum equipamento encontrado com esse código.");
            }
        }

        static void ListarEquipamentos(List<int> codigos, List<string> nomes, List<double> custos, List<int> quantidades)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n╔══════════════════ INVENTÁRIO DA ESTAÇÃO NAUTILUS ══════════════════╗");
            Console.ResetColor();

            if (codigos.Count == 0)
            {
                Console.WriteLine("\n  Nenhum equipamento cadastrado ainda.\n");
                return;
            }

            Console.WriteLine();
            Console.WriteLine(" Código | Nome                          | Custo (L de O2) | Quantidade");
            Console.WriteLine(" ----------------------------------------------------------------------");

            for (int i = 0; i < codigos.Count; i++)
            {
                // Se a quantidade estiver zerada, destaca a linha em vermelho como alerta visual.
                if (quantidades[i] == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                Console.WriteLine($" {codigos[i],-6} | {nomes[i],-29} | {custos[i],13:F2} L | {quantidades[i],5}");

                Console.ResetColor();
            }

            Console.WriteLine();
        }
    }
}