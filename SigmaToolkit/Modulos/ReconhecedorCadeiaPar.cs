using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SigmaToolkit.Modulos
{
    internal static class ReconhecedorCadeiaPar
    {
        public static void Rodar()
        {
            FuncoesAuxiliares.LimparTela();
            Console.WriteLine("Reconhecedor: cadeias com o mesmo número de 'a' e 'b'");
            Console.WriteLine();

            Console.Write("Cadeia: ");
            string? entrada = Console.ReadLine();

            if (string.IsNullOrEmpty(entrada))
            {
                Console.WriteLine("Cadeia vazia rejeitada.");
                Console.WriteLine();
                Console.WriteLine("Pressione ENTER para continuar...");
                Console.ReadLine();
                FuncoesAuxiliares.LimparTela();
                return;
            }

            Console.Write("Limite de passos: ");
            long limitePassos;
            while (true)
            {
                string? limiteStr = Console.ReadLine();
                if (long.TryParse(limiteStr?.Trim(), out limitePassos) && limitePassos > 0)
                {
                    break;
                }
                Console.WriteLine("Entrada inválida. Por favor, insira um número inteiro positivo menor que 9.223.372.036.854.775.808.");
                Console.Write("Limite de passos: ");
            }

            long passos = 0;
            int delta = 0;
            bool interrompido = false;

            foreach (char c in entrada)
            {
                passos++;
                if (passos > limitePassos)
                {
                    interrompido = true;
                    break;
                }

                if (c == 'a') delta++;
                else if (c == 'b') delta--;
                else
                {
                    // processamento infinito para símbolos inválidos
                    while (true)
                    {
                        passos++;
                        if (passos > limitePassos)
                        {
                            interrompido = true;
                            break;
                        }
                    }
                    if (interrompido) break;
                }
            }

            Console.WriteLine();
            if (interrompido)
            {
                Console.WriteLine($"Execução interrompida após {passos} passos (limite: {limitePassos}).");
            }
            else if (delta == 0)
            {
                Console.WriteLine($"SIM - Cadeia aceita (mesmo número de 'a' e 'b') - {passos} passos executados.");
            }
            else
            {
                Console.WriteLine($"NAO - Cadeia rejeitada (números diferentes de 'a' e 'b') - {passos} passos executados.");
            }

            Console.WriteLine();
            Console.WriteLine("Pressione ENTER para continuar...");
            Console.ReadLine();
            FuncoesAuxiliares.LimparTela();
        }
    }
}