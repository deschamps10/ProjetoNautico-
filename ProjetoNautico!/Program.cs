using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoNautico_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> lista_equipamentos = new List<string>();

            
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Novo Equipamento ");
                Console.WriteLine("2. Listar Equipamentos");
                Console.WriteLine("3. Remover Equipamentos");
                Console.WriteLine("0. Sair");
                int menu = int.Parse(Console.ReadLine());
                if (menu == 0) break;

                switch (menu)
                {

                    case 1:
                        NovoEquipamento(lista_equipamentos);
                        break;
                    case 2:
                        ListarEquipamentos(lista_equipamentos);
                        break;
                    //    case 3:
                    //        RemoverCarro(lista_carros);
                    //        break;
                    //    default:
                    //        Console.WriteLine("Opção inválida.");
                    //        break;
                }

                Console.ReadKey();
            }
        }

         static void NovoEquipamento(List<string> equipamentos)
        {

            int[] codigos = new int[10];
            string[] nomes = new string[10];
            string[] marcas = new string[10];
            string[] modelos = new string[10];

            int quantidade = 0;

            Console.Write("Digite o Código do Equipamento: ");
            codigos[quantidade] = int.Parse(Console.ReadLine());

            Console.Write("Digite o Nome do Equipamento: ");
            nomes[quantidade] = Console.ReadLine();

            Console.Write("Digite a Marca do Equipamento: ");
            marcas[quantidade] = Console.ReadLine();

            Console.Write("Digite o Modelo do Equipamento: ");
            modelos[quantidade] = Console.ReadLine();
            
            equipamentos.Add(codigos[quantidade].ToString());
            equipamentos.Add(nomes[quantidade]);
            equipamentos.Add(marcas[quantidade]);
            equipamentos.Add(modelos[quantidade]);
        }

        static void ListarEquipamentos(List<string> equipamentos) {
            Console.WriteLine("****** EQUIPAMENTOS *****\n");
            for (var i = 0; i < equipamentos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {equipamentos[i]}");
            }
            Console.WriteLine();
        }
        
        
    }
}