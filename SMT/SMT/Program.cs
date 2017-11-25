using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMT
{
    class Program
    {         
        static void Main(string[] args)
        {
            args = new string[3];
            args[0] = "R:\\GitHub\\SimuladorMaquinaTuring\\SMT\\config.txt";
            args[1] = "R:\\GitHub\\SimuladorMaquinaTuring\\SMT\\fitas.txt";
            args[2] = "R:\\GitHub\\SimuladorMaquinaTuring\\SMT\\out.txt";
            if (args.Length == 3)
            {
                Simulador s = new Simulador();
                if (s.configurar(padronizarCaminho(args[0]), padronizarCaminho(args[1])))
                {
                    if (s.executar(padronizarCaminho(args[2])))
                    {
                        Console.WriteLine("Processamento encerrado com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Erro ao executar o Simulador de Máquina de Turing!");
                    }
                }
                else
                {
                    Console.WriteLine("Erro ao configurar o Simulador de Máquina de Turing!");
                }
            }
            else
            {
                Console.WriteLine("Caminhos para os arquivos faltando! (configurações, fitas, resultados).");
            }
            Console.ReadKey();
        }

        static string padronizarCaminho(string caminho) //corrige a leitura da \ no caminho Windows
        {
            int pos = caminho.IndexOf('\\');
            while (pos != -1)
            {
                caminho.Insert(pos++, "\\\\");
                pos = caminho.IndexOf('\\', pos);
            }
            return caminho;
        }
    }
}
