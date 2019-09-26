using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Trabalho_1_bimestre_Rogério_leal
{
    class Program
    {
        private static List<Cliente> listaCliente = new List<Cliente>();

        static void Main(string[] args)
        {

            Boolean continua = true;

            ler();
            do
            {
                Console.WriteLine("  Menu de Cadastro de Clientes");
                Console.WriteLine();
                Console.WriteLine("  Digite sua opção: ");
                Console.WriteLine();
                Console.WriteLine("  A quantidade de clientes é: " + listaCliente.Count);
                Console.WriteLine();                
                Console.WriteLine();
                Console.WriteLine("  01 - Incluir");
                Console.WriteLine();
                Console.WriteLine("  02 - Alterar");
                Console.WriteLine();
                Console.WriteLine("  03 - Excluir");
                Console.WriteLine();
                Console.WriteLine("  04 - Listar");
                Console.WriteLine();
                Console.WriteLine("  05 - Pesquisar");
                Console.WriteLine();
                Console.WriteLine("  06 - Data");
                Console.WriteLine();
                Console.WriteLine("  09 - Sair");
                Console.WriteLine();
                Console.WriteLine("  10 - Salvar");
                Console.WriteLine();

                string opc = Console.ReadLine();

                switch (opc)
                {
                    case "1":
                    case "01":
                        Console.Clear();
                        Console.WriteLine(" Incluir:");

                        listaCliente.Add(incluirCliente());
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case "2":
                    case "02":
                        Console.Clear();
                        Console.WriteLine(" Alterar");

                        if (listaCliente.Count == 0)
                        {
                            Console.WriteLine(" Não há cadastro de Cliente para ser alterado");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else
                        {
                            Console.Write(" Digite o Nome do Cliente que deseja alterar");
                            string alteracao = Console.ReadLine();
                            Cliente auxiliador = listaCliente.Find(x => x.Nome == alteracao);

                            if (auxiliador == null)
                            {
                                Console.WriteLine(" Desculpe, Cliente não encontrado");
                                Console.ReadLine();
                            }
                            if (auxiliador != null)
                            {
                                Console.Write(" Digite novo Nome: ");
                                Cliente modificar = listaCliente.Find(x => x.Nome == alteracao);
                                modificar.Nome = Console.ReadLine();

                                Console.Write(" Digite novo Fone: ");
                                Cliente modificar1 = listaCliente.Find(x => x.Fone == alteracao);
                                modificar.Fone = Console.ReadLine();

                                Console.Write(" Digite novo EMail: ");
                                Cliente modificar2 = listaCliente.Find(x => x.EMail == alteracao);
                                modificar.EMail = Console.ReadLine();
                                Console.Clear();
                            }
                        }
                        break;

                        
                    case "3":
                    case "03":
                        Console.Clear();
                        Console.WriteLine(" Excluir");

                        
                        if (listaCliente.Count == 0)
                        {
                            Console.WriteLine(" Desculpe mas não há cliente para ser excluído.");
                            Console.WriteLine();
                        } 
                        
                        else
                        {
                            Console.WriteLine(" Realmente deseja excluir esse cliente: Y ou N ");
                            Console.ReadLine();
                                                                                 
                            Console.Write(" Qual Nome deseja excluir? ");
                            string guardar = Console.ReadLine();
                            
                            Console.WriteLine();
                            if (listaCliente.Remove(listaCliente.Find(x => x.Nome == guardar)))
                            {
                                Console.WriteLine(" Cliente excluido com sucesso");
                            }
                            else
                            {
                                Console.WriteLine(" Registro não encontrado!");
                            }
                        }
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case "4":
                    case "04":
                        Console.Clear();
                        Console.WriteLine(" Listar");

                        if (listaCliente.Count == 0)
                        {
                            Console.WriteLine(" Desculpe mas não encontramos registro no sistema. ");
                        }
                        else
                        {
                        listar();
                        }
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    case "5":
                    case "05":
                        Console.Clear();
                        Console.WriteLine(" Pesquisar");

                        Console.Write(" Digite o nome do cliente que deseja encontrar: ");
                        string pesquisar = Console.ReadLine();
                        Cliente aux = listaCliente.Find(x => x.Nome == pesquisar);
                        if (aux == null)
                        {
                            Console.Write(" Desculpe Cliente não cadastrado...");
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.Write(" Cliente encontrado..." + aux);
                            Console.WriteLine();
                        }
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "6":
                    case "06":
                        Console.Clear();
                        Console.WriteLine(" Data: ");

                        listaCliente.Add(incluirCliente());
                        Console.ReadLine();
                        Console.Clear();
                        break;


                    case "9":
                    case "09":
                        Console.Clear();
                        Console.WriteLine(" Sair");
                        continua = false;
                        Console.ReadLine();
                        Console.Clear();
                        break;

                    
                    case "10":
                        Console.Clear();
                        Console.WriteLine(" Salvar: ");                        
                        Salvar();
                        Console.Clear();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine(" Opção não existente.");
                        Console.ReadLine();
                        Console.Clear();
                        break;

                }


            } while (continua);
        }
        private static Cliente Salvar()
        {
            string json = JsonConvert.SerializeObject(listaCliente.ToArray());

            System.IO.File.WriteAllText(@"C:\Projetos\teste.txt", json);

            return null;
        }

        private static Cliente incluirCliente()
        {
            Cliente Cliente = new Cliente();

            Console.Write(" Data: ");
            Cliente.Data = Console.ReadLine();

            Console.Write(" Nome: ");
            Cliente.Nome = Console.ReadLine();

            Console.Write(" Fone: ");
            Cliente.Fone = Console.ReadLine();

            Console.Write(" EMail: ");
            Cliente.EMail = Console.ReadLine();
        
            
            return Cliente;
        }

        private static void listar()
        {
            foreach(Cliente cliente in listaCliente)
            {
                Console.WriteLine(cliente);
            }
        }

        private static Cliente ler()
        {
            string jsonFilePath = @"C:\Projetos\teste.txt";

            string json = System.IO.File.ReadAllText(jsonFilePath);

            Cliente[] lista = JsonConvert.DeserializeObject<Cliente[]>(json);

            listaCliente = lista.ToList();
            Console.WriteLine();
            return null;
                

        }


            


        
    }

 }
    

