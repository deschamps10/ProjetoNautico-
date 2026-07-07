using System;
using System.Collections.Generic;

namespace ProjetoNautico_
{
    internal class Program
    {
        // Integrante 1 - [Gabriel de Souza Pereira ] - Módulo de Controlo de Equipamento e Inventário Marinho
        // Integrante 2 - [NOME COMPLETO] - Módulo de Requisições para Expedição
        // Integrante 3 - [NOME COMPLETO] - Módulo de Custos Atmosféricos e Relatórios Operacionais

        static void Main(string[] args)
        {
            List<int> codigos = new List<int>();
            List<string> nomes = new List<string>();
            List<double> custos = new List<double>();
            List<int> quantidades = new List<int>();

            codigos.Add(101); nomes.Add("Tanque de Oxigenio Comprimido"); custos.Add(150.00); quantidades.Add(25);
            codigos.Add(102); nomes.Add("Traje de Mergulho Padrao"); custos.Add(300.00); quantidades.Add(15);
            codigos.Add(103); nomes.Add("Robo Autonomo de Coleta"); custos.Add(450.00); quantidades.Add(5);
            codigos.Add(104); nomes.Add("Lanterna Subaquatica LED"); custos.Add(40.00); quantidades.Add(30);
            codigos.Add(105); nomes.Add("Kit de Amostragem Biologica"); custos.Add(80.00); quantidades.Add(0);
            codigos.Add(106); nomes.Add("Sonda de Pressao Abissal"); custos.Add(220.00); quantidades.Add(8);

            double totalOxigenioGasto = 0;
            int totalExpedicoes = 0;

            bool sair = false;
            do
            {
                Console.Clear();
                ExibirCabecalho();

                Console.WriteLine("  1. Novo Equipamento (Reabastecimento)");
                Console.WriteLine("  2. Listar Equipamentos em Estoque");
                Console.WriteLine("  3. Consultar Item por Código");
                Console.WriteLine("  4. Iniciar Nova Expedição");
                Console.WriteLine("  5. Relatório de Eficiência da Estação");
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
                    continue;
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
                    case 4:
                        IniciarExpedicao(codigos, nomes, custos, quantidades, ref totalOxigenioGasto, ref totalExpedicoes);
                        break;
                    case 5:
                        RelatorioEficiencia(totalOxigenioGasto, totalExpedicoes);
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

        static void ExibirCabecalho()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("================================================================");
            Console.WriteLine("        ESTAÇÃO NAUTILUS - CONTROLE DE EQUIPAMENTOS");
            Console.WriteLine("================================================================");
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

        static void NovoEquipamento(List<int> codigos, List<string> nomes, List<double> custos, List<int> quantidades)
        {
            Console.WriteLine("\n--- REABASTECIMENTO DE SUPERFÍCIE (Novo Item) ---\n");

            int codigo = 0;
            
            Console.Write("Digite o Código do Equipamento: ");
            while (!int.TryParse(Console.ReadLine(), out codigo) || codigos.Contains(codigo))
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
                        EscreverAviso("\nATENÇÃO: Item indisponível nos hangares (stock zerado).");
                    }

                    break;
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
            Console.WriteLine("\n=================== INVENTÁRIO DA ESTAÇÃO NAUTILUS ===================");
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
                if (quantidades[i] == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                Console.WriteLine($" {codigos[i],-6} | {nomes[i],-29} | {custos[i],13:F2} L | {quantidades[i],5}");

                Console.ResetColor();
            }

            Console.WriteLine();
        }

        static void IniciarExpedicao(List<int> codigos, List<string> nomes, List<double> custos, List<int> quantidades, ref double totalOxigenioGasto, ref int totalExpedicoes)
        {
            Console.WriteLine("\n--- INICIAR NOVA EXPEDIÇÃO ---\n");

            Console.Write("Nome do cientista responsável pela expedição: ");
            string responsavel = Console.ReadLine();

            List<string> itensExpedicao = new List<string>();
            List<int> qtdExpedicao = new List<int>();
            List<double> custoUnitExpedicao = new List<double>();

            Console.WriteLine("\nDigite o código do item e a quantidade desejada.");
            Console.WriteLine("Digite 0 no código para finalizar a lista de pedidos.\n");

            while (true)
            {
                int codigoPedido;
                Console.Write("Código do item (0 para finalizar): ");
                while (!int.TryParse(Console.ReadLine(), out codigoPedido))
                {
                    EscreverErro("Código inválido. Digite apenas números:");
                    Console.Write("Código do item (0 para finalizar): ");
                }

                if (codigoPedido == 0)
                {
                    break;
                }

                int indice = -1;
                for (int i = 0; i < codigos.Count; i++)
                {
                    if (codigos[i] == codigoPedido)
                    {
                        indice = i;
                        break;
                    }
                }

                if (indice == -1)
                {
                    EscreverErro("Item não encontrado no inventário.\n");
                    continue;
                }

                int quantidadeDesejada;
                Console.Write("Quantidade desejada: ");
                while (!int.TryParse(Console.ReadLine(), out quantidadeDesejada))
                {
                    EscreverErro("Quantidade inválida. Digite apenas números:");
                    Console.Write("Quantidade desejada: ");
                }

                if (quantidadeDesejada > quantidades[indice])
                {
                    EscreverAviso("ALERTA DE RISCO À MISSÃO: estoque insuficiente para este item. Item não adicionado.\n");
                    continue;
                }

                quantidades[indice] -= quantidadeDesejada;

                itensExpedicao.Add(nomes[indice]);
                qtdExpedicao.Add(quantidadeDesejada);
                custoUnitExpedicao.Add(custos[indice]);

                EscreverSucesso("Item adicionado à expedição.\n");
            }

            if (itensExpedicao.Count == 0)
            {
                EscreverErro("\nNenhum item foi adicionado. Expedição cancelada.");
                return;
            }

            Console.WriteLine("\nEscolha o ambiente da expedição:");
            Console.WriteLine("1 - Fossa Abissal (Profundidade Extrema)");
            Console.WriteLine("2 - Recife de Coral (Baixa Profundidade)");
            Console.Write("Opção: ");

            int ambiente;
            while (!int.TryParse(Console.ReadLine(), out ambiente) || (ambiente != 1 && ambiente != 2))
            {
                EscreverErro("Opção inválida. Digite 1 ou 2:");
                Console.Write("Opção: ");
            }

            double custoTotal = ProcessarDespachoOxigenio(qtdExpedicao, custoUnitExpedicao, ambiente);

            EmitirManifestoSaida(responsavel, itensExpedicao, qtdExpedicao, ambiente, custoTotal);

            totalOxigenioGasto += custoTotal;
            totalExpedicoes += 1;
        }

        static double ProcessarDespachoOxigenio(List<int> qtdExpedicao, List<double> custoUnitExpedicao, int ambiente)
        {
            double custoBase = 0;

            for (int i = 0; i < qtdExpedicao.Count; i++)
            {
                custoBase += qtdExpedicao[i] * custoUnitExpedicao[i];
            }

            if (ambiente == 1)
            {
                custoBase = custoBase * 1.25;
            }
            else if (ambiente == 2)
            {
                custoBase = custoBase * 0.90;
            }

            return custoBase;
        }

        static void EmitirManifestoSaida(string responsavel, List<string> itensExpedicao, List<int> qtdExpedicao, int ambiente, double custoTotal)
        {
            string nomeAmbiente = ambiente == 1 ? "Fossa Abissal (Profundidade Extrema)" : "Recife de Coral (Baixa Profundidade)";
            string taxaAmbiente = ambiente == 1 ? "+25% (pressão extrema)" : "-10% (economia de eficiência)";

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n=================== MANIFESTO DE SAÍDA ===================");
            Console.ResetColor();

            Console.WriteLine($"Cientista responsável: {responsavel}");
            Console.WriteLine($"Ambiente: {nomeAmbiente}");
            Console.WriteLine($"Taxa aplicada: {taxaAmbiente}");
            Console.WriteLine("\nItens levados:");

            for (int i = 0; i < itensExpedicao.Count; i++)
            {
                Console.WriteLine($" - {itensExpedicao[i]} (Quantidade: {qtdExpedicao[i]})");
            }

            Console.WriteLine($"\nCusto final consolidado: {custoTotal:F2} L de O2");
            Console.WriteLine("============================================================\n");
        }

        static void RelatorioEficiencia(double totalOxigenioGasto, int totalExpedicoes)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n=================== RELATÓRIO DE EFICIÊNCIA ===================");
            Console.ResetColor();

            Console.WriteLine($"Total de expedições realizadas: {totalExpedicoes}");
            Console.WriteLine($"Total de oxigênio gasto: {totalOxigenioGasto:F2} L de O2");
            Console.WriteLine("=================================================================\n");
        }
    }
}
