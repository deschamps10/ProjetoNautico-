using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoNautico_
{
    internal class Program{
        static void Main(string[] args){

            while (true){
                
                List<string> lista_equipamentos = new List<string>();

                Console.Clear();
                Console.WriteLine("1. Novo Equipamento ");
                Console.WriteLine("2. Listar Equipamentos");
                Console.WriteLine("3. Remover Equipamentos");
                Console.WriteLine("0. Sair");
                int menu = int.Parse(Console.ReadLine());
                if (menu == 0) break;

                switch (menu){

                    case 1:
                        NovoEquipamento(lista_equipamentos);
                        break;
                //case 2:
                //        MostrarCarros(lista_carros);
                //        break;
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
            private static void NovoEquipamento(List<string> lista_equipamentos){

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

            quantidade++;
        }
    }
